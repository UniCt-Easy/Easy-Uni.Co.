(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicont() {
		MetaPage.apply(this, ['rendicont', 'default', true]);
        this.name = 'Scheda di rendicontazione / registro elettronico';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_rendicont.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicont,
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
				var def = appMeta.Deferred("afterGetFormData-rendicont_default");
				var arraydef = [];
				
				arraydef.push(this.manage_lezione_title());
				arraydef.push(this.managerendicont_default_title());
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
				
				_.forEach(this.getDataTable("rendicontaltro").rows, function (r) {
    var title = r.ore + ' ore';
    if(r.idrendicontaltrokind) {
        var tipoRows = self.getDataTable("rendicontaltrokind").select(self.q.eq('idrendicontaltrokind', r.idrendicontaltrokind));
        if (tipoRows.length) {
            title += ' per ' + tipoRows[0].title;
        }
    }
    r['!title'] = title;
});				this.managerendicont_default_title();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicont_default");
				var arraydef = [];
				
				arraydef.push(this.manage_lezione_title());
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
					$('#calendar7').fullCalendar('rerenderEvents');
				});
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar8').fullCalendar('rerenderEvents');
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
				var def = appMeta.Deferred("afterRowSelect-rendicont_default");
				$('#rendicont_default_aa').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#rendicont_default_aa').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
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


			insertClick: function (that, grid) {
				if (!$('#rendicont_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno accademico');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterFill: function () {
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg_docenti),
						self.q.eq("idrendicontaltro",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='rendicontaltro.default.default']")).then(function () {
						var filterLez = self.q.and(
							self.q.eq("idreg", self.state.currentRow.idreg_docenti),
							self.q.eq("idlezione", 0)
						);
						return self.getExternalEventForCalendar(filterLez, $("[data-tag='lezione.rendicont.rendicont']")).then(function () {
							return MetaPage.prototype.afterFill.call(self);
						});

					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			manage_lezione_title: function () {
				var self = this;
				//titolo delle lezioni
				var def = appMeta.Deferred('getlezioneTitle');
				var filter = this.q.and(this.q.isNotNull('idlezione'), this.q.eq('idreg', this.state.currentRow.idreg_docenti));
				appMeta.getData.runSelect("getcalendareventview",
					"color, title, start, stop, ore, idlezione, idassetdiary, idrendicontattivitaprogetto", filter, null)
					.then(function (dt) {

						_.forEach(self.getDataTable("lezione").rows, function (r) {

							var currLezioneEvent = _.find(dt.rows, function (row) {
								return row.idlezione === r.idlezione;
							});

							r['!title'] = currLezioneEvent.title;

						});

						def.resolve();
					});
				return def.promise();
			},

			fireOpenScheduleConfig: function (that) {
	if (!that.state.currentRow.idreg_docenti)
		return that.showMessageOk('Occorre indicare chi svolge l\'attività e salvare');
	var aa = that.state.currentRow.aa.split("/");
	var start = new Date(aa[0], 10, 1); //inizio anno accademico
	var stop = new Date(aa[1], 9, 31); //fine anno accademico
	let maxHoursPerDayTable = null;
	let idreg_docenti = that.state.currentRow.idreg_docenti;
	let filter = that.q.and([
		that.q.eq("idreg", idreg_docenti),
		that.q.or(that.q.isNull("start"), that.q.le("start", start)),
		that.q.or(that.q.isNull("stop"), that.q.ge("stop", stop))
	]);
	appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
		.then(function (dt) {
			maxHoursPerDayTable = dt;
			return that.getFormData(true);
		}).then(function () {
				var scheduler = new appMeta.scheduleConfig(that,
					{
						endDate: stop,
						minDateValue : start,
						maxHours: 1500, //massimo ore lavorabili per docente per anno
						tableNameSchedule: 'rendicontaltro',
						columnDate: 'data',
						columnOre: 'ore',
						columnTitle : '!title',
						columnTitleValue : "schedulazione",
						calendarTag : "rendicontaltro.default.default",
						maxHoursPerDayTable : maxHoursPerDayTable,
						chooseKind : true
					});
				return scheduler.show();
			});
}
,

			managerendicont_default_title: function () {
				this.state.currentRow.title = "Rendicontazione " + this.state.currentRow.aa;


			},

			children: ['lezione', 'rendicontaltro'],
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

	window.appMeta.addMetaPage('rendicont', 'default', metaPage_rendicont);

}());
