
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

    function meta_istanzasosp_segview() {
        MetaData.apply(this, ["istanzasosp_segview"]);
        this.name = 'meta_istanzasosp_segview';
    }

    meta_istanzasosp_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzasosp_segview,
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
					case 'sosp_seg':
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 50, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 50, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 60, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 60, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 70, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 70, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 70, 9);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 90, 101);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 100, 50);
						this.describeAColumn(table, 'istanzaparent_idistanzakind', 'Tipologia Istanza collegata', null, 110, null);
						this.describeAColumn(table, 'istanzaparent_idreg_studenti', 'Studente Istanza collegata', null, 110, null);
						this.describeAColumn(table, 'istanzaparent_aa', 'Anno accademico Istanza collegata', null, 110, 9);
						this.describeAColumn(table, 'istanzaparent_data', 'Data Istanza collegata', 'g', 110, null);
						this.describeAColumn(table, 'istanza_sosp_motivo', 'Motivo', null, 540, -1);
						this.describeAColumn(table, 'istanza_sosp_start', 'Data di Inizio', null, 550, null);
						this.describeAColumn(table, 'istanza_sosp_stop', 'Data di fine', null, 560, null);
//$objCalcFieldConfig_sosp_seg$
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

    window.appMeta.addMeta('istanzasosp_segview', new meta_istanzasosp_segview('istanzasosp_segview'));

	}());
