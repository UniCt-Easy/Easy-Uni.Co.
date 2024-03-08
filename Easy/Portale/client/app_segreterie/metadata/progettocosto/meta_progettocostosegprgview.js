(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettocostosegprgview() {
        MetaData.apply(this, ["progettocostosegprgview"]);
        this.name = 'meta_progettocostosegprgview';
    }

    meta_progettocostosegprgview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettocostosegprgview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'segprg':
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 1100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 1200, 2048);
						this.describeAColumn(table, 'progettotipocosto_title', 'Voce di costo', null, 2100, 2048);
						this.describeAColumn(table, 'progettocosto_amount', 'Importo', 'fixed.2', 3000, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_idreg', 'Partecipante Attività svolta', null, 4100, null);
						this.describeAColumn(table, 'position_title', 'Tipo di contratto', null, 4200, 50);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Descrizione Attività svolta', null, 4300, -1);
						this.describeAColumn(table, 'progettocosto_doc', 'Documento collegato', null, 5000, 35);
						this.describeAColumn(table, 'progettocosto_docdate', 'Data del documento collegato', null, 6000, null);
						this.describeAColumn(table, 'expense_description', 'Descrizione Spesa', null, 7100, 150);
						this.describeAColumn(table, 'expense_ymov', 'Anno movimento Spesa', null, 7200, null);
						this.describeAColumn(table, 'expense_nmov', 'N.movimento Spesa', null, 7300, null);
						this.describeAColumn(table, 'pettycash_description', 'Descrizione Fondo economale', null, 8200, 50);
						this.describeAColumn(table, 'pettycash_pettycode', 'Codice Fondo economale', null, 8200, 20);
						this.describeAColumn(table, 'progettocosto_yoperation', 'Esercizio operazione', null, 9000, null);
						this.describeAColumn(table, 'progettocosto_noperation', 'Numero operazione', null, 10000, null);
						this.describeAColumn(table, 'assetdiaryora_idassetdiary', 'Identificativo Diario d\'uso del bene strumentale', null, 14400, null);
						this.describeAColumn(table, 'assetdiaryora_start', 'Data e ora di inizio Diario d\'uso del bene strumentale', 'g', 14800, null);
						this.describeAColumn(table, 'assetdiaryora_stop', 'Data e ora di fine Diario d\'uso del bene strumentale', 'g', 14900, null);
						this.describeAColumn(table, 'salprogettoassetworkpackagemese_idsalprogettoassetworkpackage', 'Identificativo Uso del bene strumentale', null, 15100, null);
						this.describeAColumn(table, 'salprogettoassetworkpackagemese_year', 'Anno Uso del bene strumentale', null, 15200, null);
						this.describeAColumn(table, 'mese_title', 'Mese Mese Uso del bene strumentale', null, 15320, 64);
						this.describeAColumn(table, 'salprogettoassetworkpackagemese_amount', 'Importo Uso del bene strumentale', 'fixed.2', 15400, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato avanzamento lavori', null, 20100, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato avanzamento lavori', null, 20400, null);
//$objCalcFieldConfig_segprg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto", "idprogettocosto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segprg": {
						return "progettotipocosto_title asc ";
					}
					case "segprg": {
						return "workpackage_raggruppamento asc , workpackage_title asc , progettotipocosto_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettocostosegprgview', new meta_progettocostosegprgview('progettocostosegprgview'));

	}());
