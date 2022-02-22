
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


-- CREAZIONE VISTA itinerationsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationsegview]
GO

CREATE VIEW [itinerationsegview] AS 
SELECT CASE WHEN itineration.active = 'S' THEN 'Si' WHEN itineration.active = 'N' THEN 'No' END AS itineration_active, itineration.adate AS itineration_adate, itineration.additionalannotations AS itineration_additionalannotations, itineration.admincarkm AS itineration_admincarkm, itineration.admincarkmcost AS itineration_admincarkmcost,CASE WHEN itineration.advanceapplied = 'S' THEN 'Si' WHEN itineration.advanceapplied = 'N' THEN 'No' END AS itineration_advanceapplied, itineration.advancepercentage AS itineration_advancepercentage, itineration.applierannotations AS itineration_applierannotations, itineration.authdoc AS itineration_authdoc, itineration.authdocdate AS itineration_authdocdate,CASE WHEN itineration.authneeded = 'S' THEN 'Si' WHEN itineration.authneeded = 'N' THEN 'No' END AS itineration_authneeded, itineration.authorizationdate AS itineration_authorizationdate, itineration.cancelreason AS itineration_cancelreason,CASE WHEN itineration.clause_accepted = 'S' THEN 'Si' WHEN itineration.clause_accepted = 'N' THEN 'No' END AS itineration_clause_accepted,CASE WHEN itineration.completed = 'S' THEN 'Si' WHEN itineration.completed = 'N' THEN 'No' END AS itineration_completed, itineration.ct AS itineration_ct, itineration.cu AS itineration_cu, itineration.datecompleted AS itineration_datecompleted, itineration.description, itineration.flagmove AS itineration_flagmove,CASE WHEN itineration.flagoutside = 'S' THEN 'Si' WHEN itineration.flagoutside = 'N' THEN 'No' END AS itineration_flagoutside,CASE WHEN itineration.flagownfunds = 'S' THEN 'Si' WHEN itineration.flagownfunds = 'N' THEN 'No' END AS itineration_flagownfunds,CASE WHEN itineration.flagweb = 'S' THEN 'Si' WHEN itineration.flagweb = 'N' THEN 'No' END AS itineration_flagweb, itineration.footkm AS itineration_footkm, itineration.footkmcost AS itineration_footkmcost, itineration.grossfactor AS itineration_grossfactor, itineration.idaccmotive AS itineration_idaccmotive, itineration.idaccmotivedebit_crg AS itineration_idaccmotivedebit_crg, itineration.idaccmotivedebit_datacrg AS itineration_idaccmotivedebit_datacrg, itineration.idauthmodel AS itineration_idauthmodel, itineration.iddalia_dipartimento AS itineration_iddalia_dipartimento, itineration.iddalia_funzionale AS itineration_iddalia_funzionale, itineration.iddaliaposition AS itineration_iddaliaposition, itineration.iddaliarecruitmentmotive AS itineration_iddaliarecruitmentmotive, itineration.idforeigncountry AS itineration_idforeigncountry, itineration.iditineration, itineration.iditineration_ref AS itineration_iditineration_ref, itineration.iditinerationstatus AS itineration_iditinerationstatus, itineration.idreg AS itineration_idreg, itineration.idregistrylegalstatus AS itineration_idregistrylegalstatus, itineration.idregistrypaymethod AS itineration_idregistrypaymethod, itineration.idser AS itineration_idser, itineration.idsor_siope AS itineration_idsor_siope, itineration.idsor1 AS itineration_idsor1, itineration.idsor2 AS itineration_idsor2, itineration.idsor3 AS itineration_idsor3, itineration.idupb AS itineration_idupb, itineration.location AS itineration_location, itineration.lt AS itineration_lt, itineration.lu AS itineration_lu, itineration.netfee AS itineration_netfee, itineration.nfood AS itineration_nfood, itineration.nitineration AS itineration_nitineration, itineration.noauthreason AS itineration_noauthreason, itineration.owncarkm AS itineration_owncarkm, itineration.owncarkmcost AS itineration_owncarkmcost, itineration.rtf AS itineration_rtf, itineration.start AS itineration_start, itineration.starttime AS itineration_starttime, itineration.stop AS itineration_stop, itineration.stoptime AS itineration_stoptime, itineration.supposedamount AS itineration_supposedamount, itineration.supposedfood AS itineration_supposedfood, itineration.supposedliving AS itineration_supposedliving, itineration.supposedtravel AS itineration_supposedtravel, itineration.totadvance AS itineration_totadvance, itineration.total AS itineration_total, itineration.totalgross AS itineration_totalgross, itineration.txt AS itineration_txt, itineration.vehicle_info AS itineration_vehicle_info, itineration.vehicle_motive AS itineration_vehicle_motive, itineration.webwarn AS itineration_webwarn, itineration.yitineration AS itineration_yitineration,
 isnull('Motivazione: ' + itineration.description + '; ','') + ' ' + isnull('Località : ' + itineration.location + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, itineration.starttime, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, itineration.stoptime, 103),'') as dropdown_title
FROM itineration WITH (NOLOCK) 
WHERE  itineration.iditineration IS NOT NULL 
GO

