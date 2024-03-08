(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_nationsegchildview() {
        MetaData.apply(this, ["geo_nationsegchildview"]);
        this.name = 'meta_geo_nationsegchildview';
    }

    meta_geo_nationsegchildview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_nationsegchildview,
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
						this.describeAColumn(table, 'geo_nation_lang', 'Lingua', null, 40, 64);
						this.describeAColumn(table, 'geo_nation_1_title', 'Nazione in cui questa è confluita', null, 50, 65);
						this.describeAColumn(table, 'geo_nation_2_title', 'Nazione da cui questa è confluita', null, 60, 65);
						this.describeAColumn(table, 'geo_nation_start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'geo_nation_stop', 'data fine', null, 80, null);
//$objCalcFieldConfig_segchild$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idnation"];
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

    window.appMeta.addMeta('geo_nationsegchildview', new meta_geo_nationsegchildview('geo_nationsegchildview'));

	}());
