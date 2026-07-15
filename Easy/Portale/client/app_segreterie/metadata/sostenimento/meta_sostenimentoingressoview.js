(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentoingressoview() {
        MetaData.apply(this, ["sostenimentoingressoview"]);
        this.name = 'meta_sostenimentoingressoview';
    }

    meta_sostenimentoingressoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentoingressoview,
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
					case 'ingresso':
						this.describeAColumn(table, 'registry_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 2000, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 12200, 50);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 20000, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 22000, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 23000, null);
//$objCalcFieldConfig_ingresso$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idprova", "iddidprog", "idcorsostudio", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentoingressoview', new meta_sostenimentoingressoview('sostenimentoingressoview'));

	}());
