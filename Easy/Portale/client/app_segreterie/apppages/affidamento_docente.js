(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamento() {
		MetaPage.apply(this, ['affidamento', 'docente', false]);
        this.name = 'Affidamento';
		this.defaultListType = 'docente';
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.canShowLast = false;
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_affidamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamento,
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
				
				_.forEach(this.getDataTable("lezione_alias2").rows, function (r) {
					r['!title'] = parentRow.title;
				});
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-affidamento_docente");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.state.DS.tables.affidamento.defaults({ 'gratuito': "N" });
				this.state.DS.tables.affidamento.defaults({ 'iderogazkind': 1 });
				this.state.DS.tables.affidamento.defaults({ 'riferimento': "N" });
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar37').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				$('#grid_affidamentocaratteristica_seg').data('mdlconditionallookup', 'profess,S,Si;profess,N,No;');
				var grid_affidamentocaratteristica_segChildsTables = [
					{ tablename: 'affidamentocaratteristicaora', edittype: 'seg', columnlookup: 'ora', columncalc: '!affidamentocaratteristicaora'},
				];
				$('#grid_affidamentocaratteristica_seg').data('childtables', grid_affidamentocaratteristica_segChildsTables);
				$('#grid_affidamentocaratteristica_seg').data('childtablesadd', false);
				$('#grid_affidamentocaratteristica_seg').data('childtablesdelete', false);
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

			afterFill: function () {
				this.enableControl($('#affidamento_docente_freqobblSi'), false);
				this.enableControl($('#affidamento_docente_freqobblNo'), false);
				this.enableControl($('#affidamento_docente_gratuitoSi'), false);
				this.enableControl($('#affidamento_docente_gratuitoNo'), false);
				this.enableControl($('#affidamento_docente_idaffidamentokind'), false);
				this.enableControl($('#affidamento_docente_iderogazkind'), false);
				this.enableControl($('#affidamento_docente_riferimentoSi'), false);
				this.enableControl($('#affidamento_docente_riferimentoNo'), false);
				this.enableControl($('#affidamento_docente_start'), false);
				this.enableControl($('#affidamento_docente_stop'), false);
				this.enableControl($('#affidamento_docente_urlcorso'), false);
				this.enableControl($('#affidamento_docente_frequenzaminima'), false);
				this.enableControl($('#affidamento_docente_frequenzaminimadebito'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg_docenti),
						self.q.ne("idaffidamento", self.state.currentRow.idaffidamento)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='lezione_alias2.seg.seg']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {

				if (!that.state.currentRow.title) return that.showMessageOk(that.localResource.loc.getIsValidFieldMandatory('titolo'));
				var maxHoursPerDayTable = null;
				var idreg = that.state.currentRow.idreg_docenti;
				var filter = that.q.eq("idreg", idreg);
				appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						var scheduler = new appMeta.scheduleConfig(that,
							{
								endDate: that.state.currentRow.stop,
								minDateValue: that.state.currentRow.start,
								maxHours: _.sumBy(that.getDataTable('affidamentocaratteristicaora').rows, function (row) {
									return row.ora;
								}),
								tableNameSchedule: 'lezione_alias2',
								columnDate: 'start',
								columnTitle: '!title',
								columnTitleValue: that.state.currentRow.title,
								columnStop: 'stop',
								chooseAula: true,
								calendarTag : "lezione_alias2.seg.seg",
								maxHoursPerDayTable : maxHoursPerDayTable
							});
						return scheduler.show();
					})
			},

			//buttons
        });

	window.appMeta.addMetaPage('affidamento', 'docente', metaPage_affidamento);

}());
