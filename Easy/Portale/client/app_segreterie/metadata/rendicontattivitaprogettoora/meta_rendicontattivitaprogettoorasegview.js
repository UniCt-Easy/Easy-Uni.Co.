
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

    function meta_rendicontattivitaprogettoorasegview() {
        MetaData.apply(this, ["rendicontattivitaprogettoorasegview"]);
        this.name = 'meta_rendicontattivitaprogettoorasegview';
    }

    meta_rendicontattivitaprogettoorasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoorasegview,
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
					case 'seg':
						this.describeAColumn(table, 'rendicontattivitaprogettoora_data', 'Data', null, 30, null);
						this.describeAColumn(table, 'rendicontattivitaprogettoora_ore', 'Numero di ore', null, 70, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato di avanzamento lavori', null, 130, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato di avanzamento lavori', null, 130, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idworkpackage", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "rendicontattivitaprogettoora_data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettoorasegview', new meta_rendicontattivitaprogettoorasegview('rendicontattivitaprogettoorasegview'));

	}());
