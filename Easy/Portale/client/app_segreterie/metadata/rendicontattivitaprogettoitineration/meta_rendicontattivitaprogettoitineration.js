(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettoitineration() {
        MetaData.apply(this, ["rendicontattivitaprogettoitineration"]);
        this.name = 'meta_rendicontattivitaprogettoitineration';
    }

    meta_rendicontattivitaprogettoitineration.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoitineration,
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
						this.describeAColumn(table, 'iditineration', 'Missione', null, 10, null);
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
						table.columns["iditineration"].caption = "Missione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_rendicontattivitaprogettoitineration");

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

    window.appMeta.addMeta('rendicontattivitaprogettoitineration', new meta_rendicontattivitaprogettoitineration('rendicontattivitaprogettoitineration'));

	}());
