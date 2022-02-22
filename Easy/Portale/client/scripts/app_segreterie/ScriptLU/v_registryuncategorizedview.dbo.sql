
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


-- CREAZIONE VISTA registryuncategorizedview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryuncategorizedview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryuncategorizedview]
GO

CREATE VIEW [dbo].[registryuncategorizedview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender,
 [dbo].accmotive.codemotive AS accmotive_codemotive, [dbo].accmotive.title AS accmotive_title, registry.idaccmotivecredit,
 accmotive_registry.codemotive AS accmotive_registry_codemotive, accmotive_registry.title AS accmotive_registry_title, registry.idaccmotivedebit, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, registry.idcity AS registry_idcity, registry.idexternal AS registry_idexternal, registry.idmaritalstatus AS registry_idmaritalstatus, registry.idnation AS registry_idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, registry.idtitle AS registry_idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, registry.residence AS registry_residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt,
 isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia: ' + [dbo].registryclass.description + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].accmotive WITH (NOLOCK) ON registry.idaccmotivecredit = [dbo].accmotive.idaccmotive
LEFT OUTER JOIN [dbo].accmotive AS accmotive_registry WITH (NOLOCK) ON registry.idaccmotivedebit = accmotive_registry.idaccmotive
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
WHERE  registry.idreg IS NOT NULL 
GO

