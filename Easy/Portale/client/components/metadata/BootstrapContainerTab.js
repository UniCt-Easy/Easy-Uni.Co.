
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
 * @module BootstrapContainerTab
 * @description
 * Implements the methods to manage a Bootstrap container.
 */
(function() {

    /**
     * @constructor BootstrapContainerTab
     * @description
     * Initializes a bootstrap tab container
     * @param {Html node} el
     * @param {HelpForm} helpForm
     */
    function BootstrapContainerTab(el, helpForm) {
        this.el = el;
        this.helpForm = helpForm;
        return this;
    }

    BootstrapContainerTab.prototype = {
        constructor: BootstrapContainerTab,

        /**
         * @method focusContainer
         * @public
         * @description SYNC
         * Selects the tab in the bootstrap tab container, where the control ctrl is hosted
         * @param {Html element} ctrl
         * @returns {null}
         */
        focusContainer: function(ctrl) {
            if (ctrl === null) return null;
            // recupera il tab prossimo al controllo, quindi dove è ospitato il controllo
            var currTab = $(ctrl).closest(".tab-pane");
            if (currTab) {
                // recupoera l'id è utilizza la "show" di bootstrap
                var currId = $(currTab).prop('id');
                $('.nav-tabs a[href="' + currId + '"]').tab('show');
               // $('#'+currId).tab('show');
            }
            return null;
        }

    };

    window.appMeta.CustomContainer("bootstrapTab", BootstrapContainerTab);
}());
