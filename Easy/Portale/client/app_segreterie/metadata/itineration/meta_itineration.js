(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_itineration() {
        MetaData.apply(this, ["itineration"]);
        this.name = 'meta_itineration';
    }

    meta_itineration.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_itineration,
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
						this.describeAColumn(table, 'description', 'Motivazione', null, 10, 150);
						this.describeAColumn(table, 'location', 'Località di destinazione', null, 20, 65);
						this.describeAColumn(table, 'start', 'Data inizio', 'g', 40, null);
						this.describeAColumn(table, 'stop', 'Data fine', 'g', 50, null);
						this.describeAColumn(table, 'nitineration', 'Numero', null, 580, null);
						this.describeAColumn(table, 'yitineration', 'Anno esercizio', null, 800, null);
						this.describeAColumn(table, '!idupb_upbelenchiview_codeupb', 'Codice UPB', null, 541, null);
						this.describeAColumn(table, '!idupb_upbelenchiview_title', 'Denominazione UPB', null, 542, null);
						objCalcFieldConfig['!idupb_upbelenchiview_codeupb'] = { tableNameLookup:'upbelenchiview', columnNameLookup:'codeupb', columnNamekey:'idupb' };
						objCalcFieldConfig['!idupb_upbelenchiview_title'] = { tableNameLookup:'upbelenchiview', columnNameLookup:'title', columnNamekey:'idupb' };
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
						table.columns["description"].caption = "Motivazione";
						table.columns["location"].caption = "Località di destinazione";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["starttime"].caption = "Inizio";
						table.columns["stoptime"].caption = "Fine";
						table.columns["active"].caption = "attivo";
						table.columns["adate"].caption = "data contabile";
						table.columns["additionalannotations"].caption = "Richieste aggiuntive sulla missione";
						table.columns["admincarkm"].caption = "Km percorsi con mezzo amministrazione";
						table.columns["admincarkmcost"].caption = "Costo a Km per utilizzo mezzo amministrazione";
						table.columns["applierannotations"].caption = "Appunti per il pagamento";
						table.columns["authdoc"].caption = "Doc. autorizzazione";
						table.columns["authdocdate"].caption = "Data autorizzazione";
						table.columns["authneeded"].caption = "Autorizzaz. richiesta";
						table.columns["authorizationdate"].caption = "Data autorizz.";
						table.columns["cancelreason"].caption = "Motivo rifiuto richiesta";
						table.columns["clause_accepted"].caption = "Accetta la clausola per utilizzo mezzo indicato";
						table.columns["completed"].caption = "Considera eseguito quindi pagabile";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["datecompleted"].caption = "data acquisizione documentazione definitiva";
						table.columns["flagweb"].caption = "Missione inserita mediante interfaccia web";
						table.columns["footkm"].caption = "Km percorsi a piedi";
						table.columns["footkmcost"].caption = "Costo a Km per percorso a piedi";
						table.columns["grossfactor"].caption = "Coeff. di lordizzazione";
						table.columns["idaccmotive"].caption = "id causale (tabella acccmotive)";
						table.columns["idaccmotivedebit"].caption = "Id della causale di debito (tabella accmotive) ";
						table.columns["idaccmotivedebit_crg"].caption = "Id causale di debito - correzione (tabella accmotive)";
						table.columns["idaccmotivedebit_datacrg"].caption = "Data correzione causale di debito";
						table.columns["idauthmodel"].caption = "id modello autorizzativo (tabella authmodel)";
						table.columns["iddaliaposition"].caption = "Codice qualifica Dalia";
						table.columns["iditineration"].caption = "id missione (tabella itineration)";
						table.columns["iditinerationstatus"].caption = "ID Stato missione (tabella itinerationstatus)";
						table.columns["idman"].caption = "id responsabile (tabella manager)";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["idregistrylegalstatus"].caption = "id progressivo pos. giuridica";
						table.columns["idser"].caption = "chiave prestazione (tabella service)";
						table.columns["idsor_siope"].caption = "id della class. siope (idsor di sorting) per il costo";
						table.columns["idsor1"].caption = "id voce analitica 1(tabella sorting)";
						table.columns["idsor2"].caption = "id voce analitica 2(tabella sorting)";
						table.columns["idsor3"].caption = "id voce analitica 3(tabella sorting)";
						table.columns["idupb"].caption = "UPB";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["netfee"].caption = "Importo Netto";
						table.columns["nitineration"].caption = "Numero";
						table.columns["noauthreason"].caption = "Motivo di rifiuto autorizzazione";
						table.columns["owncarkm"].caption = "Km percorsi con mezzo proprio";
						table.columns["owncarkmcost"].caption = "Costo a Km per utilizzo mezzo proprio";
						table.columns["rtf"].caption = "allegati";
						table.columns["start"].caption = "data inizio";
						table.columns["stop"].caption = "data fine";
						table.columns["totadvance"].caption = "Anticipo";
						table.columns["total"].caption = "Totale";
						table.columns["totalgross"].caption = "Importo Lordo";
						table.columns["txt"].caption = "note testuali";
						table.columns["vehicle_info"].caption = "Dati identificativi del veicolo";
						table.columns["vehicle_motive"].caption = "Causale per utilizzo mezzo";
						table.columns["webwarn"].caption = "Avvisi per il Richiedente";
						table.columns["yitineration"].caption = "Anno esercizio";
						table.columns["start"].caption = "Data inizio";
						table.columns["stop"].caption = "Data fine";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_itineration");

				//$getNewRowInside$

				dt.autoIncrement('iditineration', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "starttime asc , start asc , stoptime asc , stop asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('itineration', new meta_itineration('itineration'));

	}());
