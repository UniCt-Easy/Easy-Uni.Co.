(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotiporicavoaccmotive() {
        MetaData.apply(this, ["progettotiporicavoaccmotive"]);
        this.name = 'meta_progettotiporicavoaccmotive';
    }

    meta_progettotiporicavoaccmotive.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotiporicavoaccmotive,
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
						this.describeAColumn(table, '!idaccmotive_accmotive_alias1_title', 'Causale', null, 13, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_alias1_codemotive', 'Codice', null, 16, null);
						objCalcFieldConfig['!idaccmotive_accmotive_alias1_title'] = { tableNameLookup:'accmotive_alias1', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_alias1_codemotive'] = { tableNameLookup:'accmotive_alias1', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
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
						table.columns["idaccmotive"].caption = "Causale economico patrimoniale";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotiporicavoaccmotive");

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

			//$describeTree$
        });

    window.appMeta.addMeta('progettotiporicavoaccmotive', new meta_progettotiporicavoaccmotive('progettotiporicavoaccmotive'));

	}());
