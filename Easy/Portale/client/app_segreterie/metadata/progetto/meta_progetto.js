(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progetto() {
        MetaData.apply(this, ["progetto"]);
        this.name = 'meta_progetto';
    }

    meta_progetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progetto,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seg':
						this.describeAColumn(table, 'idprogetto', 'Codice interno', null, 10, null);
						this.describeAColumn(table, 'titolobreve', 'Titolo breve o acronimo', null, 50, 2048);
						this.describeAColumn(table, 'finanziatoretxt', 'Ente finanziatore non censito', null, 180, 2048);
						this.describeAColumn(table, 'cup', 'Codice univoco progetto (CUP)', null, 210, 15);
						this.describeAColumn(table, 'codiceidentificativo', 'Codice attribuito dall\'ente finanziatore', null, 220, 2048);
						this.describeAColumn(table, 'capofilatxt', 'Ente capofila non censito', null, 260, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 300, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 310, null);
						this.describeAColumn(table, 'datacontabile', 'Data chiusura contablile', null, 330, null);
						this.describeAColumn(table, 'budget', 'Costo totale per l\'ateneo', 'fixed.2', 410, null);
						this.describeAColumn(table, 'contributoente', 'Contributo totale ottenuto per l\'ateneo dall’ente finanziatore', 'fixed.2', 420, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento ottenuto dall\'ateneo', 'fixed.2', 430, null);
						this.describeAColumn(table, 'budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 450, null);
						this.describeAColumn(table, 'budgetcalcolatodate', 'Calcolato il', 'g', 460, null);
						this.describeAColumn(table, 'contributoenterichiesto', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 700, null);
						this.describeAColumn(table, 'contributorichiesto', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 710, null);
//$objCalcFieldConfig_seg$
						break;
					case 'catania':
						this.describeAColumn(table, '!datafine', 'Data fine', null, 0, null);
						this.describeAColumn(table, '!datainizio', 'Data inizio', null, 0, null);
						this.describeAColumn(table, '!idreg', 'Membro dell\'unità di ricerca', null, 0, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto', 'Attività', null, 0, null);
						this.describeAColumn(table, 'titolobreve', 'Titolo breve o acronimo', null, 50, 2048);
						this.describeAColumn(table, 'finanziatoretxt', 'Ente finanziatore non censito', null, 180, 2048);
						this.describeAColumn(table, 'cup', 'Codice univoco progetto (CUP)', null, 200, 15);
						this.describeAColumn(table, 'ulteriorecup', 'Ulteriore CUP', null, 210, 15);
						this.describeAColumn(table, 'codiceidentificativo', 'Codice attribuito dall\'ente finanziatore', null, 220, 2048);
						this.describeAColumn(table, 'respscientifici', 'Responsabili scientifici', null, 230, 4000);
						this.describeAColumn(table, 'respamministrativi', 'Responsabili amministrativi', null, 240, 4000);
						this.describeAColumn(table, 'responsabiliscientifici', 'Referenti scientifici', null, 250, 4000);
						this.describeAColumn(table, 'responsabiliamministrativi', 'Referenti amministrativi', null, 260, 4000);
						this.describeAColumn(table, 'capofilatxt', 'Ente capofila non censito', null, 280, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 300, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 310, null);
						this.describeAColumn(table, 'datacontabile', 'Data chiusura contablile', null, 330, null);
						this.describeAColumn(table, 'budget', 'Costo/budget dell\'ateneo proposto', 'fixed.2', 400, null);
						this.describeAColumn(table, 'contributoenterichiesto', 'Di cui contributo totale richiesto dall’ateneo all’ente finanziatore', 'fixed.2', 410, null);
						this.describeAColumn(table, 'contributorichiesto', 'Di cui cofinanziamento proposto', 'fixed.2', 420, null);
						this.describeAColumn(table, 'totalbudget', 'Preventivato', 'fixed.2', 430, null);
						this.describeAColumn(table, 'totalcontributo', 'Approvato', 'fixed.2', 440, null);
						this.describeAColumn(table, 'costoapprovatoateneo', 'Costo/budget dell\'ateneo approvato', 'fixed.2', 450, null);
						this.describeAColumn(table, 'costoapprovatoateneocalcolato', 'Costo/budget dell\'ateneo approvato calcolato', 'fixed.2', 460, null);
						this.describeAColumn(table, 'contributoente', 'Contributo all’ateneo approvato dall’ente finanziatore', 'fixed.2', 470, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento approvato', 'fixed.2', 480, null);
						this.describeAColumn(table, 'budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 490, null);
						this.describeAColumn(table, 'budgetcalcolatodate', 'Calcolato il', 'g', 500, null);
						this.describeAColumn(table, 'unitaorganizzativa', 'Unità Organizzative', null, 720, 4000);
//$objCalcFieldConfig_catania$
						break;
					case 'elenchi':
						this.describeAColumn(table, 'titolobreve', 'Titolo breve o acronimo', null, 10, 2048);
						this.describeAColumn(table, 'idprogetto', 'Codice interno', null, 20, null);
						this.describeAColumn(table, 'finanziatoretxt', 'Ente finanziatore non censito', null, 180, 2048);
						this.describeAColumn(table, 'cup', 'Codice univoco progetto (CUP)', null, 210, 15);
						this.describeAColumn(table, 'codiceidentificativo', 'Codice attribuito dall\'ente finanziatore', null, 220, 2048);
						this.describeAColumn(table, 'capofilatxt', 'Ente capofila non censito', null, 260, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 300, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 310, null);
						this.describeAColumn(table, 'datacontabile', 'Data chiusura contablile', null, 330, null);
						this.describeAColumn(table, 'budget', 'Costo totale per l\'ateneo', 'fixed.2', 410, null);
						this.describeAColumn(table, 'contributoente', 'Contributo totale ottenuto per l\'ateneo dall’ente finanziatore', 'fixed.2', 420, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento ottenuto dall\'ateneo', 'fixed.2', 430, null);
						this.describeAColumn(table, 'budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 450, null);
						this.describeAColumn(table, 'budgetcalcolatodate', 'Calcolato il', 'g', 460, null);
						this.describeAColumn(table, 'contributoenterichiesto', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 700, null);
						this.describeAColumn(table, 'contributorichiesto', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 710, null);
//$objCalcFieldConfig_elenchi$
						break;
					case 'griglie':
						this.describeAColumn(table, 'idprogetto', 'Codice interno', null, 10, null);
						this.describeAColumn(table, 'titolobreve', 'Titolo breve o acronimo', null, 50, 2048);
						this.describeAColumn(table, 'finanziatoretxt', 'Ente finanziatore non censito', null, 180, 2048);
						this.describeAColumn(table, 'cup', 'Codice univoco progetto (CUP)', null, 210, 15);
						this.describeAColumn(table, 'codiceidentificativo', 'Codice attribuito dall\'ente finanziatore', null, 220, 2048);
						this.describeAColumn(table, 'capofilatxt', 'Ente capofila non censito', null, 260, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 300, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 310, null);
						this.describeAColumn(table, 'datacontabile', 'Data chiusura contablile', null, 330, null);
						this.describeAColumn(table, 'budget', 'Costo totale per l\'ateneo', 'fixed.2', 410, null);
						this.describeAColumn(table, 'contributoente', 'Contributo totale ottenuto per l\'ateneo dall’ente finanziatore', 'fixed.2', 420, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento ottenuto dall\'ateneo', 'fixed.2', 430, null);
						this.describeAColumn(table, 'budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 450, null);
						this.describeAColumn(table, 'budgetcalcolatodate', 'Calcolato il', 'g', 460, null);
						this.describeAColumn(table, 'contributoenterichiesto', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 700, null);
						this.describeAColumn(table, 'contributorichiesto', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 710, null);
						this.describeAColumn(table, '!idcorsostudio_corsostudio_title', 'Denominazione Didattica', null, 511, null);
						this.describeAColumn(table, '!idcorsostudio_corsostudio_annoistituz', 'Anno accademico di istituzione Didattica', null, 512, null);
						objCalcFieldConfig['!idcorsostudio_corsostudio_title'] = { tableNameLookup:'corsostudio', columnNameLookup:'title', columnNamekey:'idcorsostudio' };
						objCalcFieldConfig['!idcorsostudio_corsostudio_annoistituz'] = { tableNameLookup:'corsostudio', columnNameLookup:'annoistituz', columnNamekey:'idcorsostudio' };
						this.describeAColumn(table, '!idpartnerkind_partnerkind_title', 'Ruolo dell\'ateneo', null, 271, null);
						objCalcFieldConfig['!idpartnerkind_partnerkind_title'] = { tableNameLookup:'partnerkind', columnNameLookup:'title', columnNamekey:'idpartnerkind' };
						this.describeAColumn(table, '!idprogettokind_progettokind_title', 'Modello di progetto', null, 172, null);
						objCalcFieldConfig['!idprogettokind_progettokind_title'] = { tableNameLookup:'progettokind', columnNameLookup:'title', columnNamekey:'idprogettokind' };
						this.describeAColumn(table, '!idprogettostatuskind_progettostatuskind_title', 'Stato del progetto o attività', null, 21, null);
						objCalcFieldConfig['!idprogettostatuskind_progettostatuskind_title'] = { tableNameLookup:'progettostatuskind', columnNameLookup:'title', columnNamekey:'idprogettostatuskind' };
						this.describeAColumn(table, '!idreg_registry_title', 'Principal investigator / Responsabile scientifico', null, 241, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idreg_amm_registry_surname', 'Cognome Responsabile amministrativo', null, 232, null);
						this.describeAColumn(table, '!idreg_amm_registry_forename', 'Nome Responsabile amministrativo', null, 233, null);
						this.describeAColumn(table, '!idreg_amm_registry_cf', 'Codice fiscale Responsabile amministrativo', null, 234, null);
						this.describeAColumn(table, '!idreg_amm_registry_idtitle_description', 'Titolo Responsabile amministrativo', null, 230, null);
						objCalcFieldConfig['!idreg_amm_registry_surname'] = { tableNameLookup:'registry_alias1', columnNameLookup:'surname', columnNamekey:'idreg_amm' };
						objCalcFieldConfig['!idreg_amm_registry_forename'] = { tableNameLookup:'registry_alias1', columnNameLookup:'forename', columnNamekey:'idreg_amm' };
						objCalcFieldConfig['!idreg_amm_registry_cf'] = { tableNameLookup:'registry_alias1', columnNameLookup:'cf', columnNamekey:'idreg_amm' };
						objCalcFieldConfig['!idreg_amm_registry_idtitle_description'] = { tableNameLookup:'title', columnNameLookup:'description', columnNamekey:'idreg_amm' };
						this.describeAColumn(table, '!idreg_aziende_registry_title', 'Ente capofila', null, 251, null);
						objCalcFieldConfig['!idreg_aziende_registry_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						this.describeAColumn(table, '!idreg_aziende_fin_registry_title', 'Ente finanziatore', null, 101, null);
						objCalcFieldConfig['!idreg_aziende_fin_registry_title'] = { tableNameLookup:'registry_alias4', columnNameLookup:'title', columnNamekey:'idreg_aziende_fin' };
						this.describeAColumn(table, '!idstrumentofin_strumentofin_title', 'Strumento di finanziamento', null, 161, null);
						objCalcFieldConfig['!idstrumentofin_strumentofin_title'] = { tableNameLookup:'strumentofin', columnNameLookup:'title', columnNamekey:'idstrumentofin' };
//$objCalcFieldConfig_griglie$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["!altreupb"].caption = "Cerca anche cespiti di altre UPB ";
						table.columns["!filtraAsset"].caption = "Filtro per la ricerca dei cespiti";
						table.columns["bandoriferimentotxt"].caption = "Bando di riferimento non censito";
						table.columns["budget"].caption = "Costo totale per l'ateneo";
						table.columns["budgetcalcolato"].caption = "Costo totale effettivo per l'ateneo";
						table.columns["budgetcalcolatodate"].caption = "Calcolato il";
						table.columns["capofilatxt"].caption = "Ente capofila non censito";
						table.columns["codiceidentificativo"].caption = "Codice attribuito dall'ente finanziatore";
						table.columns["contributo"].caption = "Cofinanziamento ottenuto dall'ateneo";
						table.columns["contributoente"].caption = "Contributo totale ottenuto per l'ateneo dall’ente finanziatore";
						table.columns["contributoenterichiesto"].caption = "Contributo totale richiesto dall'ateneo all’ente finanziatore";
						table.columns["contributorichiesto"].caption = "Cofinanziamento richiesto all'ateneo";
						table.columns["cup"].caption = "Codice univoco progetto (CUP)";
						table.columns["data"].caption = "Data di presentazione";
						table.columns["datacontabile"].caption = "Data chiusura contablile";
						table.columns["dataesito"].caption = "Data dell’esito di valutazione";
						table.columns["description"].caption = "Descrizione / Abstract";
						table.columns["finanziamento"].caption = "Riferimenti del finanziamento";
						table.columns["finanziatoretxt"].caption = "Ente finanziatore non censito";
						table.columns["idcorsostudio"].caption = "Didattica";
						table.columns["idcurrency"].caption = "Codice valuta";
						table.columns["idduratakind"].caption = "Espressa in";
						table.columns["idpartnerkind"].caption = "Ruolo dell'ateneo";
						table.columns["idprogetto"].caption = "Codice interno";
						table.columns["idprogettokind"].caption = "Modello di progetto";
						table.columns["idprogettostatuskind"].caption = "Stato del progetto o attività";
						table.columns["idreg"].caption = "Principal investigator / Responsabile scientifico";
						table.columns["idreg_amm"].caption = "Responsabile amministrativo";
						table.columns["idreg_aziende"].caption = "Ente capofila";
						table.columns["idreg_aziende_fin"].caption = "Ente finanziatore";
						table.columns["idregistryprogfin"].caption = "Programma di finanziamento";
						table.columns["idregistryprogfinbando"].caption = "Bando di riferimento";
						table.columns["idstrumentofin"].caption = "Strumento di finanziamento";
						table.columns["progfinanziamentotxt"].caption = "Programma di riferimento non censito";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
						table.columns["title"].caption = "Titolo";
						table.columns["title_en"].caption = "Titolo in inglese";
						table.columns["titolobreve"].caption = "Titolo breve o acronimo";
						table.columns["totalbudget"].caption = "Costo totale del progetto per tutto il partenariato";
						table.columns["totalcontributo"].caption = "Contributo globale del progetto per tutto il partenariato";
						table.columns["url"].caption = "URL del sito del progetto";
//$innerSetCaptionConfig_seg$
						break;
					case 'catania':
						table.columns["!datafine"].caption = "Data fine";
						table.columns["!datainizio"].caption = "Data inizio";
						table.columns["!idreg"].caption = "Membro dell'unità di ricerca";
						table.columns["!idrendicontattivitaprogetto"].caption = "Attività";
						table.columns["budget"].caption = "Costo/budget dell'ateneo proposto";
						table.columns["contributo"].caption = "Cofinanziamento approvato";
						table.columns["contributoente"].caption = "Contributo all’ateneo approvato dall’ente finanziatore";
						table.columns["contributoenterichiesto"].caption = "Di cui contributo totale richiesto dall’ateneo all’ente finanziatore";
						table.columns["contributorichiesto"].caption = "Di cui cofinanziamento proposto";
						table.columns["costoapprovatoateneo"].caption = "Costo/budget dell'ateneo approvato";
						table.columns["costoapprovatoateneocalcolato"].caption = "Costo/budget dell'ateneo approvato calcolato";
						table.columns["idreg"].caption = "Principal investigator / Referente scientifico";
						table.columns["idreg_amm"].caption = "Referente amministrativo";
						table.columns["respamministrativi"].caption = "Responsabili amministrativi";
						table.columns["responsabiliamministrativi"].caption = "Referenti amministrativi";
						table.columns["responsabiliscientifici"].caption = "Referenti scientifici";
						table.columns["respscientifici"].caption = "Responsabili scientifici";
						table.columns["totalbudget"].caption = "Preventivato";
						table.columns["totalcontributo"].caption = "Approvato";
						table.columns["ulteriorecup"].caption = "Ulteriore CUP";
						table.columns["unitaorganizzativa"].caption = "Unità Organizzative";
//$innerSetCaptionConfig_catania$
						break;
					case 'elenchi':
//$innerSetCaptionConfig_elenchi$
						break;
					case 'griglie':
//$innerSetCaptionConfig_griglie$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progetto");

				//$getNewRowInside$

				dt.autoIncrement('idprogetto', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "titolobreve asc ";
					}
					case "catania": {
						return "titolobreve asc ";
					}
					case "elenchi": {
						return "titolobreve asc ";
					}
					case "griglie": {
						return "titolobreve asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progetto', new meta_progetto('progetto'));

	}());
