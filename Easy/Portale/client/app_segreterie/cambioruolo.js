
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
 * @module BootstrapModal
 * @description
 * Implements the methods to open and manage a bootstrap modal form
 */
(function () {

    var Deferred = appMeta.Deferred;
    var utils = appMeta.utils;
    var localResource = appMeta.localResource;
    var methodEnum = appMeta.routing.methodEnum;

    /**
     *
     * @returns {CambioRuolo}
     * @constructor
     */
    function CambioRuolo() {
        this.rootElement = document.body;
        return this;
    }

    CambioRuolo.prototype = {
        constructor: CambioRuolo,

        /**
         * @method getModalHtml
         * @private
         * @description SYNC
         * Builds the html for a modal scheduleConfig dialog
         * @returns {string} html string for a modal Bootstrap dialog
         */
        getModalHtml:function () {
            var templateFileHtmlPath = "cambioruolo.html";
            return appMeta.getData.cachedSyncGetHtml(templateFileHtmlPath);
        },

        forceClose:function() {
            $("#" + this.dialogid).dialog("close");
            if (appMeta.modalLoaderControl) {
                appMeta.modalLoaderControl.hide();
            }
            this.dialogrootelement.remove();
        },

        /**
         *
         * @param dtRoles
         * @returns {*}
         */
        show: function (dtRoles) {
            // apro deferred
            this.def = Deferred("CambioRuolo.show");

            if (appMeta.modalLoaderControl) {
                appMeta.modalLoaderControl.hide();
            }
            var self = this;
            this.dialogid = "dialogid" + utils.getUnivoqueId();
            this.dialogrootelement = $('<div id="' +  this.dialogid + '">');
            $(this.rootElement).append(this.dialogrootelement);
            var htmlInfo = this.getModalHtml();
            $("#" + this.dialogid).dialog({
                dialogClass: "no-close",
                modal: true,
                autoResize:true,
                width: screen.width * 0.5,
                title: localResource.cambioRuolo,
                open: function () {
                    // attacco html
                    $(this).html(htmlInfo);
                    self.setControls(dtRoles);
                },
                position: { my: "center bottom", at: "center center", of: window }
            });
            return this.def.promise();
        },

        /**
         *
         * @param dtRoles
         */
        setControls: function (dtRoles) {
            // popolo la combo con i ruoli
            _.forEach(
                dtRoles.rows,
                function(dataRow) {
                    var opt = document.createElement("option");
                    opt.textContent = dataRow['title'];
                    opt.value = dataRow['k'];
                    $("#idRoles").append(opt);
                });
            // handler del bottone
            $("#btnCambioRuoloOk").on("click", _.partial(this.enter, this ));
        },

        /**
         *
         * @param that
         */
        enter: function(that) {
            var value = $("#idRoles").val();
            if (!value) {
                return;
            }
            var elements = value.split("Â§");
            var idflowchart = elements[0];
            var ndetail = elements[1];
            var idcustomuser = appMeta.security.usr("userweb");
            var objConn = {
                method: methodEnum.cambiaRuolo,
                prm: {
                    ndetail: ndetail,
                    idflowchart: idflowchart,
                    idcustomuser: idcustomuser
                }
            };
            appMeta.modalLoaderControl.show("Cambio ruolo in corso", false);
            appMeta.connection.call(objConn)
                .then(function(data) {
                        // salvo var ambiente di sicurezza tornate dal server sulla classe scurity
                        that.forceClose();
                        return that.def.resolve(data);
                    },
                    function() {
                        that.forceClose();
                        return  that.def.resolve(false);
                    });
        }

    };

    appMeta.CambioRuolo = CambioRuolo;

}());
