
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
 * Custom Control for the graph.
 * @module UploadControl
 * @description
 * Manages the graphics and the logic of a numeric slider
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
    function GraphControl(el, helpForm, table, primaryTable, listType) {
        this.helpForm = helpForm;
        this.tag = $(el).data("tag");
        this.el = el;
        // recupero tableName  e columnName dal tag del controllo
        this.tableName = helpForm.getField(this.tag, 0);
        // dal tag prendo la colonna della tabella su cui verrà inserito l'id dell'attachment calcolato lato server
        this.columnName = helpForm.getField(this.tag, 1);

        this.xaxestime = (typeof $(el).data("xaxestime") !== "undefined");
        // ---> può essere "bar" o "line"
        this.type = (typeof $(el).data("type") === "undefined") ? 'line' : $(el).data("type");
        this.ycol = $(el).data("ycol");
        this.xcol = $(el).data("xcol");
        this.tname = $(el).data("tname");
        this.title = (typeof $(el).data("title") === "undefined") ? 'graph' : $(el).data("title");

        $(el).css('border', '1px solid lightgrey');
        $(el).css('padding', '5px');
        $(el).css('background-color', 'white');
        $(el).css('border-radius', '10px');
        $(el).css('box-shadow', '0px 2px 4px lightgrey');

        // costrusice la grafica del controllo
        this.buildTemplateHtml();
    }

    GraphControl.prototype = {
        constructor: GraphControl,

        /**
         * @method buildTemplateHtml
         * @private
         * @description SYNC
         * Builds the graph control with empty values
         */
        buildTemplateHtml:function () {
            var uniqueid = appMeta.utils.getUnivoqueId();
            this.idGraph = "graph_" + uniqueid;
            var htmlCodeTemplate = '';
            htmlCodeTemplate = '<div></div><canvas id="' + this.idGraph + '"></canvas></div>' ;
            // appendo al controllo padre
            $(this.el).append(htmlCodeTemplate);
            var ctx = document.getElementById(this.idGraph).getContext("2d");
            var config = {
                    type: this.type,
                    options: {}
            };
            this.myNewChart = new Chart(ctx, config);
            this.updateGraph([], []);
        },


        // QUI INZIANO METODI DI INTERFACCIA Del CUSTOM CONTROL

        /**
         * @method fillControl
         * @public
         * @description ASYNC
         * Fills the control.
         */
        fillControl:function(el){
            var def = Deferred("upload-fillControl");
            //  label che appare se l'allegato è caricato
            var table = this.metaPage.state.DS.tables[this.tname];
            var xvalues = this.getXValues(table.rows);
            var yvalues = this.getYValues(table.rows);
            this.updateGraph(xvalues, yvalues);
            return def.resolve();
        },

        getXValues:function(rows) {
            var self = this;
            return rows.map(function (row) {
                if (self.xaxestime && row[self.xcol]) {
                    return moment(row[self.xcol]).format("DD-MM-YYYY");
                }
                return row[self.xcol];
            });
        },

        getYValues:function(rows) {
            var self = this;
            return rows.map(function (row) {
                return row[self.ycol];
            });
        },

        updateGraph: function(xvalues, yvalues) {
            var data = {
                labels: xvalues,
                datasets: [{
                    label: this.title,
                    data: yvalues,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)'
                    ],
                    borderWidth: 1
                }]
            };
            this.myNewChart.data = data;
            this.myNewChart.update();
        },

        /**
         * @method getControl
         * @public
         * @description ASYNC
         */
        getControl: function(el, r, field) {
            // r[field] = this.getValue();
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
            this.updateGraph([], []);
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

    window.appMeta.CustomControl("graph", GraphControl);

}());
