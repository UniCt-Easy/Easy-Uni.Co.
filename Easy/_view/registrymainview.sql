
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA registrymainview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrymainview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrymainview]
GO




-- CREAZIONE VISTA registrymainview
CREATE   VIEW [DBO].[registrymainview]
(
	idreg, 
	title, 
	idregistryclass, 
	registryclass,
	surname, 
	forename, 
	cf, 
	p_iva, 
	residence, coderesidence,
	residencekind,
	annotation, 
	birthdate, 
	idcity, 
	city, 
	gender, 
	foreigncf, 
	idtitle,
	qualification, 
	idmaritalstatus, 
	maritalstatus, 
	idregistrykind, 
	sortcode,
	registrykind,
	human, 
	active, 
	badgecode,
	maritalsurname, 
	idcategory,
	category, 
	extmatricula, 
	idcentralizedcategory,
	cu,
	ct,
	lu,
	lt,
	location,
	idnation,
	nation,
	authorization_free,
	multi_cf,
	toredirect,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivecredit,
	codemotivecredit,
	ccp,
	flagbankitaliaproceeds,
	ipa_fe,
	pec_fe,
	email_fe,
	flag_pa,
	sdi_norifamm,
	sdi_defrifamm
)
AS
SELECT
	registry.idreg, registry.title, 
	registry.idregistryclass, 
	registryclass.description, 
	registry.surname, registry.forename, 
	registry.cf, registry.p_iva, 
	registry.residence, residence.coderesidence,
	residence.description, 
	registry.annotation, 
	registry.birthdate, 
	registry.idcity, geo_city.title,
	registry.gender, registry.foreigncf, 
	registry.idtitle, 
	title.description, 
	registry.idmaritalstatus, 
	maritalstatus.description, 
	registry.idregistrykind,
	registrykind.sortcode, 
	registrykind.description, 
	registryclass.flaghuman, registry.active, 
	registry.badgecode, 
	registry.maritalsurname, 
	registry.idcategory, 
	category.description,
	registry.extmatricula, 
	registry.idcentralizedcategory,
	registry.cu, 
	registry.ct, 
	registry.lu, 
	registry.lt,
	registry.location,
	registry.idnation,
	geo_nation.title,
	registry.authorization_free,
	registry.multi_cf,
	registry.toredirect,
	registry.idaccmotivedebit,
	DB.codemotive,
	registry.idaccmotivecredit,
	CR.codemotive,
	registry.ccp,
	registry.flagbankitaliaproceeds,
	registry.ipa_fe,
	registry.pec_fe,
	registry.email_fe,
	registry.flag_pa,
	registry.sdi_norifamm,
	registry.sdi_defrifamm
FROM registry
LEFT OUTER JOIN registrykind
	ON registrykind.idregistrykind = registry.idregistrykind
LEFT OUTER JOIN residence
	ON residence.idresidence = registry.residence
LEFT OUTER JOIN registryclass
	ON registryclass.idregistryclass = registry.idregistryclass
LEFT OUTER JOIN title
	ON title.idtitle = registry.idtitle
LEFT OUTER JOIN maritalstatus
	ON maritalstatus.idmaritalstatus = registry.idmaritalstatus
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
LEFT OUTER JOIN category
	ON category.idcategory = registry.idcategory

LEFT OUTER JOIN accmotive DB
	ON DB.idaccmotive =  registry.idaccmotivedebit
LEFT OUTER JOIN accmotive CR
	ON CR.idaccmotive =  registry.idaccmotivecredit





GO
