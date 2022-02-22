
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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

    function metaPage_registry() {
        MetaPage.apply(this, arguments);
        this.name = 'Anagrafica';
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage('registry', 'anagrafica', false),
        {
            constructor: metaPage_registry,

            superClass: MetaPage.prototype,

            /**
             * @method getName
             * @private
             * @description SYNC - Overriden
             * Sets the name of the page
             */
            getName:function () {
               return this.name;
            },

            /**
             * @method afterLink
             * @private
             * @description SYNC - Overriden
             */
            afterLink:function () {
                // mette le dipendenze tra controlli
                this.configureDependencies();
            },

            /**
             *
             */
            configureDependencies:function () {
                // N.B i controlli padre e figlio con dipendenze devono aver settato un id su html
                // poich√® MDWL usa id al suo interno. Capire se e come ovviare a questa cosa.
                var p1 = $("input[data-tag='registry.surname']");
                var p2 = $("input[data-tag='registry.forename']");
                var f1 = $("input[data-tag='registry.title']");

                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename;
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            }
        });

	window.appMeta.addMetaPage('registry', 'anagrafica', metaPage_registry);

}());
