
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


/**
 * @module getDataUtilsNode. overrides getDataUtils methods for node backend
 * @description
 * Collection of utility functions for GetData
 */
(function () {

    /**
     * @function getJsObjectFromJson
     * @public
     * @description SYNC
     * Given a json representation of the DataSet/DataTable returns a javascript object
     * @param {string} json
     * @returns {object} an object (DataTable or DataSet)
     */
    appMeta.getDataUtils.getJsObjectFromJson = function (json) {
        // riconverto la stringa json proveniente dal server
       return JSON.parse(json);
    };


    /**
    * @method normalizeDataWithoutOffsetTimezone
    * @public
    * @description SYNC
    * When js convert to JSON, JSON uses Date.prototype.toISOString that doesn't represent local hour but the UTC +offset.
    * So the string will be modified with a new date. In this function we avoid this behaviour, it adds the offset to the date. succesive stringfy() doesn't change the date
    * @param {DataTable} date
    */
    appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone = function (date, normalize) {
        // nel caso nodejs, la parse toglie offset, la stringfy lo aggiiunge quindi non Ã¨ necessario normalizzare
        return date;
    };

}());

