(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_city() {
        MetaData.apply(this, ["geo_city"]);
        this.name = 'meta_geo_city';
    }

    meta_geo_city.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_city,
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
					case 'seg5':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'idcity', 'Codice', null, 20, null);
						this.describeAColumn(table, 'start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 70, null);
//$objCalcFieldConfig_seg5$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 70, null);
//$objCalcFieldConfig_seg$
						break;
					case 'segchild':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 70, null);
						this.describeAColumn(table, '!newcity_geo_city_title', 'Nuovo comune in cui questo è confluito', null, 41, null);
						objCalcFieldConfig['!newcity_geo_city_title'] = { tableNameLookup:'geo_city_alias1', columnNameLookup:'title', columnNamekey:'newcity' };
						this.describeAColumn(table, '!oldcity_geo_city_title', 'id comune da cui questo è confluito', null, 51, null);
						objCalcFieldConfig['!oldcity_geo_city_title'] = { tableNameLookup:'geo_city_alias3', columnNameLookup:'title', columnNamekey:'oldcity' };
//$objCalcFieldConfig_segchild$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'idcity', 'Codice', null, 20, null);
						this.describeAColumn(table, 'start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 70, null);
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
					case 'seg':
						table.columns["idcountry"].caption = "Provincia";
						table.columns["newcity"].caption = "Nuovo comune in cui questo è confluito";
//$innerSetCaptionConfig_seg$
						break;
					case 'segchild':
						table.columns["idcountry"].caption = "Provincia";
						table.columns["newcity"].caption = "Nuovo comune in cui questo è confluito";
//$innerSetCaptionConfig_segchild$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_geo_city");

				//$getNewRowInside$

				dt.autoIncrement('idcity', { minimum: 99990001 });

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
						return "title asc ";
					}
					case "segchild": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_city', new meta_geo_city('geo_city'));

	}());
