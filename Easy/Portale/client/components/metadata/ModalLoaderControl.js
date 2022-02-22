
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
 * @module ModalLoaderControl
 * @description
 * Manages the graphics for a waiting modal control
 */
(function() {

    /**
     * @constructor ModalLoaderControl
     * @description
     * Initializes an html waiting modal control
     * @param {Html node} rootElement
     */
    function ModalLoaderControl(rootElement) {
        // gestisco le modali come unica risorsa condivisa. quindi metto in una lista, poi
        // nell'hideWaitingIndicator() toglierò dalla lista, faccio la hide fisica solo se non ci sono più messaggi
        this.waitIndicatorList = [];
        this.rootElement = rootElement || document.body;

    }

    ModalLoaderControl.prototype = {
        
        constructor: ModalLoaderControl,

        /**
         *
         */
       addProgressBar:function() {
            var p = '<div class="waitProgress" id="waitProgressId"> <div class="waitBar" id="waitBarId"></div> </div>';
            $(appMeta.rootToolbar).after($(p));
        },

        /**
         *
         * @returns {string}
         */
        getHtmlModal:function() {
          return '<div class="modal" id="modalLoader_control_id" data-backdrop="static" data-keyboard="false">' +
                    '<div class="modal-dialog">' +
                        '<div class="modal-content">' +
                            '<div class="modal-header">' +
                            '   <h4 class="modal-title"></h4>' +
                            '</div>' +
                            '<div class="modal-body">' +
                                '<h4 style="text-align:center; margin-top: 25px;" class="modalLoader_control_text"></h4>' +
                                '<div class="spinner-cont">' +
                                    '<span class="fa fa-spinner fa-spin fa-3x"></span>' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>';
        },


        /**
         * @method showControl
         * @private
         * @description SYNC
         * Sets the message and shows the modal control
         * @param {string} msg
         * @param {boolean} isBar
         */
        showControl:function (msg, isBar) {
            if (!this.initiated){
                this.initiated = true;
                this.rootElement = this.rootElement || document.body;
                $(this.rootElement).append(this.getHtmlModal());
                this.$el = $("#modalLoader_control_id");

                this.addProgressBar();
            }

            if (isBar) return this.pbarMove();
            this.setMessage(msg);
            if (this.$el.hasClass('in')) return;
            this.$el.modal("show");
        },

        /**
         * Show and move the progress bar
         */
        pbarMove:function() {
            $("#waitProgressId").css("visibility", "visible");
            var bar =  $("#waitBarId");
            var width = 5;
            var id = setInterval(frame, 10);
            function frame() {
                if (width >= 95) return clearInterval(id);
                width++;
                bar.width(width + "%");
            }
        },

        /**
         * @method hideControl
         * @private
         * @description SYNC
         * Hides the loader
         */
        hideControl:function () {
            if (this.$el) this.$el.modal("hide");
            $("#waitProgressId").css("visibility", "hidden");
        },

        /**
         * @method setText
         * @private
         * @description SYNC
         * Set the text message on the control
         * @param {string} msg          
         */
        setMessage:function(msg){
            this.$el.find(".modalLoader_control_text").text(msg);
        },

        /**
         * @method isAttachedToRoot
         * @public
         * @description SYNC
         * Checks if the modal is still linked to the html
         * @returns {boolean} true if modal exist on the html
         */
        isAttachedToRoot:function () {
            return !!this.$el.length;
        },


        /**
         * @method showWaitingIndicator
         * @public
         * @description SYNC
         * Shows a modal loader indicator. It is not possible to close the modal by user
         * @param {string} msg. the message to show in the box
         * @returns {number} the ahndler of the modal. It is used on hideWaitIndicator to remove the message form the list
         */
        show:function (msg, isBar) {
            var handlerMax = this.waitIndicatorList.length ?  _.maxBy(this.waitIndicatorList, 'handler').handler : 0;
            var handler = handlerMax + 1;
            this.waitIndicatorList.push({ handler:handler, msg:msg });

            // mostro il controllo con il messaggio attuale
            this.showControl(msg, isBar);

            return handler;
        },

        /**
         * @method hideWaitingIndicator
         * @private
         * @description SYNC
         * Hides a modal loader indicator. (Shown with funct. showWaitingIndicator).
         * If handler is undefiend or null or 0 it forces the hide
         * @param {number} handler. the handler of the modal to hide. in handler is undefined it force hide
         */
        hide:function (handler) {
            // tolgo elemento dalla lista{

            if (handler){
                _.remove( this.waitIndicatorList, function(w) {
                    return w.handler === handler;
                });
            } else {
                this.waitIndicatorList = [];
            }

            // mostro l'ultimo messaggio se esiste
            var waitIndicatorListLength = this.waitIndicatorList.length;
            if (waitIndicatorListLength){
                var wo = this.waitIndicatorList[waitIndicatorListLength - 1];
                // mostro il controllo con l'ultimo messaggio calcolato
                this.showControl(wo.msg);
            }

            // nascondo fisicamente la modale solo se esiste, e la lista dei messaggi è vuota
            if (!this.waitIndicatorList.length) this.hideControl();
        }
    };

    appMeta.modalLoaderControl = new ModalLoaderControl();

}());
