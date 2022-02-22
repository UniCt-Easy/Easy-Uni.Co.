
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
 * @module LoaderControl
 * @description
 * Manages the graphics for a loading control
 */
(function() {

    /**
     * @constructor LoaderControl
     * @description
     * Initializes an html Loader control
     * @param {Html node} rootElement
     * @param {string} msg
     */
    function LoaderControl(rootElement, msg) {
        this.rootElement = rootElement || document.body;
        this.msg = msg;
        this.templateFileHtmlPath  = appMeta.basePath + appMeta.config.path_loaderTemplate;
    }

    LoaderControl.prototype = {
        constructor: LoaderControl,

        /**
         * @method showControl
         * @public
         * @description SYNC
         * Loads the html template of the LoaderControl and appends it to the "rootElement"
         */
        showControl:function () {
            var htmlCodeTemplate = appMeta.getData.cachedSyncGetHtml(this.templateFileHtmlPath);
            // non rimpiazzo, aggiungo
            if (!$('#loader_control_id').length) $(this.rootElement).append(htmlCodeTemplate);
            // nascondo tutto e  mostro loader
            $(this.rootElement).children().hide();
            this.setText(this.msg);
            $("#loader_control_id").show();
        },

        /**
         * @method hideControl
         * @public
         * @description SYNC
         * Hides the loader, and reshow the control on rootelement
         */
        hideControl:function () {
            // rimostro tutto e nascondo il loader
            $(this.rootElement).children().show();
            $('#loader_control_id').hide();
        },

        /**
         * @method setText
         * @private
         * @description SYNC
         * Set the text message on the control
         * @param {string} msg
         */
        setText:function(msg){
            $(".loader_control_text").text(msg);
        }
    };

    appMeta.LoaderControl = LoaderControl;

}());
