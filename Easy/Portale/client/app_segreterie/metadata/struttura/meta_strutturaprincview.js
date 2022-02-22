
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

    function meta_strutturaprincview() {
        MetaData.apply(this, ["strutturaprincview"]);
        this.name = 'meta_strutturaprincview';
    }

    meta_strutturaprincview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaprincview,
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
					case 'princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'struttura_codiceipa', 'Codice IPA', null, 40, null);
						this.describeAColumn(table, 'struttura_email', 'E-Mail', null, 50, 200);
						this.describeAColumn(table, 'struttura_fax', 'Fax', null, 60, 50);
						this.describeAColumn(table, 'aoo_title', 'AOO', null, 70, 1024);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 80, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 90, 50);
						this.describeAColumn(table, 'upb_title', 'UPB', null, 100, 150);
						this.describeAColumn(table, 'struttura_telefono', 'Telefono', null, 110, 50);
						this.describeAColumn(table, 'struttura_title_en', 'Denominazione (ENG)', null, 120, 1024);
//$objCalcFieldConfig_princ$
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
					case "princ": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturaprincview', new meta_strutturaprincview('strutturaprincview'));

	}());
