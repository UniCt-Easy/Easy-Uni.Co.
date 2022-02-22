
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

    function meta_registry_aziende() {
        MetaData.apply(this, ["registry_aziende"]);
        this.name = 'meta_registry_aziende';
    }

    meta_registry_aziende.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_aziende,
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
					case 'aziende':
						this.describeAColumn(table, 'pic', 'Participant Identification Code (PIC)', null, 120, 10);
//$objCalcFieldConfig_aziende$
						break;
					case 'aziende_ro':
						this.describeAColumn(table, 'pic', 'Participant Identification Code (PIC)', null, 120, 10);
//$objCalcFieldConfig_aziende_ro$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'aziende_ro':
						table.columns["idateco"].caption = "Classificazione Ateco";
						table.columns["idnace"].caption = "NACE";
						table.columns["idnaturagiur"].caption = "Natura Giuridica";
						table.columns["idnumerodip"].caption = "Numero di dipendenti";
						table.columns["idreg"].caption = "Codice";
						table.columns["pic"].caption = "Participant Identification Code (PIC)";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_aziende_ro$
						break;
					case 'aziende':
						table.columns["idateco"].caption = "Classificazione Ateco";
//$innerSetCaptionConfig_aziende$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_aziende");

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
					case "aziende": {
						return "title asc ";
					}
					case "aziende_ro": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_aziende', new meta_registry_aziende('registry_aziende'));

	}());
