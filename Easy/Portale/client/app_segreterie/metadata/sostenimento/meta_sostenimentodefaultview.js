(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentodefaultview() {
        MetaData.apply(this, ["sostenimentodefaultview"]);
        this.name = 'meta_sostenimentodefaultview';
    }

    meta_sostenimentodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentodefaultview,
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
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 20, null);
						this.describeAColumn(table, 'sostenimento_ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'sostenimento_giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 120, 50);
						this.describeAColumn(table, 'sostenimento_livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 230, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idprova", "idappello", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentodefaultview', new meta_sostenimentodefaultview('sostenimentodefaultview'));

	}());
