
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

    function meta_canale() {
        MetaData.apply(this, ["canale"]);
        this.name = 'meta_canale';
    }

    meta_canale.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_canale,
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
					case 'erogata':
						this.describeAColumn(table, 'title', 'Denominazione', null, 60, 256);
						this.describeAColumn(table, 'CUIN', 'CUIN', null, 70, 9);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa', null, 51, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias2', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!iddidproganno_didproganno_title', 'Anno', null, 31, null);
						objCalcFieldConfig['!iddidproganno_didproganno_title'] = { tableNameLookup:'didproganno_alias1', columnNameLookup:'title', columnNamekey:'iddidproganno' };
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr_alias1', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori_alias1', columnNameLookup:'title', columnNamekey:'iddidprogori' };
						this.describeAColumn(table, '!iddidprogporzanno_didprogporzanno_title', 'Porzione d\'anno', null, 41, null);
						objCalcFieldConfig['!iddidprogporzanno_didprogporzanno_title'] = { tableNameLookup:'didprogporzanno_alias1', columnNameLookup:'title', columnNamekey:'iddidprogporzanno' };
						this.describeAColumn(table, '!mutuazione', 'Mutuazione o fruizione', null, 160, null);
						this.describeAColumn(table, '!affidamento', 'Affidamento', null, 150, null);
//$objCalcFieldConfig_erogata$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'CUIN', 'CUIN', null, 30, 9);
						this.describeAColumn(table, 'sortcode', 'Posizione', null, 60, null);
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
						table.columns["idattivform"].caption = "Attività formativa";
						table.columns["idcanale"].caption = "Canale";
						table.columns["iddidproganno"].caption = "Anno";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidprogori"].caption = "Orientamento";
						table.columns["iddidprogporzanno"].caption = "Porzione d'anno";
						table.columns["numerostud"].caption = "Numero di studenti";
						table.columns["sortcode"].caption = "Posizione";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
					case 'erogata':
						table.columns["idattivform"].caption = "Attività formativa";
//$innerSetCaptionConfig_erogata$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_canale");

				//$getNewRowInside$

				dt.autoIncrement('idcanale', { minimum: 99990001 });

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
					case "erogata": {
						return "iddidprogcurr asc , iddidprogori asc , iddidproganno asc , iddidprogporzanno asc , idattivform asc , sortcode asc ";
					}
					case "default": {
						return "sortcode";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('canale', new meta_canale('canale'));

	}());
