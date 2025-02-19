﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfsoglia() {
        MetaData.apply(this, ["perfsoglia"]);
        this.name = 'meta_perfsoglia';
    }

    meta_perfsoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfsoglia,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Tipo', null, 30, 50);
						this.describeAColumn(table, 'valore', 'Percentuale di default', 'fixed.2', 40, null);
						this.describeAColumn(table, 'year', 'Anno solare', null, 50, null);
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
						table.columns["idperfsogliakind"].caption = "Tipo";
						table.columns["valore"].caption = "Percentuale di default";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfsoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfsoglia', { minimum: 99990001 });

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

        });

    window.appMeta.addMeta('perfsoglia', new meta_perfsoglia('perfsoglia'));

	}());
