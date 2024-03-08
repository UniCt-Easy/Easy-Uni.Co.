(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentokind() {
        MetaData.apply(this, ["affidamentokind"]);
        this.name = 'meta_affidamentokind';
    }

    meta_affidamentokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentokind,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, 'costoora', 'Costo orario', 'fixed.2', 100, null);
						this.describeAColumn(table, 'costoorariodacontratto', 'Costo orario da ruolo', null, 110, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_affidamentokind");

				//$getNewRowInside$

				dt.autoIncrement('idaffidamentokind', { minimum: 99990001 });

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
						return "title asc ";
					}
					case "default": {
						return "title asc , sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamentokind', new meta_affidamentokind('affidamentokind'));

	}());
