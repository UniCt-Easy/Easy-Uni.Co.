(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryistitutiesteriview() {
        MetaData.apply(this, ["registryistitutiesteriview"]);
        this.name = 'meta_registryistitutiesteriview';
    }

    meta_registryistitutiesteriview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryistitutiesteriview,
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
					case 'istitutiesteri':
						this.describeAColumn(table, 'registry_istitutiesteri_idreg', 'Identificativo', null, 1000, null);
						this.describeAColumn(table, 'registry_istitutiesteri_name', 'Name', null, 2000, 1024);
						this.describeAColumn(table, 'title', 'Denominazione', null, 3000, 101);
						this.describeAColumn(table, 'registry_istitutiesteri_city', 'City', null, 3000, 255);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_istitutiesteri_code', 'Code', null, 4000, 50);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 5000, 15);
						this.describeAColumn(table, 'registry_istitutiesteri_institutionalcode', 'Institutional code', null, 5000, 50);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 6000, null);
						this.describeAColumn(table, 'registry_istitutiesteri_referencenumber', 'Reference number', null, 6000, 50);
						this.describeAColumn(table, 'geo_city_title', 'Città', null, 7100, 65);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 8300, 65);
//$objCalcFieldConfig_istitutiesteri$
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
					case "istitutiesteri": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryistitutiesteriview', new meta_registryistitutiesteriview('registryistitutiesteriview'));

	}());
