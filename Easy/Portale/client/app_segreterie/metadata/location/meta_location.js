(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_location() {
        MetaData.apply(this, ["location"]);
        this.name = 'meta_location';
    }

    meta_location.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_location,
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
						this.describeAColumn(table, 'address', 'Indirizzo', null, 10, 100);
						this.describeAColumn(table, 'idlocation', 'id ubicazione (tabella location)', null, 10, null);
						this.describeAColumn(table, 'annotations', 'Note', null, 20, 400);
						this.describeAColumn(table, 'cap', 'CAP', null, 30, 20);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 150);
						this.describeAColumn(table, 'active', 'attivo', null, 40, null);
						this.describeAColumn(table, 'locationcode', 'Codice', null, 50, 50);
						this.describeAColumn(table, 'latitude', 'Latitudine', 'fixed.7', 70, null);
						this.describeAColumn(table, 'location', 'Localit?', null, 80, 20);
						this.describeAColumn(table, 'longitude', 'Longitudine', 'fixed.7', 90, null);
//$objCalcFieldConfig_default$
						break;
					case 'consign':
						this.describeAColumn(table, 'location', 'Località', null, 170, 20);
//$objCalcFieldConfig_ consign$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_location");

				//$getNewRowInside$

				dt.autoIncrement('idlocation', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "paridlocation asc , description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('location', new meta_location('location'));

	}());
