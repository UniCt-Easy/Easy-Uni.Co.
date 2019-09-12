-- CREAZIONE VISTA itinerationview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationview]
GO

--clear_table_info'itinerationview'

--setuser 'amm'
--select * from itinerationview
CREATE  VIEW itinerationview 
(
	iditineration,
	yitineration,
	nitineration,
	description,
	idreg,
	registry,
	iddaliaposition,
	codedaliaposition,
	daliaposition,
	idser,
	service,
	codeser,
	admincarkmcost,
	owncarkmcost,
	footkmcost,
	admincarkm,
	owncarkm,
	footkm,
	authorizationdate,
	start,
	stop,
	adate,
	grossfactor,
	netfee,
	totalgross,
	total,
	totadvance,
	location,
	cu,
	ct,
	lu,
	lt,
	active,
	completed,
	iditinerationstatus,
	itinerationstatus,
	idaccmotive,
	codemotive,
	accmotive,
	idaccmotivedebit,
	codemotivedebit,
	accmotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	accmotive_crg,
	idaccmotivedebit_datacrg,
	idupb,
	codeupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idsor1,
	idsor2,
	idsor3,
	txt,
	rtf,
	position,
	incomeclass,
	incomeclassvalidity,
	extmatricula,
	foreigngroupnumber,
	idregistrylegalstatus,
	applierannotations,
	webwarn,
	idman,
	manager,
	flagweb,
	idauthmodel,
	authmodel,
	authmodtitle,
	statusimage,
	listingorder,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	clause_accepted,
	vehicle_info,
	vehicle_motive,
	advancelinked,
	totlinked,
	totresidual,
	totnoaccountsaldo,
	datecompleted,
	idrelated,
	additionalannotations,
	idsor_siope,
	iditineration_ref,
	nref
)
AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	itineration.idreg,
	registry.title,
	DP.iddaliaposition,
	DP.codedaliaposition,
	DP.description,
	itineration.idser,
	service.description,
	service.codeser,
	itineration.admincarkmcost,
	itineration.owncarkmcost,
	itineration.footkmcost,
	itineration.admincarkm,
	itineration.owncarkm,
	itineration.footkm,
	itineration.authorizationdate,
	itineration.start,
	itineration.stop,
	itineration.adate,
	itineration.grossfactor,
	itineration.netfee,
	itineration.totalgross,
	itineration.total,
	itineration.totadvance,
	itineration.location,
	itineration.cu,
	itineration.ct,
	itineration.lu,
	itineration.lt,
	itineration.active,
	itineration.completed,
	itineration.iditinerationstatus,
	itinerationstatus.description,
	itineration.idaccmotive,
	AM.codemotive,
	AM.title,
	itineration.idaccmotivedebit,
	DB.codemotive,
	DB.title,
	itineration.idaccmotivedebit_crg,
	CRG.codemotive,
	CRG.title,
	itineration.idaccmotivedebit_datacrg,
	itineration.idupb,UPB.codeupb,
	isnull(itineration.idsor01,UPB.idsor01),
	isnull(itineration.idsor02,UPB.idsor02),
	isnull(itineration.idsor03,UPB.idsor03),
	isnull(itineration.idsor04,UPB.idsor04),
	isnull(itineration.idsor05,UPB.idsor05),
	itineration.idsor1,
	itineration.idsor2,
	itineration.idsor3,
	itineration.txt,
	itineration.rtf,
	position.description,
	L1.incomeclass,
	L1.incomeclassvalidity,
	registry.extmatricula,
	foreigngroupruledetail.foreigngroupnumber,
	itineration.idregistrylegalstatus,
	itineration.applierannotations,
	itineration.webwarn,
	itineration.idman,
	manager.title,
	itineration.flagweb,
	itineration.idauthmodel,
	authmodel.description,
	authmodel.title,
	(case when itineration.iditinerationstatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when itineration.iditinerationstatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when itineration.iditinerationstatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when itineration.iditinerationstatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when itineration.iditinerationstatus=5 then '<center><img src="Immagini/inapprovazione.png" title="Autorizzazione" alt="In Fase di Approvazione"/></center>'
		  when itineration.iditinerationstatus=6 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when itineration.iditinerationstatus=7 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  when itineration.iditinerationstatus=8 then '<center><img src="Immagini/inapprovazione.png" title="Autorizzazione rendiconto" alt="In Fase di Approvazione"/></center>'
		  when itineration.iditinerationstatus=null then ''
		  end
		  ),
	itinerationstatus.listingorder,
	itineration.authneeded,
	itineration.authdoc,
	itineration.authdocdate,
	itineration.noauthreason,
	itineration.clause_accepted,
	itineration.vehicle_info,
	itineration.vehicle_motive,
	IR.linkedangir+IR.linkedanpag, -- advancelinked
	(case when linkedsaldo>0 then IR.linkedsaldo+IR.linkedanpag else IR.linkedanpag+IR.linkedangir end) ,--totlinked,
	 IR.totalgross-(case when linkedsaldo>0 then IR.linkedsaldo+IR.linkedanpag else IR.linkedanpag+IR.linkedangir end),	--totresidual
	(select sum(s.noaccount) from itinerationrefund s where s.iditineration = itineration.iditineration and s.flagadvancebalance = 'S'),
	itineration.datecompleted,
	'itineration§'+ convert(varchar(10),itineration.yitineration) + '§'+ convert(varchar(10),itineration.nitineration),
	itineration.additionalannotations,
	itineration.idsor_siope,
	ref.iditineration_ref,
	ref.nitineration
FROM itineration with (nolock)	
JOIN registry  with (nolock)					ON registry.idreg = itineration.idreg
LEFT OUTER JOIN service  with (nolock)			ON service.idser = itineration.idser
LEFT OUTER JOIN legalstatuscontract L1 with (nolock)	ON L1.idreg = itineration.idreg 
															AND L1.idregistrylegalstatus = itineration.idregistrylegalstatus 
LEFT OUTER JOIN position with (nolock)			on position.idposition=L1.idposition
LEFT OUTER JOIN foreigngrouprule with (nolock)	on idforeigngrouprule = (select max(idforeigngrouprule) from foreigngrouprule where start <= itineration.adate)
LEFT OUTER JOIN foreigngroupruledetail with (nolock)		on foreigngroupruledetail.idforeigngrouprule=foreigngrouprule.idforeigngrouprule
											and foreigngroupruledetail.idposition=L1.idposition
											and L1.incomeclass between foreigngroupruledetail.minincomeclass and foreigngroupruledetail.maxincomeclass
LEFT OUTER JOIN accmotive AM with (nolock)	ON AM.idaccmotive = itineration.idaccmotive
LEFT OUTER JOIN accmotive DB with (nolock)	ON DB.idaccmotive =  itineration.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG with (nolock)	ON CRG.idaccmotive = itineration.idaccmotivedebit_crg
LEFT OUTER JOIN itinerationstatus  with (nolock)	ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus
LEFT OUTER JOIN manager  with (nolock)		ON manager.idman = itineration.idman
LEFT OUTER JOIN authmodel  with (nolock)	ON authmodel.idauthmodel = itineration.idauthmodel
LEFT OUTER JOIN itineration ref  with (nolock)	ON ref.iditineration = itineration.iditineration_ref
LEFT OUTER JOIN upb  with (nolock)			ON upb.idupb = itineration.idupb
join itinerationresidual  IR with (nolock)	on IR.iditineration= itineration.iditineration
LEFT OUTER JOIN dalia_position DP (nolock)	ON DP.iddaliaposition = itineration.iddaliaposition
	
GO
