
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

    function meta_classescuoladefaultview() {
        MetaData.apply(this, ["classescuoladefaultview"]);
        this.name = 'meta_classescuoladefaultview';
    }

    meta_classescuoladefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classescuoladefaultview,
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
						this.describeAColumn(table, 'sigla', 'Sigla', null, 10, 50);
						this.describeAColumn(table, 'classescuola_title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'corsostudionorma_title', 'Normativa', null, 30, 50);
						this.describeAColumn(table, 'classescuola_indicecineca', 'Identificativo CINECA', null, 30, null);
						this.describeAColumn(table, 'classescuolakind_title', 'Tipologia', null, 40, 1024);
						this.describeAColumn(table, 'classescuolaarea_title', 'Area', null, 50, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idclassescuola"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "sigla asc , classescuola_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('classescuoladefaultview', new meta_classescuoladefaultview('classescuoladefaultview'));

	}());
