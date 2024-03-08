(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudioseganagstuview() {
        MetaData.apply(this, ["pianostudioseganagstuview"]);
        this.name = 'meta_pianostudioseganagstuview';
    }

    meta_pianostudioseganagstuview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioseganagstuview,
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
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'pianostudiostatus_title', 'Status', null, 50, 50);
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio", "idpianostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function(listType) {
				switch (listType) {
					case "seganagstu": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudioseganagstuview', new meta_pianostudioseganagstuview('pianostudioseganagstuview'));

	}());
