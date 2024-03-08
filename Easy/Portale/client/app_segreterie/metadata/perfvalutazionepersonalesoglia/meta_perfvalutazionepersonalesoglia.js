(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonalesoglia() {
        MetaData.apply(this, ["perfvalutazionepersonalesoglia"]);
        this.name = 'meta_perfvalutazionepersonalesoglia';
    }

    meta_perfvalutazionepersonalesoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonalesoglia,
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
						this.describeAColumn(table, 'percentuale', 'Valore % soglia', 'fixed.2', 20, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 110, null);
//$objCalcFieldConfig_default$
						break;
					case 'target':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, -1);
						this.describeAColumn(table, 'percentuale', 'Valore % soglia', 'fixed.2', 20, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 30, null);
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
						table.columns["percentuale"].caption = "Percentuale";
						table.columns["percentuale"].caption = "Valore % soglia";
						table.columns["valorenumerico"].caption = "Valore numerico soglia";
//$innerSetCaptionConfig_default$
						break;
					case 'target':
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfsogliakind"].caption = "Soglia";
						table.columns["percentuale"].caption = "Valore % soglia";
						table.columns["valorenumerico"].caption = "Valore numerico soglia";
//$innerSetCaptionConfig_target$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonalesoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonalesoglia', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazionepersonalesoglia', new meta_perfvalutazionepersonalesoglia('perfvalutazionepersonalesoglia'));

	}());
