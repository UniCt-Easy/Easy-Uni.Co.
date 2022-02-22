
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

    function meta_inquadramentodefaultview() {
        MetaData.apply(this, ["inquadramentodefaultview"]);
        this.name = 'meta_inquadramentodefaultview';
    }

    meta_inquadramentodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_inquadramentodefaultview,
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
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito', null, 30, null);
						this.describeAColumn(table, 'inquadramento_start', 'Inizio validità', 'g', 80, null);
						this.describeAColumn(table, 'inquadramento_stop', 'Fine validità', 'g', 90, null);
						this.describeAColumn(table, 'inquadramento_costolordoannuo', 'Costo lordo annuo massimo', 'fixed.2', 100, null);
						this.describeAColumn(table, 'inquadramento_costolordoannuooneri', 'Costo lordo e oneri annuo massimo', 'fixed.2', 110, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontrattokind", "idinquadramento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "inquadramento_title desc";
					}
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('inquadramentodefaultview', new meta_inquadramentodefaultview('inquadramentodefaultview'));

	}());
