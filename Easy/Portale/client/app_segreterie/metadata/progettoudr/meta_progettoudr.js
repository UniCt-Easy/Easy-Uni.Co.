
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

    function meta_progettoudr() {
        MetaData.apply(this, ["progettoudr"]);
        this.name = 'meta_progettoudr';
    }

    meta_progettoudr.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoudr,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2048);
						this.describeAColumn(table, 'contributo', 'Contributo richiesto ', 'fixed.2', 70, null);
						this.describeAColumn(table, 'impegnototale', 'Impegno temporale complessivo preventivato in mesi/uomo', 'fixed.2', 80, null);
						this.describeAColumn(table, 'budget', 'Costo complessivo preventivato in mesi/uomo', 'fixed.2', 200, null);
						this.describeAColumn(table, 'impegnototaleore', 'Impegno temporale complessivo preventivato in ore/uomo', null, 210, null);
						this.describeAColumn(table, '!budgetore', 'Costo complessivo preventivato in ore/uomo', 'fixed.2', 220, null);
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
					case 'seg':
						table.columns["budget"].caption = "Costo complessivo calcolato per mesi/uomo";
						table.columns["!budgetore"].caption = "Costo complessivo calcolato per ore/uomo";
						table.columns["budget"].caption = "Costo complessivo preventivato in mesi/uomo";
						table.columns["!budgetore"].caption = "Costo complessivo preventivato in ore/uomo";
						table.columns["assegniricerca"].caption = "Numero assegni di ricerca previsti";
						table.columns["borsedottorati"].caption = "Numero borse di dottorato previste";
						table.columns["contrattirtd"].caption = "Numero contratti RTD previsti";
						table.columns["contributo"].caption = "Contributo richiesto ";
						table.columns["description"].caption = "Descrizione";
						table.columns["impegnototale"].caption = "Impegno temporale complessivo preventivato in mesi/uomo";
						table.columns["impegnototaleore"].caption = "Impegno temporale complessivo preventivato in ore/uomo";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoudr");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoudr', { minimum: 99990001 });

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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettoudr', new meta_progettoudr('progettoudr'));

	}());
