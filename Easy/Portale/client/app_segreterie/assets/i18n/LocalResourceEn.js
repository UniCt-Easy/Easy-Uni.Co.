
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


/**
 * @module LocalResourceEn
 * @description
 * Collection of the localized strings ENGLISH app segreterie
 */
(function () {

    /**
     * @constructor LocalResourceEn
     * @description
     */
    function LocEn() {
        "use strict";
    }

    LocEn.prototype = {
        constructor: LocEn,
        // variabili sul js
        pwdNotMatch: "Attention! password doesn't match",
        compileAllFields : "Fill al the fields!",
        waitForTheRegistration : "Waiting for the registration",
        clickOnTheMailToVerifyIdentity: "First to go ahead confirm your identity clicking on the link that we sent to your email",
        thereWereProblemsWithTheregistration: "Some error occurs in the registration",
        loginRunning: "Wait for the login!",
        menuLoading : "Menù loading",

        // chiavi per controlli appMain
        menu_search_btn_id: "Search",
        menu_info_btn_id: "Info",
        menu_guide_btn_id: "Guide",
        logoutButton: 'Exit',
        loginButton: 'Login',
        gotoLogin_id: 'Login',
        gotoRegister_id: 'Sign up',

		scheduler_fields_mandatory_msg1 : "You have to insert all necessary info on main tab",
		scheduler_fields_mandatory_msg2 : "Insert description and total hour",
		scheduler_waitConfigLoading: "Wait config loading",
		scheduler_maxHoursScheduled : "You scheduled max hours",
		scheduler_title : "Scheduler configuration",
		scheduler_missing_fields : "You have to insert all fields",
		scheduler_max_hour_to_insert : "Max number of hour inserted",
		scheduler_running : "Scheduler running..",
		scheduler_done : "Scheduler configured. Press <strong>Save</strong> on the main page",
		schedulerLogMaxHourPerDay: "The day <strong>S%currday%S</strong> there wasn't enough available hours. On <strong>S%maxTotPerDay%S</strong> of total hours" +
			" you schdueld <strong>S%hoursSameDay%S</strong>, you would have added <strong>S%hoursToAdd%S</strong>",
		schedulerSospDay : "Day <strong>S%currday%S</strong> not scheduled, it was a sospension day",


		welcome_lbl_id: 'Welcome to the prototype of the segreterie. Click on menù item to open a page',

		// conditional lookups
		grid_questionariodomrisp_defaultconditionallookup: "multiplacontxt,S,Yes;multiplacontxt,N,No;",

		// columns
		grid_questionariodomrisp_default_indicerisp: "Sorting",
		grid_questionariodomrisp_default_max: "Maximum numeric value",
		grid_questionariodomrisp_default_min: "Minimum numeric value",
		grid_questionariodomrisp_default_multiplacontxt: "Multiple answer with text field",
		grid_questionariodomrisp_default_punteggio: "Score",
		grid_questionariodomrisp_default_resposta: "Answer",
		grid_questionariodom_default_question: "Question",
		"grid_questionariodom_default_!idquestionariodomkind_questionariodomkind_title": "Type",
		grid_questionariodom_default_indicedom: "Sorting",
		grid_questionario_default_title: "Title",
		grid_questionario_default_description: "Description",
		grid_questionario_default_anonimo: "Anonimo",
		"grid_questionario_default_!idquestionariokind_questionariokind_title": "Type Typology",
		"grid_questionario_default_!idquestionariokind_questionariokind_description": "Type Description",
		grid_questionario_default_questionario_description: "Description",
		grid_questionario_default_questionario_anonimo: "Anonimo",
		grid_questionario_default_questionariokind_title: "Typology Type",
		grid_questionario_default_questionariokind_description: "Type Description",

		// label on html
		questionariodomrisp_default_response: "Answer",
		questionariodomrisp_default_punteggio: "Score",
		questionariodomrisp_default_multiplacontxtYes: "Yes",
		questionariodomrisp_default_multiplacontxtNo: "No",
		questionariodomrisp_default_multiplacontxt: "Multiple answer with text field",
		questionariodomrisp_default_min: "Minimum numeric value",
		questionariodomrisp_default_max: "Maximum numeric value",
		questionariodomrisp_default_indicerisp: "Sorting",
		questionariodom_default_indicedom: "Sorting",
		questionariodom_default_idquestionariodomkind: "Type",
		questionariodom_default_question: "Question",
		questionario_default_idquestionariokind: "Type",
		questionario_default_description: "Description",
		questionario_default_title: "Title",
		questionario_default_anonimoSi: "Yes",
		questionario_default_anonimoNo: "No",
		questionario_default_anonimo: "Anonymous",
		questionariodomrisp_risposta: "Answer",
		questionariodomrisp_punteggio: "Score",
		questionariodomrisp_multiplacontxt: "Multiplacontxt",
		questionariodomrisp_min: "Min",
		questionariodomrisp_max: "Max",
		questionariodomrisp_indicerisp: "Indicerisp",
		questionariodomrisp_indicedom: "Indicedom",
		questionariodom_indicedom: "Indicedom",
		questionariodom_idquestionariodomkind: "Idquestionariodomkind",
		questionariodom_domanda: "Question",
		questionario_idquestionariokind: "Type",
		questionario_anonimo: "Anonymous",
		questionario_description: "Description",
		questionario_title: "Title",

		"grid_titolostudio_docenti_!idistattitolistudio_istattitolistudio_titolo": "ISTAT title",
		grid_titolostudio_docenti_voto: "Vote",
		grid_titolostudio_docenti_votosu: "On",
		grid_titolostudio_docenti_votolode: "Lode",
		grid_titolostudio_docenti_aa: "Accademic year",
		"grid_titolostudio_docenti_!idreg_istituti_registry_title": "Istitute",


		// nomi tab
		"#tabquestionariodom_default_1" : "Answer",
		"#tabquestionariodom_default_0" : "Main",
		"#tabquestionario_default_1" : "Question",
		"#tabquestionario_default_0" : "Main"
    };
    
    appMeta.LocEn = LocEn;
}());


