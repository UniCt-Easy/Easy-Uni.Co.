(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_citysegchildview() {
        MetaData.apply(this, ["geo_citysegchildview"]);
        this.name = 'meta_geo_citysegchildview';
    }

    meta_geo_citysegchildview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_citysegchildview,
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
					case 'segchild':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'geo_city_1_title', 'Nuovo comune in cui questo è confluito', null, 40, 65);
						this.describeAColumn(table, 'geo_city_2_title', 'id comune da cui questo è confluito', null, 50, 65);
						this.describeAColumn(table, 'geo_city_start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'geo_city_stop', 'data fine', null, 70, null);
//$objCalcFieldConfig_segchild$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcity"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segchild": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_citysegchildview', new meta_geo_citysegchildview('geo_citysegchildview'));

	}());
