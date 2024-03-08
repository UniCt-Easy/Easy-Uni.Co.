(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_perfvalutazioneuo() {
		MetaData.apply(this, ["perfvalutazioneuo"]);
		this.name = 'meta_perfvalutazioneuo';
	}

	meta_perfvalutazioneuo.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_perfvalutazioneuo,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'risultato', 'Risultato %', 'fixed.2', 30, null);
						this.describeAColumn(table, 'pesoproguo', 'Peso della valutazione della performance dei Progetti Strategici della UO', 'fixed.2', 70, null);
						this.describeAColumn(table, 'completamentopsuo', 'Percentuale di completamento per i progetti Strategici della UO', 'fixed.2', 80, null);
						this.describeAColumn(table, 'pesoprogaltreuo', 'Peso della valutazione della performance dei Progetti Strategici di altre UO ', 'fixed.2', 100, null);
						this.describeAColumn(table, 'completamentopsauo', 'Percentuale di completamento dei progetti Strategici di altre UO', 'fixed.2', 110, null);
						this.describeAColumn(table, 'pesoindicatori', 'Peso della valutazione della performance degli indicatori', 'fixed.2', 130, null);
						this.describeAColumn(table, 'indicatori', 'Percentuale di completamento degli indicatori', 'fixed.2', 140, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi una tantum', 'fixed.2', 160, null);
						this.describeAColumn(table, 'obiettiviindividuali', 'Percentuale di completamento degli obiettivi una tantum', 'fixed.2', 170, null);
//$objCalcFieldConfig_default$
						break;
										case 'onlyunatantum':
						this.describeAColumn(table, 'year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'risultato', 'Risultato %', 'fixed.2', 30, null);
						this.describeAColumn(table, 'obiettiviindividuali', 'Percentuale di completamento degli obiettivi organizzativi', 'fixed.2', 260, null);
//$objCalcFieldConfig_onlyunatantum$
						break;
					case 'upo':
						this.describeAColumn(table, 'year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'risultato', 'Risultato %', 'fixed.2', 30, null);
						this.describeAColumn(table, 'pesoproguo', 'Peso della valutazione della performance dei progetti strategici della UO', 'fixed.2', 70, null);
						this.describeAColumn(table, 'completamentopsuo', 'Percentuale di completamento per i progetti strategici della UO', 'fixed.2', 80, null);
						this.describeAColumn(table, 'pesoprogaltreuo', 'Peso della valutazione della performance degli obiettivi dei progetti strategici di altre UO ', 'fixed.2', 100, null);
						this.describeAColumn(table, 'completamentopsauo', 'Percentuale di completamento degli obiettivi dei progetti strategici di altre UO', 'fixed.2', 110, null);
						this.describeAColumn(table, 'pesoindicatori', 'Peso della valutazione della performance degli indicatori', 'fixed.2', 130, null);
						this.describeAColumn(table, 'indicatori', 'Percentuale di completamento degli indicatori', 'fixed.2', 140, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi una tantum', 'fixed.2', 160, null);
						this.describeAColumn(table, 'obiettiviindividuali', 'Percentuale di completamento degli obiettivi una tantum', 'fixed.2', 170, null);
						this.describeAColumn(table, 'motivazione', 'Motivazione', null, 260, -1);
//$objCalcFieldConfig_upo$
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
						table.columns["completamentopsauo"].caption = "Percentuale di completamento dei progetti Strategici di altre UO";
						table.columns["completamentopsuo"].caption = "Percentuale di completamento per i progetti Strategici della UO";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg_val"].caption = "Valutatore";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["indicatori"].caption = "Percentuale di completamento degli indicatori";
						table.columns["obiettiviindividuali"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori ";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi una tantum";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance dei Progetti Strategici di altre UO ";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei Progetti Strategici della UO";
						table.columns["risultato"].caption = "Risultato %";
						table.columns["year"].caption = "Anno solare";
						table.columns["completamentopsauo"].caption = "Percentuale di completamento dei progetti Strategici di altre UO";
						table.columns["completamentopsuo"].caption = "Percentuale di completamento per i progetti Strategici della UO";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg_val"].caption = "Valutatore";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["indicatori"].caption = "Percentuale di completamento degli indicatori";
						table.columns["obiettiviindividuali"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori ";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi una tantum";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance dei Progetti Strategici di altre UO ";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei Progetti Strategici della UO";
						table.columns["risultato"].caption = "Risultato %";
						table.columns["year"].caption = "Anno solare";
						table.columns["completamentopsauo"].caption = "Percentuale di completamento dei progetti Strategici di altre UO";
						table.columns["obiettiviindividuali"].caption = "Percentuale di completamento degli obiettivi una tantum";
						table.columns["idreg_appr"].caption = "Approvatore";
												table.columns["idstruttura"].caption = "Unità organizzativa";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori";
						table.columns["idreg_appr"].caption = "Compilatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi una tantum";
						table.columns["idreg_compobborg"].caption = "Compilatore indicatori";
						table.columns["idreg_create"].caption = "Inserisce obiettivi una tantum";
						table.columns["idreg_val"].caption = "Valutatore obiettivi una tantum";
						table.columns["idreg_valobborg"].caption = "Valutatore indicatori";
//$innerSetCaptionConfig_default$
						break;
										case 'onlyunatantum':
						table.columns["completamentopsauo"].caption = "Percentuale di completamento dei progetti Strategici di altre UO";
						table.columns["completamentopsuo"].caption = "Percentuale di completamento per i progetti Strategici della UO";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi organizzativi";
						table.columns["idreg_compobborg"].caption = "Compilatore indicatori";
						table.columns["idreg_create"].caption = "Inserisce obiettivi organizzativi";
						table.columns["idreg_val"].caption = "Valutatore obiettivi organizzativi";
						table.columns["idreg_valobborg"].caption = "Valutatore indicatori";
						table.columns["idstruttura"].caption = "Unità organizzativa";
						table.columns["indicatori"].caption = "Percentuale di completamento degli indicatori";
						table.columns["obiettiviindividuali"].caption = "Percentuale di completamento degli obiettivi una tantum";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi una tantum";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance dei Progetti Strategici di altre UO ";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei Progetti Strategici della UO";
						table.columns["risultato"].caption = "Risultato %";
						table.columns["year"].caption = "Anno solare";
						table.columns["indicatori"].caption = "Percentuale di completamento degli uffici sottostanti";
						table.columns["obiettiviindividuali"].caption = "Percentuale di completamento degli obiettivi organizzativi";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli uffici sottostanti";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi organizzativi";
//$innerSetCaptionConfig_onlyunatantum$
						break;
					case 'upo':
						table.columns["completamentopsauo"].caption = "Percentuale di completamento degli obiettivi dei progetti strategici di altre UO";
						table.columns["completamentopsuo"].caption = "Percentuale di completamento per i progetti strategici della UO";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance degli obiettivi dei progetti strategici di altre UO ";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei progetti strategici della UO";
//$innerSetCaptionConfig_upo$
						break;
//$innerSetCaptionConfig$
				}
			},

			//isValid: function (r) {

			//	//Aggiungere calcolo media
			//	var self = this;
			//	if (!r.current.idperfschedastatus) {
			//		return this.superClass.isValid.call(this, r);
			//	}

			//	if (r.current.idperfschedastatus !== 1 && r.current.idperfschedastatus !== 2) {
			//		if ((r.current.pesoindicatori + r.current.pesoobiettivi + r.current.pesoproguo + r.current.pesoprogaltreuo) != 100) {
			//			return self.getPromiseIsValidObject("Attenzione la somma dei pesi non corrisponde al 100%", "risultato", "risultato", r);
			//		}
			//	}
			//	return this.superClass.isValid.call(this, r);

			//	//altre tabelle dataset
			//	//var ds = r.table.dataset;

			//},

			getNewRow: function (parentRow, dt, editType) {
				var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneuo");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazioneuo', { minimum: 99990001 });

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

	window.appMeta.addMeta('perfvalutazioneuo', new meta_perfvalutazioneuo('perfvalutazioneuo'));

}());
