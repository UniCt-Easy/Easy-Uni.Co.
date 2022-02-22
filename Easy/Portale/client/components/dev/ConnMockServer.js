
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
 * @class ConnMockServer
 * @summary ConnMockServer
 * @description
 *
 */
function ConnMockServer() {
    "use strict";
}

ConnMockServer.prototype = {

    /**
     * Override of call method
     * @method callGet
     * @public
     * @param {string} method
     * @param {Object} prm
     * @returns {Promise}
     */
    call:function (objConn) {
        if (this[objConn.method]) return this[objConn.method](objConn.prm);
        throw  "method " + method + " not defined on ConnMockServer" ;
    },


    // ********** Private methods. Tey are customized based on unit test **********
    /**
     * Returns the number of the rows in a table
     * @param prm
     * @returns {Promise}
     */
    selectCount:function (prm) {
        return $.Deferred().resolve(100).promise();
    },

    /**
     * get rows of paginated table
     * @param {Object} prm
     * @returns {Promise}
     */
    getPagedTable:function (prm) {
        // recupero parametro
        var nPage = prm.nPage;
        var nrowperpage = prm.nRowPerPage;

        var ds = new jsDataSet.DataSet("temp");
        var t = ds.newTable("table1");
        t.setDataColumn("c_name", "String");
        t.setDataColumn("c_dec", "Single");
        t.setDataColumn("c_citta", "String");
        t.columns["c_name"].caption = "Name";
        t.columns["c_dec"].caption = "Age";
        t.columns["c_citta"].caption = "Citta";
        var init = ( nPage - 1 ) * nrowperpage;
        for (var i = init; i < init + nrowperpage; i++){
            var cname;
            if (i % 3 ===0){
                cname= "Long nameeeeeeeeeeeeeeeeee" + i;
            }else{
                cname= "nome" + i;
            }
            var objrow = {c_name: cname , c_dec: i, c_citta: "citta" + i};
            t.add(objrow);
        }

        return $.Deferred().resolve(t).promise();
    }
};

