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

		// lookup condizionali

		// colonne

		// label su html

		// nomi tab

		// lables
		
    };
    
    appMeta.LocEn = LocEn;
}());


