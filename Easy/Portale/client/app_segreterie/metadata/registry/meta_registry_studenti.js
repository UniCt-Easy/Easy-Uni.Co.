
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

    function meta_registry_studenti() {
        MetaData.apply(this, ["registry_studenti"]);
        this.name = 'meta_registry_studenti';
    }

    meta_registry_studenti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_studenti,
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
					case 'studenti':
						this.describeAColumn(table, 'authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 300, null);
//$objCalcFieldConfig_studenti$
						break;
					case 'seg':
						this.describeAColumn(table, 'authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 300, null);
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
					case 'studenti':
						table.columns["authinps"].caption = "Autorizzazione all'istituto di accedere ai propri dati INPS";
						table.columns["idreg"].caption = "Codice Istituto";
						table.columns["idstuddirittokind"].caption = "Tipologia per il diritto allo studio";
						table.columns["idstudprenotkind"].caption = "Tipologia per la prenotazione degli appelli";
//$innerSetCaptionConfig_studenti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_studenti");

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
					case "studenti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_studenti', new meta_registry_studenti('registry_studenti'));

	}());
