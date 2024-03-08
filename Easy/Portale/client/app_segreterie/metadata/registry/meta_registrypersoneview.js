(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrypersoneview() {
        MetaData.apply(this, ["registrypersoneview"]);
        this.name = 'meta_registrypersoneview';
    }

    meta_registrypersoneview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrypersoneview,
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
					case 'persone':
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 10, 40);
						this.describeAColumn(table, 'registry_title', 'Cognome Nome', null, 20, 101);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 40, 15);
//$objCalcFieldConfig_persone$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "persone": {
						return "registry_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('registrypersoneview', new meta_registrypersoneview('registrypersoneview'));

	}());
