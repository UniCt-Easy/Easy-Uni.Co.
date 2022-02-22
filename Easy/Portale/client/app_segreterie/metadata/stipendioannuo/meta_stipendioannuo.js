
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

    function meta_stipendioannuo() {
        MetaData.apply(this, ["stipendioannuo"]);
        this.name = 'meta_stipendioannuo';
    }

    meta_stipendioannuo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_stipendioannuo,
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
						this.describeAColumn(table, 'lordo', 'Retribuzione totale lorda', 'fixed.2', 10, null);
						this.describeAColumn(table, 'caricoente', 'Totale a carico ente', 'fixed.2', 20, null);
						this.describeAColumn(table, 'irap', 'IRAP', 'fixed.2', 30, null);
						this.describeAColumn(table, 'totale', 'Totale costo annuo', 'fixed.2', 40, null);
						this.describeAColumn(table, 'year', 'Anno', null, 50, null);
//$objCalcFieldConfig_default$
						break;
					case 'prev':
						this.describeAColumn(table, 'lordo', 'Retribuzione totale lorda', 'fixed.2', 30, null);
						this.describeAColumn(table, 'caricoente', 'Totale a carico ente', 'fixed.2', 40, null);
						this.describeAColumn(table, 'irap', 'IRAP', 'fixed.2', 50, null);
						this.describeAColumn(table, 'totale', 'Totale costo annuo', 'fixed.2', 60, null);
						this.describeAColumn(table, '!idcontratto_contratto_percentualesufondiateneo', 'Percentuale su fondi interni Contratto', 'fixed.2', 22, null);
						this.describeAColumn(table, '!idcontratto_contratto_start', 'Inizio Contratto', null, 24, null);
						this.describeAColumn(table, '!idcontratto_contratto_stop', 'Fine Contratto', null, 25, null);
						this.describeAColumn(table, '!idcontratto_contratto_parttime', 'Part-time % Contratto', 'fixed.2', 26, null);
						this.describeAColumn(table, '!idcontratto_contratto_idcontrattokind_title', 'Tipologia Contratto', null, 21, null);
						this.describeAColumn(table, '!idcontratto_contratto_idinquadramento_title', 'Denominazione Contratto', null, 21, null);
						this.describeAColumn(table, '!idcontratto_contratto_idinquadramento_tempdef', 'Tempo definito Contratto', null, 22, null);
						objCalcFieldConfig['!idcontratto_contratto_percentualesufondiateneo'] = { tableNameLookup:'contratto', columnNameLookup:'percentualesufondiateneo', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_start'] = { tableNameLookup:'contratto', columnNameLookup:'start', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_stop'] = { tableNameLookup:'contratto', columnNameLookup:'stop', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_parttime'] = { tableNameLookup:'contratto', columnNameLookup:'parttime', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_idcontrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_idinquadramento_title'] = { tableNameLookup:'inquadramento', columnNameLookup:'title', columnNamekey:'idcontratto' };
						objCalcFieldConfig['!idcontratto_contratto_idinquadramento_tempdef'] = { tableNameLookup:'inquadramento', columnNameLookup:'tempdef', columnNamekey:'idcontratto' };
						this.describeAColumn(table, '!idreg_registry_extmatricula', 'Matricola Dipendente', null, 11, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Cognome Nome Dipendente', null, 12, null);
						this.describeAColumn(table, '!idreg_registry_cf', 'Codice fiscale Dipendente', null, 13, null);
						this.describeAColumn(table, '!idreg_registry_p_iva', 'Partita iva Dipendente', null, 14, null);
						objCalcFieldConfig['!idreg_registry_extmatricula'] = { tableNameLookup:'registry', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg' };
//$objCalcFieldConfig_prev$
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
						table.columns["caricoente"].caption = "Totale a carico ente";
						table.columns["idcontratto"].caption = "Contratto";
						table.columns["idreg"].caption = "Dipendente";
						table.columns["irap"].caption = "IRAP";
						table.columns["lordo"].caption = "Retribuzione totale lorda";
						table.columns["totale"].caption = "Totale costo annuo";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_default$
						break;
					case 'prev':
						table.columns["caricoente"].caption = "Totale a carico ente";
						table.columns["idcontratto"].caption = "Contratto";
						table.columns["idreg"].caption = "Dipendente";
						table.columns["irap"].caption = "IRAP";
						table.columns["lordo"].caption = "Retribuzione totale lorda";
						table.columns["totale"].caption = "Totale costo annuo";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_prev$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_stipendioannuo");

				//$getNewRowInside$

				dt.autoIncrement('idstipendioannuo', { minimum: 99990001 });

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
						return "year asc ";
					}
					case "prev": {
						return "year asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('stipendioannuo', new meta_stipendioannuo('stipendioannuo'));

	}());
