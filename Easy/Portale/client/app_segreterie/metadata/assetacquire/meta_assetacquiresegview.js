(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assetacquiresegview() {
        MetaData.apply(this, ["assetacquiresegview"]);
        this.name = 'meta_assetacquiresegview';
    }

    meta_assetacquiresegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetacquiresegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 150);
						this.describeAColumn(table, 'inventorytree_codeinv', 'Codice Class. Inv.', null, 20, 50);
						this.describeAColumn(table, 'inventorytree_description', 'Denominazione Class. Inv.', null, 20, 150);
						this.describeAColumn(table, 'upb_title', 'UPB', null, 30, 150);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["nassetacquire"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetacquiresegview', new meta_assetacquiresegview('assetacquiresegview'));

	}());
