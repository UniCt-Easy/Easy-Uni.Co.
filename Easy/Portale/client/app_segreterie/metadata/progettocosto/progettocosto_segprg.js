
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

    function metaPage_progettocosto() {
		MetaPage.apply(this, ['progettocosto', 'segprg', false]);
        this.name = 'Dettaglio dei costi';
		this.defaultListType = 'segprg';
		//pageHeaderDeclaration
    }

    metaPage_progettocosto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettocosto,
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
				
				parentRow.idprogetto = this.state.callerState.currentRow.idprogetto;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progettocosto_segprg_idpettycash'), null);
				} else {
					this.helpForm.filter($('#progettocosto_segprg_idpettycash'), this.q.eq('pettycash_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettocosto_segprg");
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
				this.helpForm.filter($('#progettocosto_segprg_idpettycash'), null);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#progettocosto_segprg_idrelated'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto();
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

			//beforePost

			setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto: function () {
				var self = this;
				var filter = self.q.eq('idprogetto', this.state.callerState.currentRow.idprogetto);
				self.state.DS.tables.workpackagesegview.staticFilter(filter);
				self.state.DS.tables.progettotipocosto.staticFilter(filter);
				self.state.DS.tables.saldefaultview.staticFilter(filter);
				self.state.DS.tables.rendicontattivitaprogettosegview.staticFilter(filter);
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettocosto', 'segprg', metaPage_progettocosto);

}());
