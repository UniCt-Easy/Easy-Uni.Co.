(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotiporicavokindaccmotive() {
        MetaData.apply(this, ["progettotiporicavokindaccmotive"]);
        this.name = 'meta_progettotiporicavokindaccmotive';
    }

    meta_progettotiporicavokindaccmotive.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotiporicavokindaccmotive,
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
						this.describeAColumn(table, '!idaccmotive_accmotive_alias1_title', 'Causale', null, 13, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_alias1_codemotive', 'Codice', null, 16, null);
						objCalcFieldConfig['!idaccmotive_accmotive_alias1_title'] = { tableNameLookup:'accmotive_alias1', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_alias1_codemotive'] = { tableNameLookup:'accmotive_alias1', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
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
						table.columns["idaccmotive"].caption = "Causale economico patrimoniale";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotiporicavokindaccmotive");

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
					case "default": {
						return "idaccmotive asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('progettotiporicavokindaccmotive', new meta_progettotiporicavokindaccmotive('progettotiporicavokindaccmotive'));

	}());
