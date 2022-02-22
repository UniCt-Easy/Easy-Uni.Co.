
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

    function meta_perfprogettocosto() {
        MetaData.apply(this, ["perfprogettocosto"]);
        this.name = 'meta_perfprogettocosto';
    }

    meta_perfprogettocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocosto,
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
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'budget', 'Budget preventivato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'budgetcurr', 'Budget attuale', 'fixed.2', 50, null);
						this.describeAColumn(table, 'consuntivo', 'Consuntivo', 'fixed.2', 60, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice Voce di costo', null, 21, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Denominazione Voce di costo', null, 22, null);
						objCalcFieldConfig['!idaccmotive_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						this.describeAColumn(table, '!idupb_upb_title', 'UPB', null, 31, null);
						objCalcFieldConfig['!idupb_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idupb' };
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
               var def = appMeta.Deferred("getNewRow-meta_perfprogettocosto");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettocosto', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettocosto', new meta_perfprogettocosto('perfprogettocosto'));

	}());
