
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


-- CREAZIONE VISTA registryistituti_princview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryistituti_princview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryistituti_princview]
GO

CREATE VIEW [dbo].[registryistituti_princview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender,
 [dbo].accmotive.codemotive AS accmotive_codemotive, [dbo].accmotive.title AS accmotive_title, registry.idaccmotivecredit,
 accmotive_registry.codemotive AS accmotive_registry_codemotive, accmotive_registry.title AS accmotive_registry_title, registry.idaccmotivedebit,
 [dbo].category.description AS category_description, registry.idcategory,
 [dbo].centralizedcategory.description AS centralizedcategory_description, registry.idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal,
 [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus,
 [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass,
 [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind,
 [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe,
 [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_istituti.codicemiur AS registry_istituti_codicemiur, registry_istituti.codiceustat AS registry_istituti_codiceustat, registry_istituti.comune AS registry_istituti_comune, registry_istituti.ct AS registry_istituti_ct, registry_istituti.cu AS registry_istituti_cu,
 [dbo].istitutokind.tipoistituto AS istitutokind_tipoistituto, registry_istituti.idistitutokind AS registry_istituti_idistitutokind, registry_istituti.idistitutoustat AS registry_istituti_idistitutoustat, registry_istituti.idreg AS registry_istituti_idreg, registry_istituti.lt AS registry_istituti_lt, registry_istituti.lu AS registry_istituti_lu, registry_istituti.nome AS registry_istituti_nome, registry_istituti.sortcode AS registry_istituti_sortcode, registry_istituti.title AS registry_istituti_title, registry_istituti.title_en AS registry_istituti_title_en,(select top 1 acronimo 
						from dbo.istitutoprinc 
						where dbo.istitutoprinc.idreg = registry_istituti.idreg
						 order by istitutoprinc.idreg desc) as istitutoprinc_acronimo,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_istituti WITH (NOLOCK) ON registry.idreg = registry_istituti.idreg
LEFT OUTER JOIN [dbo].accmotive WITH (NOLOCK) ON registry.idaccmotivecredit = [dbo].accmotive.idaccmotive
LEFT OUTER JOIN [dbo].accmotive AS accmotive_registry WITH (NOLOCK) ON registry.idaccmotivedebit = accmotive_registry.idaccmotive
LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory
LEFT OUTER JOIN [dbo].centralizedcategory WITH (NOLOCK) ON registry.idcentralizedcategory = [dbo].centralizedcategory.idcentralizedcategory
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind
LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].istitutokind WITH (NOLOCK) ON registry_istituti.idistitutokind = [dbo].istitutokind.idistitutokind
WHERE  registry.idreg IS NOT NULL  AND registry_istituti.idreg IS NOT NULL 
GO

