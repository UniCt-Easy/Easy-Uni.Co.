
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

    function meta_sostenimentoseganagstuaccview() {
        MetaData.apply(this, ["sostenimentoseganagstuaccview"]);
        this.name = 'meta_sostenimentoseganagstuaccview';
    }

    meta_sostenimentoseganagstuaccview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentoseganagstuaccview,
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
					case 'seganagstuacc':
						this.describeAColumn(table, 'registry_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 20, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 120, 50);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 230, null);
//$objCalcFieldConfig_seganagstuacc$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idprova", "iddidprog", "idiscrizione", "idcorsostudio", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentoseganagstuaccview', new meta_sostenimentoseganagstuaccview('sostenimentoseganagstuaccview'));

	}());
