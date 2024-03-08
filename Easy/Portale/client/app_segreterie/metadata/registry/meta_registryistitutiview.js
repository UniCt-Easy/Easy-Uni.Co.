(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryistitutiview() {
        MetaData.apply(this, ["registryistitutiview"]);
        this.name = 'meta_registryistitutiview';
    }

    meta_registryistitutiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryistitutiview,
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
					case 'istituti':
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 101);
						this.describeAColumn(table, 'registry_istituti_idreg', 'Codice', null, 1000, null);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 2100, 65);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_istituti_codicemiur', 'Codice MIUR', null, 4000, 50);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 5000, 15);
						this.describeAColumn(table, 'istitutokind_tipoistituto', 'Tipologia', null, 5200, 256);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 6000, null);
//$objCalcFieldConfig_istituti$
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
					case "istituti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryistitutiview', new meta_registryistitutiview('registryistitutiview'));

	}());
