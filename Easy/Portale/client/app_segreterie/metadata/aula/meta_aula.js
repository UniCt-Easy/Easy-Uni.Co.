
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

    function meta_aula() {
        MetaData.apply(this, ["aula"]);
        this.name = 'meta_aula';
    }

    meta_aula.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_aula,
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
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'code', 'Codice', null, 20, 128);
						this.describeAColumn(table, 'capienza', 'Capienza', null, 50, null);
						this.describeAColumn(table, 'capienzadis', 'Capienza disabili', null, 60, null);
						this.describeAColumn(table, '!idaulakind_aulakind_title', 'Tipologia', null, 71, null);
						objCalcFieldConfig['!idaulakind_aulakind_title'] = { tableNameLookup:'aulakind', columnNameLookup:'title', columnNamekey:'idaulakind' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura didattica di afferenza', null, 41, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Struttura didattica di afferenza', null, 41, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_seg_child$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'code', 'Codice', null, 20, 128);
						this.describeAColumn(table, 'capienza', 'Capienza', null, 50, null);
						this.describeAColumn(table, 'capienzadis', 'Capienza disabili', null, 60, null);
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
						table.columns["address"].caption = "Indirizzo";
						table.columns["cap"].caption = "CAP";
						table.columns["capienzadis"].caption = "Capienza disabili";
						table.columns["code"].caption = "Codice";
						table.columns["idaulakind"].caption = "Tipologia";
						table.columns["idcity"].caption = "Città";
						table.columns["idedificio"].caption = "Edificio";
						table.columns["idnation"].caption = "Nazione";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstruttura"].caption = "Struttura didattica di afferenza";
						table.columns["latitude"].caption = "latitudine";
						table.columns["location"].caption = "Località";
						table.columns["longitude"].caption = "Longitudine";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
					case 'seg_child':
						table.columns["address"].caption = "Indirizzo";
//$innerSetCaptionConfig_seg_child$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_aula");

				//$getNewRowInside$

				dt.autoIncrement('idaula', { minimum: 99990001 });

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
					case "seg_child": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('aula', new meta_aula('aula'));

	}());
