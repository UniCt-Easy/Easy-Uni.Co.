
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

    function meta_sospensione() {
        MetaData.apply(this, ["sospensione"]);
        this.name = 'meta_sospensione';
    }

    meta_sospensione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sospensione,
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
					case 'princ':
						this.describeAColumn(table, 'motivo', 'Motivo', null, 60, 1024);
						this.describeAColumn(table, 'start', 'Inizio', 'g', 70, null);
						this.describeAColumn(table, 'stop', 'Fine', 'g', 80, null);
//$objCalcFieldConfig_princ$
						break;
					case 'default':
						this.describeAColumn(table, 'start', 'Inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Fine', 'g', 30, null);
						this.describeAColumn(table, 'motivo', 'Motivo', null, 40, 1024);
//$objCalcFieldConfig_default$
						break;
					case 'edifici':
						this.describeAColumn(table, 'start', 'Inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Fine', 'g', 30, null);
						this.describeAColumn(table, 'motivo', 'Motivo', null, 40, 1024);
//$objCalcFieldConfig_edifici$
						break;
					case 'aula':
						this.describeAColumn(table, 'start', 'Inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Fine', 'g', 30, null);
						this.describeAColumn(table, 'motivo', 'Motivo', null, 40, 1024);
//$objCalcFieldConfig_aula$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_sospensione");

				//$getNewRowInside$

				dt.autoIncrement('idsospensione', { minimum: 99990001 });

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
					case "default": {
						return "start asc ";
					}
					case "edifici": {
						return "start desc";
					}
					case "aula": {
						return "start desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sospensione', new meta_sospensione('sospensione'));

	}());
