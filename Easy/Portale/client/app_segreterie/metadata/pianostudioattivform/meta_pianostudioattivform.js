
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

    function meta_pianostudioattivform() {
        MetaData.apply(this, ["pianostudioattivform"]);
        this.name = 'meta_pianostudioattivform';
    }

    meta_pianostudioattivform.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioattivform,
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
					case 'seganagstusing':
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 31, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 52, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 53, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 54, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 51, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 51, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 20, null);
//$objCalcFieldConfig_seganagstu$
						break;
					case 'segstud':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 20, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 31, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa che lo studente svolgerà', null, 41, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 52, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 53, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 54, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 51, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 51, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segstud$
						break;
					case 'didprog':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 20, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 31, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa che lo studente svolgerà', null, 41, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 52, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 53, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 54, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 51, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 51, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_didprog$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_pianostudioattivform");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idpianostudioattivform', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					idattivform_scelta : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('pianostudioattivform', new meta_pianostudioattivform('pianostudioattivform'));

	}());
