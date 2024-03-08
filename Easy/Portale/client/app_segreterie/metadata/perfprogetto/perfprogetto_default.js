(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogetto() {
		MetaPage.apply(this, ['perfprogetto', 'default', false]);
        this.name = 'Progetti strategici';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		//pageHeaderDeclaration
    }

    metaPage_perfprogetto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogetto,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.calculateRisultatoPerc();
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-perfprogetto_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettouo());
				arraydef.push(this.manageperfprogetto_default_risultato());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.calculateRisultatoPerc();
				this.manageperfprogetto_default_risultato();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfprogetto_default_idstruttura'), null);
				} else {
					this.helpForm.filter($('#perfprogetto_default_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfprogetto_default_idreg_respprogetto'), null);
				} else {
					this.helpForm.filter($('#perfprogetto_default_idreg_respprogetto'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogetto_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettouo());
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			afterClear: function () {
				//parte sincrona
				this.helpForm.filter($('#perfprogetto_default_idstruttura'), null);
				this.enableControl($('#perfprogetto_default_risultato'), true);
				this.helpForm.filter($('#perfprogetto_default_idreg_respprogetto'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfprogetto_default_risultato'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("perfprogetto","idstruttura");
				appMeta.metaModel.insertFilter(this.getDataTable("perfprogettostatusdefaultview"), this.q.eq('perfprogettostatus_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("didprogsuddannokinddefaultview"), this.q.eq('didprogsuddannokind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			
			//buttonClickEnd

			//insertClick

			beforePost: function () {
				var self = this;
				this.getDataTable('perfprogettoaccountprevisionview').acceptChanges();
				//innerBeforePost
			},

			stateValue: null,
            afterPost: function () {

                // è stato cliccato annulla o elimina non invio mail
                if (!this.state.currentRow.getRow) {
                    return;
                }
                //lo stato è rimasto lo stesso, o non viene inizialmente inserito, non invio mail
                if (this.stateValue == this.state.currentRow.idperfprogettostatus || !this.state.currentRow.idperfprogettostatus)
                    return;

                var self = this;
                var destinatari = [];
                var destinatariDbRow = [];
                var invio = false;
                var exit = false;
                var ruoloLoggato;
                var titleLoggato;
                var titleStruttura;
                var strutturaRows;
                var def = appMeta.Deferred("afterPost");
                var parentRow = self.state.currentRow;
                var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

                var filter = this.q.eq("idperfprogetto", parentRow.idperfprogetto);
                var selBuilderArray = [];

                //inserisco il precendete stato nello storico
                var meta = appMeta.getMeta("perfprogettostatuschanges");
                var dataSetTable = self.state.DS.tables["perfprogettostatuschanges"];
                meta.setDefaults(dataSetTable);


                meta.getNewRow(null, dataSetTable).then(function (row) {
                    if (!row) {
                        return def.resolve();
                    }
                    row.current.idperfprogettostatus = self.state.currentRow.idperfprogettostatus;
                    row.current.changedate = new Date();
                    row.current.changeuser = self.sec.usr('userweb');
                    row.current.idperfprogetto = self.state.currentRow.idperfprogetto;
                    
                    return def.resolve();

                });
               
                //verifico se deve essere inviata una mail

                var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
                var filterIdReg = self.q.eq('idreg', self.sec.usr('idreg'));

                var filterAll = self.q.and(filterStruttura, filterIdReg);



                if (self.state.currentRow.datainizioeffettiva) {
                    var filterDa = self.q.lt('start', self.state.currentRow.datainizioeffettiva);
                    filterAll = self.q.and(filterAll, filterDa);
                }

                //Domande
                //se non ci sono date, che date prendiamo in considerazione per verificare il responsabile della struttura?
                //se viene salvato più volte lo stato, dobbiamo tener conto dell'ultimo stato salvato o del primo?

                if (self.state.currentRow.datafineeffettiva) {

                    var filterA = self.q.gt('stop', self.state.currentRow.datafineeffettiva);
                    filterAll = self.q.and(filterAll, filterA);

                }

                

                return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "idperfruolo,registry_title,title,idreg", filterAll)

                    .then(function (dtStruttura) {
                        if (exit == true || (typeof(exit) === 'string' && exit.trim()))
                            return;
                        if (!dtStruttura || !dtStruttura.rows || dtStruttura.rows.length == 0) {
                            exit = "Non sono stati individuati destinatari a cui inviare la notifica";
                            return;


                        }
                        strutturaRows = dtStruttura.rows;


                        ruoloLoggato = strutturaRows[0].idperfruolo;
                        titleLoggato = strutturaRows[0].registry_title;
                        titleStruttura = strutturaRows[0].title;


                        //vecchio stato scheda
                        var filterStato = self.q.eq('idperfprogettostatus', self.stateValue);
                        //se è il primo stato che viene salvato alla scheda setto lo stato attuale come quello di partenza
                        if (!self.stateValue) {
                            filterStato = self.q.isNull(self.state.currentRow.idperfprogettostatus);
                        }

                        //nuovo stato scheda
                        var filterStatoTo = self.q.eq('idperfprogettostatus_to', self.state.currentRow.idperfprogettostatus);


                        var filterRuolo = self.q.eq('idperfruolo', ruoloLoggato);
                        var filterAll = self.q.and(filterStato, filterStatoTo, filterRuolo);

                        //recupero i cambi stato /ruoli a cui devo inviare la mail
                        return appMeta.getData.runSelect("perfprogettocambiostatoruolimailview", "*", filterAll)
                    })
                    .then(function (dtCambiostato) {
                        if (exit == true || (typeof (exit) === 'string' && exit.trim()))
                            return;
                        //Non ci sono ruoli a cui devo inviare mail esco
                        if (!dtCambiostato || !dtCambiostato.rows || dtCambiostato.rows.length == 0 || !dtCambiostato.rows[0].idperfruolo_mail) {
                            exit = true;
                            return;
                        }
                        self.hideWaitingIndicator(waitingHandler);
                        waitingHandler = self.showWaitingIndicator('Invio mail');
                        invio = true;

                        _.forEach(dtCambiostato.rows, function (cambioStatoRow) {

                            _.forEach(strutturaRows, function (row) {
                                if (cambioStatoRow.idperfruolo_mail == row.idperfruolo) {
                                    destinatari.push(row);
                                    return false;
                                }
                            });
                        }
                        );

                        var arrayDest = [];
                        _.map(destinatari, function (row) { return arrayDest.push(row.idreg); });
                        //Recupero i dati della persona a cui inviare la mail
                        return self.superClass.getRegistryreference(arrayDest)
                    })

                    .then(function (dtRows) {
                        if (exit == true || (typeof(exit) === 'string' && exit.trim()))
                            return;
                        if (!dtRows || dtRows.length == 0) {
                            exit = "Non sono stati individuati destinatari a cui inviare la notifica";
                            return;
                        }

                        destinatariDbRow = dtRows;

                        var filterStato = self.q.eq("idperfprogettostatus", self.state.currentRow.idperfprogettostatus);

                        //recupero i cambi stato/ruoli a cui devo inviare la mail
                        return appMeta.getData.runSelect("perfprogettostatus", "*", filterStato)
                    }).then(function (dtStato) {
                        if (exit == true || (typeof(exit) === 'string' && exit.trim()))
                            return;
                        if (!dtStato || !dtStato.rows || dtStato.rows.length == 0) {
                            exit = "Lo stato selezionato non è riconosciuto";
                            return;
                        }
                        var arrayDef = [];
                        var body;


                        _.forEach(destinatariDbRow, function (row) {
                            body = "Gentile " + row.email + ",</br>";
                            var subject = "Modifica stato del progetto " + titleStruttura;
                            body += "l'utente \"" + titleLoggato + "\" ha modificato lo stato del progetto in oggetto, in  \"" + dtStato.rows[0].title + "\".";
                            arrayDef.push(self.superClass.sendMail({ emailDest: row.email, body: body, subject: subject, viewMessage: false }));
                        });

                        return $.when.apply($, arrayDef);
                    })
                    .then(function() {
                        self.stateValue = self.state.currentRow.idperfprogettostatus;
                        return self.cmdMainSave();
                    })
                    .then(function () {
                        self.hideWaitingIndicator(waitingHandler);

                        if (exit == true) {
                            return def.resolve();
                        }
                        if (typeof(exit) === 'string' && exit.trim()) {
                            return def.from(self.showMessageOk(exit));
                        }
                        if (invio) {

                            return def.from(self.showMessageOk('Invio mail avvenuto con successo'));
                        }
                        return def.resolve();
                    });
               

                def.promise();
			},
			
			manageperfprogettouo: function () {
	            var self = this;
				var getregistrydocentiamministrativifilter = self.q.isIn("idreg", _.map(self.getDataTable("perfprogettouomembro").rows, function (r) { return r.idreg; }));
				var def = appMeta.Deferred("manageperfprogettouo_default_struttura");
				var perfprogettouo = self.getDataTable("perfprogettouo");
				appMeta.getData.runSelect('getregistrydocentiamministrativi', 'idreg,struttura', getregistrydocentiamministrativifilter, null)
					.then(function (dt) {
						var perfprogettouomembro = self.getDataTable("perfprogettouomembro");
						_.forEach(perfprogettouo.rows, function (rb) {
							var arr = [];
							var getperfprogettouofilter = self.q.eq('idperfprogettouo', rb.idperfprogettouo);

							var rows = perfprogettouomembro.select(getperfprogettouofilter);
							_.forEach(rows, function (rudrmembro) {
								var rowsdt = dt.select(self.q.eq('idreg', rudrmembro.idreg))
								if (rowsdt.length) {
									if (!arr.includes(rowsdt[0].struttura) && !!rowsdt[0].struttura) {
										arr.push(rowsdt[0].struttura);
									}
								}

							});

							rb["!struttura"] = arr.join('; ');

						});

						def.resolve();

					});
				return def.promise();
			},

			calculateRisultatoPerc: function () {
					if (this.state.currentRow) {
					var arrayRisultato = [];
					var pa = this.getDataTable("perfprogettoobiettivo");
					_.forEach(pa.rows, function(row){
						arrayRisultato.push({ valore: row.completamento, peso: row.peso });
					});

					var average = this.calculateWeightedAverage(arrayRisultato);
					if(this.state.currentRow.risultato != average)
						this.state.currentRow.risultato = average;
				}
			},
			
			rowSelected: function()
			{
				this.stateValue = this.state.currentRow.idperfprogettostatus;
			},

			manageperfprogetto_default_risultato: function () {
//calcolo del completamento
this.calculateRisultatoPerc();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogetto', 'default', metaPage_perfprogetto);

}());
