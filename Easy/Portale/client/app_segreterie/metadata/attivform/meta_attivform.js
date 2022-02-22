
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

    function meta_attivform() {
        MetaData.apply(this, ["attivform"]);
        this.name = 'meta_attivform';
    }

    meta_attivform.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivform,
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
					case 'gruppo':
						this.describeAColumn(table, 'start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'tipovalutaz', 'Profitto o Idoneità', null, 100, null);
						this.describeAColumn(table, '!iddidproganno_didproganno_title', 'Anno di corso', null, 31, null);
						objCalcFieldConfig['!iddidproganno_didproganno_title'] = { tableNameLookup:'didproganno', columnNameLookup:'title', columnNamekey:'iddidproganno' };
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
						this.describeAColumn(table, '!iddidprogporzanno_didprogporzanno_title', 'Porzione d\'anno', null, 41, null);
						objCalcFieldConfig['!iddidprogporzanno_didprogporzanno_title'] = { tableNameLookup:'didprogporzanno', columnNameLookup:'title', columnNamekey:'iddidprogporzanno' };
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione Insegnamento', null, 61, null);
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice Insegnamento', null, 62, null);
						objCalcFieldConfig['!idinsegn_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idinsegn' };
						objCalcFieldConfig['!idinsegn_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idinsegn' };
						this.describeAColumn(table, '!idinsegninteg_insegninteg_denominazione', 'Denominazione Integrando', null, 71, null);
						this.describeAColumn(table, '!idinsegninteg_insegninteg_codice', 'Codice Integrando', null, 72, null);
						objCalcFieldConfig['!idinsegninteg_insegninteg_denominazione'] = { tableNameLookup:'insegninteg', columnNameLookup:'denominazione', columnNamekey:'idinsegninteg' };
						objCalcFieldConfig['!idinsegninteg_insegninteg_codice'] = { tableNameLookup:'insegninteg', columnNameLookup:'codice', columnNamekey:'idinsegninteg' };
//$objCalcFieldConfig_gruppo$
						break;
					case 'default':
						this.describeAColumn(table, 'start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'tipovalutaz', 'Profitto o Idoneità', null, 100, null);
						this.describeAColumn(table, '!iddidproganno_didproganno_title', 'Anno di corso', null, 31, null);
						objCalcFieldConfig['!iddidproganno_didproganno_title'] = { tableNameLookup:'didproganno', columnNameLookup:'title', columnNamekey:'iddidproganno' };
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidproggrupp_didproggrupp_title', 'Gruppo opzionale', null, 51, null);
						objCalcFieldConfig['!iddidproggrupp_didproggrupp_title'] = { tableNameLookup:'didproggrupp', columnNameLookup:'title', columnNamekey:'iddidproggrupp' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
						this.describeAColumn(table, '!iddidprogporzanno_didprogporzanno_title', 'Porzione d\'anno', null, 41, null);
						objCalcFieldConfig['!iddidprogporzanno_didprogporzanno_title'] = { tableNameLookup:'didprogporzanno', columnNameLookup:'title', columnNamekey:'iddidprogporzanno' };
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione Insegnamento', null, 61, null);
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice Insegnamento', null, 62, null);
						objCalcFieldConfig['!idinsegn_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idinsegn' };
						objCalcFieldConfig['!idinsegn_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idinsegn' };
						this.describeAColumn(table, '!idinsegninteg_insegninteg_denominazione', 'Denominazione Integrando', null, 71, null);
						this.describeAColumn(table, '!idinsegninteg_insegninteg_codice', 'Codice Integrando', null, 72, null);
						objCalcFieldConfig['!idinsegninteg_insegninteg_denominazione'] = { tableNameLookup:'insegninteg', columnNameLookup:'denominazione', columnNamekey:'idinsegninteg' };
						objCalcFieldConfig['!idinsegninteg_insegninteg_codice'] = { tableNameLookup:'insegninteg', columnNameLookup:'codice', columnNamekey:'idinsegninteg' };
						this.describeAColumn(table, '!canale', 'Canali', null, 140, null);
						this.describeAColumn(table, '!attivformcaratteristica', 'Caratteristiche dell\'attività formativa', null, 150, null);
//$objCalcFieldConfig_default$
						break;
					case 'appello':
						this.describeAColumn(table, 'tipovalutaz', 'Profitto o Idoneità', null, 180, null);
//$objCalcFieldConfig_appello$
						break;
					case 'proped':
						this.describeAColumn(table, 'start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'tipovalutaz', 'Profitto o Idoneità', null, 100, null);
//$objCalcFieldConfig_proped$
						break;
					case 'erogata':
						this.describeAColumn(table, 'start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'tipovalutaz', 'Profitto o Idoneità', null, 100, null);
						this.describeAColumn(table, '!iddidproganno_didproganno_title', 'Anno di corso', null, 31, null);
						objCalcFieldConfig['!iddidproganno_didproganno_title'] = { tableNameLookup:'didproganno', columnNameLookup:'title', columnNamekey:'iddidproganno' };
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidproggrupp_didproggrupp_title', 'Gruppo opzionale', null, 51, null);
						objCalcFieldConfig['!iddidproggrupp_didproggrupp_title'] = { tableNameLookup:'didproggrupp', columnNameLookup:'title', columnNamekey:'iddidproggrupp' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
						this.describeAColumn(table, '!iddidprogporzanno_didprogporzanno_title', 'Porzione d\'anno', null, 41, null);
						objCalcFieldConfig['!iddidprogporzanno_didprogporzanno_title'] = { tableNameLookup:'didprogporzanno', columnNameLookup:'title', columnNamekey:'iddidprogporzanno' };
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione Insegnamento', null, 61, null);
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice Insegnamento', null, 62, null);
						objCalcFieldConfig['!idinsegn_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idinsegn' };
						objCalcFieldConfig['!idinsegn_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idinsegn' };
						this.describeAColumn(table, '!idinsegninteg_insegninteg_denominazione', 'Denominazione Integrando', null, 71, null);
						this.describeAColumn(table, '!idinsegninteg_insegninteg_codice', 'Codice Integrando', null, 72, null);
						objCalcFieldConfig['!idinsegninteg_insegninteg_denominazione'] = { tableNameLookup:'insegninteg', columnNameLookup:'denominazione', columnNamekey:'idinsegninteg' };
						objCalcFieldConfig['!idinsegninteg_insegninteg_codice'] = { tableNameLookup:'insegninteg', columnNameLookup:'codice', columnNamekey:'idinsegninteg' };
						this.describeAColumn(table, '!attivformcaratteristica', 'Caratteristiche dell\'attività formativa', null, 150, null);
//$objCalcFieldConfig_erogata$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'erogata':
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidproganno"].caption = "Anno di corso";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidproggrupp"].caption = "Gruppo opzionale";
						table.columns["iddidprogori"].caption = "Orientamento";
						table.columns["iddidprogporzanno"].caption = "Porzione d'anno";
						table.columns["idinsegn"].caption = "Insegnamento";
						table.columns["idinsegninteg"].caption = "Integrando";
						table.columns["idsede"].caption = "Sede";
						table.columns["obbform"].caption = "Obiettivi formativi";
						table.columns["obbform_en"].caption = "Obiettivi formativi (ENG)";
						table.columns["sortcode"].caption = "Ordine";
						table.columns["start"].caption = "Dal";
						table.columns["stop"].caption = "Al";
						table.columns["tipovalutaz"].caption = "Profitto o Idoneità";
						table.columns["title"].caption = "Attività formativa";
//$innerSetCaptionConfig_erogata$
						break;
					case 'default':
						table.columns["idcorsostudio"].caption = "Corso di studi";
//$innerSetCaptionConfig_default$
						break;
					case 'gruppo':
						table.columns["idcorsostudio"].caption = "Corso di studi";
//$innerSetCaptionConfig_gruppo$
						break;
					case 'proped':
						table.columns["idcorsostudio"].caption = "Corso di studi";
//$innerSetCaptionConfig_proped$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_attivform");

				//$getNewRowInside$

				dt.autoIncrement('idattivform', { minimum: 99990001 });

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
					case "gruppo": {
						return "iddidprogcurr asc , title asc , iddidprogori asc , iddidproganno asc , iddidprogporzanno asc , iddidproggrupp asc , sortcode asc ";
					}
					case "default": {
						return "iddidprogcurr asc , title asc , iddidprogori asc , iddidproganno asc , iddidprogporzanno asc , iddidproggrupp asc , sortcode asc ";
					}
					case "appello": {
						return "title asc ";
					}
					case "proped": {
						return "iddidprogcurr asc , title asc , iddidprogori asc , iddidproganno asc , iddidprogporzanno asc , iddidproggrupp asc , sortcode asc ";
					}
					case "erogata": {
						return "iddidprogcurr asc , title asc , iddidprogori asc , iddidproganno asc , iddidprogporzanno asc , iddidproggrupp asc , sortcode asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('attivform', new meta_attivform('attivform'));

	}());
