
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


(function() {
    var MetaData = window.appMeta.MetaData;

    function meta_registrypaymethod() {
        MetaData.apply(this, ["registrypaymethod"]);
        this.name = 'meta_registrypaymethod';
    }

    meta_registrypaymethod.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrypaymethod,

            superClass: MetaData.prototype,

            /**
             * @method describeColumns
             * @public
             * @description SYNC
             * Describes a listing type (captions, column order, formulas, column formats and so on)
             * @param {DataTable} table
             * @param {string} listType
             * @returns {*}
             */
            describeColumns: function (table, listType) {
                return this.superClass.describeColumns(table, listType);
            },
            
            sortedColumnNameList:function (table) {
                return this.superClass.sortedColumnNameList(table);
            },

            /**
             *
             * @param {DataTable} table
             */
            setDefaults: function(table) {
                // si intende che il datatable sia già corredato dai defaults per come è stato deserializzato dal server
                // questo metodo può contenere al massimo delle personalizzazioni
                // La colonna title su registrypaymethod in inserimento non accetta null, quindi aggiungo un defualt.
                
            },

            /**
             * @method getSorting
             * @public
             * @description SYNC
             * Returns the default sorting for a list type "listType"
             * @param {string} listType
             * @returns {string|null}
             */
            getSorting: function(listType) {
				return "idregistrypaymethod";
            },

        });

    window.appMeta.addMeta('registrypaymethod', new meta_registrypaymethod('registrypaymethod'));
}());
