
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


-- CREAZIONE VISTA serviceregistryview 
-- clear_table_info'serviceregistryview'
IF EXISTS(select * from sysobjects where id = object_id(N'[serviceregistryview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [serviceregistryview]
GO
 -- setuser 'amm'

CREATE                      VIEW [serviceregistryview]
	(
	yservreg,
	nservreg,
	id_service,
	employkind,
	iddepartment,
	department ,
	is_annulled,
	is_delivered,
	is_changed,
	is_blocked,
	website_annulled,
	idconsultingkind,
	consultingkind,
	p_iva,
	cf,
	flagforeign,
	title,
	codcity,
	idcity,
	city,
	surname,
	forename,
	birthdate,
	gender,
	referencesemester,
	pa_code,
	idacquirekind,
	acquirekind,
	idapcontractkind,
	apcontractkind,
	idfinancialactivity,
	financialactivity,
	description,
	start,
	stop,
	servicevariation,
	expectedamount,
	payment,
	ypay,
	--semesterpay,
	--payedamount,
	idapmanager,
	apmanager,	
	idapregistrykind,
	apregistrykind,
	idapactivitykind,
	apactivitykind,	
	pa_cf,
	pa_title,
	authorizationdate,
	officeduty,
	annotation,
	referencerule,
	idreg,
	idrelated,
	regulation,
	idapfinancialactivity,
	apfinancialactivitycode,
	apfinancialactivity,
	expectationsdate,
	rulespecifics,
	paragraph,
	article,
	articlenumber,
	referencedate,
	idreferencerule,
	referenceruledescription,
	senderreporting,
	flaghuman,
	idconferring,
	conferring_piva,
	conferring_forename,
	conferring_surname,
	conferring_flagforeign,
	conferring_birthdate,
	conferring_gender,
	conferring_codcity,
	conferring_idcity,
	conferring_city,
	idserviceregistrykind,
	serviceregistrykind,
	conferringstructure,
	ordinancelink,
	authorizingstructure,
	authorizinglink,
	actreference,
	announcementlink,
	otherservice,
	professionalservice,
	componentsvariable,
	employtime,
	notes,
	certinterestconflicts,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt,
	perla_error,dichiarazione_incarichi,codicepaipa,codiceaooipa,codiceuoipa
	)
	AS SELECT
	serviceregistry.yservreg,
	serviceregistry.nservreg,
	serviceregistry.id_service,
	serviceregistry.employkind,
	serviceregistry.iddepartment,
	department.description ,
	serviceregistry.is_annulled,
	serviceregistry.is_delivered,
	serviceregistry.is_changed,
	serviceregistry.is_blocked,
	serviceregistry.website_annulled,
	serviceregistry.idconsultingkind,
	consultingkind.description,
	serviceregistry.p_iva,
	serviceregistry.cf,
	serviceregistry.flagforeign,
	serviceregistry.title,
	serviceregistry.codcity,
	serviceregistry.idcity,
	geo_city.title,
	serviceregistry.surname,
	serviceregistry.forename,
	serviceregistry.birthdate,
	serviceregistry.gender,
	serviceregistry.referencesemester,
	serviceregistry.pa_code,
	serviceregistry.idacquirekind,
	acquirekind.description,
	serviceregistry.idapcontractkind,
	apcontractkind.description,
	serviceregistry.idfinancialactivity,
	financialactivity.description,
	serviceregistry.description,
	serviceregistry.start,
	serviceregistry.stop,
	serviceregistry.servicevariation,
	serviceregistry.expectedamount,
	serviceregistry.payment,
	serviceregistry.ypay,
	--serviceregistry.semesterpay,
	--serviceregistry.payedamount,
	serviceregistry.idapmanager,
	apmanager.description,	
	serviceregistry.idapregistrykind,
	apregistrykind.description,
	serviceregistry.idapactivitykind,
	apactivitykind.description,	
	serviceregistry.pa_cf,
	serviceregistry.pa_title,
	serviceregistry.authorizationdate,
	serviceregistry.officeduty,
	serviceregistry.annotation,
	serviceregistry.referencerule,
	serviceregistry.idreg,
	serviceregistry.idrelated,
	serviceregistry.regulation,
	serviceregistry.idapfinancialactivity,
	apfinancialactivity.apfinancialactivitycode,
	apfinancialactivity.description,
	serviceregistry.expectationsdate,
	serviceregistry.rulespecifics,
	serviceregistry.paragraph,
	serviceregistry.article,
	serviceregistry.articlenumber,
	serviceregistry.referencedate,
	serviceregistry.idreferencerule,
	referencerule.description,
	serviceregistry.senderreporting,
	serviceregistry.flaghuman,
	serviceregistry.idconferring,
	serviceregistry.conferring_piva,
	serviceregistry.conferring_forename,
	serviceregistry.conferring_surname,
	serviceregistry.conferring_flagforeign,
	serviceregistry.conferring_birthdate,
	serviceregistry.conferring_gender,
	serviceregistry.conferring_codcity,
	serviceregistry.conferring_idcity,	
	geo_city_conferring.title,
	serviceregistry.idserviceregistrykind,
 	serviceregistrykind.description,
	serviceregistry.conferringstructure,
	serviceregistry.ordinancelink,
	serviceregistry.authorizingstructure,
	serviceregistry.authorizinglink,
	serviceregistry.actreference,
	serviceregistry.announcementlink,
	serviceregistry.otherservice,
	serviceregistry.professionalservice,
	serviceregistry.componentsvariable,
 	serviceregistry.employtime,
	serviceregistry.notes,
	serviceregistry.certinterestconflicts,
	serviceregistry.idsor01,
	serviceregistry.idsor02,
	serviceregistry.idsor03,
	serviceregistry.idsor04,
	serviceregistry.idsor05,
	serviceregistry.cu,
	serviceregistry.ct,
	serviceregistry.lu,
	serviceregistry.lt,
	serviceregistry.perla_error,
	serviceregistry.dichiarazione_incarichi,
	serviceregistry.codicepaipa,
	serviceregistry.codiceaooipa,
	serviceregistry.codiceuoipa
	FROM serviceregistry (NOLOCK)
	left outer JOIN apcontractkind (NOLOCK)
		ON serviceregistry.idapcontractkind = apcontractkind.idapcontractkind
		and serviceregistry.yservreg = apcontractkind.ayear
	LEFT OUTER JOIN apregistrykind (NOLOCK)
		ON apregistrykind.idapregistrykind = serviceregistry.idapregistrykind
		and serviceregistry.yservreg = apregistrykind.ayear
	LEFT OUTER JOIN consultingkind (NOLOCK)
		ON consultingkind.idconsultingkind = serviceregistry.idconsultingkind
		and serviceregistry.yservreg = consultingkind.ayear
	LEFT OUTER JOIN apmanager (NOLOCK)
		ON apmanager.idapmanager = serviceregistry.idapmanager
		and serviceregistry.yservreg = apmanager.ayear
	LEFT OUTER join financialactivity (NOLOCK)
		on financialactivity.idfinancialactivity = serviceregistry.idfinancialactivity
		and serviceregistry.yservreg = financialactivity.ayear
	LEFT OUTER join acquirekind (NOLOCK)			
		on acquirekind.idacquirekind = serviceregistry.idacquirekind
		and serviceregistry.yservreg = acquirekind.ayear
	LEFT OUTER join apactivitykind(NOLOCK)	
		on apactivitykind.idapactivitykind = serviceregistry.idapactivitykind
		and serviceregistry.yservreg = apactivitykind.ayear
	LEFT OUTER join department(NOLOCK)	
		on department.iddepartment = serviceregistry.iddepartment
	LEFT OUTER join geo_city(NOLOCK)	
		on geo_city.idcity = serviceregistry.idcity
	LEFT OUTER JOIN apfinancialactivity
		ON serviceregistry.idapfinancialactivity = apfinancialactivity.idapfinancialactivity
	LEFT OUTER JOIN referencerule
		ON referencerule.idreferencerule = serviceregistry.idreferencerule
		AND referencerule.ayear = serviceregistry.yservreg 
	LEFT OUTER join geo_city as geo_city_conferring(NOLOCK)	
		on geo_city_conferring.idcity = serviceregistry.conferring_idcity
	LEFT OUTER JOIN serviceregistrykind 
		ON serviceregistrykind.idserviceregistrykind = serviceregistry.idserviceregistrykind

GO
