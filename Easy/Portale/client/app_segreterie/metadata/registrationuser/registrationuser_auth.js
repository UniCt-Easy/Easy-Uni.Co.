
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

    function metaPage_registrationuser() {
		MetaPage.apply(this, ['registrationuser', 'auth', false]);
        this.name = 'Richiesta di accesso';
		this.defaultListType = 'auth';
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canSave = false;
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_registrationuser.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registrationuser,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_registrationuser");
				var firstErrorObj;

				if (rowToCheck.table.dataset.tables["registrationuserflowchart"] && rowToCheck.table.dataset.tables["registrationuserflowchart"].rows.length < 1) {
					firstErrorObj = { warningMsg: "", errMsg: loc.getMinNumRowRequired("Autorizzazioni richieste", 1), errField: "XXregistrationuserflowchart", row: rowToCheck };
					return def.resolve(firstErrorObj);
				}
//$isValidArray$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.esercizio)
					parentRow.esercizio = (new Date()).getFullYear();
				if (!parentRow.idregistrationuserstatus)
					parentRow.idregistrationuserstatus = 1;
				if (!parentRow.userkind)
					parentRow.userkind = 5;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registrationuser_auth");
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

			//afterClear

			afterFill: function () {
				this.enableControl($('#registrationuser_auth_surname'), false);
				this.enableControl($('#registrationuser_auth_forename'), false);
				this.enableControl($('#registrationuser_auth_cf'), false);
				this.enableControl($('#registrationuser_auth_email'), false);
				this.enableControl($('#registrationuser_auth_login'), false);
				this.enableControl($('#registrationuser_auth_idregistrationuserstatus'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#GiveAccess").on("click", _.partial(this.fireGiveAccess, this));
				$("#GiveAccess").prop("disabled", true);
				this.setFilterRegistrationuser_usr_flowchart();
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
				$("#GiveAccess").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#GiveAccess").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			fireGiveAccess: function (that) {
				var def = appMeta.Deferred("registerUser");
				// chiama la getFormData() per rinfrescare il Dataset con i dati inseriti sulla form.

				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_for_registration);

				that.getFormData(false)
					.then(function (res) {
						// salvo i dati se la getForm datata è ok
						var codeflowchart = that.getCodesFlowChart();
						if (!codeflowchart) {
							return that.showMessageOk('Seleziona almeno un profilo da associare all\'utente')
								.then(function () {
									that.hideWaitingIndicator(waitingHandler);
									return def.resolve();
								});
						}

						var msg = "";
						if (res) {
							return appMeta.callWebService("adminregisteruser",
								{
									login: $("#registrationuser_auth_login").val(),
									password: '',
									passwordweb: '',
									surname: $("#registrationuser_auth_surname").val(),
									forename: $("#registrationuser_auth_forename").val(),
									cf: $("#registrationuser_auth_cf").val(),
									email: $("#registrationuser_auth_email").val(),
									codeflowchart: codeflowchart,
									esercizio: (new Date()).getFullYear(),
									usertype: $("#registrationuser_auth_usertype option:selected").text(),
									matricola: $("#registrationuser_auth_matricola").val(),
									userkind : 5,
									idregistrationuser: that.state.currentRow.idregistrationuser
								})
								.then(function (res) {
									var err  = res.err;
									msg = res.msg;
									// è andata a buon fine
									if (err === 0) {
										that.state.currentRow.idregistrationuserstatus = 2;
										that.state.currentRow.getRow().acceptChanges();
										msg = "Registrazione eseguita con successo. Utente autorizzato. <br><br>" + msg;
										return that.freshForm(true, false)
									}
									return true;
								}).then(function(){
									that.hideWaitingIndicator(waitingHandler);
									return that.showMessageOk(msg)
								}).then(function () {
									return def.resolve();
								});
						}
						that.hideWaitingIndicator(waitingHandler);
						return def.resolve();
					});

				return def.promise();
			},

			/**
			 * returns a string with codeflowchart separated by ;. code1;code2;coden
			 * @returns {string}
			 */
			getCodesFlowChart: function() {
				var registrationuserflowchart = this.getDataTable('registrationuserflowchart');
				var flowchart = this.getDataTable('flowchart');
				var codesFlowChart = [];
				if (registrationuserflowchart.rows && registrationuserflowchart.rows.length) {

					var notDeletedRows = _.filter(registrationuserflowchart.rows, function(r) {
						return r.getRow().state !== jsDataSet.dataRowState.deleted
					});

					if (notDeletedRows && notDeletedRows.length){
						_.forEach(notDeletedRows, function (r) {

							var idflowchart = r.idflowchart;
							var rowsFlowChart = _.filter(flowchart.rows, function(rflowChart) {
								return rflowChart.idflowchart === idflowchart;
							});
							if (rowsFlowChart.length) {
								codesFlowChart.push(rowsFlowChart[0].codeflowchart);
							}
						});
					}
				}
				return _.join(codesFlowChart, ';');
			},

			setFilterRegistrationuser_usr_flowchart: function () {
				var self = this;
				var filter = self.q.eq('ayear', (new Date()).getFullYear());
				self.state.DS.tables.flowchart.staticFilter(filter);
			},

			//buttons
        });

	window.appMeta.addMetaPage('registrationuser', 'auth', metaPage_registrationuser);

}());
