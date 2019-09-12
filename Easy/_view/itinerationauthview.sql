-- CREAZIONE VISTA itinerationauthview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationauthview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationauthview]
GO

--setuser 'amministrazione'


CREATE view [itinerationauthview] as
(
select  
       itinerationview.iditineration as iditineration,
	   itinerationview.statusimage as statusimage,
	   itinerationview.nitineration as nitineration,
	   itinerationview.yitineration as yitineration,
	   (case when itinerationauthagency.flagstatus='S' then 'Approvata'
		when itinerationauthagency.flagstatus='D' then 'Da Definire'
		when itinerationauthagency.flagstatus='N' then 'Non Approvata' end) as authstatus,
	   (case when itinerationauthagency.flagstatus='S' then '<center><img src="Immagini\tl_green.png" title="Approvata" alt="Approvata" ></center>'
		when itinerationauthagency.flagstatus='N' then '<center><img src="Immagini\tl_red.png" title="Non Approvata" alt="Non Approvata"></center>'
		when itinerationauthagency.flagstatus='D' then '<center><img src="Immagini\tl_yellow.png" title="Da Definire" alt="Da Definire"></center>'
		end) as authstatusimage,	
       itinerationview.description as description,
	   itinerationview.idreg as idreg,
	   itinerationview.registry as registry,
       itinerationview.start as start,
       itinerationview.stop as stop,
	   itinerationview.adate as adate,
	   itinerationview.total as total,
	   (
			select sum(isnull(itinerationrefund.amount,0)) from itinerationrefund 
			where itinerationrefund.iditineration = itinerationview.iditineration and itinerationrefund.flagadvancebalance='A'
		) as totadvance,
       (select count(*) from itinerationlap where itinerationlap.iditineration=itinerationview.iditineration) as lapcount,
	   itinerationview.idman as idman,
	   manager.title as managertitle,
	   itinerationview.idauthmodel as idauthmodel,
	   itinerationauthagency.idauthagency as idauthagency,
	   authagency.title as authagencytitle,
	   authagency.priority as priority,
	   authagency.ismanager as ismanager,
	   itinerationauthagency.flagstatus as flagstatus,
	   itinerationview.authorizationdate as authorizationdate,
	   itinerationview.iditinerationstatus as iditinerationstatus,
	   itinerationview.location as location,
	   itinerationview.idsor01,
	   itinerationview.idsor02,
	   itinerationview.idsor03,
	   itinerationview.idsor04,
	   itinerationview.idsor05,
	   itinerationview.applierannotations,
	   itinerationview.vehicle_motive,
	   itinerationauthagency.annotationsrejectapproval,
	   itinerationview.additionalannotations,
	   itinerationview.idupb
from itinerationview 
join 	itinerationstatus on 	itinerationview.iditinerationstatus=itinerationstatus.iditinerationstatus
join    authmodel	on	itinerationview.idauthmodel=authmodel.idauthmodel
join	itinerationauthagency on     itinerationview.iditineration=itinerationauthagency.iditineration
join authagency on      itinerationauthagency.idauthagency=authagency.idauthagency
join manager on itinerationview.idman=manager.idman
)





GO
