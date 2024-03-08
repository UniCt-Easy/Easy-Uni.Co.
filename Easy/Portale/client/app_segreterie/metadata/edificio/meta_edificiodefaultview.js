(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_edificiodefaultview() {
        MetaData.apply(this, ["edificiodefaultview"]);
        this.name = 'meta_edificiodefaultview';
    }

    meta_edificiodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_edificiodefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 20, 1024);
						this.describeAColumn(table, 'edificio_address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'edificio_cap', 'CAP', null, 40, 20);
						this.describeAColumn(table, 'edificio_code', 'Codice', null, 50, 128);
						this.describeAColumn(table, 'geo_city_title', 'Città', null, 60, 65);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 70, 65);
						this.describeAColumn(table, 'edificio_location', 'Località', null, 100, 20);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsede", "idedificio"];
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

    window.appMeta.addMeta('edificiodefaultview', new meta_edificiodefaultview('edificiodefaultview'));

	}());
