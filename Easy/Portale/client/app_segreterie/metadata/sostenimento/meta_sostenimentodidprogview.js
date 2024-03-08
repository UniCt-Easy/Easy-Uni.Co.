(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentodidprogview() {
        MetaData.apply(this, ["sostenimentodidprogview"]);
        this.name = 'meta_sostenimentodidprogview';
    }

    meta_sostenimentodidprogview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentodidprogview,
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
					case 'didprog':
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 20, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 120, 50);
						this.describeAColumn(table, 'sostenimento_livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'sostenimento_giudizio', 'Giudizio', null, 240, 50);
//$objCalcFieldConfig_didprog$
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

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentodidprogview', new meta_sostenimentodidprogview('sostenimentodidprogview'));

	}());
