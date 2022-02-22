
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

    function meta_istanzaconseg_segview() {
        MetaData.apply(this, ["istanzaconseg_segview"]);
        this.name = 'meta_istanzaconseg_segview';
    }

    meta_istanzaconseg_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaconseg_segview,
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
					case 'conseg_seg':
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 60, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 60, 9);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 100, 50);
						this.describeAColumn(table, 'istanza_conseg_datacompalmalaur', 'Data di compilazione del questionario su Almalaurea', null, 510, null);
						this.describeAColumn(table, 'istanza_conseg_fascicolo', 'Fascicolo', null, 520, 50);
						this.describeAColumn(table, 'appello_description', 'Descrizione Appello', null, 530, 1024);
						this.describeAColumn(table, 'appello_aa', 'Anno accademico Appello', null, 530, 9);
						this.describeAColumn(table, 'istanza_conseg_posizione', 'Posizione', null, 580, 50);
//$objCalcFieldConfig_conseg_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idistanza", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzaconseg_segview', new meta_istanzaconseg_segview('istanzaconseg_segview'));

	}());
