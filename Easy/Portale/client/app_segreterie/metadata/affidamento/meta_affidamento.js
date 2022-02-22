
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

    function meta_affidamento() {
        MetaData.apply(this, ["affidamento"]);
        this.name = 'meta_affidamento';
    }

    meta_affidamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamento,
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
						this.describeAColumn(table, 'riferimento', 'Docente di riferimento per il canale', null, 30, null);
						this.describeAColumn(table, 'freqobbl', 'Frequenza obbligatoria', null, 50, null);
						this.describeAColumn(table, 'gratuito', 'Gratuito', null, 60, null);
						this.describeAColumn(table, 'start', 'Inizio', null, 70, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 80, null);
						this.describeAColumn(table, '!idaffidamentokind_affidamentokind_title', 'Tipologia', null, 21, null);
						objCalcFieldConfig['!idaffidamentokind_affidamentokind_title'] = { tableNameLookup:'affidamentokind', columnNameLookup:'title', columnNamekey:'idaffidamentokind' };
						this.describeAColumn(table, '!iderogazkind_erogazkind_title', 'Tipo di erogazione', null, 41, null);
						objCalcFieldConfig['!iderogazkind_erogazkind_title'] = { tableNameLookup:'erogazkind', columnNameLookup:'title', columnNamekey:'iderogazkind' };
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Docente', null, 11, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!affidamentocaratteristica', 'Caratteristiche dell\'affidamento', null, 90, null);
						this.describeAColumn(table, '!idreg_docenti_registry_title', 'Docente', null, 11, null);
						objCalcFieldConfig['!idreg_docenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
//$objCalcFieldConfig_default$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'jsonancestor', 'Didattica', null, 10, -1);
						this.describeAColumn(table, 'riferimento', 'Docente di riferimento per il canale', null, 30, null);
						this.describeAColumn(table, 'freqobbl', 'Frequenza obbligatoria', null, 50, null);
						this.describeAColumn(table, 'gratuito', 'Gratuito', null, 60, null);
						this.describeAColumn(table, 'start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 160, null);
						this.describeAColumn(table, '!idaffidamentokind_affidamentokind_title', 'Tipologia', null, 21, null);
						objCalcFieldConfig['!idaffidamentokind_affidamentokind_title'] = { tableNameLookup:'affidamentokind', columnNameLookup:'title', columnNamekey:'idaffidamentokind' };
						this.describeAColumn(table, '!iderogazkind_erogazkind_title', 'Tipo di erogazione', null, 41, null);
						objCalcFieldConfig['!iderogazkind_erogazkind_title'] = { tableNameLookup:'erogazkind', columnNameLookup:'title', columnNamekey:'iderogazkind' };
						this.describeAColumn(table, '!affidamentocaratteristica', 'Caratteristiche dell\'affidamento', null, 200, null);
//$objCalcFieldConfig_seg$
						break;
					case 'doc':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'jsonancestor', 'Didattica', null, 10, -1);
						this.describeAColumn(table, 'riferimento', 'Docente di riferimento per il canale', null, 30, null);
						this.describeAColumn(table, 'freqobbl', 'Frequenza obbligatoria', null, 50, null);
						this.describeAColumn(table, 'gratuito', 'Gratuito', null, 60, null);
						this.describeAColumn(table, 'start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 160, null);
//$objCalcFieldConfig_doc$
						break;
					case 'docente':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'jsonancestor', 'Didattica', null, 10, -1);
						this.describeAColumn(table, 'riferimento', 'Docente di riferimento per il canale', null, 30, null);
						this.describeAColumn(table, 'freqobbl', 'Frequenza obbligatoria', null, 50, null);
						this.describeAColumn(table, 'gratuito', 'Gratuito', null, 60, null);
						this.describeAColumn(table, 'start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 160, null);
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
					case 'default':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["freqobbl"].caption = "Frequenza obbligatoria";
						table.columns["frequenzaminima"].caption = "Frequenza minima (%)";
						table.columns["frequenzaminimadebito"].caption = "Frequenza minima con debito (%)";
						table.columns["idaffidamento"].caption = "Codice";
						table.columns["idaffidamentokind"].caption = "Tipologia";
						table.columns["idcanale"].caption = "Canale";
						table.columns["iderogazkind"].caption = "Tipo di erogazione";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idsede"].caption = "Sede";
						table.columns["json"].caption = "Affidamento";
						table.columns["jsonancestor"].caption = "Didattica";
						table.columns["orariric"].caption = "Orari di ricevimento";
						table.columns["orariric_en"].caption = "Oriari di ricevimento (EN)";
						table.columns["prog"].caption = "Programma";
						table.columns["prog_en"].caption = "Programma (EN)";
						table.columns["riferimento"].caption = "Docente di riferimento per il canale";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["testi_en"].caption = "Testi (EN)";
						table.columns["title"].caption = "Denominazione";
						table.columns["urlcorso"].caption = "Indirizzo web del corso";
//$innerSetCaptionConfig_default$
						break;
					case 'seg':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seg$
						break;
					case 'docente':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_docente$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_affidamento");

				//$getNewRowInside$

				dt.autoIncrement('idaffidamento', { minimum: 99990001 });

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
						return "riferimento asc ";
					}
					case "doc": {
						return "riferimento asc ";
					}
					case "default": {
						return "riferimento asc ";
					}
					case "docente": {
						return "riferimento asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamento', new meta_affidamento('affidamento'));

	}());
