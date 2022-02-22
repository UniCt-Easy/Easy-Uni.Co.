
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

    function meta_rendicontaltro() {
        MetaData.apply(this, ["rendicontaltro"]);
        this.name = 'meta_rendicontaltro';
    }

    meta_rendicontaltro.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontaltro,
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
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ore', 'Ore', 'fixed.2', 50, null);
						this.describeAColumn(table, '!idrendicontaltrokind_rendicontaltrokind_title', 'Tipologia', null, 41, null);
						objCalcFieldConfig['!idrendicontaltrokind_rendicontaltrokind_title'] = { tableNameLookup:'rendicontaltrokind', columnNameLookup:'title', columnNamekey:'idrendicontaltrokind' };
//$objCalcFieldConfig_default$
						break;
					case 'doc':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ore', 'Ore', 'fixed.2', 50, null);
						this.describeAColumn(table, '!idrendicontaltrokind_rendicontaltrokind_title', 'Tipologia', null, 41, null);
						objCalcFieldConfig['!idrendicontaltrokind_rendicontaltrokind_title'] = { tableNameLookup:'rendicontaltrokind', columnNameLookup:'title', columnNamekey:'idrendicontaltrokind' };
//$objCalcFieldConfig_doc$
						break;
					case 'docente':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ore', 'Ore', 'fixed.2', 50, null);
						this.describeAColumn(table, '!idrendicontaltrokind_rendicontaltrokind_title', 'Tipologia', null, 41, null);
						objCalcFieldConfig['!idrendicontaltrokind_rendicontaltrokind_title'] = { tableNameLookup:'rendicontaltrokind', columnNameLookup:'title', columnNamekey:'idrendicontaltrokind' };
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
						table.columns["!title"].caption = "Descrizione";
//$innerSetCaptionConfig_default$
						break;
					case 'doc':
						table.columns["!title"].caption = "Descrizione";
						table.columns["aa"].caption = "Anno accademico della rendicontazione";
//$innerSetCaptionConfig_doc$
						break;
					case 'docente':
						table.columns["!title"].caption = "Descrizione";
						table.columns["aa"].caption = "Anno accademico della rendicontazione";
//$innerSetCaptionConfig_docente$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontaltro");

				//$getNewRowInside$

				dt.autoIncrement('idrendicontaltro', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('rendicontaltro', new meta_rendicontaltro('rendicontaltro'));

	}());
