(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ccnlregistry_aziende() {
        MetaData.apply(this, ["ccnlregistry_aziende"]);
        this.name = 'meta_ccnlregistry_aziende';
    }

    meta_ccnlregistry_aziende.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ccnlregistry_aziende,
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
						this.describeAColumn(table, '!idccnl_ccnl_title', 'Denominazione', null, 11, null);
						this.describeAColumn(table, '!idccnl_ccnl_active', 'Attivo', null, 10, null);
						this.describeAColumn(table, '!idccnl_ccnl_area', 'Area', null, 10, null);
						this.describeAColumn(table, '!idccnl_ccnl_decorrenza', 'Decorrenza', null, 10, null);
						this.describeAColumn(table, '!idccnl_ccnl_scadec', 'Scadenza ec.', null, 10, null);
						this.describeAColumn(table, '!idccnl_ccnl_scadenza', 'Scadenza', null, 10, null);
						this.describeAColumn(table, '!idccnl_ccnl_sortcode', 'Ordinamento', null, 10, null);
						this.describeAColumn(table, '!idccnl_ccnl_stipula', 'Stipula', null, 10, null);
						objCalcFieldConfig['!idccnl_ccnl_title'] = { tableNameLookup:'ccnl', columnNameLookup:'title', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_active'] = { tableNameLookup:'ccnl', columnNameLookup:'active', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_area'] = { tableNameLookup:'ccnl', columnNameLookup:'area', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_decorrenza'] = { tableNameLookup:'ccnl', columnNameLookup:'decorrenza', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_scadec'] = { tableNameLookup:'ccnl', columnNameLookup:'scadec', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_scadenza'] = { tableNameLookup:'ccnl', columnNameLookup:'scadenza', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_sortcode'] = { tableNameLookup:'ccnl', columnNameLookup:'sortcode', columnNamekey:'idccnl' };
						objCalcFieldConfig['!idccnl_ccnl_stipula'] = { tableNameLookup:'ccnl', columnNameLookup:'stipula', columnNamekey:'idccnl' };
						this.describeAColumn(table, '!idccnl_ccnl_title', 'Denominazione', null, 13, null);
						this.describeAColumn(table, '!idccnl_ccnl_active', 'Attivo', null, 13, null);
						this.describeAColumn(table, '!idccnl_ccnl_area', 'Area', null, 14, null);
						this.describeAColumn(table, '!idccnl_ccnl_decorrenza', 'Decorrenza', null, 16, null);
						this.describeAColumn(table, '!idccnl_ccnl_scadec', 'Scadenza ec.', null, 17, null);
						this.describeAColumn(table, '!idccnl_ccnl_scadenza', 'Scadenza', null, 18, null);
						this.describeAColumn(table, '!idccnl_ccnl_sortcode', 'Sortcode', null, 19, null);
						this.describeAColumn(table, '!idccnl_ccnl_stipula', 'Stipula', null, 20, null);
						this.describeAColumn(table, '!idccnl_ccnl_sortcode', 'Ordinamento', null, 19, null);
						this.describeAColumn(table, '!idccnl_ccnl_title', 'Denominazione Tipologia di contratto', null, 13, null);
						this.describeAColumn(table, '!idccnl_ccnl_active', 'Attivo Tipologia di contratto', null, 13, null);
						this.describeAColumn(table, '!idccnl_ccnl_area', 'Area Tipologia di contratto', null, 14, null);
						this.describeAColumn(table, '!idccnl_ccnl_decorrenza', 'Decorrenza Tipologia di contratto', null, 16, null);
						this.describeAColumn(table, '!idccnl_ccnl_scadec', 'Scadenza ec. Tipologia di contratto', null, 17, null);
						this.describeAColumn(table, '!idccnl_ccnl_scadenza', 'Scadenza Tipologia di contratto', null, 18, null);
						this.describeAColumn(table, '!idccnl_ccnl_sortcode', 'Ordinamento Tipologia di contratto', null, 19, null);
						this.describeAColumn(table, '!idccnl_ccnl_stipula', 'Stipula Tipologia di contratto', null, 20, null);
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
               var def = appMeta.Deferred("getNewRow-meta_ccnlregistry_aziende");

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

    window.appMeta.addMeta('ccnlregistry_aziende', new meta_ccnlregistry_aziende('ccnlregistry_aziende'));

	}());
