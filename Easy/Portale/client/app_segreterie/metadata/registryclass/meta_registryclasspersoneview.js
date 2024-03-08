(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryclasspersoneview() {
        MetaData.apply(this, ["registryclasspersoneview"]);
        this.name = 'meta_registryclasspersoneview';
    }

    meta_registryclasspersoneview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryclasspersoneview,
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
					case 'persone':
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'registryclass_active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_persone$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idregistryclass"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registryclasspersoneview', new meta_registryclasspersoneview('registryclasspersoneview'));

	}());
