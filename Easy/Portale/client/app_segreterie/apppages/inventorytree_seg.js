
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

    function metaPage_inventorytree() {
		MetaPage.apply(this, ['inventorytree', 'seg', false]);
        this.name = 'Classificazione inventariale';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_inventorytree.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_inventorytree,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.setCodeinvExtendedPropertiesLength();
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-inventorytree_seg");
				var arraydef = [];
				
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			setCodeinvExtendedPropertiesLength: function () {
				this.getDataTable("inventorytree").columns.codeinv.length = this.state.currentRow.codeinv.length;
			} ,

			//buttons
        });

	window.appMeta.addMetaPage('inventorytree', 'seg', metaPage_inventorytree);

}());
