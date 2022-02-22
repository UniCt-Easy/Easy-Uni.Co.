
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

    function meta_istanzarein_segview() {
        MetaData.apply(this, ["istanzarein_segview"]);
        this.name = 'meta_istanzarein_segview';
    }

    meta_istanzarein_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzarein_segview,
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
					case 'rein_seg':
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 20, 101);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 80, 50);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 510, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 510, 9);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 620, null);
						this.describeAColumn(table, 'istanza_rein_darindec', 'Corso della rinuncia o decadenza ', null, 520, null);
						this.describeAColumn(table, 'istanza_rein_datarindec', 'Data della rinuncia o decadenza ', null, 530, null);
						this.describeAColumn(table, 'iscrizione_istanza_rein_anno', 'Anno di corso Iscrizione da cui si vuole farsi reintegrare', null, 560, null);
						this.describeAColumn(table, 'iscrizione_istanza_rein_iddidprog', 'Didattica programmata Iscrizione da cui si vuole farsi reintegrare', null, 560, null);
						this.describeAColumn(table, 'iscrizione_istanza_rein_aa', 'Anno accademico Iscrizione da cui si vuole farsi reintegrare', null, 560, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di  studio da cui si vuole farsi reintegrare', null, 600, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di  studio da cui si vuole farsi reintegrare', null, 600, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di  studio da cui si vuole farsi reintegrare', null, 600, null);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademco Titolo di  studio da cui si vuole farsi reintegrare', null, 600, 9);
						this.describeAColumn(table, 'aa_rindec', 'Anno accademico della rinuncia o decadenza', null, 1660, 9);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT', null, 10, 1024);
						this.describeAColumn(table, 'istattitolistudio_idistattitolistudio', 'Titolo ISTAT Titolo ISTAT', null, 10, null);
//$objCalcFieldConfig_rein_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idistanza", "idiscrizione", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzarein_segview', new meta_istanzarein_segview('istanzarein_segview'));

	}());
