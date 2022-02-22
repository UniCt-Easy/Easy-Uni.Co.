
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

    function meta_rendicontattivitaprogetto() {
        MetaData.apply(this, ["rendicontattivitaprogetto"]);
        this.name = 'meta_rendicontattivitaprogetto';
    }

    meta_rendicontattivitaprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogetto,
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
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_doc$
						break;
					case 'anagamm':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Progetto', null, 11, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto_alias1', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 21, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 22, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'title', columnNamekey:'idworkpackage' };
//$objCalcFieldConfig_anagamm$
						break;
					case 'anag':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Progetto', null, 11, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 21, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 22, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'title', columnNamekey:'idworkpackage' };
//$objCalcFieldConfig_anag$
						break;
					case 'seg':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Partecipante', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_seg$
						break;
					case 'docente':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_docente$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'doc':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_doc$
						break;
					case 'anagamm':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iditineration"].caption = "Missione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Partecipante";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Numero di ore preventivate";
						table.columns["stop"].caption = "Data fine prevista";
//$innerSetCaptionConfig_anagamm$
						break;
					case 'anag':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_anag$
						break;
					case 'seg':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iditineration"].caption = "Missione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Partecipante";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Numero di ore preventivate";
						table.columns["stop"].caption = "Data fine prevista";
//$innerSetCaptionConfig_seg$
						break;
					case 'docente':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_docente$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontattivitaprogetto");

				//$getNewRowInside$

				dt.autoIncrement('idrendicontattivitaprogetto', { minimum: 99990001 });

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
					case "doc": {
						return "datainizioprevista asc ";
					}
					case "anagamm": {
						return "datainizioprevista asc ";
					}
					case "anag": {
						return "datainizioprevista asc ";
					}
					case "seg": {
						return "datainizioprevista asc ";
					}
					case "docente": {
						return "datainizioprevista asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogetto', new meta_rendicontattivitaprogetto('rendicontattivitaprogetto'));

	}());
