(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_regionsegview() {
        MetaData.apply(this, ["geo_regionsegview"]);
        this.name = 'meta_geo_regionsegview';
    }

    meta_geo_regionsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_regionsegview,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 20, 65);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idregion"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_regionsegview', new meta_geo_regionsegview('geo_regionsegview'));

	}());
