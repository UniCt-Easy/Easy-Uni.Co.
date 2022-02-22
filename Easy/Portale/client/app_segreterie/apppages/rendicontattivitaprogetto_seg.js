
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
		MetaPage.apply(this, ['rendicontattivitaprogetto', 'seg', true]);
        this.name = 'Attività';
		this.defaultListType = 'seg';
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
				var def = appMeta.Deferred("afterGetFormData-rendicontattivitaprogetto_seg");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogetto_seg_orerendicont());
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
								var that = this;
				_.forEach(this.getDataTable("rendicontattivitaprogettoora").rows, function (r) {
					var progettoTitle = that.state.callerState.callerState.currentRow.title;
					var workpageTitle = that.state.callerState.currentRow.title;
					var rendicontattivitaprogettoTitle = that.state.currentRow.description;

					var p = [];
					p.push([progettoTitle, null, 'Progetto']);
					p.push([workpageTitle, null, 'Workpackage']);
					p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
					p.push([r.ore, null, 'Ore']);
					r['!titleancestor'] = that.stringify(p, 'string');
				});
				this.managerendicontattivitaprogetto_seg_orerendicont();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogetto_seg");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.setFilterRendicontattivitaprogetto_seg_idreg();
				this.setFilterRendicontattivitaprogetto_seg_itineration();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar14').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				$('#rendicontattivitaprogetto_seg_datainizioprevista').on("change", _.partial(this.managedatainizioprevista, self));
				$('#rendicontattivitaprogetto_seg_idreg').on("change", _.partial(this.manageidreg, self));
				$('#rendicontattivitaprogetto_seg_stop').on("change", _.partial(this.managestop, self));
				this.setDenyNull("rendicontattivitaprogetto","orepreventivate");
				this.setDenyNull("rendicontattivitaprogetto","datainizioprevista");
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


			//insertClick

			//beforePost

			afterRowSelect: function (t, r) {
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "getregistrydocentiamministratividefaultview" && r !== null) {
					if (r.idreg) {
						arraydef.push(self.getFormData(true)
							.then(function () {
								self.setFilterRendicontattivitaprogetto_seg_itineration();
								self.getDataTable('itineration').clear();
								var checkListCtrl = $("[data-tag='itineration.seg.seg']");
								var ctrl = checkListCtrl.data("customController");
								return ctrl.loadCheckBoxList();
							}));
					}
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			setFilterRendicontattivitaprogetto_seg_idreg: function () {
				var self = this;
				var filter = self.q.isIn('idreg',
					_.map(self.state.callerState.callerPage.getDataTable("progettoudrmembro").rows, function (r) { return r.idreg; })
				);
				self.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(filter);
			},

			setFilterRendicontattivitaprogetto_seg_itineration: function () {
				var self = this;
				var filtermembro = self.q.eq('idreg', self.state.currentRow ? self.state.currentRow.idreg : 0);
				var filterstart = self.q.lt('start', self.state.currentRow ? (self.state.currentRow.stop ? self.state.currentRow.stop : new Date()) : new Date());
				var filterstop = self.q.gt('stop', self.state.currentRow ? (self.state.currentRow.datainizioprevista ? self.state.currentRow.datainizioprevista : new Date()) : new Date());
				var filter = self.q.and([filtermembro, filterstart, filterstop]);
				self.state.DS.tables.itineration.staticFilter(filter);
			},

			afterFill: function () {
				this.enableControl($('#rendicontattivitaprogetto_seg_orerendicont'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					if (this.state.currentRow.idreg && this.state.currentRow.idrendicontattivitaprogetto) {
						// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
						var filter = self.q.and(
							self.q.eq("idreg", this.state.currentRow.idreg),
							self.q.ne("idrendicontattivitaprogetto", this.state.currentRow.idrendicontattivitaprogetto)
						);
						return this.getExternalEventForCalendar(filter, $("[data-tag='rendicontattivitaprogettoora.seg.seg']")).then(function () {
							return MetaPage.prototype.afterFill.call(self);
						});
					}
					return MetaPage.prototype.afterFill.call(this);
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig:function(that) {
				var maxHoursPerDayTable = null;
				var idreg = that.state.currentRow.idreg;
				var filter = that.q.eq("idreg", idreg);
				appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						return that.getFormData(true);
					}).then(function () {
							var progettoTitle = that.state.callerState.callerState.currentRow.title;
							var workpageTitle = that.state.callerState.currentRow.title;
							var rendicontattivitaprogettoTitle = that.state.currentRow.description;

							if (!rendicontattivitaprogettoTitle
								|| !that.state.currentRow.orepreventivate
								|| !that.state.currentRow.idprogetto
								|| !progettoTitle
								|| !workpageTitle
								|| !that.state.currentRow.idworkpackage) return that.showMessageOk(that.localResource.scheduler_fields_mandatory_msg1);

							var p = [];
							p.push([progettoTitle, null, 'Progetto']);
							p.push([workpageTitle, null, 'Workpackage']);
							p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
							var columnTitleValue = that.stringify(p, 'string');
							var scheduler = new appMeta.scheduleConfig(that,
								{
									minDateValue : that.state.currentRow.datainizioprevista,
									maxHours: that.state.currentRow.orepreventivate,
									tableNameSchedule: 'rendicontattivitaprogettoora',
									columnDate: 'data',
									columnOre: 'ore',
									columnTitle : '!titleancestor',
									columnTitleValue : columnTitleValue,
									calendarTag : "rendicontattivitaprogettoora.seg.seg",
									maxHoursPerDayTable : maxHoursPerDayTable
								});
							return scheduler.show();
						});
			},

			managedatainizioprevista: function(that) { 
				that.setFilterRendicontattivitaprogetto_seg_itineration();
				var checkListCtrl = $("[data-tag='itineration.seg.seg']");
				var ctrl = checkListCtrl.data("customController");
				that.getDataTable('itineration').clear();
				ctrl.loadCheckBoxList();
			},

			manageidreg: function(that) { 
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

			managerendicontattivitaprogetto_seg_orerendicont: function () {
				this.state.currentRow['!orerendicont'] = _.sumBy(this.getDataTable('rendicontattivitaprogettoora').rows, function (r) {
					return r.ore;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicontattivitaprogetto', 'seg', metaPage_rendicontattivitaprogetto);

}());
