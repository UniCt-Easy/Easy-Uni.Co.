
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
    var TreeViewManager = window.appMeta.TreeViewManager;
    var Deferred = appMeta.Deferred;

    function SimpleUnLeveled_TreeViewManager() {
        TreeViewManager.apply(this, arguments);
        this.doubleClickForSelect = false;
    }

    SimpleUnLeveled_TreeViewManager.prototype = _.extend(
        new TreeViewManager(),
        {
            constructor: SimpleUnLeveled_TreeViewManager,

            superClass: TreeViewManager.prototype,

            start:function( rootFilter,  clear) {
                var def =  Deferred("start")
                return def.resolve(true);
            },

            /**
             * @method fillNodes
             * @private
             * @description SYNC
             * Fills the treeview with the nodes taken from all tree_table rows
             * Selects no node.
             * @returns {Deferred}
             */
            fillNodes:function (isToSelect, last) {
                var def = Deferred('filNodes');
                var self = this;

                // mi assicuro che il jstree è caricato, così posso aggiungere i nodi.
                // Altrimenti succede che aggiunge solamente l'ultimo nodo.
                var res = this.initializeJsTree()

                    .then(function () {

                        var roots = self.treeTable.select(self.rootCondition);

                        var allCreateNodeDeferred = [];

                        // le createnode sono asyncrone dentro un ciclo, metto in array e risolvo in when()
                        _.forEach(roots, function (rootRow) {
                            allCreateNodeDeferred.push(self.createNewNode(null, rootRow));

                        });

                        // risolvo i deferred
                        return $.when.apply($, allCreateNodeDeferred)
                            .then(function() {

                                // ogni def risolto lancia un altro def, che quinid appoggio in un array che a sua volta risolverò nela when
                                var allfillChildsNodeDeferred = [];

                                _.forEach(arguments, function (newNode) {

                                    // se passo null come 1o prm aggiunge in testa all'albero. oppure potrei passare "#"
                                    self.addNode(null, newNode);

                                    allfillChildsNodeDeferred.push(self.fillChildsNode(newNode, newNode.dataRow));
                                });

                                return $.when.apply($, allfillChildsNodeDeferred)
                                    .then(function() {
                                        self.tree.jstree("redraw" , true);
                                        def.resolve();
                                    });

                            });
                    });

                return def.from(res).promise();
            },

            /**
             * @method fillChildsNode
             * @private
             * @description ASYNC
             * @param {jstree node} parentNode
             * @param {ObjectRow} parentRow
             * @returns {Deferred}
             */
            fillChildsNode:function (parentNode, parentRow) {

                var def = Deferred("fillChildsNode");
                // reset del booleano che indica che devo esplorare il nodo
                parentNode.toExplore = false;

                var self = this;
                var childList = parentRow.getRow().getChildRows(this.autoChildRelation.name);

                // le createnode sono asyncrone dentro un ciclo, metto in array e risolvo in when()
                var allCreateNodeDeferred = [];
                _.forEach(childList, function (childRow) {
                    if (childRow === parentRow) return true; // promssima iterazione
                    allCreateNodeDeferred.push(self.createNewNode(parentRow, childRow));
                });

                var res =  $.when.apply($, allCreateNodeDeferred)
                    .then(function() {
                        var allfillChildsNodeDeferred = [];
                        _.forEach(arguments, function (newNode) {
                            self.addNode(parentNode, newNode);
                            allfillChildsNodeDeferred.push(self.fillChildsNode(newNode, newNode.dataRow));
                        });

                        return $.when.apply($, allfillChildsNodeDeferred)
                            .then(function(defObj) {
                                // if fixed data don't add dummy nodes
                                if (self.fixedData) return def.resolve();
                                // se non ho figli devo esplorare. recupero i children dall'oggetto node intenro al jstree
                                var currJsTreeNode = self.tree.jstree("get_node" , parentNode);
                                if (currJsTreeNode){
                                    if (currJsTreeNode.children.length === 0){
                                        parentNode.toExplore = true;
                                    }
                                }
                                return def.resolve();
                            });

                    });

                return def.from(res).promise();

            },

        });

    appMeta.CustomControl("simpleUnLeveledTree", SimpleUnLeveled_TreeViewManager);
    appMeta.SimpleUnLeveled_TreeViewManager = SimpleUnLeveled_TreeViewManager;
}());
