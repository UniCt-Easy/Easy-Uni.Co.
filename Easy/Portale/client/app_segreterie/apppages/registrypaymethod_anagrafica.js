
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

    function metaPage_registrypaymethod() {
        MetaPage.apply(this, arguments);
        this.name = 'Registrypaymethod - Anagrafica';
    }

    metaPage_registrypaymethod.prototype = _.extend(
        new MetaPage('registrypaymethod', 'anagrafica', true),
        {
            constructor: metaPage_registrypaymethod,

            superClass: MetaPage.prototype,

            /**
             * @method getName
             * @private
             * @description SYNC - Overriden
             * Sets the name of the page
             */
            getName:function () {
               return this.name;
            }
        });

    window.appMeta.addMetaPage('registrypaymethod', 'anagrafica', metaPage_registrypaymethod);
}());
