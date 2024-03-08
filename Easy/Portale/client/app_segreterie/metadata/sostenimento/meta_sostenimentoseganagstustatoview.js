(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentoseganagstustatoview() {
        MetaData.apply(this, ["sostenimentoseganagstustatoview"]);
        this.name = 'meta_sostenimentoseganagstustatoview';
    }

    meta_sostenimentoseganagstustatoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentoseganagstustatoview,
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
					case 'seganagstustato':
						this.describeAColumn(table, 'registry_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 20, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 120, 50);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 230, null);
//$objCalcFieldConfig_seganagstustato$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idprova", "iddidprog", "idiscrizione", "idcorsostudio", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentoseganagstustatoview', new meta_sostenimentoseganagstustatoview('sostenimentoseganagstustatoview'));

	}());
