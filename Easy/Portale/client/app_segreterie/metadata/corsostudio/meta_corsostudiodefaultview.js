
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

    function meta_corsostudiodefaultview() {
        MetaData.apply(this, ["corsostudiodefaultview"]);
        this.name = 'meta_corsostudiodefaultview';
    }

    meta_corsostudiodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudiodefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'corsostudio_title_en', 'Denominazione (EN)', null, 20, 1024);
						this.describeAColumn(table, 'corsostudio_codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'corsostudio_codicemiur', 'Codice MIUR', null, 40, 10);
						this.describeAColumn(table, 'corsostudio_codicemiurlungo', 'Codice MIUR lungo', null, 50, 50);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione', null, 60, null);
						this.describeAColumn(table, 'corsostudiokind_title', 'Tipologia', null, 70, 50);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di riferimento', null, 80, 1024);
						this.describeAColumn(table, 'corsostudionorma_title', 'Normativa di riferimento', null, 110, 50);
						this.describeAColumn(table, 'corsostudiolivello_title', 'Livello', null, 130, 50);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc , corsostudio_annoistituz asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('corsostudiodefaultview', new meta_corsostudiodefaultview('corsostudiodefaultview'));

	}());
