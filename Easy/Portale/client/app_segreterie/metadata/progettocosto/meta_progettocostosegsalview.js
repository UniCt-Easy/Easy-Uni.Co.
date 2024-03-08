(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettocostosegsalview() {
        MetaData.apply(this, ["progettocostosegsalview"]);
        this.name = 'meta_progettocostosegsalview';
    }

    meta_progettocostosegsalview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettocostosegsalview,
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
					case 'segsal':
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 1100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 1200, 2048);
						this.describeAColumn(table, 'progettotipocosto_title', 'Voce di costo', null, 2100, 2048);
						this.describeAColumn(table, 'progettocosto_amount', 'Importo', 'fixed.2', 3000, null);
						this.describeAColumn(table, 'position_title', 'Tipo di contratto', null, 3200, 50);
						this.describeAColumn(table, 'rendicontattivitaprogetto_idreg', 'Partecipante Attività svolta', null, 5100, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Descrizione Attività svolta', null, 5300, -1);
						this.describeAColumn(table, 'progettocosto_doc', 'Documento collegato', null, 6000, 35);
						this.describeAColumn(table, 'progettocosto_docdate', 'Data del documento collegato', null, 7000, null);
						this.describeAColumn(table, 'expense_description', 'Descrizione Spesa', null, 8100, 150);
						this.describeAColumn(table, 'expense_ymov', 'Anno movimento Spesa', null, 8200, null);
						this.describeAColumn(table, 'expense_nmov', 'N.movimento Spesa', null, 8300, null);
						this.describeAColumn(table, 'pettycash_description', 'Descrizione Fondo economale', null, 9200, 50);
						this.describeAColumn(table, 'pettycash_pettycode', 'Codice Fondo economale', null, 9200, 20);
						this.describeAColumn(table, 'progettocosto_yoperation', 'Esercizio operazione', null, 10000, null);
						this.describeAColumn(table, 'progettocosto_noperation', 'Numero operazione', null, 11000, null);
						this.describeAColumn(table, 'assetdiaryora_idassetdiary', 'Identificativo Diario d\'uso del bene strumentale', null, 12400, null);
						this.describeAColumn(table, 'assetdiaryora_start', 'Data e ora di inizio Diario d\'uso del bene strumentale', 'g', 12800, null);
						this.describeAColumn(table, 'assetdiaryora_stop', 'Data e ora di fine Diario d\'uso del bene strumentale', 'g', 12900, null);
						this.describeAColumn(table, 'salprogettoassetworkpackagemese_idsalprogettoassetworkpackage', 'Identificativo Uso del bene strumentale', null, 13100, null);
						this.describeAColumn(table, 'salprogettoassetworkpackagemese_year', 'Anno Uso del bene strumentale', null, 13200, null);
						this.describeAColumn(table, 'mese_title', 'Mese Mese Uso del bene strumentale', null, 13320, 64);
						this.describeAColumn(table, 'salprogettoassetworkpackagemese_amount', 'Importo Uso del bene strumentale', 'fixed.2', 13400, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato avanzamento lavori', null, 14100, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato avanzamento lavori', null, 14400, null);
//$objCalcFieldConfig_segsal$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto", "idworkpackage", "idprogettocosto", "idprogettotipocosto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segsal": {
						return "progettotipocosto_title asc ";
					}
					case "segsal": {
						return "workpackage_raggruppamento asc , workpackage_title asc , progettotipocosto_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettocostosegsalview', new meta_progettocostosegsalview('progettocostosegsalview'));

	}());
