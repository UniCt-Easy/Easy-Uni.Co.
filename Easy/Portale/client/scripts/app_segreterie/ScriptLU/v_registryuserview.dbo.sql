
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


-- CREAZIONE VISTA registryuserview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryuserview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryuserview]
GO

CREATE VIEW [dbo].[registryuserview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idaccmotivecredit AS registry_idaccmotivecredit, registry.idaccmotivedebit AS registry_idaccmotivedebit, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, registry.idmaritalstatus AS registry_idmaritalstatus, registry.idnation AS registry_idnation, registry.idreg, registry.idregistryclass AS registry_idregistryclass, registry.idregistrykind AS registry_idregistrykind, registry.idtitle AS registry_idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, registry.residence AS registry_residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_user.ct AS registry_user_ct, registry_user.cu AS registry_user_cu,
 [dbo].attach.filename AS attach_filename, registry_user.idattach, registry_user.idreg AS registry_user_idreg, registry_user.lt AS registry_user_lt, registry_user.lu AS registry_user_lu,CASE WHEN registry_user.newsletter = 'S' THEN 'Si' WHEN registry_user.newsletter = 'N' THEN 'No' END AS registry_user_newsletter,CASE WHEN registry_user.privacy = 'S' THEN 'Si' WHEN registry_user.privacy = 'N' THEN 'No' END AS registry_user_privacy,CASE WHEN registry_user.regulationaccept = 'S' THEN 'Si' WHEN registry_user.regulationaccept = 'N' THEN 'No' END AS registry_user_regulationaccept,(select top 1 email 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_email,
						(select top 1 faxnumber 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_faxnumber,
						(select top 1 mobilenumber 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_mobilenumber,
						(select top 1 pec 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_pec,
						(select top 1 phonenumber 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_phonenumber,
						(select top 1 referencename 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_referencename,
						(select top 1 userweb 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_userweb,
						(select top 1 website 
						from dbo.registryreference 
						where dbo.registryreference.idreg = registry_user.idreg
						 order by registryreference.idregistryreference asc ) as registryreference_website,
 isnull('Nome e Cognome: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_user WITH (NOLOCK) ON registry.idreg = registry_user.idreg
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].attach WITH (NOLOCK) ON registry_user.idattach = [dbo].attach.idattach
WHERE  registry.idreg IS NOT NULL  AND registry_user.idreg IS NOT NULL 
GO

