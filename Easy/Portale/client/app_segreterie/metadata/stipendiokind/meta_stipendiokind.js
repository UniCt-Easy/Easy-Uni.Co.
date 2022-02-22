
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

    function meta_stipendiokind() {
        MetaData.apply(this, ["stipendiokind"]);
        this.name = 'meta_stipendiokind';
    }

    meta_stipendiokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_stipendiokind,
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
						this.describeAColumn(table, 'scatto', 'Scatto', null, 30, null);
						this.describeAColumn(table, 'tempdef', 'Tempo definito', null, 40, null);
						this.describeAColumn(table, 'assegnoaggiuntivo', 'Assegno aggiuntivo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'indennitadiateneo', 'Indennità di ateneo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'indennitadiposizione', 'Indennità di posizione', 'fixed.2', 70, null);
						this.describeAColumn(table, 'indintegrativaspeciale', 'Indennità integrativa speciale', 'fixed.2', 80, null);
						this.describeAColumn(table, 'indvacancacontrattuale', 'Indennità vacanca contrattuale', 'fixed.2', 90, null);
						this.describeAColumn(table, 'irap', 'IRAP', 'fixed.2', 100, null);
						this.describeAColumn(table, 'oneriprevidenzialicaricoente', 'Oneri previdenziali a carico dell\'ente', 'fixed.2', 110, null);
						this.describeAColumn(table, 'retribuzione', 'Retribuzione', 'fixed.2', 120, null);
						this.describeAColumn(table, 'elementoperequativo', 'Elemento perequativo', 'fixed.2', 130, null);
						this.describeAColumn(table, 'totaletredicesima', 'Totale tredicesima', 'fixed.2', 150, null);
						this.describeAColumn(table, 'tredicesimaindennitaintegrativaspeciale', 'Tredicesima indennità integrativa speciale', 'fixed.2', 160, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_stipendiokind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idstipendiokind', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "idcontrattokind asc , idinquadramento asc , scatto asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('stipendiokind', new meta_stipendiokind('stipendiokind'));

	}());
