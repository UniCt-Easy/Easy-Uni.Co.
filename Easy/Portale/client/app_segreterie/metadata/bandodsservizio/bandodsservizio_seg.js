
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

    function metaPage_bandodsservizio() {
		MetaPage.apply(this, ['bandodsservizio', 'seg', true]);
        this.name = 'Servizi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsservizio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsservizio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
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

			//buttons
        });

	window.appMeta.addMetaPage('bandodsservizio', 'seg', metaPage_bandodsservizio);

}());