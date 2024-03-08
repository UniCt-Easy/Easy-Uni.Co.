(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accreditokinddefaultview() {
        MetaData.apply(this, ["accreditokinddefaultview"]);
        this.name = 'meta_accreditokinddefaultview';
    }

    meta_accreditokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accreditokinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'accreditokind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'accreditokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'accreditokind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaccreditokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('accreditokinddefaultview', new meta_accreditokinddefaultview('accreditokinddefaultview'));

	}());
