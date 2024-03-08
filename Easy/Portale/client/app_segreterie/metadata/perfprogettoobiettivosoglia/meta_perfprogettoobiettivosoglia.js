(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivosoglia() {
        MetaData.apply(this, ["perfprogettoobiettivosoglia"]);
        this.name = 'meta_perfprogettoobiettivosoglia';
    }

    meta_perfprogettoobiettivosoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivosoglia,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Soglia', null, 50, 50);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 60, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 110, -1);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 120, null);
//$objCalcFieldConfig_default$
						break;
					case 'soglia':
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, -1);
						this.describeAColumn(table, 'idperfsogliakind', 'Soglia', null, 50, 50);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 60, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 70, null);
//$objCalcFieldConfig_soglia$
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
//$innerSetCaptionConfig_default$
						break;
					case 'soglia':
						table.columns["description"].caption = "Descrizione";
//$innerSetCaptionConfig_soglia$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoobiettivosoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoobiettivosoglia', { minimum: 99990001 });

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
					case "soglia": {
						return "percentuale asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivosoglia', new meta_perfprogettoobiettivosoglia('perfprogettoobiettivosoglia'));

	}());
