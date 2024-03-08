(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzasegstuelencoview() {
        MetaData.apply(this, ["istanzasegstuelencoview"]);
        this.name = 'meta_istanzasegstuelencoview';
    }

    meta_istanzasegstuelencoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzasegstuelencoview,
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
					case 'segstuelenco':
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'istanzakind_title', 'Tipologia', null, 60, 50);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 80, 50);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segstuelenco$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idistanza", "paridistanza", "idcorsostudio", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzasegstuelencoview', new meta_istanzasegstuelencoview('istanzasegstuelencoview'));

	}());
