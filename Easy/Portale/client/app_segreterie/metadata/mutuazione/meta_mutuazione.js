(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_mutuazione() {
        MetaData.apply(this, ["mutuazione"]);
        this.name = 'meta_mutuazione';
    }

    meta_mutuazione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mutuazione,
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
						this.describeAColumn(table, 'riferimento', 'Di riferimento per il canale', null, 50, null);
						this.describeAColumn(table, '!idcanale_from_canale_title', 'Canale mutuato', null, 41, null);
						objCalcFieldConfig['!idcanale_from_canale_title'] = { tableNameLookup:'canale_alias1', columnNameLookup:'title', columnNamekey:'idcanale_from' };
						objCalcFieldConfig['!idcanale_from_canale_title'] = { tableNameLookup:'canale_alias2', columnNameLookup:'title', columnNamekey:'idcanale_from' };
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
						table.columns["idcanale"].caption = "Canale mutuante";
						table.columns["idcanale_from"].caption = "Canale mutuato";
						table.columns["json"].caption = "Mutuazione";
						table.columns["riferimento"].caption = "Di riferimento per il canale";
						table.columns["title"].caption = "Mutuazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_mutuazione");

				//$getNewRowInside$

				dt.autoIncrement('idmutuazione', { minimum: 99990001 });

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
						return "riferimento desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('mutuazione', new meta_mutuazione('mutuazione'));

	}());
