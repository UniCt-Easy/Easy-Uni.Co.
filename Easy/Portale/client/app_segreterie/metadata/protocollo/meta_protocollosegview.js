﻿(function() {

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
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 10, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 20, null);
						this.describeAColumn(table, 'protocollo_protdata', 'Data di protocollo', null, 30, null);
						this.describeAColumn(table, 'protocollo_codiceregistro', 'Codice Registro (univoco nell\'Istituto)', null, 40, 1024);
						this.describeAColumn(table, 'protocollo_codiceammipa', 'Codice IPA dell\'Istituto', null, 50, 50);
						this.describeAColumn(table, 'aoo_title', 'Area organizzativa omogenea', null, 60, 1024);
						this.describeAColumn(table, 'registryorigine_title', 'Mittente', null, 70, 101);
						this.describeAColumn(table, 'protocollo_originemail', 'E-mail mittente', null, 80, 512);
						this.describeAColumn(table, 'protocollo_originecodiceaoo', 'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea', null, 90, 50);
						this.describeAColumn(table, 'protocollo_origineidamm', 'Amministrazione pubblica mittente - Codice IPA', null, 100, 50);
						this.describeAColumn(table, 'protocollo_oggetto', 'Oggetto del documento', null, 110, 1024);
						this.describeAColumn(table, 'protocollo_annullato', 'Annullato', null, 120, null);
						this.describeAColumn(table, 'protocollo_dataannullamento', 'Data di annullamento', 'g', 180, null);
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

			//$getSorting$

        });

    window.appMeta.addMeta('protocollosegview', new meta_protocollosegview('protocollosegview'));

	}());
