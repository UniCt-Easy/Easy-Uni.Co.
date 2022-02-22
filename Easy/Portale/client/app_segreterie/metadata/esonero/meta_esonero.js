
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

    function meta_esonero() {
        MetaData.apply(this, ["esonero"]);
        this.name = 'meta_esonero';
    }

    meta_esonero.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonero,
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
					case 'carriera':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'soloconisee', 'Applicabile solo con ISEE', null, 90, null);
//$objCalcFieldConfig_carriera$
						break;
					case 'titolostudio':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'soloconisee', 'Applicabile solo con ISEE', null, 90, null);
//$objCalcFieldConfig_titolostudio$
						break;
					case 'disabil':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'soloconisee', 'Applicabile solo con ISEE', null, 90, null);
//$objCalcFieldConfig_disabil$
						break;
					case 'default':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'soloconisee', 'Applicabile solo con ISEE', null, 90, null);
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
					case 'titolostudio':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["applunavolta"].caption = "Applicabile una sola volta";
						table.columns["description"].caption = "Descrizione";
						table.columns["idcostoscontodef"].caption = "Sconto";
						table.columns["idesoneroanskind"].caption = "Codice ANS";
						table.columns["soloconisee"].caption = "Applicabile solo con ISEE";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_titolostudio$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_esonero");

				//$getNewRowInside$

				dt.autoIncrement('idesonero', { minimum: 99990001 });

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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonero', new meta_esonero('esonero'));

	}());
