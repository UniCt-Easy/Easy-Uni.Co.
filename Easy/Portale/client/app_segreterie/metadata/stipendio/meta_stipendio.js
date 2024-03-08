(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_stipendio() {
        MetaData.apply(this, ["stipendio"]);
        this.name = 'meta_stipendio';
    }

    meta_stipendio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_stipendio,
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
						this.describeAColumn(table, '!totalece', 'Totale a carico ente', 'fixed.2', 0, null);
						this.describeAColumn(table, '!tredicesima', 'Tredicesima', 'fixed.2', 0, null);
						this.describeAColumn(table, 'classe', 'Classe', null, 10, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 20, null);
						this.describeAColumn(table, 'anzianitamin', 'Anno minimo di anzianità', null, 30, null);
						this.describeAColumn(table, 'anzianitamax', 'Anno massimo di anzianità', null, 40, null);
						this.describeAColumn(table, 'start', 'Data inizio validità', null, 50, null);
						this.describeAColumn(table, 'stop', 'Data fine validità', null, 60, null);
						this.describeAColumn(table, 'stipendio', 'Stipendio', 'fixed.2', 70, null);
						this.describeAColumn(table, 'iis', 'Indennità integrativa speciale', 'fixed.2', 80, null);
						this.describeAColumn(table, 'assegno', 'Assegno aggiuntivo', 'fixed.2', 90, null);
						this.describeAColumn(table, 'indennitaateneo', 'Indennità di Ateneo', 'fixed.2', 100, null);
						this.describeAColumn(table, 'elementoperequativo', 'Elemento perequativo', 'fixed.2', 110, null);
						this.describeAColumn(table, 'indennitaposizioneminima', 'Indennità posizione minima', 'fixed.2', 120, null);
						this.describeAColumn(table, 'lordonotredicesima', 'Retribuzione lorda senza tredicesima', 'fixed.2', 130, null);
						this.describeAColumn(table, 'lordo', 'Retribuzione totale lorda', 'fixed.2', 140, null);
						this.describeAColumn(table, 'irap', 'IRAP', 'fixed.2', 200, null);
						this.describeAColumn(table, 'totale', 'Totale costo annuo', 'fixed.2', 210, null);
						this.describeAColumn(table, 'rifnormativo', 'Riferimento normativo', null, 300, 2048);
						this.describeAColumn(table, 'siglaimportazione', 'Sigla importazione', null, 310, 1024);
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
						table.columns["!totalece"].caption = "Totale a carico ente";
						table.columns["!tredicesima"].caption = "Tredicesima";
						table.columns["anzianitamax"].caption = "Anno massimo di anzianità";
						table.columns["anzianitamin"].caption = "Anno minimo di anzianità";
						table.columns["assegno"].caption = "Assegno aggiuntivo";
						table.columns["elementoperequativo"].caption = "Elemento perequativo";
						table.columns["iis"].caption = "Indennità integrativa speciale";
						table.columns["indennitaateneo"].caption = "Indennità di Ateneo";
						table.columns["indennitaposizioneminima"].caption = "Indennità posizione minima";
						table.columns["irap"].caption = "IRAP";
						table.columns["lordo"].caption = "Retribuzione totale lorda";
						table.columns["lordonotredicesima"].caption = "Retribuzione lorda senza tredicesima";
						table.columns["rifnormativo"].caption = "Riferimento normativo";
						table.columns["siglaimportazione"].caption = "Sigla importazione";
						table.columns["start"].caption = "Data inizio validità";
						table.columns["stop"].caption = "Data fine validità";
						table.columns["totale"].caption = "Totale costo annuo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_stipendio");

				//$getNewRowInside$

				dt.autoIncrement('idstipendio', { minimum: 99990001 });

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
						return "anzianitamin asc , start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('stipendio', new meta_stipendio('stipendio'));

	}());
