-- CREAZIONE VISTA finvardetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[finvardetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finvardetailview]
GO





CREATE  VIEW finvardetailview
(
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
	previousprevision
)
AS SELECT
	finvardetail.yvar,
	finvardetail.nvar,
	finvardetail.rownum,
	finvar.description,
	finvar.enactment,
	finvar.nenactment,
	finvar.enactmentdate,
	finvar.variationkind,
	variationkind.description,
	finvar.flagprevision,	
	finvar.flagcredit,
	finvar.flagproceeds,
	finvar.flagsecondaryprev,
	finvar.official,
	finvar.nofficial,
	enactment.nenactment,
	finvar.idman,
	manager.title,
	finvar.idfinvarstatus,
	finvarstatus.description,
	finvardetail.idfin,
	fin.ayear,
	fin.flag,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.title,
	finvardetail.description,
	upb.idupb,	
	upb.codeupb,		
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	finvardetail.amount,
	finvardetail.limit,
	finvardetail.annotation,
	finvardetail.idlcard,
	finvar.adate,	
	finvardetail.cu,
	finvardetail.ct,
	finvardetail.lu,
	finvardetail.lt,
	finvardetail.idunderwriting,
	underwriting.title,
	finvardetail.prevision2,
	finvardetail.prevision3,
	finvardetail.residual,
	finvardetail.createexpense,
	finvardetail.idexp,
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
	finvar.varflag,
	upb.idtreasurer,
	finvardetail.previousprevision
FROM finvardetail with (nolock)
JOIN finvar with (nolock)
	ON finvardetail.yvar = finvar.yvar
	AND finvardetail.nvar = finvar.nvar
JOIN fin with (nolock)
	ON finvardetail.idfin = fin.idfin
JOIN upb with (nolock)
	ON finvardetail.idupb=upb.idupb 	
JOIN variationkind with (nolock)
	ON variationkind.idvariationkind = finvar.variationkind
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = finvar.idman
LEFT OUTER JOIN finvarstatus with (nolock)
	ON finvarstatus.idfinvarstatus = finvar.idfinvarstatus
LEFT OUTER JOIN enactment with (nolock)
	ON enactment.idenactment = finvar.idenactment
LEFT OUTER JOIN underwriting   with (nolock)
	ON finvardetail.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN expense  with (nolock)
	ON finvardetail.idexp=  expense.idexp
LEFT OUTER JOIN expensephase with (nolock)
	on expense.nphase= expensephase.nphase






GO
