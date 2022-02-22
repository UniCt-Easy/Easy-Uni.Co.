
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

    function metaPage_sal() {
		MetaPage.apply(this, ['sal', 'default', false]);
        this.name = 'Stato avanzamento lavori';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sal.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sal,
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
				var def = appMeta.Deferred("afterGetFormData-sal_default");
				var arraydef = [];
				
				arraydef.push(this.managesal_default_budgetcalcolato());
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
				
				parentRow.idprogetto = this.state.callerState.currentRow.idprogetto;
				this.managesal_default_budgetcalcolato();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sal_default");
				var arraydef = [];
				
				arraydef.push(this.calcDescriptionAssetDiaryes());

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
				this.enableControl($('#sal_default_budgetcalcolato'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilters();
				self.firstSearchFilter  = window.jsDataQuery.eq("idprogetto", this.state.callerState.currentRow.idprogetto);
					self.startFilter = self.firstSearchFilter;
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

			
			beforePost: function () {
				var self = this;

				//per ogni riga collegata ...
				this.state.DS.tables['progettocosto']
					//....dalle righe della tabella di collegamento...
					.select(window.jsDataQuery.isIn('idprogettocosto', _.map(self.getDataTable('salprogettocosto').rows, function (row) {
						return row['idprogettocosto'];
					}))).forEach(function (row) {
						//...associo il sal corrente se non cel'ha
						if (!row.idsal)
							row.idsal = self.state.currentRow.idsal;
					});

				//per ogni riga collegata ...
				this.state.DS.tables['rendicontattivitaprogettoora']
					//....dalle righe della tabella di collegamento...
					.select(window.jsDataQuery.isIn('idrendicontattivitaprogettoora', _.map(self.getDataTable('salrendicontattivitaprogettoora').rows, function (row) {
						return row['idrendicontattivitaprogettoora'];
					}))).forEach(function (row) {
						//...associo il sal corrente se non cel'ha
						if (!row.idsal)
							row.idsal = self.state.currentRow.idsal;
					});

				//per ogni riga collegata ...
				this.state.DS.tables['assetdiaryora']
					//....dalle righe della tabella di collegamento...
					.select(window.jsDataQuery.isIn('idassetdiaryora', _.map(self.getDataTable('salassetdiaryora').rows, function (row) {
						return row['idassetdiaryora'];
					}))).forEach(function (row) {
						//...associo il sal corrente se non cel'ha
						if (!row.idsal)
							row.idsal = self.state.currentRow.idsal;
					});

			},

			setFilters: function () {
				var metaPage = window.appMeta.currentMetaPage;
				var q = window.jsDataQuery;
				metaPage.state.DS.tables.assetdiaryora.staticFilter(q.isIn('idassetdiary',
					_.map(metaPage.state.callerState.DS.tables.assetdiary.rows, function (row) {
						return row['idassetdiary'];
					})));
				metaPage.state.DS.tables.rendicontattivitaprogettoora.staticFilter(q.isIn('idrendicontattivitaprogetto',
					_.map(metaPage.state.callerState.DS.tables.rendicontattivitaprogetto.rows, function (row) {
						return row['idrendicontattivitaprogetto'];
					})));
				metaPage.state.DS.tables.progettocosto.staticFilter(q.eq("idprogetto", metaPage.state.callerState.currentRow.idprogetto));
			},

			calcDescriptionAssetDiaryes: function () {
				var def = appMeta.Deferred("calcDescriptionAssetDiaryes-sal_default");
				var self = this;
				var q = self.q;

				_.forEach(this.getDataTable("rendicontattivitaprogettoora").rows, function (r) {
					var progettoTitle = self.state.callerState.currentRow.titolobreve;
					var workpageTitle = "";
					var rendicontattivitaprogettoTitle = self.state.currentRow.description;

					var workpackageRows = self.state.callerPage.getDataTable('workpackage')
						.select(q.eq('idworkpackage', r.idworkpackage));
					if (workpackageRows.length) {
						workpageTitle = workpackageRows[0].title;
					}

					var rendicontattivitaprogettoRows = self.state.callerPage.getDataTable('rendicontattivitaprogetto')
						.select(q.eq('idrendicontattivitaprogetto', r.idrendicontattivitaprogetto));
					if (rendicontattivitaprogettoRows.length) {
						rendicontattivitaprogettoTitle = rendicontattivitaprogettoRows[0].description;
					}

					var p = [];
					p.push([progettoTitle, null, 'Progetto']);
					p.push([workpageTitle, null, 'Workpackage']);
					p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
					r['!titleancestor'] = self.stringify(p, 'string');
				});

				var filter = q.isIn('idreg', _.map(self.state.callerPage.getDataTable('assetdiary').rows, function (row) {
					return row['idreg'];
				}));
				appMeta.getData.runSelect('getregistrydocentiamministratividefaultview', 'idreg,dropdown_title', filter, null)
					.then(function (dtOperatori) {
						_.forEach(self.getDataTable("assetdiaryora").rows, function (r) {

							var progettoTitle = self.state.callerState.currentRow.titolobreve;
							var workpageTitle = "";
							var operatoreTitle = "";
							var beneStrumentaleTitle = "";

							var workpackageRows = self.state.callerPage.getDataTable('workpackage')
								.select(q.eq('idworkpackage', r.idworkpackage));
							if (workpackageRows.length) {
								workpageTitle = workpackageRows[0].title;
							}

							var assetdiaryRows = self.state.callerPage.getDataTable('assetdiary')
								.select(q.eq('idassetdiary', r.idassetdiary));
							if (assetdiaryRows.length) {
								var operatoreRows = dtOperatori.select(q.eq('idreg', assetdiaryRows[0].idreg));
								if (operatoreRows.length) {
									operatoreTitle = operatoreRows[0].dropdown_title;
								}

								var assetRow = self.state.callerPage.getDataTable('asset')
									.select(q.and([q.eq('idasset', assetdiaryRows[0].idasset), q.eq('idpiece', assetdiaryRows[0].idpiece)]));
								if (assetRow.length) {
									var assetacquireRows = self.state.callerPage.getDataTable('assetacquire')
										.select(q.eq('nassetacquire', assetRow[0].nassetacquire));
									if (assetacquireRows.length) {
										beneStrumentaleTitle = assetacquireRows[0].description;
									}
								}
							}

							var p = [];
							p.push([progettoTitle, null, 'Progetto']);
							p.push([workpageTitle, null, 'Workpackage']);
							p.push([operatoreTitle, null, 'Operatore']);
							p.push([beneStrumentaleTitle, null, 'Bene']);

							r['!title'] = self.stringify(p, 'string');
						});
						return def.resolve();
					});
				return def.promise();
			},

			managesal_default_budgetcalcolato: function () {
				var self = window.appMeta.currentMetaPage;
				var progettocostoRows = self.getDataTable("progettocosto").select(
					self.q.eq('idsal', self.state.currentRow.idsal)
				);

				self.state.currentRow['!budgetcalcolato'] = _.sumBy(progettocostoRows, function (r) {
					return r.amount;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('sal', 'default', metaPage_sal);

}());
