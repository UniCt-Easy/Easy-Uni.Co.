(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contratto() {
        MetaData.apply(this, ["contratto"]);
        this.name = 'meta_contratto';
    }

    meta_contratto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contratto,
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
						this.describeAColumn(table, 'start', 'Inizio', null, 30, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 40, null);
						this.describeAColumn(table, 'parttime', 'Part-time %', 'fixed.2', 50, null);
						this.describeAColumn(table, 'tempdef', 'Tempo definito', null, 70, null);
						this.describeAColumn(table, 'tempindet', 'Tempo indeterminato', null, 80, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 110, null);
						this.describeAColumn(table, 'classe', 'Classe', null, 120, null);
						this.describeAColumn(table, 'percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 140, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Tipologia di contratto', null, 11, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
						this.describeAColumn(table, '!idinquadramento_inquadramento_title', 'Denominazione Inquadramento', null, 21, null);
						this.describeAColumn(table, '!idinquadramento_inquadramento_tempdef', 'Tempo definito Inquadramento', null, 22, null);
						objCalcFieldConfig['!idinquadramento_inquadramento_title'] = { tableNameLookup:'inquadramento', columnNameLookup:'title', columnNamekey:'idinquadramento' };
						objCalcFieldConfig['!idinquadramento_inquadramento_tempdef'] = { tableNameLookup:'inquadramento', columnNameLookup:'tempdef', columnNamekey:'idinquadramento' };
//$objCalcFieldConfig_default$
						break;
					case 'amm':
						this.describeAColumn(table, 'start', 'Inizio', null, 30, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 40, null);
						this.describeAColumn(table, 'parttime', 'Part-time %', 'fixed.2', 50, null);
						this.describeAColumn(table, 'tempindet', 'Tempo indeterminato', null, 80, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 110, null);
						this.describeAColumn(table, 'datarivalutazione', 'Data di prossima rivalutazione', null, 130, null);
						this.describeAColumn(table, 'percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 140, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Tipologia di contratto', null, 11, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
						this.describeAColumn(table, '!idinquadramento_inquadramento_title', 'Denominazione Inquadramento', null, 21, null);
						this.describeAColumn(table, '!idinquadramento_inquadramento_tempdef', 'Tempo definito Inquadramento', null, 22, null);
						objCalcFieldConfig['!idinquadramento_inquadramento_title'] = { tableNameLookup:'inquadramento', columnNameLookup:'title', columnNamekey:'idinquadramento' };
						objCalcFieldConfig['!idinquadramento_inquadramento_tempdef'] = { tableNameLookup:'inquadramento', columnNameLookup:'tempdef', columnNamekey:'idinquadramento' };
//$objCalcFieldConfig_amm$
						break;
					case 'prev':
						this.describeAColumn(table, 'percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 30, null);
						this.describeAColumn(table, 'start', 'Inizio', null, 40, null);
						this.describeAColumn(table, 'datarivalutazione', 'Data di prossima rivalutazione', null, 50, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 60, null);
						this.describeAColumn(table, 'parttime', 'Part-time %', 'fixed.2', 70, null);
						this.describeAColumn(table, 'tempindet', 'Tempo indeterminato', null, 80, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 110, null);
						this.describeAColumn(table, 'classe', 'Classe', null, 120, null);
//$objCalcFieldConfig_prev$
						break;
					case 'servizi':
						this.describeAColumn(table, 'istituzione', 'Istituzione', null, 10, 2048);
						this.describeAColumn(table, 'start', 'Inizio', null, 30, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 40, null);
						this.describeAColumn(table, 'anni', 'Anni', null, 150, null);
						this.describeAColumn(table, 'mesi', 'Mesi', null, 160, null);
						this.describeAColumn(table, 'giorni', 'Giorni', null, 170, null);
						this.describeAColumn(table, 'classe', 'Classe', null, 210, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 220, null);
						this.describeAColumn(table, 'parttime', 'Part-time %', 'fixed.2', 230, null);
						this.describeAColumn(table, 'tempdef', 'Tempo definito', null, 240, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Tipologia di contratto', null, 201, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
//$objCalcFieldConfig_servizi$
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
						table.columns["estremibando"].caption = "Estremi del bando di contratto";
						table.columns["idcontratto"].caption = "Codice";
						table.columns["idcontrattokind"].caption = "Tipologia di contratto";
						table.columns["idinquadramento"].caption = "Inquadramento";
						table.columns["idreg"].caption = "Docente";
						table.columns["parttime"].caption = "Part-time %";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["tempdef"].caption = "Tempo definito";
						table.columns["tempindet"].caption = "Tempo indeterminato";
						table.columns["classe"].caption = "Classe";
						table.columns["datarivalutazione"].caption = "Data di prossima rivalutazione";
						table.columns["scatto"].caption = "Scatto";
						table.columns["percentualesufondiateneo"].caption = "Percentuale su fondi interni";
//$innerSetCaptionConfig_default$
						break;
					case 'amm':
						table.columns["classe"].caption = "Classe";
						table.columns["datarivalutazione"].caption = "Data di prossima rivalutazione";
						table.columns["estremibando"].caption = "Estremi del bando di contratto";
						table.columns["idcontratto"].caption = "Codice";
						table.columns["idcontrattokind"].caption = "Tipologia di contratto";
						table.columns["idinquadramento"].caption = "Inquadramento";
						table.columns["idreg"].caption = "Docente";
						table.columns["parttime"].caption = "Part-time %";
						table.columns["scatto"].caption = "Scatto";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["tempdef"].caption = "Tempo definito";
						table.columns["tempindet"].caption = "Tempo indeterminato";
						table.columns["percentualesufondiateneo"].caption = "Percentuale su fondi interni";
//$innerSetCaptionConfig_amm$
						break;
					case 'prev':
						table.columns["classe"].caption = "Classe";
						table.columns["datarivalutazione"].caption = "Data di prossima rivalutazione";
						table.columns["estremibando"].caption = "Estremi del bando di contratto";
						table.columns["idcontratto"].caption = "Codice";
						table.columns["idcontrattokind"].caption = "Tipologia di contratto";
						table.columns["idinquadramento"].caption = "Inquadramento";
						table.columns["idreg"].caption = "Docente";
						table.columns["parttime"].caption = "Part-time %";
						table.columns["percentualesufondiateneo"].caption = "Percentuale su fondi interni";
						table.columns["scatto"].caption = "Scatto";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["tempdef"].caption = "Tempo definito";
						table.columns["tempindet"].caption = "Tempo indeterminato";
//$innerSetCaptionConfig_prev$
						break;
					case 'servizi':
						table.columns["classe"].caption = "Classe";
						table.columns["datarivalutazione"].caption = "Data di prossima rivalutazione";
						table.columns["estremibando"].caption = "Estremi del bando di contratto";
						table.columns["idcontratto"].caption = "Codice";
						table.columns["idcontrattokind"].caption = "Tipologia di contratto";
						table.columns["idinquadramento"].caption = "Inquadramento";
						table.columns["idreg"].caption = "Docente";
						table.columns["parttime"].caption = "Part-time %";
						table.columns["percentualesufondiateneo"].caption = "Percentuale su fondi interni";
						table.columns["scatto"].caption = "Scatto";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["tempdef"].caption = "Tempo definito";
						table.columns["tempindet"].caption = "Tempo indeterminato";
						table.columns["classe"].caption = "Anzianità minima di fascia";
//$innerSetCaptionConfig_servizi$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_contratto");

				//$getNewRowInside$

				dt.autoIncrement('idcontratto', { minimum: 99990001 });

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
					case "amm": {
						return "start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('contratto', new meta_contratto('contratto'));

	}());
