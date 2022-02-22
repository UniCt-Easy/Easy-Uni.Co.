
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


-- CREAZIONE VISTA registryaziende_roview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaziende_roview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryaziende_roview]
GO

CREATE VIEW [dbo].[registryaziende_roview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender, registry.idaccmotivecredit AS registry_idaccmotivecredit, registry.idaccmotivedebit AS registry_idaccmotivedebit,
 [dbo].category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, registry.idmaritalstatus AS registry_idmaritalstatus,
 [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass,
 [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, registry.idtitle AS registry_idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe,
 [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_aziende.ct AS registry_aziende_ct, registry_aziende.cu AS registry_aziende_cu,
 [dbo].ateco.codice AS ateco_codice, [dbo].ateco.title AS ateco_title, registry_aziende.idateco,
 [dbo].nace.idnace AS nace_idnace, [dbo].nace.activity AS nace_activity, registry_aziende.idnace,
 [dbo].naturagiur.title AS naturagiur_title, registry_aziende.idnaturagiur,
 [dbo].numerodip.title AS numerodip_title, registry_aziende.idnumerodip, registry_aziende.idreg AS registry_aziende_idreg, registry_aziende.lt AS registry_aziende_lt, registry_aziende.lu AS registry_aziende_lu, registry_aziende.pic AS registry_aziende_pic, registry_aziende.title_en AS registry_aziende_title_en, registry_aziende.txt_en AS registry_aziende_txt_en,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_aziende WITH (NOLOCK) ON registry.idreg = registry_aziende.idreg
LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].ateco WITH (NOLOCK) ON registry_aziende.idateco = [dbo].ateco.idateco
LEFT OUTER JOIN [dbo].nace WITH (NOLOCK) ON registry_aziende.idnace = [dbo].nace.idnace
LEFT OUTER JOIN [dbo].naturagiur WITH (NOLOCK) ON registry_aziende.idnaturagiur = [dbo].naturagiur.idnaturagiur
LEFT OUTER JOIN [dbo].numerodip WITH (NOLOCK) ON registry_aziende.idnumerodip = [dbo].numerodip.idnumerodip
WHERE  registry.idreg IS NOT NULL  AND registry_aziende.idreg IS NOT NULL 
GO

-- VERIFICA DI registryaziende_roview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryaziende_roview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','ateco_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(255)','ASSISTENZA','ateco_title','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','category_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','varchar(118)','ASSISTENZA','dropdown_title','118','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','idateco','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','nvarchar(50)','ASSISTENZA','idnace','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','idnaturagiur','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','idnumerodip','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','nvarchar(max)','ASSISTENZA','nace_activity','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','nvarchar(50)','ASSISTENZA','nace_idnace','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','nvarchar(200)','ASSISTENZA','naturagiur_title','200','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','nvarchar(50)','ASSISTENZA','numerodip_title','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','datetime','ASSISTENZA','registry_aziende_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','varchar(64)','ASSISTENZA','registry_aziende_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','int','ASSISTENZA','registry_aziende_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','datetime','ASSISTENZA','registry_aziende_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','varchar(64)','ASSISTENZA','registry_aziende_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(10)','ASSISTENZA','registry_aziende_pic','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(150)','ASSISTENZA','registry_aziende_title_en','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','nvarchar(max)','ASSISTENZA','registry_aziende_txt_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_gender','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(36)','ASSISTENZA','registry_idaccmotivecredit','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(36)','ASSISTENZA','registry_idaccmotivedebit','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(20)','ASSISTENZA','registry_idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(50)','ASSISTENZA','registrykind_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaziende_roview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaziende_roview','varchar(101)','ASSISTENZA','title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryaziende_roview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryaziende_roview')
UPDATE customobject set isreal = 'N' where objectname = 'registryaziende_roview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryaziende_roview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

