(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfpositionsoglieindividuali() {
        MetaData.apply(this, ["perfpositionsoglieindividuali"]);
        this.name = 'meta_perfpositionsoglieindividuali';
    }

    meta_perfpositionsoglieindividuali.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfpositionsoglieindividuali,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Tipo', null, 20, 50);
						this.describeAColumn(table, 'valore', 'Valore % soglia', 'fixed.2', 40, null);
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
						table.columns["valore"].caption = "Valore % soglia";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfpositionsoglieindividuali");

				//$getNewRowInside$

				dt.autoIncrement('idperfpositionsoglieindividuali', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfpositionsoglieindividuali', new meta_perfpositionsoglieindividuali('perfpositionsoglieindividuali'));

	}());
