
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

    function metaPage_assetdiary() {
		MetaPage.apply(this, ['assetdiary', 'seganag', true]);
        this.name = 'Diari di utilizzo di beni strumentali';
		this.defaultListType = 'seganag';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_assetdiary.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_assetdiary,
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
				
								_.forEach(this.getDataTable("assetdiaryora").rows, function (r) {
					var p = [];
					var dtProgetto = self.getDataTable('progettosegview');
					var progettoTitle = "";
					if (dtProgetto.rows.length) {
						progettoTitle = dtProgetto.rows[0].dropdown_title;
					}

					var workpageTitle = $("#assetdiary_seganag_idworkpackage option:selected").text();

					var operatoreTitle = "";
					var dtReg = self.state.callerState.DS.tables.registry;
					if (dtReg.rows.length) {
						operatoreTitle = dtReg.rows[0].title;
					}

					var dtAssetsegview = self.getDataTable('assetsegview');
					var beneStrumentaleTitle = "";
					if (dtAssetsegview.rows.length) {
						beneStrumentaleTitle = dtAssetsegview.rows[0].dropdown_title;
					}
					p.push([progettoTitle, null, 'Progetto']);
					p.push([workpageTitle, null, 'Workpackage']);
					p.push([operatoreTitle, null, 'Operatore']);
					p.push([beneStrumentaleTitle, null, 'Bene']);

					r['!title'] = self.stringify(p, 'string');
				});
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-assetdiary_seganag");
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

			
			afterLink: function () {
				var self = this;
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar11').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				$('#assetdiary_seganag_idpiece').on("change", _.partial(this.manageidpiece, self));
				appMeta.metaModel.cachedTable(this.getDataTable("workpackagesegview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("workpackagesegview"));
				appMeta.metaModel.cachedTable(this.getDataTable("assetsegview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("assetsegview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#assetdiary_seganag_idworkpackage').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#assetdiary_seganag_idworkpackage').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#assetdiary_seganag_idprogetto').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#assetdiary_seganag_idprogetto').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "progettosegview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("workpackagesegview"), false);
					var assetdiary_seganag_idworkpackageCtrl = $('#assetdiary_seganag_idworkpackage').data("customController");
					arraydef.push(assetdiary_seganag_idworkpackageCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idprogetto", r ? r.idprogetto : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idworkpackage)
								assetdiary_seganag_idworkpackageCtrl.fillControl(null, self.state.currentRow.idworkpackage);
							return true;
						})
);
				}
				if (t.name === "progettosegview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("assetsegview"), false);
					var assetdiary_seganag_idpieceCtrl = $('#assetdiary_seganag_idpiece').data("customController");
					if (r) {
						var filter = this.q.eq('idprogetto', r.idprogetto);
						var def = appMeta.getData.runSelect('progettoasset', 'idpiece, idasset', filter)
							.then(function (dt) {
								var arrayOr = [];
								_.forEach(dt.rows, function(r){
									arrayOr.push(self.q.and( self.q.eq('idpiece', r.idpiece),self.q.eq('idasset', r.idasset)));
								});
								return assetdiary_seganag_idpieceCtrl.filteredPreFillCombo(self.q.or(arrayOr), null, true);
							});
						arraydef.push(def);
					}
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			afterActivation: function () {
				var parentRow = this.state.currentRow;
				var self = this;
				//afterActivationin
				var arraydef = [];
				if (parentRow.idprogetto) {
					appMeta.metaModel.cachedTable(this.getDataTable("workpackagesegview"), false);
					var assetdiary_seganag_idworkpackageCtrl = $('#assetdiary_seganag_idworkpackage').data("customController");
					arraydef.push(assetdiary_seganag_idworkpackageCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idprogetto", parentRow.idprogetto), null, true));
				}
				if (parentRow.idprogetto) {
					appMeta.metaModel.cachedTable(this.getDataTable("assetsegview"), false);
					var assetdiary_seganag_idpieceCtrl = $('#assetdiary_seganag_idpiece').data("customController");
					var filter = this.q.eq('idprogetto', this.state.currentRow.idprogetto);
					var def = appMeta.getData.runSelect('progettoasset', 'idpiece, idasset', filter)
						.then(function (dt) {
							var arrayOr = [];
							_.forEach(dt.rows, function(r){
								arrayOr.push(self.q.and( self.q.eq('idpiece', r.idpiece),self.q.eq('idasset', r.idasset)));
							});
							return assetdiary_seganag_idpieceCtrl.filteredPreFillCombo(self.q.or(arrayOr), null, true).then(function () {
									return assetdiary_seganag_idpieceCtrl.fillControl(null, self.state.currentRow.idpiece);
							});
							arraydef.push(def);
						});
				}
				//afterActivationAsincIn
				return $.when.apply($, arraydef);
			},

			rowSelected: function (dataRow) {
				$("#OpenScheduleConfig").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#OpenScheduleConfig").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#assetdiary_seganag_idworkpackage').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterFill: function () {
				var matches = $('#assetdiary_seganag_idpiece').text().match(new RegExp("Identificativo: " + "(.*)" + ";  Codice UPB:"));
				if (matches && matches.length > 1) {
					$("#assetdiary_seganag_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";  Codice UPB:" + ")").attr('selected', true);
					$("#assetdiary_seganag_idpiece").parent().find('.select2-selection__rendered').text($("#assetdiary_seganag_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";  Codice UPB:" + ")").text())
				} else {
					matches = $('#assetdiary_seganag_idpiece').text().match(new RegExp("Identificativo: " + "(.*)" + ";     Numero parte:"));
					if (matches && matches.length > 1) {
						$("#assetdiary_seganag_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";     Numero parte:" + ")").attr('selected', true);
						$("#assetdiary_seganag_idpiece").parent().find('.select2-selection__rendered').text($("#assetdiary_seganag_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";     Numero parte:" + ")").text())
					}
				}

				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					if (this.state.currentRow.idreg && this.state.currentRow.idassetdiary &&
						this.state.currentRow.idasset && this.state.currentRow.idpiece) {
						// carica tutte le attività dell'utente tranne quelle del diario d'uso corrente 
						var filterOthersActivities = self.q.and(
							self.q.eq("idreg", this.state.currentRow.idreg),
							self.q.ne("idassetdiary", this.state.currentRow.idassetdiary)
						);
						var filterAss = self.q.and([
							self.q.eq("idasset", this.state.currentRow.idasset),
							self.q.eq("idpiece", this.state.currentRow.idpiece),
							self.q.ne("idreg", this.state.currentRow.idreg)]
						);
						var filter = self.q.or(
							filterOthersActivities,
							filterAss
						);
						return this.getExternalEventForCalendar(filter, $("[data-tag='assetdiaryora.seg.seg']")).then(function () {
							return MetaPage.prototype.afterFill.call(self);
						});
					}
					return MetaPage.prototype.afterFill.call(this);
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {
				var maxHoursPerDayTable = null;
				var idreg = that.state.currentRow.idreg;
				var filter = that.q.eq("idreg", idreg);
				appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						return that.getFormData(true);
					}).then(function () {
						var p = [];

						var dtProgetto = that.getDataTable('progettosegview');
						var progettoTitle = "";
						if (dtProgetto.rows.length) {
							progettoTitle = dtProgetto.rows[0].dropdown_title;
						}

						var workpageTitle = $("#assetdiary_seganag_idworkpackage option:selected").text();

						var operatoreTitle = "";
						var dtReg =  that.state.callerState.DS.tables.registry;
						if (dtReg.rows.length) {
							operatoreTitle = dtReg.rows[0].title;
						}

						var dtAssetsegview =  that.getDataTable('assetsegview');
						var beneStrumentaleTitle = "";
						if (dtAssetsegview.rows.length) {
							beneStrumentaleTitle = dtAssetsegview.rows[0].dropdown_title;
						}

						p.push([progettoTitle, null, 'Progetto']);
						p.push([workpageTitle, null, 'Workpackage']);
						p.push([operatoreTitle, null, 'Operatore']);
						p.push([beneStrumentaleTitle, null, 'Bene']);

						var columnTitleValue = that.stringify(p, 'string');

						var scheduler = new appMeta.scheduleConfig(that,
							{
								minDateValue: new Date(),
								maxHours: that.state.currentRow.orepreventivate,
								tableNameSchedule: 'assetdiaryora',
								columnDate: 'start',
								columnTitle: '!title',
								columnTitleValue: columnTitleValue,
								columnStop: 'stop',
								calendarTag : "assetdiaryora.seg.seg",
								maxHoursPerDayTable : maxHoursPerDayTable
							});
						return scheduler.show();
					});
			},

			manageidpiece: function(that) { 
				if ($('#assetdiary_seganag_idpiece option:selected').text()) {
					var matches = $('#assetdiary_seganag_idpiece option:selected').text().match(new RegExp("Identificativo: " + "(.*)" + ";  Codice UPB:"));
					if (matches && matches.length > 1) {
						$('#assetdiary_seganag_idasset').val(matches[1]);
					} else {
						matches = $('#assetdiary_seganag_idpiece option:selected').text().match(new RegExp("Identificativo: " + "(.*)" + ";     Numero parte:"));
						if (matches && matches.length > 1) {
							$('#assetdiary_seganag_idasset').val(matches[1]);
						}
					}
				}
			},

			children: ['assetdiaryora'],
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

	window.appMeta.addMetaPage('assetdiary', 'seganag', metaPage_assetdiary);

}());
