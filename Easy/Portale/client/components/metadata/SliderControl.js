
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
 * Custom Control for the slider with max and min
 * @module UploadControl
 * @description
 * Manages the graphics and the logic of a numeric slider
 */
(function() {

    var Deferred = appMeta.Deferred;
    var Attachment = appMeta.Attachment;
    var localResource = appMeta.localResource;
    var $q = window.jsDataQuery;

    /**
     *
     * @param {html node} el
     * @param {HelpForm} helpForm
     * @param {DataTable} table
     * @param {DataTable} primaryTable
     * @param {string} listType
     * @constructor
     */
    function SliderControl(el, helpForm, table, primaryTable, listType) {
        this.helpForm = helpForm;
        this.tag = $(el).data("tag");
        this.el = el;
        this.callback = (typeof $(this.el).data("callback") === "undefined") ?  _.partial(this.defaultCallback, this) : $(el).data("callback");
        this.callbackmove = (typeof $(this.el).data("callbackmove") === "undefined") ?  _.partial(this.defaultCallback, this) : $(el).data("callbackmove");
        this.min = (typeof $(this.el).data("min") === "undefined") ? 0 : $(el).data("min");
        this.max = (typeof $(this.el).data("max") === "undefined") ? 100 : $(el).data("max");
        this.step = (typeof $(this.el).data("step") === "undefined") ? 1 : $(el).data("step");
        $(el).css('width', '100%');
        $(el).css('border', '1px solid lightgrey');
        $(el).css('padding', '5px');
        $(el).css('background-color', 'white');
        $(el).css('border-radius', '10px');
        $(el).css('box-shadow', '0px 2px 4px lightgrey');


        var tag = helpForm.getStandardTag(this.tag);
        // recupero tableName  e columnName dal tag del controllo
        this.tableName = helpForm.getField(tag, 0);

        // dal tag prendo la colonna della tabella su cui verrà inserito l'id dell'attachment calcolato lato server
        this.columnName = helpForm.getField(tag, 1);

        /****
         Deve essere presente su DS di pagina una tabella attach, che ha idattach e filename, il controllo upload
         sarà referenziato ad una colonna della riga di questo form in cui c'è il valore "idattach". L'assunzione è che colonna inizi per "idattach"
         Tale valore sarà bindato con l'id calcolato dal server, che è già salvato quindi.
         Quindi il valore è importate chiarire che è bindato sulla riga principale del form dove è ospitato il controllo
         In questo modo avremo il collegamento tra l'allegato nella specifica tabella e la tabella attach, dove verranno gestiti anche i contatori,
         che serviranno per l'algoritmo di pulizia degli allegati, come ad esempio quelli che una volta caricati non verranno più confermati
         ****/

        // init tabella in cui inserire l'allegato il cui riferimento sarà sulla tab  del ds che vogliamo(corrisponde tab principale qui)

        // devo trovare la tabella attacch che potrebbe utilizzare un alias, quindi non posso andare per nome diretto
        // mai in base alla relazione

        // costrusice la grafica del controllo
        this.buildTemplateHtml();
    }

    SliderControl.prototype = {
        constructor: SliderControl,

        defaultCallback:function(that, value) {
            console.log('value slider ' + value);
        },

        /**
         * @method buildTemplateHtml
         * @private
         * @description SYNC
         * Builds the upload control and appends to the parent
         */
        buildTemplateHtml:function () {
            var uniqueid = appMeta.utils.getUnivoqueId();
            this.idLbValue = "range_lbl" + uniqueid;
            this.idRange = "range_" + uniqueid;
            var htmlCodeTemplate = '';
            htmlCodeTemplate = '<input id="'+ this.idRange + '" type="range" min="' + this.min +
                '" max="' + this.max +'" step="' + this.step  + '" value="0" class="mdlw-slider" id="myRange" data-custom-control="slider">' +
                '<div class="row">' +
                    '<div class="col mdlw-sliderLabel-min"><label style="font-weight: bold"/> ' + this.min + '<label/></div>' +
                    '<div class="col mdlw-sliderLabel-value"><label id="'+ this.idLbValue + '"/> <label/></div>' +
                    '<div class="col mdlw-sliderLabel-max"><label style="font-weight: bold"/> ' + this.max + '<label/></div>' +
                '</div>' ;
            // appendo al controllo padre
            $(this.el).append(htmlCodeTemplate);
        },

        /**
         * Returns the row on the table where we have to put the idattach value
         * @returns {null | ObjectRow}
         */
        getMainRow:function () {
            var  dt = this.helpForm.DS.tables[this.tableName];
            if (!dt){
                console.log("table " + this.tableName + " doesn't exist on dataset");
                return null;
            }
            if (dt.rows.length !== 1) {
                console.log("on " + this.tableName + " there are zero or more then 1 rows. It is not possible to manage the attachment");
                return null;
            }
            return dt.rows[0];
        },

        // QUI INZIANO METODI DI INTERFACCIA Del CUSTOM CONTROL

        /**
         * @method fillControl
         * @public
         * @description ASYNC
         * Fills the control. First to fill it resets the events rect
         */
        fillControl:function(el){
            var def = Deferred("upload-fillControl");
            var mainRow = this.metaPage.state.currentRow;
            //  label che appare se l'allegato è caricato

            // messaggi di errore, di solito qualche configurazione sbagliata o azione utente non permessa
            if (!mainRow) return def.resolve();
            if (!mainRow.getRow) return def.resolve();

            $('#' + this.idRange).val(mainRow[this.columnName]);
            $('#' + this.idLbValue).text(mainRow[this.columnName]);

            return def.resolve();
        },

        /**
         * @method getControl
         * @public
         * @description ASYNC
         */
        getControl: function(el, r, field) {
            r[field] = this.getValue();
        },

        getValue: function() {
            var v = $('#' + this.idRange).val();
            return !!v ? Number(v) : 0;
        },

        /**
         * @method clearControl
         * @public
         * @description ASYNC
         * Executes a clear of the control. It removes rows and set the index to -1 value.
         * @returns {Deferred}
         */
        clearControl: function() {
            var def = Deferred("slider-clearControl");
            $('#' + this.idRange).val(0);
            return def.resolve();
        },

        /**
         * @method addEvents
         * @public
         * @description ASYNC
         * @param {html node} el
         * @param {MetaPage} metaPage
         * @param {boolean} subscribe
         */
        addEvents: function(el, metaPage, subscribe) {
            this.metaPage = metaPage;
            var $slider = $("#" + this.idRange);
            $slider.on("input", _.partial(this.rangeInpput, this));
            $slider.on("mouseup", _.partial(this.rangMouseUp, this));
        },

        rangMouseUp: function(that) {
            that.callback($("#" + that.idRange).val());
        },

        rangeInpput: function(that) {
            var $slider = $("#" + that.idRange);
            var val = $slider.val();
            $('#' + that.idLbValue).text(val);
            that.callbackmove(val);
        },

        /**
         * @method preFill
         * @public
         * @description ASYNC
         * Executes a prefill of the control
         * @param {Html node} el
         * @param {Object} param {tableWantedName:tableWantedName, filter:filter, selList:selList}
         * @returns {Deferred}
         */
        preFill: function(el, param) {
            var def = Deferred("preFill-Upload");
            return def.resolve();
        },

        /**
         * @method getCurrentRow
         * @private
         * @description SYNC
         * @returns {{table: *, row: *}}
         */
        getCurrentRow: function() {return null},

        /**
         * @method setCurrentRow
         * @private
         * @description SYNC
         * Used when the user click the event to set the current row. read from metapage with getCurrentRow() method
         * @param {ObjectRow} row
         */
        setCurrentRow:function (row) {}
    };

    window.appMeta.CustomControl("slider", SliderControl);

}());
