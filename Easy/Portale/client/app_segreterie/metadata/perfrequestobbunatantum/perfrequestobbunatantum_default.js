
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

    function metaPage_perfrequestobbunatantum() {
		MetaPage.apply(this, ['perfrequestobbunatantum', 'default', false]);
        this.name = 'Richiesta di inserimento di un obiettivo una tantum';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_perfrequestobbunatantum.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfrequestobbunatantum,
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
				var def = appMeta.Deferred("beforeFill-perfrequestobbunatantum_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfrequestobbunatantum'), this.getDataTable('perfrequestobbunatantumsoglia'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfrequestobbunatantum_default_inseritoS'), false);
				this.enableControl($('#perfrequestobbunatantum_default_inseritoN'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfrequestobbunatantum'), this.getDataTable('perfrequestobbunatantumsoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#SendMail").on("click", _.partial(this.fireSendMail, this));
				$("#SendMail").prop("disabled", true);
				$("#InsertRequest").on("click", _.partial(this.fireInsertRequest, this));
				$("#InsertRequest").prop("disabled", true);
				$('#perfrequestobbunatantum_default_year').on("change", _.partial(this.manageyear, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfrequestobbunatantum_default");
				$('#perfrequestobbunatantum_default_idstruttura').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfrequestobbunatantum_default_idstruttura').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			
			
			insertClick: function (that, grid) {
				if (!$('#perfrequestobbunatantum_default_idstruttura').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Unità organizzativa');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			insertSoglie: function (prm) {
                     var self = this;
				if (prm.state.currentRow && !!$('#perfrequestobbunatantum_default_year').val()) {
					var filterYear = window.jsDataQuery.eq('year', $('#perfrequestobbunatantum_default_year').val());
					this.superClass.insertSoglie({
						table: "perfrequestobbunatantumsoglia", keyColumns: "idperfrequestobbunatantum", filter: filterYear, columnValueName: "percentuale"
					}).then(function () {
						var grid = self.getCustomControl('perfrequestobbunatantumsoglia.default.default');
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
				if (cmd === "mainsave" && $('#perfrequestobbunatantum_default_idstruttura').val()) {
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
		
				var def = appMeta.Deferred("fireSendMail");
				if (!that.state.currentRow.year) {
					return def.from(self.showMessageOk("Inserire prima l'anno solare"));
				}
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
				
				var filterMinDate = self.q.gt('start', "1/1/" + that.state.currentRow.year);
				var filterEqMinDate = self.q.eq('start', "1/1/" + that.state.currentRow.year);				
				var filterOrMinDate = self.q.or(filterMinDate, filterEqMinDate);

				var filterMaxDate = self.q.lt('stop', "12/31/" + that.state.currentRow.year);
				var filterEqMaxDate = self.q.eq('stop', "12/31/" + that.state.currentRow.year);
				var filterOrMaxDate = self.q.or(filterMaxDate, filterEqMaxDate);

				var filterRuolo = self.q.eq('idperfruolo', 'Responsabile');

				var filterComplete = self.q.and(filterRuolo, filterOrMinDate, filterOrMaxDate, filterStruttura);
				

				appMeta.getData.runSelect("strutturaparentresponsabiliview", "*", filterComplete).
					then(function (dtStruttura) {
						//	recupero dalla struttura il responsabile
						if (dtStruttura.rows && dtStruttura.rows.length > 0) {

							struttura = dtStruttura;
							return self.superClass.getRegistryreference(struttura.rows[0].idreg)
								.then(function (respRow) {
									responsabile = respRow[0];
									return that.showMessageOkCancel("Sarà inviata una mail al responsabile dell'unità organizzativa all'indirizzo " + responsabile.email + ". Si desidera procedere?")
								})
								.then(function (res) {
									if (!res) {
										self.hideWaitingIndicator(waitingHandler);
										return def.resolve();
									}

									return self.superClass.getRegistryreference(that.sec.usrEnv.idreg)
								}).then(function (resLog) {
									loggato = resLog[0];



									body = "Gentile responsabile dell'unità organizzativa " + struttura.rows[0].title;
									if (responsabile.idreg != loggato.idreg) {
										body = body + ",<br>l'utente " + loggato.email + " ha inserito";
									}
									else
										body = body + "<br> è stata inserita";
									body = body + " la richiesta di inserimento del seguente obiettivo una tantum per la Vostra unità organizzativa. <br><br>Titolo obiettivo:<br>" + that.state.currentRow.title + "<br><br>Descrizione:<br>" + that.state.currentRow.description;
									subject = "Richiesta inserimento obiettivo una tantum per l'unità organizzativa " + struttura.rows[0].title;

									return self.superClass.sendMail({ emailDest: responsabile.email, htmlBody: body, subject: subject })
								})
								.then(function (msg) {

									self.hideWaitingIndicator(waitingHandler);

									if (msg) {
										return def.from(self.showMessageOk(msg));
									}


									return def.resolve();
								});

						}
						else {
							self.hideWaitingIndicator(waitingHandler);
							return def.from(self.showMessageOk("Non è stato configurato il responsabile della unità organizzativa. Configurare un responsabile nella scheda anagrafica dell'unità organizzativa selezionata"));
						}

					});
				def.promise();
			},

			fireInsertRequest: function (that) {
				if (!that.state.currentRow) {
					return;
				}
				//recupero la valutazione della uo nell'anno inserito
				var self = that;
				var getData = appMeta.getData;


				var def = appMeta.Deferred("fireInsertRequest");
				//appMeta.security.userEnv.idreg
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				var perfvalutazioneuoTableName = 'perfvalutazioneuo';
				var perfvalutazioneuoEditType = 'insertvalutazione';

				var ds;

				getData.getDataSet(perfvalutazioneuoTableName, perfvalutazioneuoEditType)
					.then(function (dsPerfrequestobbitantum) {
						ds = dsPerfrequestobbitantum;
						var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
						var filterYear = self.q.eq('year', self.state.currentRow.year);
						//verificare anche se la valutazione è ancora attiva.
						var filterAnd = self.q.and(filterStruttura, filterYear);

						return getData.runSelectIntoTable(ds.tables.perfvalutazioneuo, filterAnd, null)
						//return getData.fillDataSet(dsPerfrequestobbindividuale, 'perfvalutazionepersonale', 'istituti_princ', filterAnd);
					}).then(function () {
						if (ds.tables.perfvalutazioneuo.rows.length === 0) {
							def.resolve();

							self.hideWaitingIndicator(waitingHandler);
							return self.showMessageOk('Per l\'unità organizzativa selezionata non è presente alcuna valutazione nell\'anno selezionato.')
						}
						// devo riempire perfvalutazionepersonale
						appMeta.getMeta('perfobiettiviuo').setDefaults(ds.tables.perfobiettiviuo);
						appMeta.getMeta('perfobiettiviuo').getNewRow(null, ds.tables.perfobiettiviuo, null);
						ds.tables.perfobiettiviuo.rows[0].title = self.state.currentRow.title;
						ds.tables.perfobiettiviuo.rows[0].description = self.state.currentRow.description;
						ds.tables.perfobiettiviuo.rows[0].peso = self.state.currentRow.peso;
						ds.tables.perfobiettiviuo.rows[0].idperfvalutazioneuo = ds.tables.perfvalutazioneuo.rows[0].idperfvalutazioneuo;
						var filter = window.jsDataQuery.eq('idperfrequestobbunatantum', self.state.currentRow.idperfrequestobbunatantum);


						appMeta.getMeta('perfobiettiviuosoglia').setDefaults(ds.tables.perfobiettiviuosoglia);
						return that.superClass.insertSoglie({
							table: "perfobiettiviuosoglia",
							tableSoglie: "perfrequestobbunatantumsoglia",
							keyColumns: "idperfobiettiviuo=" + ds.tables.perfobiettiviuo.rows[0].idperfobiettiviuo + ",idperfvalutazioneuo=" + ds.tables.perfobiettiviuo.rows[0].idperfvalutazioneuo,
							columnValueName: "percentuale",
							filter: filter,
							ds: ds,
							desMessage: false
						}).then(function () {

							self.hideWaitingIndicator(waitingHandler);
							waitingHandler = self.showWaitingIndicator('Inserisco obiettivo');

							return appMeta.postData.doPostSilent(ds, perfvalutazioneuoTableName, perfvalutazioneuoEditType, [])
						}).then(function (res, msg) {
							self.hideWaitingIndicator(waitingHandler);
							if (!res && msg && msg.length) {
								var s = msg.reduce(function (acc, m) {
									acc += m.description + '\n';
									return acc;
								}, '');
								def.resolve;
								return self.showMessageOk(s);
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

			children: ['perfrequestobbunatantumsoglia'],
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

	window.appMeta.addMetaPage('perfrequestobbunatantum', 'default', metaPage_perfrequestobbunatantum);

}());
