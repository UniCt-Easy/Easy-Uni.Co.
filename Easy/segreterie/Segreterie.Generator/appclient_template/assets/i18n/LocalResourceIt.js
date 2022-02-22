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
	function LocIt() {
		"use strict";
	}

	LocIt.prototype = {
		constructor: LocIt,
		pwdNotMatch: "Attenzione la password non corrisponde",
		compileAllFields: "Compila tutti i campi!",
		waitForTheRegistration: "Registrazione in corso",
		clickOnTheMailToVerifyIdentity: "Prima di procedere con il login conferma la tua identità cliccando sul link che ti abbiamo inviato sulla tua mail!",
		thereWereProblemsWithTheregistration: "C'è stato qualche problema nella registrazione",
		loginRunning: "Login in corso...",
		menuLoading: "Caricamento menù",
		toast_login_success: "Login effettuata correttamente",
		toast_reg_success: "Registrazione avvenuta correttamente",

		scheduler_fields_mandatory_msg1: "Prima di procedere con la schedulazione devi inserire tutte le informazioni necessarie sul tab principale, e i titoli a progetto e workpackage",
		scheduler_fields_mandatory_msg2: "Devi inserire la descrizione e il numero totale di ore",
		scheduler_waitConfigLoading: "Attendi caricamento configurazione",
		scheduler_maxHoursScheduled: "Hai schedulato il numero massimo di ore!",
		scheduler_title: "Configurazione scheduler",
		scheduler_missing_fields: "Devi compilare tutti i campi",
		scheduler_max_hour_to_insert: "Numero massimo di ore da inserire",
		scheduler_running: "Creazione scheduler...",
		scheduler_done: "Scheduler configurato. Premi <strong>Salva</strong> sulla pagina principale per salvare la nuova distribuzione ore",
		schedulerLogMaxHourPerDay: "Per il giorno <strong>S%currday%S</strong> non ci sono abbastanza ore disponibili. " +
			"Il limite giornaliero impostato è pari a <strong>S%maxTotPerDay%S</strong> ore, per la qualifica <strong>S%role%S</strong>. " +
			"Erano già occupate <strong>S%hoursSameDay%S</strong>. Sono state aggiunte solo  <strong>S%hoursToAdd%S</strong> di  <strong>S%hoursWouldAdd%S</strong>",

		schedulerSkypDay: "Per il giorno <strong>S%currday%S</strong> non è stata impostata nessuna ora, poiche" +
			" è stato già raggiunto il massimo numero di <strong>S%maxTotPerDay%S</strong> ore, per la qualifica <strong>S%role%S</strong>.",

		schedulerNoRoleDefined: " <span style='color:red;'>non definita per questo giorno<span>",
		schedulerLastDay: "L'ultimo giorno <strong>S%currday%S</strong> sono state impostate <strong>S%maxTotPerDay%S</strong> ore, rimanenti",
		schedulerTooManyHours : "Configurazione ore terminata correttamente, ma non ho inserito <strong>S%remaininghours%S</strong> ore, poichè la programmazione andrebbe oltre la data fine <strong>S%endDate%S</strong>",

		schedulerSospDay: "Non è stato inserito il giorno <strong>S%currday%S</strong>, poichè è un giorno in cui la didattica è sospesa",
		welcome_lbl_id: 'Benvenuto su app prototipo segreterie! clicca su voce di menù per aprire la MetaPage associata',

		// chiavi per controlli appMain
		menu_search_btn_id: "Cerca",
		menu_info_btn_id: "Info",
		menu_guide_btn_id: "Guida",
		logoutButton: 'Esci',
		loginButton: 'Accedi',
		gotoLogin_id: 'Accedi',
		gotoRegister_id: 'Registrati',

		// stringe custom pagine
		protocolSaveOK: "Registrazione di protocollo generata correttamente",
		protocolSaveNOK: "Ci sono dei problemi nell'assegnazione del protocollo",
		protocolSaveNOSaved: "Devi salvare prima di assegnare il protocollo",

		// lookup condizionali

		// colonne

		// label su html

		// nomi tab

		// lables
		

	};

	appMeta.LocIt = LocIt;
}());


