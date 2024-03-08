(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotimesheetprogetto() {
        MetaData.apply(this, ["progettotimesheetprogetto"]);
        this.name = 'meta_progettotimesheetprogetto';
    }

    meta_progettotimesheetprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotimesheetprogetto,
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
					case 'default':
						this.describeAColumn(table, '!idprogetto_progetto_codiceidentificativo', 'Codice identificativo', null, 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Titolo breve o acronimo', null, 11, null);
						this.describeAColumn(table, '!idprogetto_progettokind_title', 'Tipo di progetto o attività', null, 12, null);
						this.describeAColumn(table, '!idprogetto_progetto_start', 'Data di inizio', null, 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_stop', 'Data di fine', null, 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_datacontabile', 'Data chiusura contablile', null, 10, null);
						this.describeAColumn(table, '!idprogetto_progettostatuskind_title', 'Stato del progetto o attività', null, 11, null);
						this.describeAColumn(table, '!idprogetto_registry_title', 'Principal investigator / Responsabile di progetto ', null, 11, null);
						this.describeAColumn(table, '!idprogetto_registry_title', 'Ente capofila', null, 11, null);
						this.describeAColumn(table, '!idprogetto_progetto_capofilatxt', 'Ente capofila non censito', null, 10, null);
						this.describeAColumn(table, '!idprogetto_registry_title', 'Ente finanziatore', null, 11, null);
						this.describeAColumn(table, '!idprogetto_progetto_finanziatoretxt', 'Ente finanziatore non censito', null, 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_budget', 'Costo totale per l\'ateneo', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_budgetcalcolatodate', 'Calcolato il', 'g', 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_contributoente', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_contributo', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idprogetto_progetto_cup', 'Codice univoco progetto (CUP)', null, 10, null);
						this.describeAColumn(table, '!idprogetto_corsostudio_title', 'Denominazione Didattica', null, 11, null);
						this.describeAColumn(table, '!idprogetto_corsostudio_annoistituz', 'Anno accademico di istituzione Didattica', null, 12, null);
						this.describeAColumn(table, '!idprogetto_currency_codecurrency', 'Codice valuta', null, 11, null);
						objCalcFieldConfig['!idprogetto_progetto_codiceidentificativo'] = { tableNameLookup:'progetto', columnNameLookup:'codiceidentificativo', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progettokind_title'] = { tableNameLookup:'progettokind', columnNameLookup:'title', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_start'] = { tableNameLookup:'progetto', columnNameLookup:'start', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_stop'] = { tableNameLookup:'progetto', columnNameLookup:'stop', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_datacontabile'] = { tableNameLookup:'progetto', columnNameLookup:'datacontabile', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progettostatuskind_title'] = { tableNameLookup:'progettostatuskind', columnNameLookup:'title', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_capofilatxt'] = { tableNameLookup:'progetto', columnNameLookup:'capofilatxt', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_finanziatoretxt'] = { tableNameLookup:'progetto', columnNameLookup:'finanziatoretxt', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_budget'] = { tableNameLookup:'progetto', columnNameLookup:'budget', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_budgetcalcolato'] = { tableNameLookup:'progetto', columnNameLookup:'budgetcalcolato', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_budgetcalcolatodate'] = { tableNameLookup:'progetto', columnNameLookup:'budgetcalcolatodate', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_contributoente'] = { tableNameLookup:'progetto', columnNameLookup:'contributoente', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_contributo'] = { tableNameLookup:'progetto', columnNameLookup:'contributo', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_cup'] = { tableNameLookup:'progetto', columnNameLookup:'cup', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_corsostudio_title'] = { tableNameLookup:'corsostudio', columnNameLookup:'title', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_corsostudio_annoistituz'] = { tableNameLookup:'corsostudio', columnNameLookup:'annoistituz', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_currency_codecurrency'] = { tableNameLookup:'currency', columnNameLookup:'codecurrency', columnNamekey:'idprogetto' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotimesheetprogetto");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('progettotimesheetprogetto', new meta_progettotimesheetprogetto('progettotimesheetprogetto'));

	}());
