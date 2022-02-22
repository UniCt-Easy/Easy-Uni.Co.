
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('getcostoview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('perfprogettocostobudgetview'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfprogetto_default_risultato'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('getcostoview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('perfprogettocostobudgetview'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("perfprogetto","idstruttura");
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
				this.getDataTable('getcostoview').acceptChanges();
				this.getDataTable('perfprogettocostobudgetview').acceptChanges();
				//innerBeforePost
			},

			stateValue: null,
afterPost: function () {

				if (!this.state.currentRow.getRow) {
					return;
				}
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




				// è stato cliccato annulla o elimina non invio mail
				if (!self.state.currentRow.getRow) {
					exit = true;
					return def.resolve();
				}

				//lo stato è rimasto lo stesso, o non viene inizialmente inserito, non invio mail
				if (self.stateValue == self.state.currentRow.idperfprogettostatus || !self.state.currentRow.idperfprogettostatus) {
					exit = true;
					return def.resolve();
				}

				//verifico se deve essere inviata una mail

				var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
				var filterIdReg = self.q.eq('idreg', self.sec.usr('idreg'));

				var filterAll = self.q.and(filterStruttura, filterIdReg);


				
				if (self.state.currentRow.datainizioeffettiva) {
					var filterDa = self.q.lt('strutturaresponsabile_start', self.state.currentRow.datainizioeffettiva);
					filterAll = self.q.and(filterAll, filterDa);
				}

				//Domande
				//se non ci sono date, che date prendiamo in considerazione per verificare il responsabile della struttura?
				//se viene salvato più volte lo stato, dobbiamo tener conto dell'ultimo stato salvato o del primo?

				if (self.state.currentRow.datafineeffettiva) {

					var filterA = self.q.gt('strutturaresponsabile_stop', self.state.currentRow.datafineeffettiva);
					filterAll = self.q.and(filterAll, filterA);

				}



				/*
				if (!self.state.currentRow.datainizioeffettiva) {
					var startdA = new Date();
					startdA.setMonth(11);
					startdA.setDate(31);

					startdA.setFullYear(startA.getFullYear() - 1);
					filterDa = self.q.lt('strutturaresponsabile_start', startdA);
				}

				var filterDaNull = self.q.isNull('strutturaresponsabile_start');
				var filterOrDa = self.q.or(filterDa, filterDaNull);


				var filterA = self.q.gt('strutturaresponsabile_stop', self.state.currentRow.datafineeffettiva);
				if (!self.state.currentRow.datafineeffettiva) {
					var startA = new Date();
					startA.setMonth(0);
					startA.setDate(1);
					startA.setFullYear(startA.getFullYear() + 1);
					filterA = self.q.gt('strutturaresponsabile_stop', startA);
				}


				var filterANull = self.q.isNull('strutturaresponsabile_stop');

				var filterOrA = self.q.or(filterA, filterANull);

				*/

				return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "idperfruolo,registry_title,title,idreg", filterAll)

					.then(function (dtStruttura) {
						if (exit == true || (typeof(exit)  === 'string' &&  exit.trim()))
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
						return appMeta.getData.runSelect("perfprogettocambiostato", "*", filterAll)
					})
					.then(function (dtCambiostato) {
						if (exit == true || (typeof (exit) === 'string' && exit.trim()))
							return;
						//Non ci sono ruoli a cui devo inviare mail esco
						if (!dtCambiostato || !dtCambiostato.rows|| dtCambiostato.rows.length == 0 || !dtCambiostato.rows[0].idperfruolo_mail) {
							exit=true;
							return;
						}
						self.stateValue = self.state.currentRow.idperfprogettostatus;
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
							var subject = "Modifica stato progetto " + titleStruttura;
							body += "l'utente \"" + titleLoggato + "\" ha modificato lo stato del progetto in oggetto, in  \"" + dtStato.rows[0].title + "\".";
							arrayDef.push(self.superClass.sendMail({ emailDest: row.email, body: body, subject: subject, viewMessage: false }));
						});

						return $.when.apply($, arrayDef);
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
this.stateValue = $('#perfprogetto_default_idperfprogettostatus').val();
},

			manageperfprogetto_default_risultato: function () {
//calcolo del completamento
this.calculateRisultatoPerc();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogetto', 'default', metaPage_perfprogetto);

}());
