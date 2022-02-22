
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

    function metaPage_progettotimesheet() {
		MetaPage.apply(this, ['progettotimesheet', 'default', true]);
        this.name = 'Timesheets';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_progettotimesheet.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotimesheet,
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettotimesheet_default");
				var arraydef = [];
				
				arraydef.push(this.projectGridfilter());				//beforeFillInside
				
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#timesheetReport").on("click", _.partial(this.firetimesheetReport, this));
				$("#timesheetReport").prop("disabled", true);
				$('#progettotimesheet_default_year').on("select2:select", _.partial(this.manageyear, self));
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
				$("#timesheetReport").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#timesheetReport").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			projectGridfilter: function () {
				var self = this;
				var def = appMeta.Deferred("projectGridfilter");
				//costruzione filtro per determinare i progetti coinvolti
				var filter = self.q.eq("idreg", self.state.currentRow.idreg);
				if (self.state.currentRow.year) {
					filter = self.q.and(self.q.eq("anno", self.state.currentRow.year), filter);
				}
				//query su timesheetview con il filtro calcolato
				appMeta.getData.runSelect("timesheetview", "idprogetto", filter)
					.then(function (dt) {
						//id dei progetti dell'utente e dell'anno selezionato
						var progettiRows = _.filter(dt.rows, function (r) { return !!r.idprogetto });
						var filterProgetti = self.q.isIn('idprogetto',
							_.map(progettiRows, function (r) {
							return r.idprogetto;
						}));
						self.getDataTable('progetto').clear();
						var selBuilderArray = [];
						//faccio la query su sql e aggiorno contemporaneamente il dataset
						selBuilderArray.push({ filter: filterProgetti, top: null, tableName: 'progetto', table: self.getDataTable('progetto') });
						return appMeta.getData.multiRunSelect(selBuilderArray);
					})
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},

			firetimesheetReport: function (that) {
				return that.getFormData(true)
					.then(function () {
						var row = that.state.currentRow;
						if (!row) {
							return that.showMessageOk("Seleziona un docente!");
						}
						// tabella di collegamento dove ci sono i progetti selezionati che devono finire nel timesheet
						var dt = that.getDataTable('progettotimesheetprogetto');
						var rows = dt.rows.filter(function (r) {
							return r.getRow && r.getRow().state !== jsDataSet.dataRowState.deleted
						});
						if (!rows.length) {
							return that.showMessageOk("Seleziona almeno un progetto!");
						}
						var filterProgetti = that.q.isIn('idprogetto', _.map(rows, function (r) {
							return r.idprogetto;
						}));
						var showactivitiesrow = (row.showactivitiesrow === 'S');
						var riepilogoanno = (row.riepilogoanno === 'S');
						var intestazioneallsheet = (row.intestazioneallsheet === 'S');
						return that.buildAndGetTimesheet({
							filterProgetti: filterProgetti,
							idreg: row.idreg,
							year: row.year,
							showactivitiesrow: showactivitiesrow,
							riepilogoanno: riepilogoanno,
							intestazioneallsheet: intestazioneallsheet,
							idtimesheettemplate : row.idtimesheettemplate
						});
					});
			},

			manageyear: function(that) { 
				var def = appMeta.Deferred("manageYearfilter");
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				that.getFormData(true)
					.then(function () {
						return that.projectGridfilter();
					})
					.then(function () {
						return that.freshForm(true, false);
					})
					.then(function () {
						that.hideWaitingIndicator(waitingHandler);
						return def.resolve();
					});
				return def.promise();

			},

			//buttons
        });

	window.appMeta.addMetaPage('progettotimesheet', 'default', metaPage_progettotimesheet);

}());
