
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

    function metaPage_rendicontattivitaprogettoora() {
		MetaPage.apply(this, ['rendicontattivitaprogettoora', 'seg', true]);
        this.name = 'Dettaglio giorni della attività';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogettoora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogettoora,
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
				var def = appMeta.Deferred("afterGetFormData-rendicontattivitaprogettoora_seg");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogettoora_seg_titleancestor());
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogettoora_seg");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogettoora_seg_titleancestor());
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

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			createAndGetListManager: function (searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, isCommandSearch) {
                // isCommandSearch è true se lancio comando di ricerca, false se vengo da un autochoose, e qin quel caso implemnto comportamento di default
                var startColumnName = "data";
                var titleColumnName = "!titleancestor";
                var stopColumnName = null;
                if (isCommandSearch) return new window.appMeta.ListManagerCalendar(searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, startColumnName , titleColumnName, stopColumnName);
                // se non esco prima, significa autochoose e quindi esegue il sodiuce della superClass
                return this.superClass.createAndGetListManager(searchTableName, listingType, prefilter, isModal,rootElement, that, filterLocked, toMerge, isCommandSearch);
            },

			managerendicontattivitaprogettoora_seg_titleancestor: function () {
				var self = this;
				var p = [];

				var progettoTitle = '';
				var workpageTitle = '';
				if (this.state.callerState.callerState && this.state.callerState.callerState.callerState) {
					progettoTitle = this.state.callerState.callerState.callerState.currentRow.titolobreve;
					workpageTitle = this.state.callerState.callerState.currentRow.title;
				}
				else {
					progettoTitle = this.state.callerState.DS.tables.progettosegview.rows[0].titolobreve;
					workpageTitle = this.state.callerState.DS.tables.workpackagesegview.rows[0].dropdown_title;
				}

				var rendicontattivitaprogettoTitle = this.state.callerState.currentRow.description;
				p.push([progettoTitle, null, 'Progetto']);
				p.push([workpageTitle, null, 'Workpackage']);
				p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
				self.state.currentRow["!titleancestor"] = self.stringify(p, 'string');
				return true;
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicontattivitaprogettoora', 'seg', metaPage_rendicontattivitaprogettoora);

}());
