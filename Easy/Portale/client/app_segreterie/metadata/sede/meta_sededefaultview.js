(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sededefaultview() {
        MetaData.apply(this, ["sededefaultview"]);
        this.name = 'meta_sededefaultview';
    }

    meta_sededefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sededefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'sede_idsedemiur', 'Identificativo MIUR', null, 30, null);
						this.describeAColumn(table, 'sede_address', 'Indirizzo', null, 40, 100);
						this.describeAColumn(table, 'sede_cap', 'CAP', null, 50, 20);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 60, 65);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsede"];
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

    window.appMeta.addMeta('sededefaultview', new meta_sededefaultview('sededefaultview'));

	}());
