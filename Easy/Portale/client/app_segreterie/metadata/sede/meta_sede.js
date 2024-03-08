(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sede() {
        MetaData.apply(this, ["sede"]);
        this.name = 'meta_sede';
    }

    meta_sede.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sede,
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
					case 'seg_child':
						this.describeAColumn(table, '!idcity_geo_city_title', 'Comune', null, 61, null);
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup:'geo_city_alias1', columnNameLookup:'title', columnNamekey:'idcity' };
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup:'geo_city_alias2', columnNameLookup:'title', columnNamekey:'idcity' };
//$objCalcFieldConfig_seg_child$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'idsedemiur', 'Identificativo MIUR', null, 30, null);
						this.describeAColumn(table, 'address', 'Indirizzo', null, 40, 100);
						this.describeAColumn(table, 'cap', 'CAP', null, 50, 20);
//$objCalcFieldConfig_default$
						break;
					case 'seg_child_azienda':
						this.describeAColumn(table, '!idcity_geo_city_title', 'Comune', null, 61, null);
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup:'geo_city_alias2', columnNameLookup:'title', columnNamekey:'idcity' };
//$objCalcFieldConfig_seg_child_azienda$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_sede");

				//$getNewRowInside$

				dt.autoIncrement('idsede', { minimum: 99990001 });

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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sede', new meta_sede('sede'));

	}());
