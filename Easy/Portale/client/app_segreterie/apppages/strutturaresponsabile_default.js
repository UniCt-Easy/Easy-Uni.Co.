
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

    function metaPage_strutturaresponsabile() {
		MetaPage.apply(this, ['strutturaresponsabile', 'default', true]);
        this.name = 'Responsabili, valutatori e approvatori';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_strutturaresponsabile.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_strutturaresponsabile,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.registrydefaultview.staticFilter(window.jsDataQuery.isIn("idreg", _.map(this.state.callerState.DS.tables.afferenza.rows, function (row) 				{ 					 if (row.idstruttura == self.state.callerPage.state.currentRow.idstruttura) { 						return row.idreg; 					} 					return 0; 				})));
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

			//buttons
        });

	window.appMeta.addMetaPage('strutturaresponsabile', 'default', metaPage_strutturaresponsabile);

}());
