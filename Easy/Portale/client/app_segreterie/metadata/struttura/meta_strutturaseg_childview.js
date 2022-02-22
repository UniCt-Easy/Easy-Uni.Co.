
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

    function meta_strutturaseg_childview() {
        MetaData.apply(this, ["strutturaseg_childview"]);
        this.name = 'meta_strutturaseg_childview';
    }

    meta_strutturaseg_childview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaseg_childview,
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
					case 'seg_child':
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 10, 50);
						this.describeAColumn(table, 'strutturakind_struttura_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'strutturaparent_idstrutturakind', 'Tipo Tipo', null, 20, null);
						this.describeAColumn(table, 'struttura_title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'struttura_title_en', 'Denominazione (ENG)', null, 30, 1024);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 40, 50);
						this.describeAColumn(table, 'struttura_email', 'E-Mail', null, 50, 200);
						this.describeAColumn(table, 'struttura_fax', 'Fax', null, 60, 50);
						this.describeAColumn(table, 'struttura_telefono', 'Telefono', null, 70, 50);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione Struttura madre', null, 90, 1024);
//$objCalcFieldConfig_seg_child$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg_child": {
						return "struttura_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturaseg_childview', new meta_strutturaseg_childview('strutturaseg_childview'));

	}());
