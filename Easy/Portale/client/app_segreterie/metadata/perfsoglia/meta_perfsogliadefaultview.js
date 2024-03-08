(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfsogliadefaultview() {
        MetaData.apply(this, ["perfsogliadefaultview"]);
        this.name = 'meta_perfsogliadefaultview';
    }

    meta_perfsogliadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfsogliadefaultview,
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
					case 'default':
						this.describeAColumn(table, 'idperfsogliakind', 'Tipo', null, 3000, 50);
						this.describeAColumn(table, 'perfsoglia_valore', 'Percentuale di default', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'year', 'Anno solare', null, 5000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfsoglia"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "perfsoglia_valore asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfsogliadefaultview', new meta_perfsogliadefaultview('perfsogliadefaultview'));

	}());
