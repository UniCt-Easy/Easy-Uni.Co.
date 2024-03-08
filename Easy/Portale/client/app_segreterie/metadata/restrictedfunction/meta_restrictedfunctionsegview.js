(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_restrictedfunctionsegview() {
        MetaData.apply(this, ["restrictedfunctionsegview"]);
        this.name = 'meta_restrictedfunctionsegview';
    }

    meta_restrictedfunctionsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_restrictedfunctionsegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 100);
						this.describeAColumn(table, 'restrictedfunction_variablename', 'Variabile', null, 30, 50);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrestrictedfunction"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('restrictedfunctionsegview', new meta_restrictedfunctionsegview('restrictedfunctionsegview'));

	}());
