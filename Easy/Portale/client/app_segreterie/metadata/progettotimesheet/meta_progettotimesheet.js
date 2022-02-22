
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

    function meta_progettotimesheet() {
        MetaData.apply(this, ["progettotimesheet"]);
        this.name = 'meta_progettotimesheet';
    }

    meta_progettotimesheet.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotimesheet,
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
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'title', 'Descrizione', null, 30, 2048);
						this.describeAColumn(table, 'idtimesheettemplate', 'Intestazione', null, 40, 60);
						this.describeAColumn(table, 'showactivitiesrow', 'Visualizza la riga con il totale giornaliero', null, 50, null);
						this.describeAColumn(table, 'intestazioneallsheet', 'Intestazione in  tutti i fogli', null, 110, null);
						this.describeAColumn(table, 'riepilogoanno', 'Inserisci il riepilogo annuale', null, 120, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettotimesheet");

				//$getNewRowInside$

				dt.autoIncrement('idprogettotimesheet', { minimum: 99990001 });

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
						return "year desc, title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettotimesheet', new meta_progettotimesheet('progettotimesheet'));

	}());
