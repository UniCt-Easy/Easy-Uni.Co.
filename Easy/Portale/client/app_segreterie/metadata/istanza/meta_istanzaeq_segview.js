
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_istanzaeq_segview() {
        MetaData.apply(this, ["istanzaeq_segview"]);
        this.name = 'meta_istanzaeq_segview';
    }

    meta_istanzaeq_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaeq_segview,
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
					case 'eq_seg':
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Corso equipollente', null, 60, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Corso equipollente', null, 60, 9);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 100, 50);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 130, null);
						this.describeAColumn(table, 'dichiartitolo_seg_idreg', 'Dichiarazione del titolo di studio', null, 1090, null);
//$objCalcFieldConfig_eq_seg$
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

    window.appMeta.addMeta('istanzaeq_segview', new meta_istanzaeq_segview('istanzaeq_segview'));

	}());