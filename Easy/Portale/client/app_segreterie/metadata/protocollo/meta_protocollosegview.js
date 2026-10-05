(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollosegview() {
        MetaData.apply(this, ["protocollosegview"]);
        this.name = 'meta_protocollosegview';
    }

    meta_protocollosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollosegview,
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
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 1000, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 2000, null);
						this.describeAColumn(table, 'protocollokind_title', 'Ingresso - Uscita - Interno', null, 3200, 255);
						this.describeAColumn(table, 'protocollo_protdata', 'Data di protocollo', null, 4000, null);
						this.describeAColumn(table, 'protocollo_codiceammipa', 'Codice IPA dell\'Istituto', null, 6000, 50);
						this.describeAColumn(table, 'aoo_title', 'Area organizzativa omogenea', null, 7200, 1024);
						this.describeAColumn(table, 'registryorigine_title', 'Mittente', null, 8300, 101);
						this.describeAColumn(table, 'protocollo_originemail', 'E-mail mittente', null, 9000, 512);
						this.describeAColumn(table, 'protocollo_originecodiceaoo', 'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea', null, 10000, 50);
						this.describeAColumn(table, 'protocollo_origineidamm', 'Amministrazione pubblica mittente - Codice IPA', null, 11000, 1024);
						this.describeAColumn(table, 'protocollo_oggetto', 'Oggetto del documento', null, 12000, 1024);
						this.describeAColumn(table, 'classificazioneprotocollo_title', 'Sottoclassificazione 1', null, 13200, 1024);
						this.describeAColumn(table, 'classificazioneprotocollo2_title', 'Sottoclassificazione 2', null, 14200, 1024);
						this.describeAColumn(table, 'protocollo_annullato', 'Annullato', null, 20000, null);
						this.describeAColumn(table, 'protocollo_dataannullamento', 'Data di annullamento', 'g', 21000, null);
						this.describeAColumn(table, 'protocollo_motivoann', 'Motivo annullamento', null, 22000, -1);
						this.describeAColumn(table, 'protocollo_protannoregistro', 'Anno di protocollo del registro', null, 27000, null);
						this.describeAColumn(table, 'protocollo_protregistro', 'Numero di protocollo del registro', null, 28000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["protanno", "protnumero"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "protnumero desc, protanno desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('protocollosegview', new meta_protocollosegview('protocollosegview'));

	}());
