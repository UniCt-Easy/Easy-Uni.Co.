
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
    var TreeNode_Dispatcher = window.appMeta.TreeNode_Dispatcher;
    var Deferred = appMeta.Deferred;
    var TreeNodeLeveled = appMeta.TreeNodeLeveled;
    function TreeNodeLeveled_Dispatcher( level_table,
                                         level_field,
                                         descr_level_field,
                                         selectable_level_field,
                                         descr_field,
                                         code_string) {
        TreeNode_Dispatcher.apply(this, []);
        this.level_table = level_table;
        this.level_field = level_field;
        this.descr_level_field = descr_level_field;
        this.selectable_level_field = selectable_level_field;
        this.descr_field = descr_field;
        this.code_string = code_string;
    }

    TreeNodeLeveled_Dispatcher.prototype = _.extend(
        new TreeNode_Dispatcher(),
        {
            constructor: TreeNodeLeveled_Dispatcher,

            superClass: TreeNode_Dispatcher.prototype,

            /**
             * @method getNode
             * @public
             * @description ASYNC
             * To override. It builds the TreeNode starting from the info on the parentRow and childRow
             * @param {DataRow} parentRow
             * @param {DataRow} childRow
             * @returns {Deferred(TreeNodeLeveled)}
             */
            getNode:function (parentRow, childRow) {
                var def = Deferred("TreeNodeLeveled_Dispatcher-getNode");

                return def.resolve(new TreeNodeLeveled(childRow,
                    this.level_table,
                    this.level_field,
                    this.descr_level_field,
                    this.selectable_level_field,
                    this.descr_field,
                    this.code_string));
            }

        });

    appMeta.TreeNodeLeveled_Dispatcher = TreeNodeLeveled_Dispatcher;

}());
