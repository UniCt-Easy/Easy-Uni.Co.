
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

    function meta_progettobudget() {
        MetaData.apply(this, ["progettobudget"]);
        this.name = 'meta_progettobudget';
    }

    meta_progettobudget.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettobudget,
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
						this.describeAColumn(table, 'budget', 'Budget iniziale', 'fixed.2', 30, null);
						this.describeAColumn(table, '!budgetvariazione', 'Budget corrente', 'fixed.2', 40, null);
						this.describeAColumn(table, '!spese', 'Costi', 'fixed.2', 50, null);
						this.describeAColumn(table, '!ricaviincassati', 'Ricavi', 'fixed.2', 150, null);
						this.describeAColumn(table, '!idprogettotipocosto_progettotipocosto_title', 'Voce di costo', null, 21, null);
						objCalcFieldConfig['!idprogettotipocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto_alias2', columnNameLookup:'title', columnNamekey:'idprogettotipocosto' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 11, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 12, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage_alias2', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage_alias2', columnNameLookup:'title', columnNamekey:'idworkpackage' };
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
						table.columns["!budgetvariazione"].caption = "Budget attuale";
						table.columns["!ricaviincassati"].caption = "Ricavi incassati";
						table.columns["!ricavinonincassati"].caption = "Ricavi non incassati";
						table.columns["!spese"].caption = "Costi";
						table.columns["budget"].caption = "Budget iniziale";
						table.columns["idprogettotipocosto"].caption = "Voce di costo";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["sortcode"].caption = "Ordine di visualizzazione";
						table.columns["budget"].caption = "Budget disponibile iniziale";
						table.columns["!budgetvariazione"].caption = "Budget disponibile attuale";
						table.columns["!budgetvariazione"].caption = "Budget corrente";
						table.columns["!ricaviincassati"].caption = "Ricavi";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettobudget");

				//$getNewRowInside$

				dt.autoIncrement('idprogettobudget', { minimum: 99990001 });

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
						return "idworkpackage asc , sortcode asc , idprogettotipocosto asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettobudget', new meta_progettobudget('progettobudget'));

	}());
