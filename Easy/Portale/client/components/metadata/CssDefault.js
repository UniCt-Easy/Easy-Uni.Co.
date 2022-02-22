
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
 * @module CssDefault
 * @description
 * Contains the default css class name of the app. The class are defined  in app/style/app.css
 */
(function () {

    /**
     * @constructor CssDefault
     * @description
     */
    function CssDefault() {
        "use strict";
    }

    CssDefault.prototype = {

        constructor: CssDefault,
        selectedRow:  "selectedRow",
        //odd: "odd",
        listManagerFooterCont: "listManagerFooterCont",
        listManagerFooter: "listManagerFooter",
        autoChoose: "autoChoose",
        btnPushed: "btnPushed",
        detailPage: "detailPage",
        alignNumericColumn: "alignNumericColumn",
        alignStringColumn : "alignStringColumn",

        /**
         * @method getColumnsAlignmentCssClass
         * @private
         * @description SYNC
         * Returns the css style of the column depending on the column type
         * @param {DataColumn} c
         * @returns {string}
         */
        getColumnsAlignmentCssClass: function (ctype) {
            switch (ctype) {
                case "Decimal":
                case "Double":
                case "Int16":
                case "Single":
                case "Int32":
                case "DateTime":
                    return this.alignNumericColumn;
                case "String":
                    return this.alignStringColumn;
                default:
                    return this.alignStringColumn;
            }
        },
    };

    appMeta.cssDefault = new CssDefault();
}());
