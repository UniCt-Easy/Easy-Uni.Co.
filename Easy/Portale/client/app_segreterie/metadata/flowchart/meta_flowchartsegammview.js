
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

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_flowchartsegammview() {
        MetaData.apply(this, ["flowchartsegammview"]);
        this.name = 'meta_flowchartsegammview';
    }

    meta_flowchartsegammview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_flowchartsegammview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'segamm':
						this.describeAColumn(table, 'idflowchart', 'Identificativo', null, 10, 34);
						this.describeAColumn(table, 'flowchart_ayear', 'Anno esercizio', null, 20, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 150);
						this.describeAColumn(table, 'flowchart_codeflowchart', 'Codice', null, 40, 50);
						this.describeAColumn(table, 'flowchartparent_codeflowchart', 'Codice Nodo padre', null, 50, 50);
						this.describeAColumn(table, 'flowchartparent_title', 'Denominazione Nodo padre', null, 50, 150);
//$objCalcFieldConfig_segamm$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idflowchart"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segamm": {
						return "idflowchart asc , flowchart_title desc";
					}
					case "segamm": {
						return "idflowchart asc , title desc";
					}
					case "segamm": {
						return "idflowchart asc , title desc, flowchart_codeflowchart asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('flowchartsegammview', new meta_flowchartsegammview('flowchartsegammview'));

	}());
