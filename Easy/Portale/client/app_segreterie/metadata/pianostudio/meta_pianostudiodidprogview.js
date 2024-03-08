(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudiodidprogview() {
        MetaData.apply(this, ["pianostudiodidprogview"]);
        this.name = 'meta_pianostudiodidprogview';
    }

    meta_pianostudiodidprogview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudiodidprogview,
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
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'pianostudiostatus_title', 'Status', null, 50, 50);
//$objCalcFieldConfig_didprog$
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
					case "didprog": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudiodidprogview', new meta_pianostudiodidprogview('pianostudiodidprogview'));

	}());
