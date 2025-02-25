(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentoseganagstuview() {
        MetaData.apply(this, ["sostenimentoseganagstuview"]);
        this.name = 'meta_sostenimentoseganagstuview';
    }

    meta_sostenimentoseganagstuview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentoseganagstuview,
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
					case 'seganagstu':
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 2000, null);
						this.describeAColumn(table, 'attivform_title', 'Attività formativa', null, 9100, -1);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 12200, 50);
						this.describeAColumn(table, 'sostenimento_livello', 'Livello', null, 16000, null);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 20000, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 22000, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 23000, null);
						this.describeAColumn(table, 'sostenimento_giudizio', 'Giudizio', null, 24000, 50);
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seganagstu": {
						return "sostenimento_data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sostenimentoseganagstuview', new meta_sostenimentoseganagstuview('sostenimentoseganagstuview'));

	}());
