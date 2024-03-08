(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tesikinddefaultview() {
        MetaData.apply(this, ["tesikinddefaultview"]);
        this.name = 'meta_tesikinddefaultview';
    }

    meta_tesikinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tesikinddefaultview,
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
						this.describeAColumn(table, 'tesikind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'tesikind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'tesikind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtesikind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, tesikind_sortcode asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tesikinddefaultview', new meta_tesikinddefaultview('tesikinddefaultview'));

	}());
