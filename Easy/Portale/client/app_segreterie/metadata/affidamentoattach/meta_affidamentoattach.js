(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentoattach() {
        MetaData.apply(this, ["affidamentoattach"]);
        this.name = 'meta_affidamentoattach';
    }

    meta_affidamentoattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentoattach,
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
					case 'seganag':
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 30, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 30, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						objCalcFieldConfig['!idattach_attach_size'] = { tableNameLookup:'attach', columnNameLookup:'size', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 33, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 35, null);
//$objCalcFieldConfig_seganag$
						break;
					case 'default':
						this.describeAColumn(table, 'idattach', 'Allegato', null, 30, null);
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 33, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 35, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						objCalcFieldConfig['!idattach_attach_size'] = { tableNameLookup:'attach', columnNameLookup:'size', columnNamekey:'idattach' };
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
						table.columns["idreg_docenti"].caption = "Docente";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_affidamentoattach");

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

    window.appMeta.addMeta('affidamentoattach', new meta_affidamentoattach('affidamentoattach'));

	}());
