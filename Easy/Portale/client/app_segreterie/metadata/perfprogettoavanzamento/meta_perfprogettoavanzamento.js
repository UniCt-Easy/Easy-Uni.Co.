
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

    function meta_perfprogettoavanzamento() {
        MetaData.apply(this, ["perfprogettoavanzamento"]);
        this.name = 'meta_perfprogettoavanzamento';
    }

    meta_perfprogettoavanzamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoavanzamento,
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
						this.describeAColumn(table, 'avanzamento', 'Percentuale di avanzamento degli obiettivi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'data', 'Data', null, 30, null);
						this.describeAColumn(table, '!idreg_amministrativi_registry_amministrativi_surname', 'Cognome Iniziato da', null, 52, null);
						this.describeAColumn(table, '!idreg_amministrativi_registry_amministrativi_forename', 'Nome Iniziato da', null, 53, null);
						this.describeAColumn(table, '!idreg_amministrativi_registry_amministrativi_cf', 'Codice fiscale Iniziato da', null, 54, null);
						this.describeAColumn(table, '!idreg_amministrativi_registry_amministrativi_idreg_amministrativi_description', 'Descrizione Iniziato da', null, 52, null);
						objCalcFieldConfig['!idreg_amministrativi_registry_amministrativi_surname'] = { tableNameLookup:'registry', columnNameLookup:'surname', columnNamekey:'idreg_amministrativi' };
						objCalcFieldConfig['!idreg_amministrativi_registry_amministrativi_forename'] = { tableNameLookup:'registry', columnNameLookup:'forename', columnNamekey:'idreg_amministrativi' };
						objCalcFieldConfig['!idreg_amministrativi_registry_amministrativi_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_amministrativi' };
						objCalcFieldConfig['!idreg_amministrativi_registry_amministrativi_idreg_amministrativi_description'] = { tableNameLookup:'title', columnNameLookup:'description', columnNamekey:'idreg_amministrativi' };
						this.describeAColumn(table, '!idreg_amministrativi_ver_registry_amministrativi_surname', 'Cognome Verificato da', null, 62, null);
						this.describeAColumn(table, '!idreg_amministrativi_ver_registry_amministrativi_forename', 'Nome Verificato da', null, 63, null);
						this.describeAColumn(table, '!idreg_amministrativi_ver_registry_amministrativi_cf', 'Codice fiscale Verificato da', null, 64, null);
						this.describeAColumn(table, '!idreg_amministrativi_ver_registry_amministrativi_idreg_amministrativi_ver_description', 'Descrizione Verificato da', null, 62, null);
						objCalcFieldConfig['!idreg_amministrativi_ver_registry_amministrativi_surname'] = { tableNameLookup:'registry_alias2', columnNameLookup:'surname', columnNamekey:'idreg_amministrativi_ver' };
						objCalcFieldConfig['!idreg_amministrativi_ver_registry_amministrativi_forename'] = { tableNameLookup:'registry_alias2', columnNameLookup:'forename', columnNamekey:'idreg_amministrativi_ver' };
						objCalcFieldConfig['!idreg_amministrativi_ver_registry_amministrativi_cf'] = { tableNameLookup:'registry_alias2', columnNameLookup:'cf', columnNamekey:'idreg_amministrativi_ver' };
						objCalcFieldConfig['!idreg_amministrativi_ver_registry_amministrativi_idreg_amministrativi_ver_description'] = { tableNameLookup:'title', columnNameLookup:'description', columnNamekey:'idreg_amministrativi_ver' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["avanzamento"].caption = "Percentuale di avanzamento degli obiettivi";
						table.columns["data"].caption = "Data";
						table.columns["idreg_amministrativi"].caption = "Iniziato da";
						table.columns["idreg_amministrativi_ver"].caption = "Verificato da";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoavanzamento");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoavanzamento', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfprogettoavanzamento', new meta_perfprogettoavanzamento('perfprogettoavanzamento'));

	}());