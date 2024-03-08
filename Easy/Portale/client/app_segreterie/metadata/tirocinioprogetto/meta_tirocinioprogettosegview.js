(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirocinioprogettosegview() {
        MetaData.apply(this, ["tirocinioprogettosegview"]);
        this.name = 'meta_tirocinioprogettosegview';
    }

    meta_tirocinioprogettosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioprogettosegview,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, -1);
						this.describeAColumn(table, 'tirocinioprogetto_description', 'Descrizione', null, 3000, -1);
						this.describeAColumn(table, 'tirocinioprogetto_competenze', 'Competenze', null, 4000, -1);
						this.describeAColumn(table, 'tirocinioprogetto_datafineeffettiva', 'Data fine effettiva', null, 5000, null);
						this.describeAColumn(table, 'tirocinioprogetto_datafineprevista', 'Data fine prevista', null, 6000, null);
						this.describeAColumn(table, 'tirocinioprogetto_datainizioeffettiva', 'Data inizio effettiva', null, 7000, null);
						this.describeAColumn(table, 'tirocinioprogetto_datainizioprevista', 'Data inizio prevista', null, 8000, null);
						this.describeAColumn(table, 'tirocinioprogetto_dataverbale', 'Data verbale', null, 9000, null);
						this.describeAColumn(table, 'tirocinioprogetto_description_en', 'Descrizione in inglese', null, 10000, -1);
						this.describeAColumn(table, 'aoo_title', 'Area organizzativa omogenea', null, 11200, 1024);
						this.describeAColumn(table, 'registrydocenti_title', 'Tutor', null, 12300, 101);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 15200, 1024);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura didattica', null, 16100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura didattica', null, 16220, 50);
						this.describeAColumn(table, 'tirociniostato_title', 'Stato del tirocinio', null, 19200, 50);
						this.describeAColumn(table, 'tirocinioprogetto_ore', 'Ore', null, 20000, null);
						this.describeAColumn(table, 'tirocinioprogetto_tempiaccesso', 'Tempi di accesso', null, 23000, -1);
						this.describeAColumn(table, 'tirocinioprogetto_title_en', 'Titolo in inglese', null, 24000, -1);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg_studenti", "idreg_referente", "idtirocinioprogetto", "idtirocinioproposto", "idtirociniocandidatura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc, tirocinioprogetto_description desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirocinioprogettosegview', new meta_tirocinioprogettosegview('tirocinioprogettosegview'));

	}());
