(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattokind() {
        MetaData.apply(this, ["contrattokind"]);
        this.name = 'meta_contrattokind';
    }

    meta_contrattokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattokind,
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
						this.describeAColumn(table, 'active', 'Attivo', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'oremaxgg', 'Ore di lavoro al giorno massime', null, 30, null);
						this.describeAColumn(table, 'costolordoannuo', 'Costo lordo annuo', 'fixed.2', 200, null);
						this.describeAColumn(table, 'costolordoannuooneri', 'Costo lordo annuo e oneri', 'fixed.2', 210, null);
						this.describeAColumn(table, 'puntiorganico', 'Punti organico', 'fixed.2', 230, null);
						this.describeAColumn(table, 'tipopersonale', 'Categoria di personale', null, 260, null);
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
						table.columns["assegnoaggiuntivo"].caption = "Abilita assegno aggiuntivo";
						table.columns["costolordoannuo"].caption = "Costo lordo annuo";
						table.columns["costolordoannuooneri"].caption = "Costo lordo annuo e oneri";
						table.columns["elementoperequativo"].caption = "Abilita elemento perequativo";
						table.columns["indennitadiateneo"].caption = "Abilita indennità di ateneo";
						table.columns["indennitadiposizione"].caption = "Abilita indennità di posizione";
						table.columns["indvacancacontrattuale"].caption = "Abilita ind. vacanca contrattuale";
						table.columns["oremaxcompitididatempoparziale"].caption = "Ore massime per i compiti didattici a tempo parziale";
						table.columns["oremaxcompitididatempopieno"].caption = "Ore massime per i compiti didattici a tempo pieno";
						table.columns["oremaxdidatempoparziale"].caption = "Ore massime per didattica frontale a tempo parziale";
						table.columns["oremaxdidatempopieno"].caption = "Ore massime per didattica frontale a tempo pieno";
						table.columns["oremaxgg"].caption = "Ore di lavoro al giorno massime";
						table.columns["oremaxtempoparziale"].caption = "Ore massime a tempo parziale";
						table.columns["oremaxtempopieno"].caption = "Ore massime a tempo pieno";
						table.columns["oremincompitididatempoparziale"].caption = "Ore minime per i compiti didattici a tempo parziale";
						table.columns["oremincompitididatempopieno"].caption = "Ore minime per i compiti didattici a tempo pieno";
						table.columns["oremindidatempoparziale"].caption = "Ore minime di didattica frontale a tempo parziale";
						table.columns["oremindidatempopieno"].caption = "Ore minime di didattica frontale a tempo pieno";
						table.columns["oremintempoparziale"].caption = "Ore minime a tempo parziale";
						table.columns["oremintempopieno"].caption = "Ore minime a tempo pieno";
						table.columns["orestraordinariemax"].caption = "Ore massime di straordinario rendicontabili";
						table.columns["parttime"].caption = "Abilita part-time";
						table.columns["puntiorganico"].caption = "Punti organico";
						table.columns["scatto"].caption = "Abilita scatti stipendio";
						table.columns["siglaesportazione"].caption = "Sigla esportazione";
						table.columns["siglaimportazione"].caption = "Sigla importazione";
						table.columns["tempdef"].caption = "Abilita tempo definito o parziale";
						table.columns["totaletredicesima"].caption = "Abilita totale tredicesima";
						table.columns["tredicesimaindennitaintegrativaspeciale"].caption = "Abilita tredicesima indennità integrativa speciale";
						table.columns["idcontrattokind"].caption = "Tipologia del contratto";
						table.columns["tipopersonale"].caption = "Categoria di personale";
						table.columns["indvacancacontrattuale"].caption = "Abilita ind. vacanza contrattuale";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_contrattokind");

				//$getNewRowInside$

				dt.autoIncrement('idcontrattokind', { minimum: 99990001 });

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
						return "active desc, title asc ";
					}
					case "default": {
						return "active desc, title asc , sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('contrattokind', new meta_contrattokind('contrattokind'));

	}());
