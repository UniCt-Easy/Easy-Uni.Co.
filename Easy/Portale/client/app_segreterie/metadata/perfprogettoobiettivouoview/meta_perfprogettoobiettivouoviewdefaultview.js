
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

    function meta_perfprogettoobiettivouoviewdefaultview() {
        MetaData.apply(this, ["perfprogettoobiettivouoviewdefaultview"]);
        this.name = 'meta_perfprogettoobiettivouoviewdefaultview';
    }

    meta_perfprogettoobiettivouoviewdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivouoviewdefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'progetto_title', 'Progetto', null, 10, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_title', 'Titolo', null, 30, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_description', 'Descrizione', null, 40, -1);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_peso', 'Peso per il progetto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'XXperfprogettoobiettivosoglia', 'Soglie', null, 50, null);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura", "idperfvalutazioneuo", "idperfprogettoobiettivo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "perfprogettoobiettivouoview_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivouoviewdefaultview', new meta_perfprogettoobiettivouoviewdefaultview('perfprogettoobiettivouoviewdefaultview'));

	}());
