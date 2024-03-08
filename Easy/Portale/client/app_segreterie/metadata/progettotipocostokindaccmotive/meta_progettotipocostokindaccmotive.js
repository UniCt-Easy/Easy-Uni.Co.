(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocostokindaccmotive() {
        MetaData.apply(this, ["progettotipocostokindaccmotive"]);
        this.name = 'meta_progettotipocostokindaccmotive';
    }

    meta_progettotipocostokindaccmotive.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostokindaccmotive,
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
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Causale', null, 11, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice', null, 12, null);
						objCalcFieldConfig['!idaccmotive_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Causale', null, 13, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice', null, 16, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostokindaccmotive");

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
						return "idaccmotive asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettotipocostokindaccmotive', new meta_progettotipocostokindaccmotive('progettotipocostokindaccmotive'));

	}());
