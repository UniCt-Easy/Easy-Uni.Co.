
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

    function meta_rendicontattivitaprogettoora() {
        MetaData.apply(this, ["rendicontattivitaprogettoora"]);
        this.name = 'meta_rendicontattivitaprogettoora';
    }

    meta_rendicontattivitaprogettoora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoora,
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
						this.describeAColumn(table, '!titleancestor', 'Descrizione', null, 10, null);
						this.describeAColumn(table, 'data', 'Data', null, 30, null);
						this.describeAColumn(table, 'ore', 'Numero di ore', null, 70, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato di avanzamento lavori', null, 131, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato di avanzamento lavori', null, 132, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
//$objCalcFieldConfig_seg$
						break;
					case 'segsal':
						this.describeAColumn(table, '!titleancestor', 'Descrizione', null, 10, null);
						this.describeAColumn(table, 'data', 'Data', null, 30, null);
						this.describeAColumn(table, 'ore', 'Numero di ore', null, 70, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato di avanzamento lavori', null, 131, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato di avanzamento lavori', null, 132, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idsal' };
//$objCalcFieldConfig_segsal$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["!titleancestor"].caption = "Descrizione";
//$innerSetCaptionConfig_seg$
						break;
					case 'segsal':
						table.columns["!titleancestor"].caption = "Descrizione";
//$innerSetCaptionConfig_segsal$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontattivitaprogettoora");

				//$getNewRowInside$

				dt.autoIncrement('idrendicontattivitaprogettoora', { minimum: 99990001 });

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
						return "data asc ";
					}
					case "segsal": {
						return "data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettoora', new meta_rendicontattivitaprogettoora('rendicontattivitaprogettoora'));

	}());
