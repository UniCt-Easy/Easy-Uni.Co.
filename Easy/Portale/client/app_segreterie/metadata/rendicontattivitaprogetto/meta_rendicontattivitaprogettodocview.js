
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

    function meta_rendicontattivitaprogettodocview() {
        MetaData.apply(this, ["rendicontattivitaprogettodocview"]);
        this.name = 'meta_rendicontattivitaprogettodocview';
    }

    meta_rendicontattivitaprogettodocview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettodocview,
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
					case 'doc':
						this.describeAColumn(table, 'progetto_titolobreve', 'Progetto', null, 10, 2048);
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 20, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 20, 2048);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'rendicontattivitaprogetto_orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_doc$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrendicontattivitaprogetto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "doc": {
						return "rendicontattivitaprogetto_datainizioprevista asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettodocview', new meta_rendicontattivitaprogettodocview('rendicontattivitaprogettodocview'));

	}());
