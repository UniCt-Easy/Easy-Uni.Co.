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
						this.describeAColumn(table, 'idreg_studenti', 'Studente', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_surname', 'Cognome', null, 21, null);
						this.describeAColumn(table, '!idreg_studenti_registry_forename', 'Nome', null, 22, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 24, null);
						this.describeAColumn(table, '!idreg_studenti_registry_extmatricula', 'Matricola', null, 25, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 26, null);
						this.describeAColumn(table, '!idreg_studenti_registry_idanpr', 'Idanpr', null, 39, null);
						objCalcFieldConfig['!idreg_studenti_registry_surname'] = { tableNameLookup:'registry', columnNameLookup:'surname', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_forename'] = { tableNameLookup:'registry', columnNameLookup:'forename', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_extmatricula'] = { tableNameLookup:'registry', columnNameLookup:'extmatricula', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_idanpr'] = { tableNameLookup:'registry', columnNameLookup:'idanpr', columnNamekey:'idreg_studenti' };
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
						table.columns["iddidprog"].caption = "Didattica Programmata";
						table.columns["idreg_studenti"].caption = "Studente";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


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
