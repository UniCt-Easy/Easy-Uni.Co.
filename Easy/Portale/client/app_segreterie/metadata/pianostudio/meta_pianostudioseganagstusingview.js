(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudioseganagstusingview() {
        MetaData.apply(this, ["pianostudioseganagstusingview"]);
        this.name = 'meta_pianostudioseganagstusingview';
    }

    meta_pianostudioseganagstusingview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioseganagstusingview,
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
					case 'seganagstusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'pianostudiostatus_title', 'Status', null, 50, 50);
//$objCalcFieldConfig_seganagstusing$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idiscrizione", "idpianostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function(listType) {
				switch (listType) {
					case "seganagstusing": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudioseganagstusingview', new meta_pianostudioseganagstusingview('pianostudioseganagstusingview'));

	}());
