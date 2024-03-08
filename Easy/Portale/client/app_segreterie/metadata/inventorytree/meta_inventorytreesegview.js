(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_inventorytreesegview() {
        MetaData.apply(this, ["inventorytreesegview"]);
        this.name = 'meta_inventorytreesegview';
    }

    meta_inventorytreesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_inventorytreesegview,
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
					case 'seg':
						this.describeAColumn(table, 'codeinv', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'inventorytree_description', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'accmotive_codemotive', 'Codice causale di carico', null, 40, 50);
						this.describeAColumn(table, 'accmotive_title', 'Denominazione causale di carico', null, 40, 150);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idinv"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "codeinv asc , inventorytree_description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('inventorytreesegview', new meta_inventorytreesegview('inventorytreesegview'));

	}());
