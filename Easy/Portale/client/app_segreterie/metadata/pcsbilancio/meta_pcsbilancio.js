(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pcsbilancio() {
        MetaData.apply(this, ["pcsbilancio"]);
        this.name = 'meta_pcsbilancio';
    }

    meta_pcsbilancio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcsbilancio,
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
						this.describeAColumn(table, 'descrizione', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'importo', 'Importo anno', 'fixed.2', 30, null);
						this.describeAColumn(table, 'importo1', 'Importo anno successivo', 'fixed.2', 40, null);
						this.describeAColumn(table, 'importo2', 'Importo secondo anno successivo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'importo3', 'Importo terzo anno successivo', 'fixed.2', 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["descrizione"].caption = "Descrizione";
						table.columns["importo"].caption = "Importo anno";
						table.columns["importo1"].caption = "Importo anno successivo";
						table.columns["importo2"].caption = "Importo secondo anno successivo";
						table.columns["importo3"].caption = "Importo terzo anno successivo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pcsbilancio");

				//$getNewRowInside$

				dt.autoIncrement('idpcsbilancio', { minimum: 99990001 });

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
						return "year asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pcsbilancio', new meta_pcsbilancio('pcsbilancio'));

	}());
