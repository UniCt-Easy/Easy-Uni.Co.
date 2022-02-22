
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function metaPage_progettoudr() {
		MetaPage.apply(this, ['progettoudr', 'seg', true]);
        this.name = 'Unit� di personale';
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
				
				if (!parentRow.budget)
					parentRow.budget = 0;
				if (!parentRow['!budgetore'])
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

			//afterClear

			afterFill: function () {
				this.enableControl($('#progettoudr_seg_budget'), false);
				this.enableControl($('#progettoudr_seg_budgetore'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

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
						//di base metto costo mensile del contratto ...
						if (contratti[0].costomese)
							costomese = contratti[0].costomese;
						if (contratti[0].oremaxgg)
							oremaxgg = contratti[0].oremaxgg;
						if (contratti[0].costolordoannuo)
							costoora = (contratti[0].costolordoannuo / contratti[0].oremax);
					}
					//se � definito un costo orario specifico per questo membro in questo progetto ...
					if (rudrmembro.costoorario) {
						//...lo moltiplico per le ore che pu� lavorare al giorno per 30 giorni 
						costomese = rudrmembro.costoorario * (oreLavorabiliAnno / 12);
						costoora = rudrmembro.costoorario;
					}
					else {
						//...altrimenti prendo in considerazione il costo mensile da contratto

						// se sono definite sulla tipologia di progetto lo calcolo in base alle quelle ore...
						if (progettokinds.length > 0 && contratti.length > 0)
							if (progettokinds[0].progettokind_oredivisionecostostipendio && contratti[0].costolordoannuo) {
								costomese = (contratti[0].costolordoannuo / 12);
								costoora = (contratti[0].costolordoannuo / oreLavorabiliAnno);
							}
						//... altrimenti lascio quello calcolato dalle ore della tipologia di contratto che ho inserito all'inizio
					}
					// ... infine lo moltiplico per i mesi di impegno del menbro nel progetto e lo sommo al budget
					self.state.currentRow.budget += costomese * (rudrmembro.impegno ?? 0);
					self.state.currentRow['!budgetore'] += costoora * (rudrmembro.orepreventivate ?? 0);

					//----------------ore rendicontate
					var projectPage = self.state.callerPage;
					var membroRow = rudrmembro;
					var q = self.q;
					var rendicontattivitaprogettoRows = projectPage.getDataTable("rendicontattivitaprogetto")
						.select(q.eq("idreg", membroRow.idreg));
					if (rendicontattivitaprogettoRows.length > 0) {
						var rendicontattivitaprogettooraRows = projectPage.getDataTable("rendicontattivitaprogettoora")
							.select(q.isIn("idrendicontattivitaprogetto", _.map(
								rendicontattivitaprogettoRows, function (row) {
									return row.idrendicontattivitaprogetto;
								})));
						if (rendicontattivitaprogettooraRows.length > 0) {
							membroRow['!orerendicontate'] = _.sumBy(rendicontattivitaprogettooraRows, function (r) {
								if (r.ore) return r.ore;
								return 0;
							});
						}
					}
				});
				this.state.currentRow.budget = _.ceil(this.state.currentRow.budget, 2);
				this.state.currentRow['!budgetore'] = _.ceil(this.state.currentRow['!budgetore'], 2);

			},

			//buttons
        });

	window.appMeta.addMetaPage('progettoudr', 'seg', metaPage_progettoudr);

}());
