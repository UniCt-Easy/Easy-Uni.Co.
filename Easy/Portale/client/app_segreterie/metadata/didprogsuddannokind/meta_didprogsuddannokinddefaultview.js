(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogsuddannokinddefaultview() {
        MetaData.apply(this, ["didprogsuddannokinddefaultview"]);
        this.name = 'meta_didprogsuddannokinddefaultview';
    }

    meta_didprogsuddannokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogsuddannokinddefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'didprogsuddannokind_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'didprogsuddannokind_sortcode', 'Ordinamento', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprogsuddannokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "didprogsuddannokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('didprogsuddannokinddefaultview', new meta_didprogsuddannokinddefaultview('didprogsuddannokinddefaultview'));

	}());
