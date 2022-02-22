
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

    function meta_corsostudio() {
        MetaData.apply(this, ["corsostudio"]);
        this.name = 'meta_corsostudio';
    }

    meta_corsostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudio,
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
					case 'stato':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'title_en', 'Denominazione (EN)', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_stato$
						break;
					case 'dotmas':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'title_en', 'Denominazione (EN)', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_dotmas$
						break;
					case 'ingresso':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'title_en', 'Denominazione (EN)', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_ingresso$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'title_en', 'Denominazione (EN)', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'codicemiur', 'Codice MIUR', null, 40, 10);
						this.describeAColumn(table, 'codicemiurlungo', 'Codice MIUR lungo', null, 50, 50);
						this.describeAColumn(table, 'annoistituz', 'Anno accademico di istituzione', null, 60, null);
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
						table.columns["almalaureasurvey"].caption = "Questionario Almalaurea";
						table.columns["annoistituz"].caption = "Anno accademico di istituzione";
						table.columns["basevoto"].caption = "Base del voto di conseguimento";
						table.columns["codicemiur"].caption = "Codice MIUR";
						table.columns["codicemiurlungo"].caption = "Codice MIUR lungo";
						table.columns["idcorsostudiokind"].caption = "Tipologia";
						table.columns["idcorsostudiolivello"].caption = "Livello";
						table.columns["idcorsostudionorma"].caption = "Normativa di riferimento";
						table.columns["idduratakind"].caption = "Tipologia della durata";
						table.columns["idstruttura"].caption = "Struttura di riferimento";
						table.columns["obbform"].caption = "Obiettivi formativi";
						table.columns["sboccocc"].caption = "Sbocchi occupazionali";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (EN)";
//$innerSetCaptionConfig_default$
						break;
					case 'stato':
						table.columns["almalaureasurvey"].caption = "Questionario Almalaurea";
//$innerSetCaptionConfig_stato$
						break;
					case 'dotmas':
						table.columns["almalaureasurvey"].caption = "Questionario Almalaurea";
//$innerSetCaptionConfig_dotmas$
						break;
					case 'ingresso':
						table.columns["almalaureasurvey"].caption = "Questionario Almalaurea";
//$innerSetCaptionConfig_ingresso$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_corsostudio");

				//$getNewRowInside$

				dt.autoIncrement('idcorsostudio', { minimum: 99990001 });

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
					case "stato": {
						return "title asc ";
					}
					case "dotmas": {
						return "title asc ";
					}
					case "ingresso": {
						return "title asc ";
					}
					case "default": {
						return "title asc , annoistituz asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('corsostudio', new meta_corsostudio('corsostudio'));

	}());
