
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
 * @module TreeNode_Dispatcher
 * @description
 * Contains the strucuture to manage a node in a treeview structure
 */
(function () {
    
    var Deferred = appMeta.Deferred;
    
    /**
     * @constructor
     * Base (empty) class able to create a tree_node, given Parent DataRow and
     * a new Child DataRow.
     * @returns {TreeNode_Dispatcher}
     */
    function TreeNode_Dispatcher() {
        return this;
    }

    TreeNode_Dispatcher.prototype = {
        constructor: TreeNode_Dispatcher,

        /**
         * @method getNode
         * @public
         * @description ASYNC
         * To override. It builds the TreeNode starting from the info on the parentRow and childRow
         * @param {DataRow} parentRow
         * @param {DataRow} childRow
         * @returns {Deferred(TreeNode)}
         */
        getNode:function (parentRow, childRow) {
            var def = Deferred("getNode");
            return def.resolve(null);
        }

    };
    
    appMeta.TreeNode_Dispatcher = TreeNode_Dispatcher;

}());
