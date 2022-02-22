
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


(function() {
	
    var MetaPage = window.appMeta.MetaPage;

    function metaPage_tabella() {
        MetaPage.apply(this, arguments);
        this.name = 'Insegnamenti integrandi';
		this.defaultListType = 'integrandi';
		//rowSelectedEventManager
		//buttonClickEndEventManager
    }

    metaPage_tabella.prototype = _.extend(
        new MetaPage('insegn', 'integrandi', true),
        {
            constructor: metaPage_tabella,
            superClass: MetaPage.prototype,

            getName:function () {
               return this.name;
            },
			
			//beforeFill

			//afterLink

			//rowSelected

			//buttonClickEnd

			//buttons
        });

	window.appMeta.addMetaPage('insegn', 'integrandi', metaPage_tabella);

}());
