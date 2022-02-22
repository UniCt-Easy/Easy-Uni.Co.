
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

    function meta_registry_docenti() {
        MetaData.apply(this, ["registry_docenti"]);
        this.name = 'meta_registry_docenti';
    }

    meta_registry_docenti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_docenti,
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
					case 'docenti_doc':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 10, 50);
//$objCalcFieldConfig_docenti_doc$
						break;
					case 'docenti':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 10, 50);
//$objCalcFieldConfig_docenti$
						break;
					case 'docenti_docente':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 10, 50);
//$objCalcFieldConfig_docenti_docente$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'docenti':
						table.columns["cv"].caption = "Curriculum Vitae";
						table.columns["idclassconsorsuale"].caption = "Classe consorsuale";
						table.columns["idcontrattokind"].caption = "Tipo";
						table.columns["idfonteindicebibliometrico"].caption = "Fonte";
						table.columns["idreg"].caption = "Codice Istituto";
						table.columns["idreg_istituti"].caption = "Istituto, Ente o Azienda";
						table.columns["idsasd"].caption = "SASD";
						table.columns["idstruttura"].caption = "Struttura di afferenza";
						table.columns["indicebibliometrico"].caption = "Indice bibliometrico (H-Index)";
						table.columns["matricola"].caption = "Matricola";
						table.columns["ricevimento"].caption = "Orari di ricevimento";
						table.columns["soggiorno"].caption = "Permesso di soggiorno";
//$innerSetCaptionConfig_docenti$
						break;
					case 'docenti_docente':
						table.columns["cv"].caption = "Curriculum Vitae";
//$innerSetCaptionConfig_docenti_docente$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_docenti");

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

			getSorting: function (listType) {
				switch (listType) {
					case "docenti_doc": {
						return "title asc ";
					}
					case "docenti": {
						return "title asc ";
					}
					case "docenti_docente": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_docenti', new meta_registry_docenti('registry_docenti'));

	}());
