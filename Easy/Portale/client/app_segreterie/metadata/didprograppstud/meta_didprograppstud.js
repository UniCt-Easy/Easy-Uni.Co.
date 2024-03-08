(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprograppstud() {
        MetaData.apply(this, ["didprograppstud"]);
        this.name = 'meta_didprograppstud';
    }

    meta_didprograppstud.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprograppstud,
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
						this.describeAColumn(table, '!idreg_studenti_registry_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_p_iva', 'Partita iva', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_studdirittokind_title', 'Tipologia per il diritto allo studio', null, 21, null);
						this.describeAColumn(table, '!idreg_studenti_studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 21, null);
						objCalcFieldConfig['!idreg_studenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_studenti_authinps'] = { tableNameLookup:'registry_studenti', columnNameLookup:'authinps', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_studdirittokind_title'] = { tableNameLookup:'studdirittokind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_studprenotkind_title'] = { tableNameLookup:'studprenotkind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						this.describeAColumn(table, '!idreg_studenti_registry_title', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 24, null);
						this.describeAColumn(table, '!idreg_studenti_registry_p_iva', 'Partita iva', null, 25, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 26, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 50, null);
						this.describeAColumn(table, '!idreg_studenti_studdirittokind_title', 'Tipologia per il diritto allo studio', null, 52, null);
						this.describeAColumn(table, '!idreg_studenti_studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 53, null);
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
               var def = appMeta.Deferred("getNewRow-meta_didprograppstud");

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

    window.appMeta.addMeta('didprograppstud', new meta_didprograppstud('didprograppstud'));

	}());
