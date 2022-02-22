
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

    function meta_progettokindsegview() {
        MetaData.apply(this, ["progettokindsegview"]);
        this.name = 'meta_progettokindsegview';
    }

    meta_progettokindsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettokindsegview,
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
						this.describeAColumn(table, 'progettoactivitykind_title', 'Tipologia', null, 10, 2048);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'progettokind_oredivisionecostostipendio', 'Numero ore lavorate in un anno dal personale', null, 30, null);
						this.describeAColumn(table, 'progettokind_stipendioannoprec', 'Usa stipendi anno precedente', null, 80, null);
						this.describeAColumn(table, 'progettokind_stipendiocomericavo', 'Usa stipendi come ricavi', null, 90, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogettokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "progettoactivitykind_title asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettokindsegview', new meta_progettokindsegview('progettokindsegview'));

	}());
