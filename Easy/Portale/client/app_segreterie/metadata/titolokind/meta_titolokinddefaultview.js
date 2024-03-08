(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_titolokinddefaultview() {
        MetaData.apply(this, ["titolokinddefaultview"]);
        this.name = 'meta_titolokinddefaultview';
    }

    meta_titolokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_titolokinddefaultview,
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
						this.describeAColumn(table, 'titolokind_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'titolokind_sortcode', 'Ordinamento', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtitolokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "titolokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('titolokinddefaultview', new meta_titolokinddefaultview('titolokinddefaultview'));

	}());
