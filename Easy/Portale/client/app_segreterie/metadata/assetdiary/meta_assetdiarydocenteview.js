(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assetdiarydocenteview() {
        MetaData.apply(this, ["assetdiarydocenteview"]);
        this.name = 'meta_assetdiarydocenteview';
    }

    meta_assetdiarydocenteview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiarydocenteview,
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
					case 'docente':
						this.describeAColumn(table, 'inventory_codeinventory', 'Codice Inventario Bene strumentale', null, 1110, 20);
						this.describeAColumn(table, 'inventory_description', 'Descrizione Inventario Bene strumentale', null, 1120, 50);
						this.describeAColumn(table, 'asset_ninventory', 'Numero inventario Bene strumentale', null, 1200, null);
						this.describeAColumn(table, 'asset_idasset', 'Identificativo Bene strumentale', null, 1300, null);
						this.describeAColumn(table, 'asset_idpiece', 'Numero parte Bene strumentale', null, 1400, null);
						this.describeAColumn(table, 'assetacquire_description', 'Descrizione Descrizione Bene strumentale', null, 1510, 150);
						this.describeAColumn(table, 'asset_rfid', 'Codice RFID Bene strumentale', null, 1600, 30);
						this.describeAColumn(table, 'progetto_titolobreve', 'Progetto', null, 3500, 2048);
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 5100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 5200, 2048);
						this.describeAColumn(table, 'assetdiary_orepreventivate', 'Ore di utilizzo complessive preventivate', null, 6000, null);
//$objCalcFieldConfig_docente$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idassetdiary", "idworkpackage"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docente": {
						return "progetto_titolobreve asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('assetdiarydocenteview', new meta_assetdiarydocenteview('assetdiarydocenteview'));

	}());
