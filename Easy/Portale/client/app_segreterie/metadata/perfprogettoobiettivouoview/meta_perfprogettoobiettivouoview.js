
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

    function meta_perfprogettoobiettivouoview() {
        MetaData.apply(this, ["perfprogettoobiettivouoview"]);
        this.name = 'meta_perfprogettoobiettivouoview';
    }

    meta_perfprogettoobiettivouoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivouoview,
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
						this.describeAColumn(table, 'progetto_title', 'Progetto', null, 10, 1024);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, -1);
						this.describeAColumn(table, 'peso', 'Peso per il progetto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
						this.describeAColumn(table, '!perfprogettoobiettivosoglia', 'Soglie', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["peso"].caption = "Peso per il progetto";
						table.columns["progetto_title"].caption = "Progetto";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["idstruttura", "idperfstrutturauo", "idperfvalutazioneuo", "idperfprogettoobiettivo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivouoview', new meta_perfprogettoobiettivouoview('perfprogettoobiettivouoview'));

	}());
