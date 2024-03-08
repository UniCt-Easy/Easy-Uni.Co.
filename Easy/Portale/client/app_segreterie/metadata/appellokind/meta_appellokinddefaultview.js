(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appellokinddefaultview() {
        MetaData.apply(this, ["appellokinddefaultview"]);
        this.name = 'meta_appellokinddefaultview';
    }

    meta_appellokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appellokinddefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 50);
						this.describeAColumn(table, 'appellokind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'appellokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'appellokind_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idappellokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , appellokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('appellokinddefaultview', new meta_appellokinddefaultview('appellokinddefaultview'));

	}());
