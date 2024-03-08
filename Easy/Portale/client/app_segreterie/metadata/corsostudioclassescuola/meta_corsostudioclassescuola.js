(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudioclassescuola() {
        MetaData.apply(this, ["corsostudioclassescuola"]);
        this.name = 'meta_corsostudioclassescuola';
    }

    meta_corsostudioclassescuola.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudioclassescuola,
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
						this.describeAColumn(table, '!idclassescuola_classescuola_sigla', 'Sigla', null, 11, null);
						this.describeAColumn(table, '!idclassescuola_classescuola_title', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idclassescuola_corsostudionorma_title', 'Normativa', null, 11, null);
						this.describeAColumn(table, '!idclassescuola_classescuola_indicecineca', 'Identificativo CINECA', null, 10, null);
						this.describeAColumn(table, '!idclassescuola_classescuolakind_title', 'Tipologia', null, 11, null);
						this.describeAColumn(table, '!idclassescuola_classescuolaarea_title', 'Area', null, 11, null);
						objCalcFieldConfig['!idclassescuola_classescuola_sigla'] = { tableNameLookup:'classescuola', columnNameLookup:'sigla', columnNamekey:'idclassescuola' };
						objCalcFieldConfig['!idclassescuola_classescuola_title'] = { tableNameLookup:'classescuola', columnNameLookup:'title', columnNamekey:'idclassescuola' };
						objCalcFieldConfig['!idclassescuola_corsostudionorma_title'] = { tableNameLookup:'corsostudionorma', columnNameLookup:'title', columnNamekey:'idclassescuola' };
						objCalcFieldConfig['!idclassescuola_classescuola_indicecineca'] = { tableNameLookup:'classescuola', columnNameLookup:'indicecineca', columnNamekey:'idclassescuola' };
						objCalcFieldConfig['!idclassescuola_classescuolakind_title'] = { tableNameLookup:'classescuolakind', columnNameLookup:'title', columnNamekey:'idclassescuola' };
						objCalcFieldConfig['!idclassescuola_classescuolaarea_title'] = { tableNameLookup:'classescuolaarea', columnNameLookup:'title', columnNamekey:'idclassescuola' };
						this.describeAColumn(table, '!idclassescuola_classescuola_sigla', 'Sigla', null, 12, null);
						this.describeAColumn(table, '!idclassescuola_classescuola_title', 'Denominazione', null, 14, null);
						this.describeAColumn(table, '!idclassescuola_corsostudionorma_title', 'Normativa', null, 14, null);
						this.describeAColumn(table, '!idclassescuola_classescuola_indicecineca', 'Identificativo CINECA', null, 13, null);
						this.describeAColumn(table, '!idclassescuola_classescuolakind_title', 'Tipologia', null, 15, null);
						this.describeAColumn(table, '!idclassescuola_classescuolaarea_title', 'Area', null, 16, null);
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
               var def = appMeta.Deferred("getNewRow-meta_corsostudioclassescuola");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('corsostudioclassescuola', new meta_corsostudioclassescuola('corsostudioclassescuola'));

	}());
