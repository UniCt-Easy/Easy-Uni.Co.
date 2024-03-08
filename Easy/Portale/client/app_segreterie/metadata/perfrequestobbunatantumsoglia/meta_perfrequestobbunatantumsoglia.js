(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfrequestobbunatantumsoglia() {
        MetaData.apply(this, ["perfrequestobbunatantumsoglia"]);
        this.name = 'meta_perfrequestobbunatantumsoglia';
    }

    meta_perfrequestobbunatantumsoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfrequestobbunatantumsoglia,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Soglia', null, 30, 50);
						this.describeAColumn(table, 'percentuale', 'Valore % soglia', 'fixed.2', 40, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 50, null);
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
						table.columns["idperfsogliakind"].caption = "Soglia";
						table.columns["percentuale"].caption = "Valore % soglia";
						table.columns["valorenumerico"].caption = "Valore numerico soglia";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfrequestobbunatantumsoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfrequestobbunatantumsoglia', { minimum: 99990001 });

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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfrequestobbunatantumsoglia', new meta_perfrequestobbunatantumsoglia('perfrequestobbunatantumsoglia'));

	}());
