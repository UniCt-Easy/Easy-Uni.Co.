(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudio() {
        MetaData.apply(this, ["pianostudio"]);
        this.name = 'meta_pianostudio';
    }

    meta_pianostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudio,
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
					case 'seganagstusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 51, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 51, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'segstud':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
//$objCalcFieldConfig_segstud$
						break;
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 51, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
//$objCalcFieldConfig_didprog$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seganagstusing':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seganagstusing$
						break;
					case 'seganagstu':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'segstud':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_segstud$
						break;
					case 'didprog':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_didprog$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pianostudio");

				//$getNewRowInside$

				dt.autoIncrement('idpianostudio', { minimum: 99990001 });

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
					case "seganagstusing": {
						return "aa desc";
					}
					case "seganagstu": {
						return "aa desc";
					}
					case "segstud": {
						return "aa desc";
					}
					case "didprog": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudio', new meta_pianostudio('pianostudio'));

	}());
