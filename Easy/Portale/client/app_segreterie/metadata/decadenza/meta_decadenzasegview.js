
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

    function meta_decadenzasegview() {
        MetaData.apply(this, ["decadenzasegview"]);
        this.name = 'meta_decadenzasegview';
    }

    meta_decadenzasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_decadenzasegview,
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
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 20, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 20, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 30, 9);
						this.describeAColumn(table, 'decadenza_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'decadenza_protanno', 'Anno di protocollo', null, 60, null);
						this.describeAColumn(table, 'decadenza_protnumero', 'Numero di protocollo', null, 70, null);
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 10, 9);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddecadenza", "idiscrizione", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "registrystudenti_title asc , iscrizione_anno asc , iscrizione_iddidprog asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('decadenzasegview', new meta_decadenzasegview('decadenzasegview'));

	}());
