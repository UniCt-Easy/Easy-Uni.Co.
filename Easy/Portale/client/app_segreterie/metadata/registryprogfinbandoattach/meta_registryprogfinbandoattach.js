(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryprogfinbandoattach() {
        MetaData.apply(this, ["registryprogfinbandoattach"]);
        this.name = 'meta_registryprogfinbandoattach';
    }

    meta_registryprogfinbandoattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryprogfinbandoattach,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo', null, 90, 2048);
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', 'skipNChar.40', 13, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 15, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						objCalcFieldConfig['!idattach_attach_size'] = { tableNameLookup:'attach', columnNameLookup:'size', columnNamekey:'idattach' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idattach"].caption = "Allegato";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registryprogfinbandoattach");

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

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryprogfinbandoattach', new meta_registryprogfinbandoattach('registryprogfinbandoattach'));

	}());
