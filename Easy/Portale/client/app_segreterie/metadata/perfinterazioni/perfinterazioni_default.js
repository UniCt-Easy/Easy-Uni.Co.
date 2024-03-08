(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfinterazioni() {
		MetaPage.apply(this, ['perfinterazioni', 'default', false]);
        this.name = 'Interazioni';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_perfinterazioni.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfinterazioni,
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
				
				if ((this.state.isInsertState() /*|| this.state.isEditState()*/) && (!parentRow.cu || this.sec.sysEnv.idcustomuser.toUpperCase() == parentRow.cu.split('{')[0].toUpperCase())) {
                   parentRow.utente = appMeta.security.usr('forename') + ' ' + appMeta.security.usr('surname');
                   this.enableControl($('#perfinterazioni_default_commenti'), true);
                }
                else this.enableControl($('#perfinterazioni_default_commenti'), false);
     
                if (this.isNull(parentRow.data))
                   parentRow.data = new Date();                                

				this.enableControl($("#SendMail"), this.state.callerState.currentRow.idreg != this.state.callerState.currentRow.idreg_val);
			    this.enableControl($("#SendMailComp"), this.state.callerState.currentRow.idreg != this.state.callerState.currentRow.idreg_comp);
			
				parentRow.idperfvalutazionepersonale = this.state.callerState.currentRow.idperfvalutazionepersonale;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfinterazioni_default");
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
				//parte sincrona
				this.enableControl($('#perfinterazioni_default_data'), true);
				this.enableControl($('#perfinterazioni_default_utente'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfinterazioni_default_data'), false);
				this.enableControl($('#perfinterazioni_default_utente'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setRights();
				var f1 = window.jsDataQuery.eq("idperfvalutazionepersonale", this.state.callerState.currentRow.idperfvalutazionepersonale);
				self.firstSearchFilter  = f1;
					self.startFilter = self.firstSearchFilter;
				$("#SendMail").on("click", _.partial(this.fireSendMail, this));
				$("#SendMail").prop("disabled", true);
				$("#SendMailComp").on("click", _.partial(this.fireSendMailComp, this));
				$("#SendMailComp").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			rowSelected: function (dataRow) {
				$("#SendMail").prop("disabled", false);
				$("#SendMailComp").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#SendMail").prop("disabled", true);
					$("#SendMailComp").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			setRights: function () {
				this.canSave = appMeta.security.usr('idreg') == this.state.callerState.currentRow.idreg_val || appMeta.security.usr('idreg') == this.state.callerState.currentRow.idreg_comp || appMeta.security.usr('idreg') == this.state.callerState.currentRow.idreg || this.state.callerPage.approva || appMeta.security.usrEnv.progetti_performance.includes('S');
				this.canInsert = appMeta.security.usr('idreg') == this.state.callerState.currentRow.idreg_val || appMeta.security.usr('idreg') == this.state.callerState.currentRow.idreg_comp || appMeta.security.usr('idreg') == this.state.callerState.currentRow.idreg;
				this.canInsertCopy = false;
				this.canCancel = this.state.callerPage.approva || appMeta.security.usrEnv.progetti_performance.includes('S');
				return this.freshToolBar();
			},

			fireSendMail: function (that) {

				if (that.state.isInsertState() ) {
					return that.showMessageOk('Per inviare la mail occorre prima aver salvato.');
				}

	            var messaggioErr;
				var valutato;
				var valutatore;
				var def = appMeta.Deferred("fireSendMail");

				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				if (that.state.callerState.currentRow.idreg) {

					if (that.state.callerState.currentRow.idreg_val) {

						var subj = ' ' + that.state.currentRow.utente;
						var message = '';

						return that.superClass.getRegistryreference(that.state.callerState.currentRow.idreg)
							.then(function (resValutato) {
								valutato = resValutato[0];


								return that.superClass.getRegistryreference(that.state.callerState.currentRow.idreg_val)
							})
							.then(function (resValutatore) {
								valutatore = resValutatore[0];

								//è collegato il valutatore
								if (valutato.idreg != that.sec.usrEnv.idreg) {
									message += ' al valutato ' + valutato.referencename;
								}

								//è collegato il valutato
								if (valutatore.idreg != that.sec.usrEnv.idreg) {
									message += message == '' ? '' : ' e ' + 'al valutatore ' + valutatore.referencename;
								}

								return that.showMessageOkCancel('Saranno inviate delle mail ' + message + '. Procedere?')
							}).then(function (res) {
								if (!res) {
									that.hideWaitingIndicator(waitingHandler);
									return def.resolve();

								}
								var filter = window.jsDataQuery.eq('idperfinterazionekind', that.state.currentRow.idperfinterazionekind);

								return appMeta.getData.runSelect("perfinterazionekind", "*", filter)
							}).
							then(function (dsInterazionikind) { 

								var body = "Sono stati inseriti i seguenti commenti in riferimento all'interazione in oggetto del " +
									that.superClass.stringFromDate_ddmmyyyy(that.state.currentRow.data) + "." + "<br/><br/>" + /*"<br><br>Commenti del valutatore " + valutatore.referencename +  ":<br>" + (that.state.currentRow.commentival ?? "") + "<br><br>" + "Commenti del valutato " + valutato.referencename +":<br>"*/
									(that.state.currentRow.commenti ?? "") + "<br/><br/>";

								body += "<a href=\"" + document.URL.replace("?tablename=perfvalutazionepersonale&edittype=default","") + "\">Vai al portale<\a>";
								
								var subject = dsInterazionikind.rows[0].title + subj +  " in data " + that.superClass.stringFromDate_ddmmyyyy(that.state.currentRow.data);

                                                               body = that.getReturnFromDb(body);
								return that.superClass.sendMail({ emailDest: valutato.email + ';' + valutatore.email, body: body, subject: subject })
							})
							.then(function (msg) {
								that.hideWaitingIndicator(waitingHandler);

								if (msg) {
									return def.from(self.showMessageOk(msg));
								}


								return def.resolve();

							});


					}

					else messaggioErr = "Valorizzare prima l'indirizzo email del valutatore";


				}
				else {
					messaggioErr = "Valorizzare prima l'indirizzo email del valutato";
				}

				if (messaggioErr) {

					return def.resolve(that.showMessageOk("Non è possibile inviare mail, " + messaggioErr));

				}

				def.promise();
			},

			fireSendMailComp: function (that) {

				if (that.state.isInsertState()) {
					return that.showMessageOk('Per inviare la mail occorre prima aver salvato.');
				}

				var messaggioErr;
				var valutato;
				var valutatore;
				var def = appMeta.Deferred("fireSendMailComp");

				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				if (that.state.callerState.currentRow.idreg) {

					if (that.state.callerState.currentRow.idreg_comp) {

						var subj = ' ' + that.state.currentRow.utente;
						var message = '';

						return that.superClass.getRegistryreference(that.state.callerState.currentRow.idreg)
							.then(function (resValutato) {
								valutato = resValutato[0];


								return that.superClass.getRegistryreference(that.state.callerState.currentRow.idreg_comp)
							})
							.then(function (resValutatore) {
								valutatore = resValutatore[0];

								//è collegato il valutatore
								if (valutato.idreg != that.sec.usrEnv.idreg) {
									message += ' al valutato ' + valutato.referencename;
								}

								//è collegato il valutato
								if (valutatore.idreg != that.sec.usrEnv.idreg) {
									message += message == '' ? '' : ' e al rilevatore ' + valutatore.referencename;
								}

								return that.showMessageOkCancel('Saranno inviate delle mail ' + message + '. Procedere?')
							}).then(function (res) {
								if (!res) {
									that.hideWaitingIndicator(waitingHandler);
									return def.resolve();

								}
								var filter = window.jsDataQuery.eq('idperfinterazionekind', that.state.currentRow.idperfinterazionekind);

								return appMeta.getData.runSelect("perfinterazionekind", "*", filter)
							}).
							then(function (dsInterazionikind) {

								var body = "Sono stati inseriti i seguenti commenti in riferimento all'interazione in oggetto del " +
									that.superClass.stringFromDate_ddmmyyyy(that.state.currentRow.data) + "." + "<br/><br/>"+ /*"<br><br>Commenti del rilevatore " + valutatore.referencename +  ":<br>" + (that.state.currentRow.commentival ?? "") + "<br><br>"+ "Commenti del valutato " + valutato.referencename +":<br>"*/
									(that.state.currentRow.commenti ?? "") +  "<br/><br/>";

 								body += "<a href=\"" + document.URL.replace("?tablename=perfvalutazionepersonale&edittype=default","") + "\">Vai al portale<\a>";
								
								var subject = dsInterazionikind.rows[0].title + subj + " in data " + that.superClass.stringFromDate_ddmmyyyy(that.state.currentRow.data);

                                                                body = that.getReturnFromDb(body);
								return that.superClass.sendMail({ emailDest: valutato.email + ';' + valutatore.email, body: body, subject: subject })
							})
							.then(function (msg) {
								that.hideWaitingIndicator(waitingHandler);

								if (msg) {
									return def.from(self.showMessageOk(msg));
								}


								return def.resolve();

							});


					}

					else messaggioErr = "Valorizzare prima l'indirizzo email del rilevatore";


				}
				else {
					messaggioErr = "Valorizzare prima l'indirizzo email del valutato";
				}

				if (messaggioErr) {

					return def.resolve(that.showMessageOk("Non è possibile inviare mail, " + messaggioErr));

				}

				def.promise();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfinterazioni', 'default', metaPage_perfinterazioni);

}());
