(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfobiettiviuosoglia() {
        MetaData.apply(this, ["perfobiettiviuosoglia"]);
        this.name = 'meta_perfobiettiviuosoglia';
    }

    meta_perfobiettiviuosoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfobiettiviuosoglia,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Soglia', null, 10, 50);
						this.describeAColumn(table, 'percentuale', 'Valore Percentuale', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore Numerico', 'fixed.2', 40, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 50, -1);
//$objCalcFieldConfig_default$
						break;
					case 'target':
						this.describeAColumn(table, 'percentuale', 'Valore Percentuale', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore Numerico', 'fixed.2', 40, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 50, -1);
//$objCalcFieldConfig_target$
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
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfsogliakind"].caption = "Soglia";
						table.columns["percentuale"].caption = "Valore Percentuale";
						table.columns["valorenumerico"].caption = "Valore Numerico";
//$innerSetCaptionConfig_default$
						break;
					case 'target':
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfsogliakind"].caption = "Soglia";
						table.columns["percentuale"].caption = "Valore Percentuale";
						table.columns["valorenumerico"].caption = "Valore Numerico";
//$innerSetCaptionConfig_target$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfobiettiviuosoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfobiettiviuosoglia', { minimum: 99990001 });

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
						return "percentuale asc ";
					}
					case "target": {
						return "percentuale asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfobiettiviuosoglia', new meta_perfobiettiviuosoglia('perfobiettiviuosoglia'));

	}());
