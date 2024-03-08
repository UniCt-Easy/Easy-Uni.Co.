(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionebmiattach() {
        MetaData.apply(this, ["iscrizionebmiattach"]);
        this.name = 'meta_iscrizionebmiattach';
    }

    meta_iscrizionebmiattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionebmiattach,
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
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 20, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 20, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						objCalcFieldConfig['!idattach_attach_size'] = { tableNameLookup:'attach', columnNameLookup:'size', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 23, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 25, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_iscrizionebmiattach");

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

    window.appMeta.addMeta('iscrizionebmiattach', new meta_iscrizionebmiattach('iscrizionebmiattach'));

	}());
