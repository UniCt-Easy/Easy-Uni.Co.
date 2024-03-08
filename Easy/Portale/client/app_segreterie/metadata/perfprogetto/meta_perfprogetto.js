(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogetto() {
        MetaData.apply(this, ["perfprogetto"]);
        this.name = 'meta_perfprogetto';
    }

    meta_perfprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogetto,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 40, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 50, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 60, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 70, null);
						this.describeAColumn(table, 'risultato', 'Percentuale di completamento', 'fixed.2', 80, null);
						this.describeAColumn(table, 'note', 'Note', null, 90, -1);
						this.describeAColumn(table, 'benefici', 'Benefici attesi', null, 110, -1);
//$objCalcFieldConfig_default$
						break;
					case 'responsabili':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 40, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 50, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 60, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 70, null);
						this.describeAColumn(table, 'risultato', 'Percentuale di completamento', 'fixed.2', 80, null);
						this.describeAColumn(table, 'note', 'Note', null, 90, -1);
						this.describeAColumn(table, 'benefici', 'Benefici attesi', null, 110, -1);
//$objCalcFieldConfig_responsabili$
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
						table.columns["benefici"].caption = "Benefici attesi";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idattach"].caption = "Relazione finale del progetto";
						table.columns["iddidprogsuddannokind"].caption = "Frequenza monitoraggi";
						table.columns["idperfprogettostatus"].caption = "Stato";
						table.columns["idreg_respprogetto"].caption = "Responsabile";
						table.columns["idstruttura"].caption = "Unità organizzativa";
						table.columns["note"].caption = "Note";
						table.columns["risultato"].caption = "Percentuale di completamento";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
					case 'responsabili':
//$innerSetCaptionConfig_responsabili$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogetto");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogetto', { minimum: 99990001 });

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
					case "default": {
						return "title desc";
					}
					case "responsabili": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogetto', new meta_perfprogetto('perfprogetto'));

	}());
