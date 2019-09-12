
IF EXISTS(select * from sysobjects where id = object_id(N'[viterbo_finvardetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [viterbo_finvardetailview]
GO

-- clear_table_info'viterbo_finvardetailview'
-- select  * from viterbo_finvardetailview
CREATE VIEW viterbo_finvardetailview (
	yvar,
	nvar,
	rownum,
	variationdescription,
	enactment,
	nenactment,
	enactmentdate,
	variationkind,
	variationkinddescr,
	flagprevision,	
	flagcredit,
	flagproceeds,
	flagsecondaryprev,
	official,
	nofficial,
	enactmentnumber,
	idman,
	manager,
	idfinvarstatus,
	finvarstatus,
	idfin,
	ayear,
	flag,
	finpart,
	codefin,
	finance,
	description,
	idupb,		
	codeupb,	
	upb,	
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	amount,
	limit,
	annotation,
	idlcard,
	adate,	
	cu,
	ct,
	lu,
	lt,
	idunderwriting,
	underwriting,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	residual,
	createexpense,
	idexp,
	phase,
	nmov,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr,
	varflag,
	idtreasurer,
	previousprevision,
	idacc,codeacc,account,underwritingkind,
	idupb_procedureman,
	start,
	stop,
	didattica,
	ricerca,
	servizi,
	idcostpartition,
	idsor1,idsor2,idsor3,
	prevcassa
)
AS SELECT
	viterbo_finvardetail.yvar,
	viterbo_finvardetail.nvar,
	viterbo_finvardetail.rownum,
	viterbo_finvar.description,
	viterbo_finvar.enactment,
	viterbo_finvar.nenactment,
	viterbo_finvar.enactmentdate,
	viterbo_finvar.variationkind,
	variationkind.description,
	viterbo_finvar.flagprevision,	
	viterbo_finvar.flagcredit,
	viterbo_finvar.flagproceeds,
	viterbo_finvar.flagsecondaryprev,
	viterbo_finvar.official,
	viterbo_finvar.nofficial,
	enactment.nenactment,
	viterbo_finvar.idman,
	manager.title,
	viterbo_finvar.idfinvarstatus,
	finvarstatus.description,
	viterbo_finvardetail.idfin,
	fin.ayear,
	fin.flag,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.title,
	viterbo_finvardetail.description,
	upb.idupb,	
	upb.codeupb,		
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	viterbo_finvardetail.amount,
	viterbo_finvardetail.limit,
	viterbo_finvardetail.annotation,
	viterbo_finvardetail.idlcard,
	viterbo_finvar.adate,	
	viterbo_finvardetail.cu,
	viterbo_finvardetail.ct,
	viterbo_finvardetail.lu,
	viterbo_finvardetail.lt,
	viterbo_finvardetail.idunderwriting,
	underwriting.title,
	viterbo_finvardetail.prevision2,
	viterbo_finvardetail.prevision3,
	viterbo_finvardetail.prevision4,
	viterbo_finvardetail.prevision5,
	viterbo_finvardetail.residual,
	viterbo_finvardetail.createexpense,
	viterbo_finvardetail.idexp,
	expensephase.description,
	expense.nmov,
	upb.flagactivity,
--	activity,
	case
	when upb.flagactivity ='1' then 'Istituzionale'
	when upb.flagactivity ='2' then 'Commerciale'
	-- when upb.flagactivity ='3' then 'p': l'upb non ha il promiscuo
	when upb.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end,
	upb.flagkind,
--	kindd,
	CASE
		when (( upb.flagkind & 1)<> 0) then 'S'
	End,
--	kindr,
	CASE
		when (( upb.flagkind & 2)<>0) then 'S'
	End,
	viterbo_finvar.varflag,
	upb.idtreasurer,
	viterbo_finvardetail.previousprevision,
	viterbo_finvardetail.idacc, account.codeacc, account.title,
	viterbo_finvardetail.underwritingkind,
	viterbo_finvardetail.idupb_procedureman,
	viterbo_finvardetail.start,
	viterbo_finvardetail.stop,
	viterbo_finvardetail.didattica,
	viterbo_finvardetail.ricerca,
	viterbo_finvardetail.servizi,
	viterbo_finvardetail.idcostpartition,
	viterbo_finvardetail.idsor1,
	viterbo_finvardetail.idsor2,
	viterbo_finvardetail.idsor3,
	viterbo_finvardetail.prevcassa
FROM viterbo_finvardetail with (nolock)
JOIN viterbo_finvar with (nolock)		ON viterbo_finvardetail.yvar = viterbo_finvar.yvar	AND viterbo_finvardetail.nvar = viterbo_finvar.nvar
JOIN fin with (nolock)							ON viterbo_finvardetail.idfin = fin.idfin
JOIN upb with (nolock)							ON viterbo_finvardetail.idupb=upb.idupb 	
JOIN variationkind with (nolock)				ON variationkind.idvariationkind = viterbo_finvar.variationkind
LEFT OUTER JOIN manager with (nolock)			ON manager.idman = viterbo_finvar.idman
LEFT OUTER JOIN finvarstatus with (nolock)		ON finvarstatus.idfinvarstatus = viterbo_finvar.idfinvarstatus
LEFT OUTER JOIN enactment with (nolock)			ON enactment.idenactment = viterbo_finvar.idenactment
LEFT OUTER JOIN underwriting   with (nolock)	ON viterbo_finvardetail.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN expense  with (nolock)			ON viterbo_finvardetail.idexp=  expense.idexp
LEFT OUTER JOIN expensephase with (nolock)		on expense.nphase= expensephase.nphase
	LEFT OUTER JOIN account ON viterbo_finvardetail.idacc = account.idacc





GO


