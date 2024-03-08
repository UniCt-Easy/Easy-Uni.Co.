(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontaltrokinddefaultview() {
        MetaData.apply(this, ["rendicontaltrokinddefaultview"]);
        this.name = 'meta_rendicontaltrokinddefaultview';
    }

    meta_rendicontaltrokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontaltrokinddefaultview,
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
						this.describeAColumn(table, 'idrendicontaltrokind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 128);
						this.describeAColumn(table, 'rendicontaltrokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'rendicontaltrokind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrendicontaltrokind"];
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

    window.appMeta.addMeta('rendicontaltrokinddefaultview', new meta_rendicontaltrokinddefaultview('rendicontaltrokinddefaultview'));

	}());
