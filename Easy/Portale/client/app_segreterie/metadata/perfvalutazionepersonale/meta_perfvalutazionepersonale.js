(function () {

   var MetaData = window.appMeta.MetaSegreterieData;

   function meta_perfvalutazionepersonale() {
      MetaData.apply(this, ["perfvalutazionepersonale"]);
      this.name = 'meta_perfvalutazionepersonale';
   }

   meta_perfvalutazionepersonale.prototype = _.extend(
      new MetaData(),
      {
         constructor: meta_perfvalutazionepersonale,
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
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'risultato', 'Percentuale risultato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'pesoperfuo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 90, null);
						this.describeAColumn(table, 'percperfuo', 'Percentuale di completamento dell’unità organizzativa', 'fixed.2', 100, null);
						this.describeAColumn(table, 'pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 120, null);
						this.describeAColumn(table, 'perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 130, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 170, null);
						this.describeAColumn(table, 'percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 180, null);
						this.describeAColumn(table, 'percateneo', 'Percentuale performance strategica', 'fixed.2', 230, null);
						this.describeAColumn(table, 'pesoateneo', 'Peso performance strategica', 'fixed.2', 240, null);
						this.describeAColumn(table, 'motivazione', 'Motivazione Valutazione', null, 250, -1);
//$objCalcFieldConfig_default$
                  break;
               					case 'tuscia':
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'risultato', 'Percentuale risultato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'pesoperfuo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 90, null);
						this.describeAColumn(table, 'percperfuo', 'Percentuale di completamento dell’unità organizzativa', 'fixed.2', 100, null);
						this.describeAColumn(table, 'pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 120, null);
						this.describeAColumn(table, 'perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 130, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 170, null);
						this.describeAColumn(table, 'percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 180, null);
//$objCalcFieldConfig_tuscia$
						break;
					case 'onlyprestazionali':
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'pesoperfuo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 90, null);
						this.describeAColumn(table, 'percperfuo', 'Percentuale di completamento dell’unità organizzativa', 'fixed.2', 100, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 170, null);
						this.describeAColumn(table, 'percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 180, null);
//$objCalcFieldConfig_onlyprestazionali$
						break;
					case 'onlycomportamentali':
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 120, null);
						this.describeAColumn(table, 'perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 130, null);
//$objCalcFieldConfig_onlycomportamentali$
						break;
					case 'tusciasint':
						this.describeAColumn(table, '!ateneoponderato', 'Strategici: Valutazione ponderata', 'fixed.2', 0, null);
						this.describeAColumn(table, '!compponderato', 'Comportamentali: Valutazione ponderata', 'fixed.2', 0, null);
						this.describeAColumn(table, '!obiettiviponderato', 'Individuali: Valutazione ponderata', 'fixed.2', 0, null);
						this.describeAColumn(table, '!uoponderato', 'Organizzativi: Valutazione ponderata', 'fixed.2', 0, null);
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'risultato', 'Valutazione complessiva', 'fixed.2', 40, null);
						this.describeAColumn(table, 'pesoperfuo', 'Organizzativi: Peso', 'fixed.2', 90, null);
						this.describeAColumn(table, 'percperfuo', 'Organizzativi: Valutazione', 'fixed.2', 100, null);
						this.describeAColumn(table, 'pesocomportamenti', 'Comportamentali: Peso', 'fixed.2', 120, null);
						this.describeAColumn(table, 'perccomportamenti', 'Comportamentali: Valutazione', 'fixed.2', 130, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Individuali: Peso', 'fixed.2', 170, null);
						this.describeAColumn(table, 'percobiettivi', 'Individuali: Valutazione', 'fixed.2', 180, null);
//$objCalcFieldConfig_tusciasint$
						break;
					case 'campaniasint':
						this.describeAColumn(table, 'risultato', 'Percentuale risultato', 'fixed.2', 40, null);
//$objCalcFieldConfig_campaniasint$
						break;
					case 'campania':
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'risultato', 'Percentuale risultato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'pesoperfuo', 'Peso della valutazione della performance organizzativa', 'fixed.2', 90, null);
						this.describeAColumn(table, 'percperfuo', 'Percentuale di completamento della performance organizzativa', 'fixed.2', 100, null);
						this.describeAColumn(table, 'pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 120, null);
						this.describeAColumn(table, 'perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 130, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 170, null);
						this.describeAColumn(table, 'percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 180, null);
//$objCalcFieldConfig_campania$
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
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Rilevatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Rilevatore comportamenti";
						table.columns["idreg_create"].caption = "Inserisce obiettivi individuali";
						table.columns["idreg_val"].caption = "Valutatore obiettivi individuali";
						table.columns["idreg_valcomp"].caption = "Valutatore comportamenti";
						table.columns["motivazione"].caption = "Motivazione Valutazione";
						table.columns["percateneo"].caption = "Percentuale performance strategica";
						table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
						table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["percperfuo"].caption = "Percentuale di completamento dell’unità organizzativa";
						table.columns["pesoateneo"].caption = "Peso performance strategica";
						table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_default$
                  break;
               					case 'tuscia':
						table.columns["idreg_comp"].caption = "Compilatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Compilatore comportamenti";
//$innerSetCaptionConfig_tuscia$
						break;
					case 'onlyprestazionali':
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Compilatore comportamenti";
						table.columns["idreg_create"].caption = "Inserisce obiettivi individuali";
						table.columns["idreg_val"].caption = "Valutatore obiettivi individuali";
						table.columns["idreg_valcomp"].caption = "Valutatore comportamenti";
						table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
						table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["percperfuo"].caption = "Percentuale di completamento dell’unità organizzativa";
						table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_onlyprestazionali$
						break;
					case 'onlycomportamentali':
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Compilatore comportamenti";
						table.columns["idreg_create"].caption = "Inserisce obiettivi individuali";
						table.columns["idreg_val"].caption = "Valutatore obiettivi individuali";
						table.columns["idreg_valcomp"].caption = "Valutatore comportamenti";
						table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
						table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["percperfuo"].caption = "Percentuale di completamento dell’unità organizzativa";
						table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_onlycomportamentali$
						break;
					case 'tusciasint':
						table.columns["!ateneoponderato"].caption = "Strategici: Valutazione ponderata";
						table.columns["!compponderato"].caption = "Comportamentali: Valutazione ponderata";
						table.columns["!obiettiviponderato"].caption = "Individuali: Valutazione ponderata";
						table.columns["!uoponderato"].caption = "Organizzativi: Valutazione ponderata";
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Compilatore comportamenti";
						table.columns["idreg_create"].caption = "Inserisce obiettivi individuali";
						table.columns["idreg_val"].caption = "Valutatore obiettivi individuali";
						table.columns["idreg_valcomp"].caption = "Valutatore comportamenti";
						table.columns["percateneo"].caption = "Strategici: Valutazione";
						table.columns["perccomportamenti"].caption = "Comportamentali: Valutazione";
						table.columns["percobiettivi"].caption = "Individuali: Valutazione";
						table.columns["percperfuo"].caption = "Organizzativi: Valutazione";
						table.columns["pesoateneo"].caption = "Strategici: Peso";
						table.columns["pesocomportamenti"].caption = "Comportamentali: Peso";
						table.columns["pesoobiettivi"].caption = "Individuali: Peso";
						table.columns["pesoperfuo"].caption = "Organizzativi: Peso";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
						table.columns["risultato"].caption = "Valutazione complessiva";
//$innerSetCaptionConfig_tusciasint$
						break;
					case 'campaniasint':
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Compilatore comportamenti";
						table.columns["idreg_create"].caption = "Inserisce obiettivi individuali";
						table.columns["idreg_val"].caption = "Valutatore obiettivi individuali";
						table.columns["idreg_valcomp"].caption = "Valutatore comportamenti";
						table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
						table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["percperfuo"].caption = "Percentuale di completamento dell’unità organizzativa";
						table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_campaniasint$
						break;
					case 'campania':
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idreg_comp"].caption = "Compilatore obiettivi individuali";
						table.columns["idreg_compcomp"].caption = "Compilatore comportamenti";
						table.columns["idreg_create"].caption = "Inserisce obiettivi individuali";
						table.columns["idreg_val"].caption = "Valutatore obiettivi individuali";
						table.columns["idreg_valcomp"].caption = "Valutatore comportamenti";
						table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
						table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["percperfuo"].caption = "Percentuale di completamento della performance organizzativa";
						table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance organizzativa";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
						table.columns["percperfuo"].caption = "Percentuale di completamento della performance organizzativa";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance organizzativa";
						table.columns["percperfuo"].caption = "Percentuale di completamento della performance organizzativa";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance organizzativa";
						table.columns["percperfuo"].caption = "Percentuale di completamento della performance organizzativa";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance organizzativa";
//$innerSetCaptionConfig_campania$
						break;
//$innerSetCaptionConfig$
            }
		  },

         //isValid: function (r) {

         //   //Aggiungere calcolo media
         //   var self = this;
         //   if ((r.current.pesoperfuo + r.current.pesocomportamenti + r.current.pesoobiettivi) > 100) {
         //      return self.getPromiseIsValidObject("Attenzione la somma dei pesi non corrisponde al 100%", "risultato", "risultato", r);
         //   }

         //   return this.superClass.isValid.call(this, r);

         //   //altre tabelle dataset
         //   //var ds = r.table.dataset;

         //},

         getNewRow: function (parentRow, dt, editType) {
            var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonale");

            //$getNewRowInside$

            dt.autoIncrement('idperfvalutazionepersonale', { minimum: 99990001 });

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

   window.appMeta.addMeta('perfvalutazionepersonale', new meta_perfvalutazionepersonale('perfvalutazionepersonale'));

}());
