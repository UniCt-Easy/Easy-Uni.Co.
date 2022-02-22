
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

    function metaPage_rendicontattivitaprogetto() {
		MetaPage.apply(this, ['rendicontattivitaprogetto', 'docente', false]);
        this.name = 'Attività di ricerca';
		this.defaultListType = 'docente';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogetto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogetto,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-rendicontattivitaprogetto_docente");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogetto_docente_orerendicont());
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
				
				if (self.isNullOrMinDate(parentRow.datainizioprevista))
					parentRow.datainizioprevista = new Date();
				if (!parentRow.idreg)
					parentRow.idreg = this.sec.usr('idreg');
				this.managerendicontattivitaprogetto_docente_orerendicont();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogetto_docente");
				var arraydef = [];
				
				var p = [];
					if (self.getDataTable("rendicontattivitaprogettoora").rows.length)
						arraydef.push(appMeta.getData.runSelect('progetto', 'title', self.q.eq('idprogetto', self.state.currentRow.idprogetto), null)
							.then(function (dt) {
								p.push([dt.rows[0].title, null, 'Progetto']);
								return appMeta.getData.runSelect('workpackage', 'title', self.q.eq('idworkpackage', self.state.currentRow.idworkpackage), null);
							}).then(function (dt) {
								p.push([dt.rows[0].title, null, 'Workpackage']);
								p.push([self.state.currentRow.description, null, 'Attività']);
								_.forEach(self.getDataTable("rendicontattivitaprogettoora").rows, function (r) {
									var pcurr = p.slice();
									pcurr.push([r.ore, null, 'Ore']);
									r['!titleancestor'] = self.stringify(pcurr, 'string');
								});
								return true;
							}));
//.state.DS.tables.progettosegview. : per farla caricare full
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterClearin
			},

			
			
			afterRowSelect: function (t, r) {
				$('#rendicontattivitaprogetto_docente_idprogetto').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#rendicontattivitaprogetto_docente_idprogetto').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#rendicontattivitaprogetto_docente_idworkpackage').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#rendicontattivitaprogetto_docente_idworkpackage').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "progettosegview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("workpackagesegview"), false);
					var rendicontattivitaprogetto_docente_idworkpackageCtrl = $('#rendicontattivitaprogetto_docente_idworkpackage').data("customController");
					arraydef.push(rendicontattivitaprogetto_docente_idworkpackageCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idprogetto", r ? r.idprogetto : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idworkpackage)
								rendicontattivitaprogetto_docente_idworkpackageCtrl.fillControl(null, self.state.currentRow.idworkpackage);
							return true;
						})
);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

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


			
			//beforePost

			afterLink: function () {
				var self = this;
				this.setFilterRendicontattivitaprogetto_seg_itineration();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar14').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				$('#rendicontattivitaprogetto_docente_datainizioprevista').on("change", _.partial(this.managedatainizioprevista, self));
				$('#rendicontattivitaprogetto_docente_stop').on("change", _.partial(this.managestop, self));
				this.setDenyNull("rendicontattivitaprogetto","orepreventivate");
				this.setDenyNull("rendicontattivitaprogetto","datainizioprevista");
				appMeta.metaModel.cachedTable(this.getDataTable("workpackagesegview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("workpackagesegview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];

					var filter = self.q.eq('idreg', appMeta.security.usr("idreg"));
					var def = appMeta.getData.runSelect('progettoudrmembro', 'idprogetto', filter)
						.then(function (dt) {
							var arrayOr = [];
							_.forEach(dt.rows, function (r) {
								arrayOr.push(self.q.eq('idprogetto', r.idprogetto));
							});
							self.getDataTable('progettosegview').staticFilter(self.q.or(arrayOr));
							return true;
						})
					arraydef.push(def);

					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},


			insertClick: function (that, grid) {
				if (!$('#rendicontattivitaprogetto_docente_idworkpackage').val() && grid.dataSourceName === 'rendicontattivitaprogettoora') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				if (!$('#rendicontattivitaprogetto_docente_idprogetto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Progetto');
				}
				if (!$('#rendicontattivitaprogetto_docente_idworkpackage').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				if (!$('#rendicontattivitaprogetto_docente_idprogetto').val() && grid.dataSourceName === 'rendicontattivitaprogettoora') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Progetto');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			afterFill: function () {
				this.enableControl($('#rendicontattivitaprogetto_docente_orerendicont'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg),
						self.q.ne("idrendicontattivitaprogetto", self.state.currentRow.idrendicontattivitaprogetto)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='rendicontattivitaprogettoora.seg.seg']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			setFilterRendicontattivitaprogetto_seg_itineration: function () {
				var self = this;
				var filtermembro = self.q.eq('idreg', this.sec.usr('idreg'));
				var filterstart = self.q.lt('start', self.state.currentRow ? (self.state.currentRow.stop ? self.state.currentRow.stop : new Date()) : new Date());
				var filterstop = self.q.gt('stop', self.state.currentRow ? (self.state.currentRow.datainizioprevista ? self.state.currentRow.datainizioprevista : new Date()) : new Date());
				var filter = self.q.and([filtermembro, filterstart, filterstop]);
				self.state.DS.tables.itineration.staticFilter(filter);
			},

			fireOpenScheduleConfig: function (that) {
				// calcola titolo e apre scheduler con tutte le info

				var maxHoursPerDayTable = null;
				var idreg = that.state.currentRow.idreg;
				var filter = that.q.eq("idreg", idreg);
				appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						return that.getFormData(true);
					}).then(function () {

						if (!that.state.currentRow.description
							|| !that.state.currentRow.orepreventivate
							|| !that.state.currentRow.idprogetto
							|| !that.state.currentRow.idworkpackage) return that.showMessageOk(that.localResource.scheduler_fields_mandatory_msg1);

						var p = [];
						appMeta.getData.runSelect('progetto', 'title', that.q.eq('idprogetto', that.state.currentRow.idprogetto), null)
							.then(function (dt) {
								p.push([dt.rows[0].title, null, 'Progetto']);
								return appMeta.getData.runSelect('workpackage', 'title', that.q.eq('idworkpackage', that.state.currentRow.idworkpackage), null);
							}).then(function (dt) {
								if (dt.rows.length) p.push([dt.rows[0].title, null, 'Workpackage']);
								p.push([that.state.currentRow.description, null, 'Attività']);
								var columnTitleValue = that.stringify(p, 'string');
								var scheduler = new appMeta.scheduleConfig(that,
									{
										minDateValue: that.state.currentRow.data,
										maxHours: that.state.currentRow.orepreventivate,
										tableNameSchedule: 'rendicontattivitaprogettoora',
										columnDate: 'data',
										columnOre: 'ore',
										columnTitle: '!titleancestor',
										columnTitleValue: columnTitleValue,
										calendarTag: 'rendicontattivitaprogettoora.seg.seg',
										maxHoursPerDayTable : maxHoursPerDayTable
									});

								return scheduler.show();
							});
					});
			},

			managedatainizioprevista: function(that) { 
				that.setFilterRendicontattivitaprogetto_seg_itineration();
				var checkListCtrl = $("[data-tag='itineration.seg.seg']");
				var ctrl = checkListCtrl.data("customController");
				that.getDataTable('itineration').clear();
				ctrl.loadCheckBoxList();
			},

			managestop: function(that) { 
				that.setFilterRendicontattivitaprogetto_seg_itineration();
				var checkListCtrl = $("[data-tag='itineration.seg.seg']");
				var ctrl = checkListCtrl.data("customController");
				that.getDataTable('itineration').clear();
				ctrl.loadCheckBoxList();
			},

			managerendicontattivitaprogetto_docente_orerendicont: function () {
				this.state.currentRow['!orerendicont'] = _.sumBy(this.getDataTable('rendicontattivitaprogettoora').rows, function (r) {
					return r.ore;
				});
			},

			children: ['rendicontattivitaprogettoitineration', 'rendicontattivitaprogettoora'],
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

	window.appMeta.addMetaPage('rendicontattivitaprogetto', 'docente', metaPage_rendicontattivitaprogetto);

}());
