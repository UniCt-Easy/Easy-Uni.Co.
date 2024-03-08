(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_assetdiary() {
		MetaPage.apply(this, ['assetdiary', 'seg', true]);
        this.name = 'Diari di utilizzo di beni strumentali';
		this.defaultListType = 'seg';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-assetdiary_seg");
				var arraydef = [];
				
				arraydef.push(this.manageassetdiary_seg_amount());
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
				
								_.forEach(this.getDataTable("assetdiaryora").rows, function (r) {
					var p = [];
					var progettoTitle = self.state.callerState.callerState.currentRow.titolobreve;
					var workpageTitle = self.state.callerState.currentRow.title;
					var dtBene = self.getDataTable('assetsegview');
					var beneStrumentaleTitle = "";
					if (dtBene.rows.length) {
						beneStrumentaleTitle = dtBene.rows[0].dropdown_title;
					}

					var dtRegView = self.getDataTable('getregistrydocentiamministratividefaultview');
					var operatoreTitle = "";
					if (dtRegView.rows.length) {
						operatoreTitle = dtRegView.rows[0].dropdown_title;
					}

					p.push([progettoTitle, null, 'Progetto']);
					p.push([workpageTitle, null, 'Workpackage']);
					p.push([operatoreTitle, null, 'Operatore']);
					p.push([beneStrumentaleTitle, null, 'Bene']);

					r['!title'] = self.stringify(p, 'string');
				});
				this.manageassetdiary_seg_amount();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-assetdiary_seg");
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
				this.enableControl($('#assetdiary_seg_amount'), true);
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.setFilterRendicontattivitaprogetto_seg_idreg();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar12').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-assetdiary_seg");
				if (t.name === "assetsegview" && r !== null) {
					return this.manageidpiece(this);
				}
				//afterRowSelectin
				return def.resolve();
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


			//insertClick

			//beforePost

			setFilterRendicontattivitaprogetto_seg_idreg: function () {
				var self = this;
				var filter = self.q.isIn('idreg',
					_.map(self.state.callerState.callerPage.getDataTable("progettoudrmembro").rows, function (r) { return r.idreg; })
				);
				self.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(filter);

				var singleFilters = [];
				_.forEach(self.state.callerState.callerPage.getDataTable("progettoasset").rows, function (r) {
					singleFilters.push(self.q.and(
						self.q.eq('idasset', r.idasset),
						self.q.eq('idpiece', r.idpiece)
					));
				});
				var filterAsset = self.q.or(singleFilters);
				self.state.DS.tables.assetsegview.staticFilter(filterAsset);
			},

			afterFill: function () {
				var matches = $('#assetdiary_seg_idpiece').text().match(new RegExp("Identificativo: " + "(.*)" + ";  Codice UPB:"));
				if (matches && matches.length > 1) {
					$("#assetdiary_seg_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";  Codice UPB:" + ")").attr('selected', true);
					$("#assetdiary_seg_idpiece").parent().find('.select2-selection__rendered').text($("#assetdiary_seg_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";  Codice UPB:" + ")").text())
				} else {
					matches = $('#assetdiary_seg_idpiece').text().match(new RegExp("Identificativo: " + "(.*)" + ";     Numero parte:"));
					if (matches && matches.length > 1) {
						$("#assetdiary_seg_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";     Numero parte:" + ")").attr('selected', true);
						$("#assetdiary_seg_idpiece").parent().find('.select2-selection__rendered').text($("#assetdiary_seg_idpiece option:contains(" + "Identificativo: " + this.state.currentRow.idasset + ";     Numero parte:" + ")").text())
					}
				}

				this.enableControl($('#assetdiary_seg_amount'), false);
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
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {
				var maxHoursPerDayTable = null;
				var idreg = that.state.currentRow.idreg;
				var filter = that.q.eq("idreg", idreg);
				appMeta.getData.runSelect("getoremaxgg", "*", filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						return that.getFormData(true);
					}).then(function () {
						var p = [];
						var progettoTitle = that.state.callerState.callerState.currentRow.titolobreve;
						var workpageTitle = that.state.callerState.currentRow.title;
						var dtBene = that.getDataTable('assetsegview');
						var beneStrumentaleTitle = "";
						if (dtBene.rows.length) {
							beneStrumentaleTitle = dtBene.rows[0].dropdown_title;
						}

						var dtRegView = that.getDataTable('getregistrydocentiamministratividefaultview');
						var operatoreTitle = "";
						if (dtRegView.rows.length) {
							operatoreTitle = dtRegView.rows[0].dropdown_title;
						}

						p.push([progettoTitle, null, 'Progetto']);
						p.push([workpageTitle, null, 'Workpackage']);
						p.push([operatoreTitle, null, 'Operatore']);
						p.push([beneStrumentaleTitle, null, 'Bene']);

						var columnTitleValue = that.stringify(p, 'string');

						var scheduler = new appMeta.scheduleConfig(that,
							{
								minDateValue: new Date(
									new Date().getFullYear(),
									new Date().getMonth() - 3,
									new Date().getDate()
								),
								maxHours: that.state.currentRow.orepreventivate,
								tableNameSchedule: 'assetdiaryora',
								columnDate: 'start',
								columnTitle: '!title',
								columnTitleValue: columnTitleValue,
								columnStop: 'stop',
								calendarTag: "assetdiaryora.seg.seg",
								maxHoursPerDayTable: maxHoursPerDayTable
							});
						return scheduler.show();
					});
			},

			manageassetdiary_seg_amount: function () {
				var curr = this.state.currentRow;
				var assetdiaryora = this.getDataTable('assetdiaryora');
				curr["!amount"] = _.ceil(_.sumBy(
					_.filter(assetdiaryora.rows, function(r){
						return r.idassetdiary === curr.idassetdiary && !!r.amount; 
					}),
					'amount'), 2);
			},

			manageidpiece: function(that) { 
				if ($('#assetdiary_seg_idpiece option:selected').text()) {
					var matches = $('#assetdiary_seg_idpiece option:selected').text().match(new RegExp("Identificativo: " + "(.*)" + ";  Codice UPB:"));
					if (matches && matches.length > 1) {
						$('#assetdiary_seg_idasset').val(matches[1]);
					} else {
						matches = $('#assetdiary_seg_idpiece option:selected').text().match(new RegExp("Identificativo: " + "(.*)" + ";     Numero parte:"));
						if (matches && matches.length > 1) {
							$('#assetdiary_seg_idasset').val(matches[1]);
						}
					}
				}
			},

			//buttons
        });

	window.appMeta.addMetaPage('assetdiary', 'seg', metaPage_assetdiary);

}());
