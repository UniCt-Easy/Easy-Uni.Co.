(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonaleattach() {
        MetaData.apply(this, ["perfvalutazionepersonaleattach"]);
        this.name = 'meta_perfvalutazionepersonaleattach';
    }

    meta_perfvalutazionepersonaleattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaleattach,
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
						this.describeAColumn(table, '!idattach_attach_filename', 'Allegato', 'skipNChar.40', 20, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Allegato', null, 20, null);
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
						table.columns["cu"].caption = "Data Inserimento";
						table.columns["data"].caption = "Data Inserimento";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonaleattach");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonaleattach', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazionepersonaleattach', new meta_perfvalutazionepersonaleattach('perfvalutazionepersonaleattach'));

	}());
