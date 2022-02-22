
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

    function meta_provaaula() {
        MetaData.apply(this, ["provaaula"]);
        this.name = 'meta_provaaula';
    }

    meta_provaaula.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provaaula,
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
					case 'appelli':
						objCalcFieldConfig['!idaula_aula_title'] = { tableNameLookup:'aula', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aula_code'] = { tableNameLookup:'aula', columnNameLookup:'code', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_edificio_title'] = { tableNameLookup:'edificio', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aula_capienza'] = { tableNameLookup:'aula', columnNameLookup:'capienza', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aula_capienzadis'] = { tableNameLookup:'aula', columnNameLookup:'capienzadis', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aulakind_title'] = { tableNameLookup:'aulakind', columnNameLookup:'title', columnNamekey:'idaula' };
						this.describeAColumn(table, '!idaula_aula_title', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idaula_aula_code', 'Codice', null, 12, null);
						this.describeAColumn(table, '!idaula_edificio_title', 'Edificio', null, 14, null);
						this.describeAColumn(table, '!idaula_struttura_title', 'Denominazione Struttura didattica di afferenza', null, 15, null);
						this.describeAColumn(table, '!idaula_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 15, null);
						this.describeAColumn(table, '!idaula_aula_capienza', 'Capienza', null, 15, null);
						this.describeAColumn(table, '!idaula_aula_capienzadis', 'Capienza disabili', null, 16, null);
						this.describeAColumn(table, '!idaula_aulakind_title', 'Tipologia', null, 18, null);
						this.describeAColumn(table, '!idaula_struttura_alias1_title', 'Denominazione Struttura didattica di afferenza', null, 15, null);
						this.describeAColumn(table, '!idaula_struttura_alias1_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 15, null);
						objCalcFieldConfig['!idaula_struttura_alias1_title'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_struttura_alias1_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idaula' };
//$objCalcFieldConfig_appelli$
						break;
					case 'prova':
						objCalcFieldConfig['!idaula_aula_title'] = { tableNameLookup:'aula', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aula_code'] = { tableNameLookup:'aula', columnNameLookup:'code', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_edificio_title'] = { tableNameLookup:'edificio', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aula_capienza'] = { tableNameLookup:'aula', columnNameLookup:'capienza', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aula_capienzadis'] = { tableNameLookup:'aula', columnNameLookup:'capienzadis', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_aulakind_title'] = { tableNameLookup:'aulakind', columnNameLookup:'title', columnNamekey:'idaula' };
						this.describeAColumn(table, '!idaula_aula_title', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idaula_aula_code', 'Codice', null, 12, null);
						this.describeAColumn(table, '!idaula_edificio_title', 'Edificio', null, 14, null);
						this.describeAColumn(table, '!idaula_struttura_title', 'Denominazione Struttura didattica di afferenza', null, 15, null);
						this.describeAColumn(table, '!idaula_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 15, null);
						this.describeAColumn(table, '!idaula_aula_capienza', 'Capienza', null, 15, null);
						this.describeAColumn(table, '!idaula_aula_capienzadis', 'Capienza disabili', null, 16, null);
						this.describeAColumn(table, '!idaula_aulakind_title', 'Tipologia', null, 18, null);
						this.describeAColumn(table, '!idaula_struttura_alias1_title', 'Denominazione Struttura didattica di afferenza', null, 15, null);
						this.describeAColumn(table, '!idaula_struttura_alias1_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 15, null);
						objCalcFieldConfig['!idaula_struttura_alias1_title'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'title', columnNamekey:'idaula' };
						objCalcFieldConfig['!idaula_struttura_alias1_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idaula' };
//$objCalcFieldConfig_prova$
						break;
					case 'aula':
						objCalcFieldConfig['!idprova_prova_title'] = { tableNameLookup:'prova', columnNameLookup:'title', columnNamekey:'idprova' };
						objCalcFieldConfig['!idprova_prova_start'] = { tableNameLookup:'prova', columnNameLookup:'start', columnNamekey:'idprova' };
						objCalcFieldConfig['!idprova_prova_stop'] = { tableNameLookup:'prova', columnNameLookup:'stop', columnNamekey:'idprova' };
						this.describeAColumn(table, '!idprova_prova_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!idprova_prova_start', 'Data e ora inizio', 'g', 24, null);
						this.describeAColumn(table, '!idprova_prova_stop', 'Data e ora fine', 'g', 23, null);
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
               var def = appMeta.Deferred("getNewRow-meta_provaaula");

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

			//$getSorting$

        });

    window.appMeta.addMeta('provaaula', new meta_provaaula('provaaula'));

	}());
