(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontlezionestud() {
        MetaData.apply(this, ["rendicontlezionestud"]);
        this.name = 'meta_rendicontlezionestud';
    }

    meta_rendicontlezionestud.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontlezionestud,
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
						this.describeAColumn(table, 'idreg_studenti', 'Studente', null, 10, null);
						this.describeAColumn(table, 'assente', 'Assente', null, 20, null);
						this.describeAColumn(table, 'ritardo', 'Ritardo', 'g', 30, null);
						this.describeAColumn(table, 'ritardogiustifica', 'Giustificazione del ritardo', null, 40, 1024);
						this.describeAColumn(table, 'notadisciplinare', 'Nota disciplinare', null, 50, 1024);
						this.describeAColumn(table, '!idreg_studenti_registry_surname', 'Cognome', null, 11, null);
						this.describeAColumn(table, '!idreg_studenti_registry_forename', 'Nome', null, 12, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 14, null);
						this.describeAColumn(table, '!idreg_studenti_registry_extmatricula', 'Matricola', null, 15, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 16, null);
						this.describeAColumn(table, '!idreg_studenti_registry_idanpr', 'Idanpr', null, 29, null);
						objCalcFieldConfig['!idreg_studenti_registry_surname'] = { tableNameLookup:'registry', columnNameLookup:'surname', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_forename'] = { tableNameLookup:'registry', columnNameLookup:'forename', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_extmatricula'] = { tableNameLookup:'registry', columnNameLookup:'extmatricula', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_idanpr'] = { tableNameLookup:'registry', columnNameLookup:'idanpr', columnNamekey:'idreg_studenti' };
//$objCalcFieldConfig_default$
						break;
					case 'doc':
						this.describeAColumn(table, 'assente', 'Assente', null, 20, null);
						this.describeAColumn(table, 'ritardo', 'Ritardo', 'g', 30, null);
						this.describeAColumn(table, 'ritardogiustifica', 'Giustificazione del ritardo', null, 40, 1024);
						this.describeAColumn(table, 'notadisciplinare', 'Nota disciplinare', null, 50, 1024);
						this.describeAColumn(table, '!idreg_studenti_registry_surname', 'Cognome', null, 11, null);
						this.describeAColumn(table, '!idreg_studenti_registry_forename', 'Nome', null, 12, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 14, null);
						this.describeAColumn(table, '!idreg_studenti_registry_extmatricula', 'Matricola', null, 15, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 16, null);
						objCalcFieldConfig['!idreg_studenti_registry_surname'] = { tableNameLookup:'registry', columnNameLookup:'surname', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_forename'] = { tableNameLookup:'registry', columnNameLookup:'forename', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_extmatricula'] = { tableNameLookup:'registry', columnNameLookup:'extmatricula', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_studenti' };
//$objCalcFieldConfig_doc$
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
						table.columns["idlezione"].caption = "Lezione";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idreg_studenti"].caption = "Studente";
						table.columns["notadisciplinare"].caption = "Nota disciplinare";
						table.columns["ritardogiustifica"].caption = "Giustificazione del ritardo";
//$innerSetCaptionConfig_default$
						break;
					case 'doc':
//$innerSetCaptionConfig_doc$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontlezionestud");

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

    window.appMeta.addMeta('rendicontlezionestud', new meta_rendicontlezionestud('rendicontlezionestud'));

	}());
