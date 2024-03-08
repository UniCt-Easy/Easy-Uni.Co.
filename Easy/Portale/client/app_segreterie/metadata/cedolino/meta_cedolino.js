(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_cedolino() {
        MetaData.apply(this, ["cedolino"]);
        this.name = 'meta_cedolino';
    }

    meta_cedolino.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_cedolino,
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
						this.describeAColumn(table, '!previdenza', 'Opera di previdenza', 'fixed.2', 0, null);
						this.describeAColumn(table, '!tesoro', 'Tesoro', 'fixed.2', 0, null);
						this.describeAColumn(table, '!tredicesima', 'Tredicesima', 'fixed.2', 0, null);
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'idmese', 'Mese', null, 20, null);
						this.describeAColumn(table, 'classe', 'Classe', null, 30, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 40, null);
						this.describeAColumn(table, 'stipendio', 'Stipendio', 'fixed.2', 100, null);
						this.describeAColumn(table, 'iis', 'Indennità integrativa speciale', 'fixed.2', 110, null);
						this.describeAColumn(table, 'assegno', 'Assegno aggiuntivo', 'fixed.2', 120, null);
						this.describeAColumn(table, 'lordo', 'Retribuzione totale lorda', 'fixed.2', 130, null);
						this.describeAColumn(table, 'totalece', 'Totale a carico ente', 'fixed.2', 140, null);
						this.describeAColumn(table, 'irap', 'IRAP', 'fixed.2', 150, null);
						this.describeAColumn(table, 'totale', 'Totale', 'fixed.2', 160, null);
						this.describeAColumn(table, 'data', 'Data', null, 170, null);
						this.describeAColumn(table, '!idmese_mese_title', 'Mese', null, 21, null);
						objCalcFieldConfig['!idmese_mese_title'] = { tableNameLookup:'mese', columnNameLookup:'title', columnNamekey:'idmese' };
						this.describeAColumn(table, '!idcontratto_contratto_start', 'Inizio Idcontratto', null, 52, null);
						this.describeAColumn(table, '!idcontratto_contratto_stop', 'Fine Idcontratto', null, 53, null);
						this.describeAColumn(table, '!idcontratto_contratto_idcontrattokind_title', 'Tipologia di contratto Idcontratto', null, 50, null);
						objCalcFieldConfig['!idcontratto_contratto_start'] = { tableNameLookup:'contratto', columnNameLookup:'start', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_stop'] = { tableNameLookup:'contratto', columnNameLookup:'stop', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_idcontrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontratto' };
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
						table.columns["!previdenza"].caption = "Opera di previdenza";
						table.columns["!tesoro"].caption = "Tesoro";
						table.columns["!tredicesima"].caption = "Tredicesima";
						table.columns["assegno"].caption = "Assegno aggiuntivo";
						table.columns["data"].caption = "Data";
						table.columns["idmese"].caption = "Mese";
						table.columns["iis"].caption = "Indennità integrativa speciale";
						table.columns["irap"].caption = "IRAP";
						table.columns["lordo"].caption = "Retribuzione totale lorda";
						table.columns["totale"].caption = "Totale";
						table.columns["totalece"].caption = "Totale a carico ente";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_cedolino");

				//$getNewRowInside$

				dt.autoIncrement('idcedolino', { minimum: 99990001 });

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
						return "year asc , idmese asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('cedolino', new meta_cedolino('cedolino'));

	}());
