(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoudr() {
		MetaPage.apply(this, ['progettoudr', 'seg', true]);
        this.name = 'Unità di personale';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettoudr.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoudr,
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
				var def = appMeta.Deferred("afterGetFormData-progettoudr_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettoudr_seg_budget());
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
				
				if (this.isNull(parentRow.budget))
					parentRow.budget = 0;
				if (this.isNull(parentRow['!budgetore']))
					parentRow['!budgetore'] = 0;
				this.manageprogettoudr_seg_budget();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettoudr_seg");
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
				this.enableControl($('#progettoudr_seg_budget'), true);
				this.enableControl($('#progettoudr_seg_budgetore'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#progettoudr_seg_budget'), false);
				this.enableControl($('#progettoudr_seg_budgetore'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_progettoudrmembro_seg').data('mdlconditionallookup', 'fondiprogetto,S,Si;fondiprogetto,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			manageprogettoudr_seg_budget: function () {
				var self = this;
				var a = this.state.callerState.currentRow;
				var filterDate = self.q.not(
					self.q.or(
						self.q.and(
							self.q.isNotNull('stop'),
							self.q.lt('stop', a.start)
						), self.q.gt('start', a.stop)
					));
				var filterMembers = self.q.isIn("idreg", _.map(
					this.getDataTable("progettoudrmembro").rows, function (row) {
						return row.idreg;
					}));
				//var getcontrattiRows = this.state.callerPage.getDataTable("getcontratti")
				//.select(self.q.and(filterDate, filterMembers));
				var getcontratti = this.state.callerPage.getDataTable("getcontratti");

				this.state.currentRow.budget = 0;
				this.state.currentRow['!budgetore'] = 0;

				var oreLavorabiliAnno = 1720;
				var progettokinds = self.state.callerPage.getDataTable("progettokindsegview").select(self.q.eq("idprogettokind", self.state.callerState.currentRow.idprogettokind));
				if (progettokinds.length > 0 && progettokinds[0].progettokind_oredivisionecostostipendio)
					oreLavorabiliAnno = progettokinds[0].progettokind_oredivisionecostostipendio;

				_.forEach(self.getDataTable("progettoudrmembro").rows, function (rudrmembro) {
					var costomese = 0;
					var costoora = 0;
					var oremaxgg = 8;
					var filterNull = self.q.isNotNull('costomese');
					var contratti = getcontratti.select(self.q.and(filterDate, self.q.eq('idreg', rudrmembro.idreg), filterNull));
					if (contratti.length > 0) {
						//di base metto costo mensile del registrylegalstatus ...
						if (contratti[0].costomese)
							costomese = contratti[0].costomese;
						if (contratti[0].oremaxgg)
							oremaxgg = contratti[0].oremaxgg;
						if (contratti[0].costolordoannuo)
							costoora = (contratti[0].costolordoannuo / contratti[0].oremax);
					}
					//se è definito un costo orario specifico per questo membro in questo progetto ...
					if (rudrmembro.costoorario) {
						//...lo moltiplico per le ore che può lavorare al giorno per 30 giorni 
						costomese = rudrmembro.costoorario * (oreLavorabiliAnno / 12);
						costoora = rudrmembro.costoorario;
					}
					else {
						//...altrimenti prendo in considerazione il costo mensile da registrylegalstatus

						// se sono definite sulla tipologia di progetto lo calcolo in base alle quelle ore...
						if (progettokinds.length > 0 && contratti.length > 0)
							if (progettokinds[0].progettokind_oredivisionecostostipendio && contratti[0].costolordoannuo) {
								costomese = (contratti[0].costolordoannuo / 12);
								costoora = (contratti[0].costolordoannuo / oreLavorabiliAnno);
							}
						//... altrimenti lascio quello calcolato dalle ore della tipologia di registrylegalstatus che ho inserito all'inizio
					}
					// ... infine lo moltiplico per i mesi di impegno del menbro nel progetto e lo sommo al budget
					self.state.currentRow.budget += costomese * (rudrmembro.impegno ?? 0);
					self.state.currentRow['!budgetore'] += costoora * (rudrmembro.orepreventivate ?? 0);

					//----------------ore rendicontate
				//	var membroRow = rudrmembro;
				//	var q = self.q;
				//	var rendicontattivitaprogettoRows = self.getDataTable("rendicontattivitaprogetto")
				//		.select(q.eq("idreg", membroRow.idreg));
				//	if (rendicontattivitaprogettoRows.length > 0) {
				//		var rendicontattivitaprogettooraRows = self.getDataTable("rendicontattivitaprogettoora")
				//			.select(q.isIn("idrendicontattivitaprogetto", _.map(
				//				rendicontattivitaprogettoRows, function (row) {
				//					return row.idrendicontattivitaprogetto;
				//				})));
				//		if (rendicontattivitaprogettooraRows.length > 0) {
				//			membroRow['!orerendicontate'] = _.sumBy(rendicontattivitaprogettooraRows, function (r) {
				//				if (r.ore) return r.ore;
				//				return 0;
				//			});
				//		}
				//	}
				});
				this.state.currentRow.budget = _.ceil(this.state.currentRow.budget, 2);
				this.state.currentRow['!budgetore'] = _.ceil(this.state.currentRow['!budgetore'], 2);

			},

			//buttons
        });

	window.appMeta.addMetaPage('progettoudr', 'seg', metaPage_progettoudr);

}());
