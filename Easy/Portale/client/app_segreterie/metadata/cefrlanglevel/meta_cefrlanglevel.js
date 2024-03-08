(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_cefrlanglevel() {
        MetaData.apply(this, ["cefrlanglevel"]);
        this.name = 'meta_cefrlanglevel';
    }

    meta_cefrlanglevel.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_cefrlanglevel,
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
					case 'accordoscambiomidettlang':						
						this.describeAColumn(table, '!idaccordoscambiomidettlangkind_accordoscambiomidettlangkind_title', 'Tipologia', null, 11, null);
						objCalcFieldConfig['!idaccordoscambiomidettlangkind_accordoscambiomidettlangkind_title'] = { tableNameLookup:'accordoscambiomidettlangkind', columnNameLookup:'title', columnNamekey:'idaccordoscambiomidettlangkind' };
						this.describeAColumn(table, '!idcefr_compasc_cefr_title', 'Comprensione ascolto', null, 31, null);
						objCalcFieldConfig['!idcefr_compasc_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_compasc' };
						this.describeAColumn(table, '!idcefr_complett_cefr_title', 'Comprensione lettura', null, 41, null);
						objCalcFieldConfig['!idcefr_complett_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_complett' };
						this.describeAColumn(table, '!idcefr_parlinter_cefr_title', 'Parlato interazione', null, 51, null);
						objCalcFieldConfig['!idcefr_parlinter_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_parlinter' };
						this.describeAColumn(table, '!idcefr_parlprod_cefr_title', 'Parlato produzione', null, 61, null);
						objCalcFieldConfig['!idcefr_parlprod_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_parlprod' };
						this.describeAColumn(table, '!idcefr_scritto_cefr_title', 'Scritto', null, 71, null);
						objCalcFieldConfig['!idcefr_scritto_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_scritto' };
						this.describeAColumn(table, '!idnation_geo_nation_lang', 'Lingua', null, 21, null);
						objCalcFieldConfig['!idnation_geo_nation_lang'] = { tableNameLookup:'geo_nation', columnNameLookup:'lang', columnNamekey:'idnation' };
//$objCalcFieldConfig_accordoscambiomidettlang$
						break;
					case 'default':		
						this.describeAColumn(table, '!idcefr_compasc_cefr_title', 'Comprensione ascolto', null, 21, null);
						objCalcFieldConfig['!idcefr_compasc_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_compasc' };
						this.describeAColumn(table, '!idcefr_complett_cefr_title', 'Comprensione lettura', null, 31, null);
						objCalcFieldConfig['!idcefr_complett_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_complett' };
						this.describeAColumn(table, '!idcefr_parlinter_cefr_title', 'Parlato interazione', null, 41, null);
						objCalcFieldConfig['!idcefr_parlinter_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_parlinter' };
						this.describeAColumn(table, '!idcefr_parlprod_cefr_title', 'Parlato produzione', null, 51, null);
						objCalcFieldConfig['!idcefr_parlprod_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_parlprod' };
						this.describeAColumn(table, '!idcefr_scritto_cefr_title', 'Scritto', null, 61, null);
						objCalcFieldConfig['!idcefr_scritto_cefr_title'] = { tableNameLookup:'cefr', columnNameLookup:'title', columnNamekey:'idcefr_scritto' };
						this.describeAColumn(table, '!idnation_geo_nation_lang', 'Lingua', null, 11, null);
						objCalcFieldConfig['!idnation_geo_nation_lang'] = { tableNameLookup:'geo_nation', columnNameLookup:'lang', columnNamekey:'idnation' };
//$objCalcFieldConfig_default$			
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_cefrlanglevel");

				//$getNewRowInside$

				dt.autoIncrement('idcefrlanglevel', { minimum: 99990001 });

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
						return "idnation desc";
					}
					case "accordoscambiomidettlang": {
						return "idaccordoscambiomidettlangkind desc, idnation desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('cefrlanglevel', new meta_cefrlanglevel('cefrlanglevel'));

	}());
