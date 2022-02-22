
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

    function meta_strutturadefaultview() {
        MetaData.apply(this, ["strutturadefaultview"]);
        this.name = 'meta_strutturadefaultview';
    }

    meta_strutturadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturadefaultview,
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
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 20, 50);
						this.describeAColumn(table, 'strutturakind_struttura_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'strutturaparent_idstrutturakind', 'Tipo Tipo', null, 20, null);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione Struttura madre', null, 90, 1024);
//$objCalcFieldConfig_default$
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
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturadefaultview', new meta_strutturadefaultview('strutturadefaultview'));

	}());
