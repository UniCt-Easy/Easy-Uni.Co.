(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assetsegview() {
        MetaData.apply(this, ["assetsegview"]);
        this.name = 'meta_assetsegview';
    }

    meta_assetsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetsegview,
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
						this.describeAColumn(table, 'inventory_description', 'Inventario', null, 10, 50);
						this.describeAColumn(table, 'asset_ninventory', 'Numero inventario', null, 20, null);
						this.describeAColumn(table, 'idasset', 'Identificativo', null, 30, null);
						this.describeAColumn(table, 'idpiece', 'Numero parte', null, 40, null);
						this.describeAColumn(table, 'assetacquire_description', 'Descrizione Descrizione', null, 50, 150);
						this.describeAColumn(table, 'asset_rfid', 'Codice RFID', null, 60, 30);
						this.describeAColumn(table, 'asset_lifestart', 'Data inizio esistenza', null, 70, null);
						this.describeAColumn(table, 'inventorytree_codeinv', 'Codice Class. Inv.', null, 20, 50);
						this.describeAColumn(table, 'inventorytree_description', 'Denominazione Class. Inv.', null, 20, 150);
						this.describeAColumn(table, 'inventorytree_idinv', 'Class. Inv. Class. Inv.', null, 20, null);
						this.describeAColumn(table, 'upb_codeupb', 'Codice UPB', null, 30, 50);
						this.describeAColumn(table, 'upb_title', 'Denominazione UPB', null, 30, 150);
						this.describeAColumn(table, 'upb_idupb', 'UPB UPB', null, 30, 36);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idasset", "idpiece"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('assetsegview', new meta_assetsegview('assetsegview'));

	}());
