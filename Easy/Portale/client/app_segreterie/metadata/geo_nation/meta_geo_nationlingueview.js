(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_nationlingueview() {
        MetaData.apply(this, ["geo_nationlingueview"]);
        this.name = 'meta_geo_nationlingueview';
    }

    meta_geo_nationlingueview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_nationlingueview,
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
					case 'lingue':
						this.describeAColumn(table, 'lang', 'Lingua', null, 40, 64);
//$objCalcFieldConfig_lingue$
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
					case "lingue": {
						return "lang asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_nationlingueview', new meta_geo_nationlingueview('geo_nationlingueview'));

	}());
