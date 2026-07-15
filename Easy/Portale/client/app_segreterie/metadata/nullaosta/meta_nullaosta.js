(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_nullaosta() {
        MetaData.apply(this, ["nullaosta"]);
        this.name = 'meta_nullaosta';
    }

    meta_nullaosta.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_nullaosta,
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
					case 'segisteq':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segisteq$
						break;
					case 'segistsosp':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segistsosp$
						break;
					case 'segistrin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segistrin$
						break;
					case 'segisttru':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segisttru$
						break;
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagstupre$
						break;
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segistrein$
						break;
					case 'segpratica':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_segpratica$
						break;
					case 'imm_seganagstu':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagstu$
						break;
					case 'seganagstupratica':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_seganagstupratica$
						break;
					case 'stupass':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_stupass$
						break;
					case 'stueq':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_stueq$
						break;
					case 'stutru':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_stutru$
						break;
					case 'sturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_sturin$
						break;
					case 'stutri':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_stutri$
						break;
					case 'imm_stu':
						this.describeAColumn(table, 'data', 'Data', 'g', 50, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 60, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 70, null);
//$objCalcFieldConfig_imm_stu$
						break;
					case 'imm_sturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 50, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 60, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 70, null);
//$objCalcFieldConfig_imm_sturin$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seganagstupratica':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_seganagstupratica$
						break;
					case 'segisteq':
//$innerSetCaptionConfig_segisteq$
						break;
					case 'stupass':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_stupass$
						break;
					case 'stueq':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_stueq$
						break;
					case 'stutru':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_stutru$
						break;
					case 'sturin':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_sturin$
						break;
					case 'stutri':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_stutri$
						break;
					case 'imm_stu':
//$innerSetCaptionConfig_imm_stu$
						break;
					case 'imm_sturin':
//$innerSetCaptionConfig_imm_sturin$
						break;
					case 'segisttru':
//$innerSetCaptionConfig_segisttru$
						break;
					case 'segistsosp':
						table.columns["iddidprog"].caption = "Didattica programmata";
//$innerSetCaptionConfig_segistsosp$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_nullaosta");

				//$getNewRowInside$

				dt.autoIncrement('idnullaosta', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('nullaosta', new meta_nullaosta('nullaosta'));

	}());
