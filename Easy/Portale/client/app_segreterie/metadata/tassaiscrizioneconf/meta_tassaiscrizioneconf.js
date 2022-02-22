
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

    function meta_tassaiscrizioneconf() {
        MetaData.apply(this, ["tassaiscrizioneconf"]);
        this.name = 'meta_tassaiscrizioneconf';
    }

    meta_tassaiscrizioneconf.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaiscrizioneconf,
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
					case 'default':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Title', null, 30, 2024);
						this.describeAColumn(table, 'aamax', 'Anno accademico massimo', null, 40, 9);
						this.describeAColumn(table, 'aamin', 'Anno accademico minimo', null, 50, 9);
						this.describeAColumn(table, 'annofcmax', 'Anno di iscrizione fuori corso massimo', null, 60, null);
						this.describeAColumn(table, 'annofcmin', 'Anno di iscrizione fuori corso minimo', null, 70, null);
						this.describeAColumn(table, 'annomax', 'Anno di iscrizione massimo', null, 80, null);
						this.describeAColumn(table, 'annomin', 'Anno di iscrizione minimo', null, 90, null);
						this.describeAColumn(table, 'codice_corsostudio', 'Codice del corso di studio', null, 100, 50);
						this.describeAColumn(table, 'codice_didprog', 'Codice della didattica programmata', null, 110, 50);
						this.describeAColumn(table, 'codice_didprogcurr', 'Codice del curriculum', null, 120, 50);
						this.describeAColumn(table, 'codice_didprogori', 'Codice dell\'orientamento', null, 130, 50);
						this.describeAColumn(table, 'corsisingoli', 'Corsi singoli', null, 140, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_tassaiscrizioneconf");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idtassaiscrizioneconf', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tassaiscrizioneconf', new meta_tassaiscrizioneconf('tassaiscrizioneconf'));

	}());
