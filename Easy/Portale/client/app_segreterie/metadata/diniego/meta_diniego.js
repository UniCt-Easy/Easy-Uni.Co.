(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_diniego() {
        MetaData.apply(this, ["diniego"]);
        this.name = 'meta_diniego';
    }

    meta_diniego.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_diniego,
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
					case 'seganagstupre':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_seganagstupre$
						break;
					case 'seganagsturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_seganagsturin$
						break;
					case 'segpratica':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_segpratica$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_seganagstu$
						break;
					case 'noiscr':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_noiscr$
						break;
					case 'stupass':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_stupass$
						break;
					case 'stueq':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_stueq$
						break;
					case 'stutru':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_stutru$
						break;
					case 'sturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_sturin$
						break;
					case 'stutri':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_stutri$
						break;
					case 'imm_stu':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_imm_stu$
						break;
					case 'imm_sturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
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
					case 'seganagsturin':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_seganagsturin$
						break;
					case 'seganagstu':
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'seganagstupre':
//$innerSetCaptionConfig_seganagstupre$
						break;
					case 'noiscr':
//$innerSetCaptionConfig_noiscr$
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
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_diniego");

				//$getNewRowInside$

				dt.autoIncrement('iddiniego', { minimum: 99990001 });

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

    window.appMeta.addMeta('diniego', new meta_diniego('diniego'));

	}());
