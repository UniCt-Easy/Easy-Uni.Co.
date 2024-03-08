(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sedeseg_childview() {
        MetaData.apply(this, ["sedeseg_childview"]);
        this.name = 'meta_sedeseg_childview';
    }

    meta_sedeseg_childview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sedeseg_childview,
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
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'sede_idsedemiur', 'Identificativo MIUR', null, 20, null);
						this.describeAColumn(table, 'sede_address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'sede_cap', 'CAP', null, 50, 20);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 60, 65);
//$objCalcFieldConfig_seg_child$
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
					case "seg_child": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sedeseg_childview', new meta_sedeseg_childview('sedeseg_childview'));

	}());
