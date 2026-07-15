(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollo() {
        MetaData.apply(this, ["protocollo"]);
        this.name = 'meta_protocollo';
    }

    meta_protocollo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollo,
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
					case 'seg':
						this.describeAColumn(table, '!anteprima', 'Anteprima Segnatura', null, 0, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 10, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 20, null);
						this.describeAColumn(table, 'protdata', 'Data di protocollo', null, 40, null);
						this.describeAColumn(table, 'codiceammipa', 'Codice IPA dell\'Istituto', null, 60, 50);
						this.describeAColumn(table, 'originemail', 'E-mail mittente', null, 90, 512);
						this.describeAColumn(table, 'originecodiceaoo', 'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea', null, 100, 50);
						this.describeAColumn(table, 'origineidamm', 'Amministrazione pubblica mittente - Codice IPA', null, 110, 1024);
						this.describeAColumn(table, 'oggetto', 'Oggetto del documento', null, 120, 1024);
						this.describeAColumn(table, 'annullato', 'Annullato', null, 200, null);
						this.describeAColumn(table, 'dataannullamento', 'Data di annullamento', 'g', 210, null);
						this.describeAColumn(table, 'motivoann', 'Motivo annullamento', null, 220, -1);
						this.describeAColumn(table, 'protannoregistro', 'Anno di protocollo del registro', null, 270, null);
						this.describeAColumn(table, 'protregistro', 'Numero di protocollo del registro', null, 280, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["!anteprima"].caption = "Anteprima Segnatura";
						table.columns["codiceammipa"].caption = "Codice IPA dell'Istituto";
						table.columns["codiceregistro"].caption = "Codice Registro (univoco nell'Istituto)";
						table.columns["dataannullamento"].caption = "Data di annullamento";
						table.columns["idaoo"].caption = "Area organizzativa omogenea";
						table.columns["idclassificazioneprotocollo"].caption = "Sottoclassificazione 1";
						table.columns["idclassificazioneprotocollo_2"].caption = "Sottoclassificazione 2";
						table.columns["idprotocollokind"].caption = "Ingresso - Uscita - Interno";
						table.columns["idqueryregistry"].caption = "Tipologia di destinatari";
						table.columns["idreg_origine"].caption = "Mittente";
						table.columns["motivoann"].caption = "Motivo annullamento";
						table.columns["oggetto"].caption = "Oggetto del documento";
						table.columns["originecodiceaoo"].caption = "Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea";
						table.columns["origineidamm"].caption = "Amministrazione pubblica mittente - Codice IPA";
						table.columns["originemail"].caption = "E-mail mittente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protannoregistro"].caption = "Anno di protocollo del registro";
						table.columns["protdata"].caption = "Data di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
						table.columns["protregistro"].caption = "Numero di protocollo del registro";
						table.columns["testo"].caption = "Testo del documento (alternativamente al descrittore del documento)";
						table.columns["testosegnatura"].caption = "Segnatura";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_protocollo");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$
				dt.autoIncrement('protnumero', { minimum: 99990001, selector: ["protanno"] });

				// metto i default
				var objRow = dt.newRow({
					protanno: new Date().getFullYear()
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
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

    window.appMeta.addMeta('protocollo', new meta_protocollo('protocollo'));

	}());
