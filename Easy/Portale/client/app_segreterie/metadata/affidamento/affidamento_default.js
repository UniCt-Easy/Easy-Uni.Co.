(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamento() {
		MetaPage.apply(this, ['affidamento', 'default', true]);
        this.name = 'Affidamento';
		this.defaultListType = 'default';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-affidamento_default");
				var arraydef = [];
				
				arraydef.push(this.manageaffidamento_default_jsonancestor());
				arraydef.push(this.manageaffidamento_default_title());
				arraydef.push(this.manageaffidamento_default_idsede());
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
				
				if (this.isNull(parentRow.gratuito) || parentRow.gratuito == '')
					parentRow.gratuito = "N";
				if (this.isNull(parentRow.iderogazkind))
					parentRow.iderogazkind = 1;
				if (this.isNull(parentRow.riferimento) || parentRow.riferimento == '')
					parentRow.riferimento = "N";
				_.forEach(this.getDataTable("lezione").rows, function (r) {
					r['!title'] = parentRow.title;
				});

				var affidamentocaratteristica = self.getDataTable("affidamentocaratteristica");
				var arrayIdSasd = _.map(affidamentocaratteristica.rows, function (r) {
					return r.idsasd;
				});
				var sasdaffini = self.getDataTable("sasdaffini");
				var filtersasd = self.q.isIn('idsasd', arrayIdSasd);
				var arrayIdSasdAffiniRows = sasdaffini.select(filtersasd);
				var arrayIdsasd_affine = _.map(arrayIdSasdAffiniRows, function (r) {
					return r.idsasd_affine;
				});
				var filtersasdaffini = self.q.isIn('idsasd', arrayIdsasd_affine);
				var filter = self.q.or(filtersasd,filtersasdaffini);
				$("#grid_getdocentiperssd_seg").data("customParentRelation", filter);
				this.manageaffidamento_default_jsonancestor();
				this.manageaffidamento_default_idsede();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#affidamento_default_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#affidamento_default_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-affidamento_default");
				var arraydef = [];
				
				arraydef.push(this.manageaffidamento_default_title());
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
				this.helpForm.filter($('#affidamento_default_idreg_docenti'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			afterLink: function () {
				var self = this;
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar37').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				appMeta.metaModel.insertFilter(this.getDataTable("affidamentokinddefaultview"), this.q.eq('affidamentokind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("erogazkinddefaultview"), this.q.eq('erogazkind_active', 'Si'));
				$('#grid_affidamentocaratteristica_default').data('mdlconditionallookup', 'profess,S,Si;profess,N,No;');
				var grid_affidamentocaratteristica_defaultChildsTables = [
					{ tablename: 'affidamentocaratteristicaora', edittype: 'default', columnlookup: 'aa', columncalc: '!affidamentocaratteristicaora'},
				];
				$('#grid_affidamentocaratteristica_default').data('childtables', grid_affidamentocaratteristica_defaultChildsTables);
				//indico al framework che la tabella sasdaffini è cached
				var sasdaffiniTable = this.getDataTable("sasdaffini");
				appMeta.metaModel.cachedTable(sasdaffiniTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(sasdaffiniTable, null, null));
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

			beforePost: function () {
				var self = this;
				this.getDataTable('getdocentiperssd').acceptChanges();
				//innerBeforePost
			},

			afterFill: function () {
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("iddidprog", this.state.currentRow.iddidprog),
						self.q.ne("idaffidamento", self.state.currentRow.idaffidamento)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='lezione.attivform.attivform']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {

				if (!that.state.currentRow.title) return that.showMessageOk(that.localResource.loc.getIsValidFieldMandatory('titolo'));

				var scheduler = new appMeta.scheduleConfig(that,
					{
						endDate: that.state.currentRow.stop,
						minDateValue: that.state.currentRow.start,
						maxHours: _.sumBy(that.getDataTable('affidamentocaratteristicaora').rows, function (row) {
							return row.ora;
						}),
						tableNameSchedule: 'lezione',
						columnDate: 'start',
						columnTitle: '!title',
						columnTitleValue: that.state.currentRow.title,
						columnStop: 'stop',
						chooseAula: true
					});
				return scheduler.show();
			},

			manageaffidamento_default_jsonancestor: function () {
				var self = this;
				var p = [];
				var def = appMeta.getData.runSelect('didprog', 'title', this.q.eq('iddidprog', this.state.currentRow.iddidprog), null)
					.then(function (dt) {
						p.push([dt.rows[0].title + ' ' + dt.rows[0].aa, null, 'Corso']);
						return appMeta.getData.runSelect('didprogcurr', 'title', self.q.eq('iddidprogcurr', self.state.currentRow.iddidprogcurr), null);
					}).then(function (dt) {
						p.push([dt.rows[0].title, null, 'Curriculum']); 
						return appMeta.getData.runSelect('didprogori', 'title', self.q.eq('iddidprogori', self.state.currentRow.iddidprogori), null);
					}).then(function (dt) {
						p.push([dt.rows[0].title, null, 'Orientamento']); 
						return appMeta.getData.runSelect('didproganno', 'title', self.q.eq('iddidproganno', self.state.currentRow.iddidproganno), null);
					}).then(function (dt) {
						p.push([dt.rows[0].title, null, 'Anno di corso']); 
						return appMeta.getData.runSelect('didprogporzanno', 'title', self.q.eq('iddidprogporzanno', self.state.currentRow.iddidprogporzanno), null);
					}).then(function (dt) {
						p.push([dt.rows[0].title, null, "Porzione d'anno"]);
						self.state.currentRow.jsonancestor = self.stringify(p, 'json');
						return true;
					});
				return def.promise();
			},

			manageaffidamento_default_title: function () {
				var def = appMeta.Deferred("beforeFill-manageattivform_title");
				var self = this;
				var curraffidamentokind = _.find(this.state.DS.tables.affidamentokinddefaultview.rows, function (row) {
					return row.idaffidamentokind === self.state.currentRow.idaffidamentokind;
				});
				var currdocente = _.find(this.state.DS.tables.registrydocentiview.rows, function (row) {
					return row.idreg === self.state.currentRow.idreg_docenti;
				});

				var output = "<table>" + _.join(
					_.map(this.state.DS.tables.affidamentocaratteristica.rows, function (row) {
						if (row.idaffidamento === self.state.currentRow.idaffidamento)
							return "<tr class='table-in-cell-tr' ><td class='table-in-cell-td' >" + row.title + '</td></tr>';
					}),
					''
				) + '</table>';

				var p = [];
				p.push([curraffidamentokind, 'dropdown_title', 'Tipo di affidamento']);
				p.push([currdocente, 'dropdown_title', 'Docente']);
				p.push([currdocente, 'struttura_title', 'Dipartimento']);
				p.push([currdocente, 'registryistituti_title', 'Istituto']);
				p.push([output, null, 'CF e ore assegnate']);
				this.state.currentRow.json = this.stringify(p, 'json');
				this.state.currentRow.title = this.stringify(p, 'string');

				return def.resolve();

			},

			manageaffidamento_default_idsede: function () {
				this.state.currentRow.idsede= this.state.callerState.currentRow.idsede;
			},

			//buttons
        });

	window.appMeta.addMetaPage('affidamento', 'default', metaPage_affidamento);

}());
