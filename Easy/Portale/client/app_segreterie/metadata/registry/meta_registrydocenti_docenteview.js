(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrydocenti_docenteview() {
        MetaData.apply(this, ["registrydocenti_docenteview"]);
        this.name = 'meta_registrydocenti_docenteview';
    }

    meta_registrydocenti_docenteview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrydocenti_docenteview,
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
					case 'docenti_docente':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 1000, null);
						this.describeAColumn(table, 'sasd_codice', 'Codice SASD', null, 2200, 50);
						this.describeAColumn(table, 'sasd_title', 'Denominazione SASD', null, 2300, 255);
						this.describeAColumn(table, 'title', 'Denominazione', null, 3000, 101);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di afferenza', null, 3100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura di afferenza', null, 3220, 50);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registryistituti_title', 'Istituto, Ente o Azienda', null, 4100, 101);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 5000, 15);
						this.describeAColumn(table, 'classconsorsuale_title', 'Classe consorsuale', null, 5100, 50);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 6000, null);
//$objCalcFieldConfig_docenti_docente$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docenti_docente": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('registrydocenti_docenteview', new meta_registrydocenti_docenteview('registrydocenti_docenteview'));

	}());
