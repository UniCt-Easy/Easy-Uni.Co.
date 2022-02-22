
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
 * Custom Control for the Tachimetro
 * @module Tachimetro
 * @description
 * Manages the graphics and the logic of a gauge with 2 thresholds
 *
 *   <!-- tachimetro -->
     <script src="../components/metadata/tachimetro/gauge.js"></script>
     <script src="../components/metadata/tachimetro/TachimetroControl.js"></script>
 */
(function() {

    var Deferred = appMeta.Deferred;

    /**
     *
     * @param {html node} el
     * @param {HelpForm} helpForm
     * @param {DataTable} table
     * @param {DataTable} primaryTable
     * @param {string} listType
     * @constructor
     */
    function TachimetroControl(el, helpForm, table, primaryTable, listType) {
        this.helpForm = helpForm;
        this.tag = $(el).data("tag");
        this.el = el;

        // disegna sempre tutto il tachimetro. se true allora non arriva al amx se questo è > del maxValue
        this.limitMax = false;

        // recupero tableName  e columnName dal tag del controllo
        this.tableName = helpForm.getField(this.tag, 0);
        // dal tag prendo la colonna della tabella su cui verrà inserito l'id dell'attachment calcolato lato server
        this.columnName = helpForm.getField(this.tag, 1);

        this.min = (typeof $(el).data("min") === "undefined") ? 0 : $(el).data("min");
        this.max = (typeof $(el).data("max") === "undefined") ? 100 : $(el).data("max");
        this.th1 = (typeof $(el).data("th1") === "undefined") ? this.max/3 : $(el).data("th1");
        this.th2 = (typeof $(el).data("th2") === "undefined") ? this.max/3*2 : $(el).data("th2");
        this.limitMax = (typeof $(el).data("untilmax") === "undefined") ? true : false;

        $(el).css('border', '1px solid lightgrey');
        $(el).css('padding', '5px');
        $(el).css('background-color', 'white');
        $(el).css('border-radius', '10px');
        $(el).css('box-shadow', '0px 2px 4px lightgrey');

        // costrusice la grafica del controllo
        this.buildTemplateHtml();
    }

    TachimetroControl.prototype = {
        constructor: TachimetroControl,


        /**
         * @method buildTemplateHtml
         * @private
         * @description SYNC
         * Builds the upload control and appends to the parent
         */
        buildTemplateHtml:function () {
            var uniqueid = appMeta.utils.getUnivoqueId();
            this.idLbValue = "tach_lbl" + uniqueid;
            this.idTachimetro = "tach_" + uniqueid;
            var htmlCodeTemplate = '';
            htmlCodeTemplate = '<div id="'+ this.idLbValue +'"></div>' +
                '<canvas id="' + this.idTachimetro + '" style="width:100%"></canvas>' ;
            // appendo al controllo padre
            $(this.el).append(htmlCodeTemplate);
        },

        refreshGauge:function(value) {
            var opts = this.getGraphOptions();
            var target = document.getElementById(this.idTachimetro);
            var h = 340;
            this.gauge = new Gauge(target, h * 2 , h).setOptions(opts);
            document.getElementById(this.idLbValue).className = "mdlw-tachimetro-text";
            // a seconda del formato visualizzo
            this.gauge.setTextField(this.getTextField(value));
            this.gauge.maxValue = this.max;
            this.gauge.animationSpeed = 1;
            this.gauge.setMinValue(this.min);
            this.gauge.set(value);
        },

        // a seconda o no se c'è il formato sul tag torna un renderer
        getTextField:function(value) {
            var self =  this;
            // riassegno il textfield con il renderer.
            var CustomTextRenderer = function (el) {
                this.el = el;
                this.render = function (gauge) {
                    var dt = self.helpForm.DS.tables[self.tableName];
                    var c = dt.columns[self.columnName];
                    // utilizzo la classe del framework TypedObject per formattare il valore.
                    // la text si popola automaticamente, con questa istruzione "this.gauge.set(value)", la quale
                    // popola la text e mette la freccia del cursore con l'angolazione esatta
                    this.el.innerHTML = new appMeta.TypedObject(c.ctype, value, self.tag).stringValue(self.tag);
                }
            };
            CustomTextRenderer.prototype = new TextRenderer();
            return new CustomTextRenderer(document.getElementById(this.idLbValue));

            // in questo caso renderer di default, quindi testo normale
            // return document.getElementById(this.idLbValue);
        },

        getGraphOptions:function() {
          return  {
                // color configs
                colorStart: "#6fadcf",
                colorStop: void 0,
                gradientType: 0,
                strokeColor: "#e0e0e0",
                generateGradient: true,
                percentColors: [[0.0, "#a9d70b" ], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                // customize pointer
                pointer: {
                length: 0.57,
                    strokeWidth: 0.035,
                    iconScale: 1.0
                },
                // static labels
                staticLabels: {
                    font: "14px sans-serif",
                        labels: [this.th1, this.th2],
                        fractionDigits: 0
                },
                // static zones
                staticZones: [
                    {strokeStyle: "#30B32D", min: this.min, max: this.th1},
                    {strokeStyle: "#FFDD00", min: this.th1, max: this.th2},
                    {strokeStyle: "#F03E3E", min: this.th2, max: this.max}
                ],
                    // render ticks
                    renderTicks: {
                    /* divisions: 5,
                    divColor: '#333333',
                    divLength: 0.4,
                    divWidth: 0.8
                    divWidth: 1.1,
                    subDivisions: 3,
                    subLength: 0.5,
                    subWidth: 0.6,
                    subColor: '#666666'*/
                },
                // the span of the gauge arc
                angle: 0,
                lineWidth: 0.44,
                radiusScale: 1.0,
                fontSize: 40,
                limitMax: this.limitMax, // if false, max value increases automatically if value > maxValue
                limitMin: false,  // if true, the min value of the gauge will be fixed
                highDpiSupport: true
            };
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
            this.refreshGauge(mainRow[this.columnName]);
            return def.resolve();
        },

        /**
         * @method getControl
         * @public
         * @description ASYNC
         */
        getControl: function(el, r, field) {
            // r[field] = this.getValue();
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
            var def = Deferred("upload-clearControl");
            this.refreshGauge(this.min);
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

    window.appMeta.CustomControl("tachimetro", TachimetroControl);

}());
