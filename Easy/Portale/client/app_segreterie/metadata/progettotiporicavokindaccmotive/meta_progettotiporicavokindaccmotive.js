
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

    function meta_progettotiporicavokindaccmotive() {
        MetaData.apply(this, ["progettotiporicavokindaccmotive"]);
        this.name = 'meta_progettotiporicavokindaccmotive';
    }

    meta_progettotiporicavokindaccmotive.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotiporicavokindaccmotive,
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
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice', null, 12, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Denominazione', null, 14, null);
						objCalcFieldConfig['!idaccmotive_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Causale', null, 13, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice', null, 16, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_alias1_title', 'Causale', null, 13, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_alias1_codemotive', 'Codice', null, 16, null);
						objCalcFieldConfig['!idaccmotive_accmotive_alias1_title'] = { tableNameLookup:'accmotive_alias1', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_alias1_codemotive'] = { tableNameLookup:'accmotive_alias1', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
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
						table.columns["idaccmotive"].caption = "Causale economico patrimoniale";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotiporicavokindaccmotive");

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
					case "default": {
						return "idaccmotive asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('progettotiporicavokindaccmotive', new meta_progettotiporicavokindaccmotive('progettotiporicavokindaccmotive'));

	}());
