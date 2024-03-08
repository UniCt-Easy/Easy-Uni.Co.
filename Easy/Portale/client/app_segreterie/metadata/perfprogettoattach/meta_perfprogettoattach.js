(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoattach() {
        MetaData.apply(this, ["perfprogettoattach"]);
        this.name = 'meta_perfprogettoattach';
    }

    meta_perfprogettoattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoattach,
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
						this.describeAColumn(table, 'data', 'Data Inserimento', null, 80, null);
						this.describeAColumn(table, '!idattach_attach_filename', 'Allegato', 'skipNChar.40', 10, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
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
						table.columns["idattach"].caption = "Allegato";
						table.columns["data"].caption = "Data Inserimento";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoattach");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoattach', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfprogettoattach', new meta_perfprogettoattach('perfprogettoattach'));

	}());
