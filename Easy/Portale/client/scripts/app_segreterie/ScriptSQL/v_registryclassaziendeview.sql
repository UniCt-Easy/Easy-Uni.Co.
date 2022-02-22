
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


-- CREAZIONE VISTA registryclassaziendeview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryclassaziendeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryclassaziendeview]
GO



CREATE VIEW [dbo].[registryclassaziendeview] AS SELECT CASE WHEN registryclass.active = 'S' THEN 'Si' WHEN registryclass.active = 'N' THEN 'No' END AS registryclass_active, registryclass.ct AS registryclass_ct, registryclass.cu AS registryclass_cu, registryclass.description,CASE WHEN registryclass.flagbadgecode = 'S' THEN 'Si' WHEN registryclass.flagbadgecode = 'N' THEN 'No' END AS registryclass_flagbadgecode,CASE WHEN registryclass.flagbadgecode_forced = 'S' THEN 'Si' WHEN registryclass.flagbadgecode_forced = 'N' THEN 'No' END AS registryclass_flagbadgecode_forced,CASE WHEN registryclass.flagCF = 'S' THEN 'Si' WHEN registryclass.flagCF = 'N' THEN 'No' END AS registryclass_flagCF,CASE WHEN registryclass.flagcf_forced = 'S' THEN 'Si' WHEN registryclass.flagcf_forced = 'N' THEN 'No' END AS registryclass_flagcf_forced,CASE WHEN registryclass.flagcfbutton = 'S' THEN 'Si' WHEN registryclass.flagcfbutton = 'N' THEN 'No' END AS registryclass_flagcfbutton,CASE WHEN registryclass.flagextmatricula = 'S' THEN 'Si' WHEN registryclass.flagextmatricula = 'N' THEN 'No' END AS registryclass_flagextmatricula,CASE WHEN registryclass.flagextmatricula_forced = 'S' THEN 'Si' WHEN registryclass.flagextmatricula_forced = 'N' THEN 'No' END AS registryclass_flagextmatricula_forced,CASE WHEN registryclass.flagfiscalresidence = 'S' THEN 'Si' WHEN registryclass.flagfiscalresidence = 'N' THEN 'No' END AS registryclass_flagfiscalresidence,CASE WHEN registryclass.flagfiscalresidence_forced = 'S' THEN 'Si' WHEN registryclass.flagfiscalresidence_forced = 'N' THEN 'No' END AS registryclass_flagfiscalresidence_forced,CASE WHEN registryclass.flagforeigncf = 'S' THEN 'Si' WHEN registryclass.flagforeigncf = 'N' THEN 'No' END AS registryclass_flagforeigncf,CASE WHEN registryclass.flagforeigncf_forced = 'S' THEN 'Si' WHEN registryclass.flagforeigncf_forced = 'N' THEN 'No' END AS registryclass_flagforeigncf_forced,CASE WHEN registryclass.flaghuman = 'S' THEN 'Si' WHEN registryclass.flaghuman = 'N' THEN 'No' END AS registryclass_flaghuman,CASE WHEN registryclass.flaginfofromcfbutton = 'S' THEN 'Si' WHEN registryclass.flaginfofromcfbutton = 'N' THEN 'No' END AS registryclass_flaginfofromcfbutton,CASE WHEN registryclass.flagmaritalstatus = 'S' THEN 'Si' WHEN registryclass.flagmaritalstatus = 'N' THEN 'No' END AS registryclass_flagmaritalstatus,CASE WHEN registryclass.flagmaritalstatus_forced = 'S' THEN 'Si' WHEN registryclass.flagmaritalstatus_forced = 'N' THEN 'No' END AS registryclass_flagmaritalstatus_forced,CASE WHEN registryclass.flagmaritalsurname = 'S' THEN 'Si' WHEN registryclass.flagmaritalsurname = 'N' THEN 'No' END AS registryclass_flagmaritalsurname,CASE WHEN registryclass.flagmaritalsurname_forced = 'S' THEN 'Si' WHEN registryclass.flagmaritalsurname_forced = 'N' THEN 'No' END AS registryclass_flagmaritalsurname_forced,CASE WHEN registryclass.flagothers = 'S' THEN 'Si' WHEN registryclass.flagothers = 'N' THEN 'No' END AS registryclass_flagothers,CASE WHEN registryclass.flagothers_forced = 'S' THEN 'Si' WHEN registryclass.flagothers_forced = 'N' THEN 'No' END AS registryclass_flagothers_forced,CASE WHEN registryclass.flagp_iva = 'S' THEN 'Si' WHEN registryclass.flagp_iva = 'N' THEN 'No' END AS registryclass_flagp_iva,CASE WHEN registryclass.flagp_iva_forced = 'S' THEN 'Si' WHEN registryclass.flagp_iva_forced = 'N' THEN 'No' END AS registryclass_flagp_iva_forced,CASE WHEN registryclass.flagqualification = 'S' THEN 'Si' WHEN registryclass.flagqualification = 'N' THEN 'No' END AS registryclass_flagqualification,CASE WHEN registryclass.flagqualification_forced = 'S' THEN 'Si' WHEN registryclass.flagqualification_forced = 'N' THEN 'No' END AS registryclass_flagqualification_forced,CASE WHEN registryclass.flagresidence = 'S' THEN 'Si' WHEN registryclass.flagresidence = 'N' THEN 'No' END AS registryclass_flagresidence,CASE WHEN registryclass.flagresidence_forced = 'S' THEN 'Si' WHEN registryclass.flagresidence_forced = 'N' THEN 'No' END AS registryclass_flagresidence_forced,CASE WHEN registryclass.flagtitle = 'S' THEN 'Si' WHEN registryclass.flagtitle = 'N' THEN 'No' END AS registryclass_flagtitle,CASE WHEN registryclass.flagtitle_forced = 'S' THEN 'Si' WHEN registryclass.flagtitle_forced = 'N' THEN 'No' END AS registryclass_flagtitle_forced, registryclass.idregistryclass, registryclass.lt AS registryclass_lt, registryclass.lu AS registryclass_lu, isnull('Descrizione: ' + registryclass.description + '; ','') as dropdown_title FROM [dbo].registryclass WITH (NOLOCK)  WHERE  registryclass.active = 'S' AND registryclass.flaghuman = 'N' AND registryclass.idregistryclass IS NOT NULL 

GO

-- VERIFICA DI registryclassaziendeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryclassaziendeview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','varchar(165)','ASSISTENZA','dropdown_title','165','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','varchar(2)','ASSISTENZA','idregistryclass','2','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','datetime','ASSISTENZA','registryclass_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','varchar(64)','ASSISTENZA','registryclass_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagbadgecode','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagbadgecode_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagCF','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagcf_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagcfbutton','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagextmatricula','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagextmatricula_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagfiscalresidence','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagfiscalresidence_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagforeigncf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagforeigncf_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flaghuman','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flaginfofromcfbutton','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagmaritalstatus','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagmaritalstatus_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagmaritalsurname','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagmaritalsurname_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagothers','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagothers_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagp_iva','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagp_iva_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagqualification','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagqualification_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagresidence','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagresidence_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagtitle','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclassaziendeview','varchar(2)','ASSISTENZA','registryclass_flagtitle_forced','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','datetime','ASSISTENZA','registryclass_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclassaziendeview','varchar(64)','ASSISTENZA','registryclass_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryclassaziendeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryclassaziendeview')
UPDATE customobject set isreal = 'N' where objectname = 'registryclassaziendeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryclassaziendeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

