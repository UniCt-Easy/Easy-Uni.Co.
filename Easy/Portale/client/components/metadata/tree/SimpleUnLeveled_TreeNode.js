
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


/**
 * @module SimpleUnLeveled_TreeNode
 * @description
 * Contains the structure to manage a node in a treeview unleveled structure
 */
(function() {
    var TreeNodeUnLeveled = window.appMeta.TreeNodeUnLeveled;
    var dataRowState = jsDataSet.dataRowState;
    /**
     * 
     * @param {ObjectRow} dataRow
     * @param descrField
     * @param codeString
     * @constructor
     */
    function SimpleUnLeveled_TreeNode(dataRow, descrField, codeString) {
       TreeNodeUnLeveled.apply(this, [dataRow, descrField, codeString]);
        this.descrField = descrField;
        this.codeString = codeString;
        this.state = {};
        // popola la proprietà "text" eseenziale per far vedere il nodo
        this.nodeText();
    }

    SimpleUnLeveled_TreeNode.prototype = _.extend(
        new TreeNodeUnLeveled(),
        {
            constructor: SimpleUnLeveled_TreeNode,

            superClass: TreeNodeUnLeveled.prototype,

            /**
             * @method tooltip
             * @public
             * @description SYNC
             * Gets the tooltip string
             * @returns {string}
             */
            tooltip:function () {
                if (!this.rowExists())  return "";
                return "";
            },

            formattedDate:function(d) {
                if (!d) {
                    return "";
                }
                var month = String(d.getMonth() + 1);
                var day = String(d.getDate());
                var year = String(d.getFullYear());

                if (month.length < 2) month = '0' + month;
                if (day.length < 2) day = '0' + day;

                return day + '/' + month + '/' + year;
            },

            nodeText:function () {
                var self = this;
                if (this.rowExists()) {
                    var r = this.dataRow.getRow();
                    if (this.descrField instanceof Array) {
                        this.text = _.chain(this.descrField)
                            .filter(function (field) {
                                return !!r.current[field];
                            })
                            .map(function (field) {
                                var dc = r.table.columns[field];
                                if (dc.ctype === 'DateTime') {
                                    return dc.caption + ": " + self.formattedDate(r.current[field])
                                }
                                return dc.caption + ": " + r.current[field];
                            })
                            .join("; ")
                            .value();
                        return this.text;
                    }
                    // se non è un array va come classe base
                    return this.superClass.nodeText.call(this);
                }
                return "";
            }

        });

    appMeta.SimpleUnLeveled_TreeNode = SimpleUnLeveled_TreeNode;
}());
