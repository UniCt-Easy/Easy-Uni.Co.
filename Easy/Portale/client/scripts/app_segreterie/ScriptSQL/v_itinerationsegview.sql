
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

-- VERIFICA DI itinerationsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','varchar(313)','ASSISTENZA','dropdown_title','313','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','int','ASSISTENZA','iditineration','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','date','ASSISTENZA','itineration_adate','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(800)','ASSISTENZA','itineration_additionalannotations','800','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','float','ASSISTENZA','itineration_admincarkm','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,6)','ASSISTENZA','itineration_admincarkmcost','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_advanceapplied','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,8)','ASSISTENZA','itineration_advancepercentage','9','N','decimal','System.Decimal','','8','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(800)','ASSISTENZA','itineration_applierannotations','800','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(35)','ASSISTENZA','itineration_authdoc','35','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','date','ASSISTENZA','itineration_authdocdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_authneeded','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','date','ASSISTENZA','itineration_authorizationdate','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(400)','ASSISTENZA','itineration_cancelreason','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_clause_accepted','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_completed','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','datetime','ASSISTENZA','itineration_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','varchar(64)','ASSISTENZA','itineration_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','date','ASSISTENZA','itineration_datecompleted','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_flagmove','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_flagoutside','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_flagownfunds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2)','ASSISTENZA','itineration_flagweb','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','float','ASSISTENZA','itineration_footkm','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,6)','ASSISTENZA','itineration_footkmcost','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','float','ASSISTENZA','itineration_grossfactor','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(36)','ASSISTENZA','itineration_idaccmotive','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(36)','ASSISTENZA','itineration_idaccmotivedebit_crg','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','date','ASSISTENZA','itineration_idaccmotivedebit_datacrg','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idauthmodel','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_iddalia_dipartimento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_iddalia_funzionale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_iddaliaposition','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_iddaliarecruitmentmotive','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idforeigncountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_iditineration_ref','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','smallint','ASSISTENZA','itineration_iditinerationstatus','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','int','ASSISTENZA','itineration_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idregistrylegalstatus','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idregistrypaymethod','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','int','ASSISTENZA','itineration_idser','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idsor_siope','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idsor1','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idsor2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_idsor3','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(36)','ASSISTENZA','itineration_idupb','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','datetime','ASSISTENZA','itineration_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','varchar(64)','ASSISTENZA','itineration_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_netfee','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','int','ASSISTENZA','itineration_nfood','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','int','ASSISTENZA','itineration_nitineration','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(1000)','ASSISTENZA','itineration_noauthreason','1000','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','float','ASSISTENZA','itineration_owncarkm','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,6)','ASSISTENZA','itineration_owncarkmcost','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','image','ASSISTENZA','itineration_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','date','ASSISTENZA','itineration_start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','date','ASSISTENZA','itineration_stop','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_supposedamount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_supposedfood','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_supposedliving','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_supposedtravel','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_totadvance','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_total','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','decimal(19,2)','ASSISTENZA','itineration_totalgross','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','text','ASSISTENZA','itineration_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(200)','ASSISTENZA','itineration_vehicle_info','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(2000)','ASSISTENZA','itineration_vehicle_motive','2000','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itinerationsegview','varchar(400)','ASSISTENZA','itineration_webwarn','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itinerationsegview','smallint','ASSISTENZA','itineration_yitineration','2','S','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI itinerationsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationsegview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

