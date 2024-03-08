(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_saldefaultview() {
        MetaData.apply(this, ["saldefaultview"]);
        this.name = 'meta_saldefaultview';
    }

    meta_saldefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_saldefaultview,
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
						this.describeAColumn(table, 'start', 'Data di inizio', null, 1000, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine', null, 4000, null);
						this.describeAColumn(table, 'sal_budget', 'Budget preventivato', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'sal_datablocco', 'Data di Blocco', null, 7000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsal", "idprogetto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('saldefaultview', new meta_saldefaultview('saldefaultview'));

	}());
