(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrydefaultview() {
        MetaData.apply(this, ["registrydefaultview"]);
        this.name = 'meta_registrydefaultview';
    }

    meta_registrydefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrydefaultview,
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
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'registryclass_description', 'Tipologia', null, 20, 150);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 60, null);
//$objCalcFieldConfig_default$
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
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrydefaultview', new meta_registrydefaultview('registrydefaultview'));

	}());
