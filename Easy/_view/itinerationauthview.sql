
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- CREAZIONE VISTA itinerationauthview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationauthview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationauthview]
GO
-- setuser'amm'
-- setuser 'amministrazione'


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
		case when isnull((select sum(itinerationrefund.amount) from itinerationrefund where itinerationrefund.iditineration = itinerationview.iditineration and itinerationrefund.flagadvancebalance='A'),0) >0 
					then (select sum(itinerationrefund.amount) from itinerationrefund where itinerationrefund.iditineration = itinerationview.iditineration and itinerationrefund.flagadvancebalance='A')
				when isnull((select supposedamount from itineration where iditineration = itinerationview.iditineration),0) > 0 then (select supposedamount from itineration where iditineration = itinerationview.iditineration) 
				else 0
		end as totadvance,
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
	   itinerationview.vehicle_info,
	   itinerationview.vehicle_motive,
	   itinerationauthagency.annotationsrejectapproval,
	   itinerationview.additionalannotations,
	   itinerationview.idupb,
	   isnull(	
				(select top 1 annotationsrejectapproval 
					from itinerationauthagency ia_prec 
					join	authagency a_prec on  ia_prec.idauthagency = a_prec.idauthagency 
					where itinerationview.iditineration = ia_prec.iditineration 
						 and a_prec.priority < authagency.priority 
						 order by a_prec.priority desc
				),'') as annotationsrejectapproval_prec
from	itinerationview 
join 	itinerationstatus on 	itinerationview.iditinerationstatus=itinerationstatus.iditinerationstatus
join    authmodel	on	itinerationview.idauthmodel=authmodel.idauthmodel
join	itinerationauthagency on     itinerationview.iditineration=itinerationauthagency.iditineration
join	authagency on      itinerationauthagency.idauthagency=authagency.idauthagency
left outer join manager on itinerationview.idman=manager.idman
)





GO
