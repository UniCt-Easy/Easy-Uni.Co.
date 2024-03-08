(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appello() {
        MetaData.apply(this, ["appello"]);
        this.name = 'meta_appello';
    }

    meta_appello.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appello,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'minvoto', 'Voto minimo', null, 140, null);
						this.describeAColumn(table, 'basevoto', 'Votazione di base', null, 150, null);
						this.describeAColumn(table, 'prointermedia', 'Prova intermedia', null, 160, null);
						this.describeAColumn(table, 'posti', 'Numero massimo di posti', null, 170, null);
						this.describeAColumn(table, 'prenotstart', 'Data di inizio prenotazioni', 'g', 180, null);
						this.describeAColumn(table, 'penotend', 'Data fine delle prenotazioni', 'g', 190, null);
						this.describeAColumn(table, 'publicato', 'Publicato', null, 200, null);
//$objCalcFieldConfig_default$
						break;
					case 'erogata':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'minvoto', 'Voto minimo', null, 140, null);
						this.describeAColumn(table, 'basevoto', 'Votazione di base', null, 150, null);
						this.describeAColumn(table, 'prointermedia', 'Prova intermedia', null, 160, null);
						this.describeAColumn(table, 'posti', 'Numero massimo di posti', null, 170, null);
						this.describeAColumn(table, 'prenotstart', 'Data di inizio prenotazioni', 'g', 180, null);
						this.describeAColumn(table, 'penotend', 'Data fine delle prenotazioni', 'g', 190, null);
						this.describeAColumn(table, 'publicato', 'Publicato', null, 200, null);
//$objCalcFieldConfig_erogata$
						break;
					case 'seg':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["basevoto"].caption = "Votazione di base";
						table.columns["cftoend"].caption = "Numero di crediti mancanti alla conclusione della carriera";
						table.columns["description"].caption = "Descrizione";
						table.columns["esteroend"].caption = "Data fine di permanenza dello studente all'estero ";
						table.columns["esterostart"].caption = "Data inizio di permanenza dello studente all'estero ";
						table.columns["idappelloazionekind"].caption = "Ordinario/Correttivo/Integrativo";
						table.columns["idappellokind"].caption = "Tipologia";
						table.columns["idsessione"].caption = "Sessione";
						table.columns["idstudprenotkind"].caption = "Tipologia di studenti per la prenotazione";
						table.columns["lavoratori"].caption = "Studenti lavoratori";
						table.columns["minanniiscr"].caption = "Numero minimo di anni di iscrizione";
						table.columns["minvoto"].caption = "Voto minimo";
						table.columns["passaggio"].caption = "Studenti che hanno eseguito un passaggio di corso";
						table.columns["penotend"].caption = "Data fine delle prenotazioni";
						table.columns["posti"].caption = "Numero massimo di posti";
						table.columns["prenotstart"].caption = "Data di inizio prenotazioni";
						table.columns["prointermedia"].caption = "Prova intermedia";
						table.columns["surmanestop"].caption = "Iniziali cognome fine";
						table.columns["surnamestart"].caption = "Iniziali cognome inizio";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_appello");

				//$getNewRowInside$

				dt.autoIncrement('idappello', { minimum: 99990001 });

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

    window.appMeta.addMeta('appello', new meta_appello('appello'));

	}());
