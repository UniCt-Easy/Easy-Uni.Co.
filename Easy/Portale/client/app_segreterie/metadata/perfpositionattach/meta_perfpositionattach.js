(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfpositionattach() {
        MetaData.apply(this, ["perfpositionattach"]);
        this.name = 'meta_perfpositionattach';
    }

    meta_perfpositionattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfpositionattach,
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
						this.describeAColumn(table, 'year', 'Anno solare', null, 40, null);
						this.describeAColumn(table, '!idattach_attach_filename', 'Modulo', 'skipNChar.40', 20, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Modulo', null, 20, null);
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
						table.columns["idattach"].caption = "Modulo";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfpositionattach");

				//$getNewRowInside$

				dt.autoIncrement('idperfpositionattach', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfpositionattach', new meta_perfpositionattach('perfpositionattach'));

	}());
