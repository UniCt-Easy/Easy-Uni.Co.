
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

    function meta_getdocentiperssd() {
        MetaData.apply(this, ["getdocentiperssd"]);
        this.name = 'meta_getdocentiperssd';
    }

    meta_getdocentiperssd.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getdocentiperssd,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seg':
						this.describeAColumn(table, 'costoorario', 'Costo orario', 'fixed.2', 10, null);
						this.describeAColumn(table, 'oreperaacontratto', 'Ore già impegnate nell\'AA per contratto', null, 20, null);
						this.describeAColumn(table, 'oreperaaaffidamento', 'Ore già impegnate nell\'AA per affidamenti', null, 30, null);
						this.describeAColumn(table, 'oremindida', 'Ore minime di didattica', null, 40, null);
						this.describeAColumn(table, 'oremaxdida', 'Ore massime di didattica', null, 50, null);
						this.describeAColumn(table, 'cognome', 'Cognome', null, 60, 50);
						this.describeAColumn(table, 'nome', 'Nome', null, 70, 50);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 80, 50);
						this.describeAColumn(table, 'ssd', 'Ssd', null, 90, 50);
						this.describeAColumn(table, 'contratto', 'Contratto', null, 100, 50);
						this.describeAColumn(table, 'iniziocontratto', 'Data di inizio del contratto', null, 110, null);
						this.describeAColumn(table, 'terminecontratto', 'Data di fine del contratto', null, 120, null);
						this.describeAColumn(table, 'parttime', 'Part-time', 'fixed.2', 130, null);
						this.describeAColumn(table, 'tempodefinito', 'Tempo definito', null, 140, null);
						this.describeAColumn(table, 'struttura', 'Struttura', null, 150, 1024);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_getdocentiperssd");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "costoorario asc , oreperaacontratto asc , oreperaaaffidamento asc , ssd desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getdocentiperssd', new meta_getdocentiperssd('getdocentiperssd'));

	}());
