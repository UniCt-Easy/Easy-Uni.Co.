
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
    var TreeNodeUnLeveled_Dispatcher = window.appMeta.TreeNodeUnLeveled_Dispatcher;
    var Deferred = appMeta.Deferred;
    var SimpleUnLeveled_TreeNode = appMeta.SimpleUnLeveled_TreeNode;
    function SimpleUnLeveled_TreeNode_Dispatcher(descrField, codeString) {
        TreeNodeUnLeveled_Dispatcher.apply(this, arguments);
        this.descrField = descrField;
        this.codeString = codeString;
    }

    SimpleUnLeveled_TreeNode_Dispatcher.prototype = _.extend(
        new TreeNodeUnLeveled_Dispatcher(),
        {
            constructor: SimpleUnLeveled_TreeNode_Dispatcher,

            superClass: TreeNodeUnLeveled_Dispatcher.prototype,

            /**
             * 
             */
            getNode:function (parentRow, childRow) {
                var def = Deferred("SimpleUnLeveled_TreeNode_Dispatcher-getNode");
                return def.resolve(new SimpleUnLeveled_TreeNode(childRow, this.descrField, this.codeString) );
            }

        });
    
    appMeta.SimpleUnLeveled_TreeNode_Dispatcher = SimpleUnLeveled_TreeNode_Dispatcher;

}());
