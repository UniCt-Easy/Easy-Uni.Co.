
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

    function metaPage_perfrequestobbindividuale() {
		MetaPage.apply(this, ['perfrequestobbindividuale', 'default', false]);
        this.name = 'Richiesta di inserimento di un obiettivo individuale';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_perfrequestobbindividuale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfrequestobbindividuale,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.inserito)
					parentRow.inserito = 'N';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfrequestobbindividuale_default");
				var arraydef = [];
				
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfrequestobbindividuale'), this.getDataTable('perfrequestobbindividualesoglia'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfrequestobbindividuale_default_inseritoS'), false);
				this.enableControl($('#perfrequestobbindividuale_default_inseritoN'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfrequestobbindividuale'), this.getDataTable('perfrequestobbindividualesoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#SendMail").on("click", _.partial(this.fireSendMail, this));
				$("#SendMail").prop("disabled", true);
				$("#InsertRequest").on("click", _.partial(this.fireInsertRequest, this));
				$("#InsertRequest").prop("disabled", true);
				$('#perfrequestobbindividuale_default_year').on("change", _.partial(this.manageyear, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfrequestobbindividuale_default");
				$('#perfrequestobbindividuale_default_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfrequestobbindividuale_default_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			
			
			insertClick: function (that, grid) {
				if (!$('#perfrequestobbindividuale_default_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Valutato');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			insertSoglie: function (prm) {
                    var self = this;
				if (prm.state.currentRow && !!$('#perfrequestobbindividuale_default_year')) {
					var filterYear = window.jsDataQuery.eq('year', $('#perfrequestobbindividuale_default_year').val());
					this.superClass.insertSoglie({
						table: "perfrequestobbindividualesoglia", keyColumns: "idperfrequestobbindividuale", filter: filterYear, columnValueName: "percentuale"
					}).then(function () {
						var grid = self.getCustomControl('perfrequestobbindividualesoglia.default.default');
						grid.fillControl();						
					});
				}     
			},

			rowSelected: function (dataRow) {
				$("#InsertRequest").prop("disabled", this.state.currentRow.inserito == 'S' || !this.state.isEditState());
				$("#SendMail").prop("disabled", this.state.currentRow.inserito == 'S' || !this.state.isEditState());
			},
       
                        buttonClickEnd: function (currMetaPage, cmd) {				
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#SendMail").prop("disabled", true);
					$("#InsertRequest").prop("disabled", true);					
				}
				if (cmd === "mainsave" && $('#perfrequestobbindividuale_default_idreg').val() ) {
					$("#SendMail").prop("disabled", false);					
				}

				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			}
,

			fireSendMail: function (that) {
				if (!that.state.currentRow) {
					return;
				}

				var self = that;
				var body;
				var subject;
				var responsabile;
				var struttura;
				var loggato;
				var def = appMeta.Deferred("fireSendMail");

				if (!that.state.currentRow.year) {
					return def.from(self.showMessageOk("Inserire prima l'anno solare"));
				}
				
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				if (!that.state.currentRow.year) {
					self.hideWaitingIndicator(waitingHandler);
					return def.from(self.showMessageOk("Selezionare l'anno e salvare prima di inviare l'email."));
				}

				//invio la mail al responsabile del valutato scelto				
				var filterMinDate = self.q.gt('start', "1/1/" + that.state.currentRow.year);
				var filterEqMinDate = self.q.eq('start', "1/1/" + that.state.currentRow.year);
				var filterOrMinDate = self.q.or(filterMinDate, filterEqMinDate);

				var filterMaxDate = self.q.lt('stop', "12/31/" + that.state.currentRow.year);
				var filterEqMaxDate = self.q.eq('stop', "12/31/" + that.state.currentRow.year);
				var filterOrMaxDate = self.q.or(filterMaxDate, filterEqMaxDate);

				var filterValutato = self.q.eq('afferente_idreg', that.state.currentRow.idreg);
				var filterRuolo = self.q.eq('idperfruolo', 'Responsabile');
				var filterComplete = self.q.and(filterValutato, filterOrMinDate, filterOrMaxDate, filterRuolo);
				

				appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "*", filterComplete).
					then(function (dtStruttura) {

						if (dtStruttura.rows.length > 0) {
							struttura = dtStruttura.rows[0];
							return self.superClass.getRegistryreference(struttura.idreg);
						}
						else {
							self.hideWaitingIndicator(waitingHandler);
							return def.from(self.showMessageOk("Non è stato possibile individuare l'unità organizzativa di appartenenza del valuato. Indicare l'unità organizzativa per la richiesta di inserimento dell'obiettivo individuale"));
						}
					}).then(function (respRow) {
						if (respRow != null) {
							responsabile = respRow[0];
							return that.showMessageOkCancel("Sarà inviata una mail al responsabile dell'unità organizzativa all'indirizzo  " + respRow[0].email + ". Procedere?");
						}
						else {
							self.hideWaitingIndicator(waitingHandler);
							return def.from(self.showMessageOk("Non è stato possibile individuare il responsabile dell'unità organizzativa. Configurare un responsabile nella scheda anagrafica dell'unità organizzativa " + struttura.title + "."));
						}
					}).then(function (res) {
						if (!res) {
							that.hideWaitingIndicator(waitingHandler);
							return def.resolve();
						}
						return that.superClass.getRegistryreference(that.sec.usrEnv.idreg)
					}).then(function (resLog) {
						loggato = resLog[0];

						return self.superClass.getRegistryreference(that.state.currentRow.idreg)

					}).then(function (valutatoRow) {

						body = "Gentile responsabile dell'unità organizzativa " + struttura.title + ",";
						if (responsabile.idreg != loggato.idreg) {
							body = body + ",<br>l'utente " + loggato.email + " ha inserito";
						}
						else body = body + "<br> è stata inserita ";
						body = body + " la richiesta di inserimento del seguente obiettivo individuale per il valutato " + valutatoRow[0].email + ".<br><br>Titolo obiettivo:<br>" + that.state.currentRow.title + "<br><br>Descrizione:<br>" + that.state.currentRow.description;

						subject = "Richiesta inserimento obiettivo individuale per il valutato " + valutatoRow[0].email;

						return self.superClass.sendMailByIdReg({ emailDest: responsabile.email, idReg: that.sec.usrEnv.idreg, body: body, subject: subject })
					}).then(function (msg) {

						self.hideWaitingIndicator(waitingHandler);

						if (msg) {
							return def.from(self.showMessageOk(msg));
						}


						return def.resolve();
					});

				def.promise();
			},

			fireInsertRequest: function (that) {
				if (!that.state.currentRow) {
					return;
				}
				//recupero la valutazione del valutato nell'anno inserito
				var self = that;
				var getData = appMeta.getData;


				var def = appMeta.Deferred("fireInsertRequest");
				//appMeta.security.userEnv.idreg
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				var perfvalutazionepersonaleTableName = 'perfvalutazionepersonale';
				var perfvalutazionepersonaleEditType = 'insertvalutazione';

				var ds;

				getData.getDataSet(perfvalutazionepersonaleTableName, perfvalutazionepersonaleEditType)
					.then(function (dsPerfrequestobbindividuale) {
						ds = dsPerfrequestobbindividuale;
						var filterIdreg = self.q.eq('idreg', self.state.currentRow.idreg);
						var filterYear = self.q.eq('year', self.state.currentRow.year);
						//verificare anche se la valutazione è ancora attiva.
						var filterAnd = self.q.and(filterIdreg, filterYear);

						return getData.runSelectIntoTable(ds.tables.perfvalutazionepersonale, filterAnd, null)
						//return getData.fillDataSet(dsPerfrequestobbindividuale, 'perfvalutazionepersonale', 'istituti_princ', filterAnd);
					}).then(function () {
						if (ds.tables.perfvalutazionepersonale.rows.length === 0) {
							def.resolve();

							self.hideWaitingIndicator(waitingHandler);
							return self.showMessageOk('Per il valutato non è presente alcuna valutazione nell\'anno selezionato.')
						}
						// devo riempire perfvalutazionepersonale
						appMeta.getMeta('perfvalutazionepersonaleobiettivo').setDefaults(ds.tables.perfvalutazionepersonaleobiettivo);
						appMeta.getMeta('perfvalutazionepersonaleobiettivo').getNewRow(null, ds.tables.perfvalutazionepersonaleobiettivo, null);
						ds.tables.perfvalutazionepersonaleobiettivo.rows[0].title = self.state.currentRow.title;
						ds.tables.perfvalutazionepersonaleobiettivo.rows[0].description = self.state.currentRow.description;
						ds.tables.perfvalutazionepersonaleobiettivo.rows[0].peso = self.state.currentRow.peso;
						ds.tables.perfvalutazionepersonaleobiettivo.rows[0].idperfvalutazionepersonale = ds.tables.perfvalutazionepersonale.rows[0].idperfvalutazionepersonale;
						var filter = window.jsDataQuery.eq('idperfrequestobbindividuale', self.state.currentRow.idperfrequestobbindividuale);


						appMeta.getMeta('perfvalutazionepersonalesoglia').setDefaults(ds.tables.perfvalutazionepersonalesoglia);
						return that.superClass.insertSoglie({
							table: "perfvalutazionepersonalesoglia",
							tableSoglie: "perfrequestobbindividualesoglia",
							keyColumns: "idperfvalutazionepersonaleobiettivo=" + ds.tables.perfvalutazionepersonaleobiettivo.rows[0].idperfvalutazionepersonaleobiettivo + ",idperfvalutazionepersonale=" + ds.tables.perfvalutazionepersonaleobiettivo.rows[0].idperfvalutazionepersonale,
							columnValueName: "percentuale",
							filter: filter,
							ds: ds,
							desMessage: false
						}).then(function () {

							self.hideWaitingIndicator(waitingHandler);
							waitingHandler = self.showWaitingIndicator('Inserisco obiettivo');

							return appMeta.postData.doPostSilent(ds, perfvalutazionepersonaleTableName, perfvalutazionepersonaleEditType, [])
						}).then(function (res, msg) {

							self.hideWaitingIndicator(waitingHandler);
							if (!res && msg && msg.length) {
								var s = msg.reduce(function (acc, m) {
									acc += m.description + '\n';
									return acc;
								}, '');
								
								return def.from(self.showMessageOk(s));
							}
							if (res) {

								self.state.currentRow.inserito = 'S';
								
								waitingHandler = self.showWaitingIndicator('Salvataggio stato della richiesta di inserimento')

								return self.saveFormData().then(function () {

									self.hideWaitingIndicator(waitingHandler);
									$("#InsertRequest").prop("disabled", true);
									return def.from(self.showMessageOk('Obiettivo salvato con successo'));

								});

							}
							def.resolve();
						}, function (err) {

							self.hideWaitingIndicator(waitingHandler);
							def.resolve;
							console.log(err);
							return false;

						});

					});
				def.promise();
},

			manageyear: function(that) { 
				that.insertSoglie(that);
			},

			children: ['perfrequestobbindividualesoglia'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfrequestobbindividuale', 'default', metaPage_perfrequestobbindividuale);

}());
