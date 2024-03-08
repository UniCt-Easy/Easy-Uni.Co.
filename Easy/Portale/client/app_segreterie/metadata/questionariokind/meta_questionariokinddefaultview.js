(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_questionariokinddefaultview() {
        MetaData.apply(this, ["questionariokinddefaultview"]);
        this.name = 'meta_questionariokinddefaultview';
    }

    meta_questionariokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_questionariokinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 128);
						this.describeAColumn(table, 'questionariokind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'questionariokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'questionariokind_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idquestionariokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , questionariokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('questionariokinddefaultview', new meta_questionariokinddefaultview('questionariokinddefaultview'));

	}());
