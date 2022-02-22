
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

    function meta_classconsorsualedefaultview() {
        MetaData.apply(this, ["classconsorsualedefaultview"]);
        this.name = 'meta_classconsorsualedefaultview';
    }

    meta_classconsorsualedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classconsorsualedefaultview,
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
						this.describeAColumn(table, 'idclassconsorsuale', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'classconsorsuale_description', 'Descrizione', null, 20, 512);
						this.describeAColumn(table, 'classconsorsuale_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'classconsorsuale_ambitodisci', 'Ambito Disciplinare', null, 50, 50);
						this.describeAColumn(table, 'classconsorsuale_corr2592017', 'Corrispondenza', null, 60, 50);
						this.describeAColumn(table, 'classconsorsuale_normativa', 'Normativa', null, 70, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idclassconsorsuale"];
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

    window.appMeta.addMeta('classconsorsualedefaultview', new meta_classconsorsualedefaultview('classconsorsualedefaultview'));

	}());
