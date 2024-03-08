(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ratakinddefaultview() {
        MetaData.apply(this, ["ratakinddefaultview"]);
        this.name = 'meta_ratakinddefaultview';
    }

    meta_ratakinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ratakinddefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 50);
						this.describeAColumn(table, 'ratakind_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'ratakind_sortcode', 'Sortcode', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idratakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('ratakinddefaultview', new meta_ratakinddefaultview('ratakinddefaultview'));

	}());
