
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

    function metaPage_perfinterazioni() {
		MetaPage.apply(this, ['perfinterazioni', 'default', true]);
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
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$("#SendMail").on("click", _.partial(this.fireSendMail, this));
				$("#SendMail").prop("disabled", true);
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
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#SendMail").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			fireSendMail: function(that) {
	                       var messaggioErr;
				var valutato;
				var valutatore;
				var def = appMeta.Deferred("fireSendMail");

				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				if (that.state.callerState.currentRow.idreg) {

					if (that.state.callerState.currentRow.idreg_val) {



						return that.superClass.getRegistryreference(that.state.callerState.currentRow.idreg)
							.then(function (resValutato) {
								valutato = resValutato[0];


								return that.superClass.getRegistryreference(that.state.callerState.currentRow.idreg_val)
							})
							.then(function (resValutatore) {
								valutatore = resValutatore[0];


								var message = '';
								if (valutato.idreg != that.sec.usrEnv.idreg) {
									message += ' al valutato ' + valutato.referencename;
								}
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

								var body = "Sono stati inseriti i seguenti commenti in riferimento all'interazione in oggetto del " + that.superClass.stringFromDate_ddmmyyyy(that.state.currentRow.data) + "<br><br>Commenti del valutatore " + valutatore.referencename +  ":<br>" + (that.state.currentRow.commentival ?? "") + "<br><br>" + "Commenti del valutato " + valutato.referencename +":<br>" + (that.state.currentRow.commenti ?? "") + "<br>";
								var subject = dsInterazionikind.rows[0].title + " in data " + that.superClass.stringFromDate_ddmmyyyy(that.state.currentRow.data);

								return that.superClass.sendMail({ emailDest: valutato.email + ';' + valutatore.email, htmlBody: body, subject: subject })
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

			//buttons
        });

	window.appMeta.addMetaPage('perfinterazioni', 'default', metaPage_perfinterazioni);

}());
