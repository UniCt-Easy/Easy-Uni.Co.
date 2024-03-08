(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettodefaultview() {
        MetaData.apply(this, ["perfprogettodefaultview"]);
        this.name = 'meta_perfprogettodefaultview';
    }

    meta_perfprogettodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettodefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'struttura_title', 'Denominazione Unità organizzativa', null, 1100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Unità organizzativa', null, 1220, 50);
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 1024);
						this.describeAColumn(table, 'perfprogetto_description', 'Descrizione', null, 3000, -1);
						this.describeAColumn(table, 'perfprogetto_datainizioprevista', 'Data inizio prevista', 'g', 4000, null);
						this.describeAColumn(table, 'perfprogetto_datafineprevista', 'Data fine prevista', 'g', 5000, null);
						this.describeAColumn(table, 'perfprogetto_datainizioeffettiva', 'Data inizio effettiva', 'g', 6000, null);
						this.describeAColumn(table, 'perfprogetto_datafineeffettiva', 'Data fine effettiva', 'g', 7000, null);
						this.describeAColumn(table, 'perfprogetto_risultato', 'Percentuale di completamento', 'fixed.2', 8000, null);
						this.describeAColumn(table, 'perfprogetto_note', 'Note', null, 9000, -1);
						this.describeAColumn(table, 'perfprogettostatus_title', 'Stato', null, 9200, 1024);
						this.describeAColumn(table, 'didprogsuddannokind_title', 'Frequenza monitoraggi', null, 10200, 50);
						this.describeAColumn(table, 'perfprogetto_benefici', 'Benefici attesi', null, 11000, -1);
						this.describeAColumn(table, 'registryrespprogetto_title', 'Responsabile', null, 18300, 101);
						this.describeAColumn(table, 'attach_filename', 'Relazione finale del progetto', null, 19300, 512);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogetto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettodefaultview', new meta_perfprogettodefaultview('perfprogettodefaultview'));

	}());
