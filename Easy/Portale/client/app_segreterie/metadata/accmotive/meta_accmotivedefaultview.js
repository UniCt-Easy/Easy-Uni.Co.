(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accmotivedefaultview() {
        MetaData.apply(this, ["accmotivedefaultview"]);
        this.name = 'meta_accmotivedefaultview';
    }

    meta_accmotivedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accmotivedefaultview,
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
						this.describeAColumn(table, 'codemotive', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'accmotive_title', 'Denominazione', null, 20, 150);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaccmotive"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "codemotive asc , accmotive_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('accmotivedefaultview', new meta_accmotivedefaultview('accmotivedefaultview'));

	}());
