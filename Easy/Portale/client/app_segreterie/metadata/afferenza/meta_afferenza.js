
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

    function meta_afferenza() {
        MetaData.apply(this, ["afferenza"]);
        this.name = 'meta_afferenza';
    }

    meta_afferenza.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_afferenza,
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
					case 'doc':
						this.describeAColumn(table, 'start', 'Dal', null, 40, null);
						this.describeAColumn(table, 'stop', 'Al', null, 50, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Struttura', null, 11, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_doc$
						break;
					case 'amm':
						this.describeAColumn(table, 'start', 'Dal', null, 40, null);
						this.describeAColumn(table, 'stop', 'Al', null, 50, null);
						this.describeAColumn(table, '!idmansionekind_mansionekind_title', 'Mansione', null, 101, null);
						objCalcFieldConfig['!idmansionekind_mansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idmansionekind' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione U.O.', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_paridstruttura', 'U.O. madre U.O.', null, 12, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_paridstruttura'] = { tableNameLookup:'struttura', columnNameLookup:'paridstruttura', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_amm$
						break;
					case 'docente':
						this.describeAColumn(table, 'start', 'Dal', null, 40, null);
						this.describeAColumn(table, 'stop', 'Al', null, 50, null);
						this.describeAColumn(table, '!idmansionekind_mansionekind_title', 'Mansione', null, 101, null);
						objCalcFieldConfig['!idmansionekind_mansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idmansionekind' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Struttura', null, 11, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_docente$
						break;
					case 'stru':
						this.describeAColumn(table, 'start', 'Dal ', null, 50, null);
						this.describeAColumn(table, 'stop', 'Al ', null, 60, null);
						this.describeAColumn(table, '!idmansionekind_mansionekind_title', 'Mansione', null, 21, null);
						objCalcFieldConfig['!idmansionekind_mansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idmansionekind' };
						this.describeAColumn(table, '!idreg_registry_title', 'Membro del personale', null, 31, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_stru$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'docente':
						table.columns["idmansionekind"].caption = "Mansione";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["start"].caption = "Dal";
						table.columns["stop"].caption = "Al";
//$innerSetCaptionConfig_docente$
						break;
					case 'amm':
						table.columns["idmansionekind"].caption = "Mansione";
						table.columns["idstruttura"].caption = "U.O.";
//$innerSetCaptionConfig_amm$
						break;
					case 'stru':
						table.columns["idmansionekind"].caption = "Mansione";
						table.columns["idreg"].caption = "Membro del personale";
						table.columns["start"].caption = "Dal ";
						table.columns["stop"].caption = "Al ";
//$innerSetCaptionConfig_stru$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_afferenza");

				//$getNewRowInside$

				dt.autoIncrement('idafferenza', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('afferenza', new meta_afferenza('afferenza'));

	}());
