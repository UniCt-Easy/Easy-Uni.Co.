-- CREAZIONE VISTA itinerationlinked
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationlinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationlinked]
GO


--setuser 'amministrazione'
--clear_table_info 'itinerationlinked'
--select * from itinerationlinked 

CREATE  VIEW [itinerationlinked]
(
	ayear,
	idreg, registry,
	idser, service, codeser,
	iditineration,yitineration, nitineration,
	description,
	authorizationdate, start, stop, adate,
	admincarkmcost, owncarkmcost, footkmcost,
	admincarkm, owncarkm, footkm, 
	grossfactor,
	netfee, 
	totalgross,
	total,
	totadvance,
	idupb,
	codeupb,
	upb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	codemotive,
	iditinerationstatus,
	itinerationstatus,

	ct, cu, lu, lt
)
AS
SELECT 
	accountingyear.ayear,
	itineration.idreg, registry.title,
	itineration.idser, service.description, service.codeser,
	itineration.iditineration,itineration.yitineration, itineration.nitineration,
	itineration.description,
	itineration.authorizationdate, itineration.start, itineration.stop, itineration.adate,
	itineration.admincarkmcost, itineration.owncarkmcost, itineration.footkmcost,
	itineration.admincarkm, itineration.owncarkm, itineration.footkm, 
	itineration.grossfactor,
	itineration.netfee, 
	itineration.totalgross,
	itineration.total,
	itineration.totadvance,
	itineration.idupb,
	upb.codeupb,
	upb.title,
	itineration.idsor1,
	itineration.idsor2,
	itineration.idsor3,
	itineration.idaccmotive,
	accmotive.codemotive,
	itineration.iditinerationstatus,
	itinerationstatus.description,
	
	itineration.ct, itineration.cu, itineration.lu, itineration.lt
FROM itineration
JOIN registry				ON itineration.idreg = registry.idreg 
JOIN service				ON service.idser = itineration.idser  
LEFT OUTER JOIN upb			ON upb.idupb = itineration.idupb
LEFT OUTER JOIN accmotive		ON accmotive.idaccmotive = itineration.idaccmotive
LEFT OUTER JOIN itinerationstatus	ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus
CROSS JOIN accountingyear (nolock)
WHERE EXISTS(select * from expenseitineration JOIN expenseyear with (nolock)	ON expenseyear.idexp = expenseitineration.idexp where expenseitineration.iditineration = itineration.iditineration and accountingyear.ayear = expenseyear.ayear)


GO



