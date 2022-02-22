
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


/**
 * @module TreeNodeUnLeveled
 * @description
 * Contains the structure to manage a node in a treeview unleveled structure
 */
(function() {
    var TreeNode = window.appMeta.TreeNode;
    var dataRowState = jsDataSet.dataRowState;
    /**
     * 
     * @param {ObjectRow} dataRow
     * @param descrField
     * @param codeString
     * @constructor
     */
    function TreeNodeUnLeveled(dataRow, descrField, codeString) {
        TreeNode.apply(this, [dataRow]);
        this.descrField = descrField;
        this.codeString = codeString;

        this.state = {};
        // popola la propriet√† "text" eseenziale per fsr vededre il nodo
        this.nodeText();
    }

    TreeNodeUnLeveled.prototype = _.extend(
        new TreeNode(),
        {
            constructor: TreeNodeUnLeveled,

            superClass: TreeNode.prototype,

            /**
             * @method tooltip
             * @public
             * @description SYNC
             * Gets the tooltip string
             * @returns {string}
             */
            tooltip:function () {
                if (!this.rowExists())  return "";
                if (this.descrField)  return this.dataRow[this.descrField];
                if (this.codeString)  return this.dataRow[this.codeString];
                return "";
            },

            nodeText:function () {
                var stext = "";
                if (this.rowExists()) {
                    var r = this.dataRow.getRow();
                    if (this.descrField && r.table.columns[this.descrField]) {
                        if (this.codeString && r.state !== dataRowState.added) {
                            if (stext !== "") stext += " ";
                            stext += r.current[this.codeString];
                        }
                        if (r.table.columns[this.descrField] !== "") {
                            if (stext !== "") stext += " ";
                            stext += r.current[this.descrField];
                        }
                    } else if (this.codeString) {
                            if (stext !== "") stext += " ";
                            stext += r.current[this.codeString];
                    }
                }

                this.text = stext;
                return stext;
            }

        });

    appMeta.TreeNodeUnLeveled = TreeNodeUnLeveled;
}());
