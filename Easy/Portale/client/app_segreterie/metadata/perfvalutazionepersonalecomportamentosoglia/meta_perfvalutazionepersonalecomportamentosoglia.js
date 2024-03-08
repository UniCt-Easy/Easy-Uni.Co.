(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonalecomportamentosoglia() {
        MetaData.apply(this, ["perfvalutazionepersonalecomportamentosoglia"]);
        this.name = 'meta_perfvalutazionepersonalecomportamentosoglia';
    }

    meta_perfvalutazionepersonalecomportamentosoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonalecomportamentosoglia,
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
						this.describeAColumn(table, 'year', 'Anno solare', null, 10, null);
						this.describeAColumn(table, 'idperfsogliakind', 'Tipo ', null, 20, 50);
						this.describeAColumn(table, 'valore', 'Valore % soglia', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 40, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 50, -1);
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
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfsogliakind"].caption = "Tipo ";
						table.columns["valore"].caption = "Valore % soglia";
						table.columns["valorenumerico"].caption = "Valore numerico soglia";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonalecomportamentosoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonalecomportamentosoglia', { minimum: 99990001 });

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
						return "valore asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfvalutazionepersonalecomportamentosoglia', new meta_perfvalutazionepersonalecomportamentosoglia('perfvalutazionepersonalecomportamentosoglia'));

	}());
