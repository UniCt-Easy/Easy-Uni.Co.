
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

    function meta_bandomistrutturefrom() {
        MetaData.apply(this, ["bandomistrutturefrom"]);
        this.name = 'meta_bandomistrutturefrom';
    }

    meta_bandomistrutturefrom.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomistrutturefrom,
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
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!idstruttura_strutturakind_title', 'Tipologia', null, 21, null);
						this.describeAColumn(table, '!idstruttura_struttura_codice', 'Codice', null, 20, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_codice'] = { tableNameLookup:'struttura', columnNameLookup:'codice', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!idstruttura_strutturakind_title', 'Tipo', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_codice', 'Codice', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura madre', null, 33, null);
						this.describeAColumn(table, '!idstruttura_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 33, null);
						objCalcFieldConfig['!idstruttura_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idstruttura_registry_title', 'Responsabile', null, 29, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura madre', null, 30, null);
						this.describeAColumn(table, '!idstruttura_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 30, null);
						objCalcFieldConfig['!idstruttura_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idstruttura_struttura_alias1_title', 'Denominazione Struttura madre', null, 30, null);
						this.describeAColumn(table, '!idstruttura_struttura_alias1_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 30, null);
						objCalcFieldConfig['!idstruttura_struttura_alias1_title'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_alias1_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_seg$
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
						table.columns["idbandomi"].caption = "Bando per la mobilit� internazionale";
						table.columns["idstruttura"].caption = "Struttura didattica di partenza";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandomistrutturefrom");

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

    window.appMeta.addMeta('bandomistrutturefrom', new meta_bandomistrutturefrom('bandomistrutturefrom'));

	}());