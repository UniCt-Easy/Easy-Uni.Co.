
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_esonero_carriera() {
        MetaData.apply(this, ["esonero_carriera"]);
        this.name = 'meta_esonero_carriera';
    }

    meta_esonero_carriera.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonero_carriera,
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
						this.describeAColumn(table, 'annofcmax', 'Anno fuori corso massimo', null, 10, null);
						this.describeAColumn(table, 'annofcmin', 'Anno fuori corso minimo', null, 20, null);
						this.describeAColumn(table, 'annoiscrmax', 'Anno iscrizione massimo', null, 30, null);
						this.describeAColumn(table, 'annoiscrmin', 'Anno iscrizione minimo', null, 40, null);
						this.describeAColumn(table, 'cfaaprecmax', 'Crediti massimi anno precedente', 'fixed.2', 50, null);
						this.describeAColumn(table, 'cfaaprecmin', 'Crediti minimi anno precedente', 'fixed.2', 60, null);
						this.describeAColumn(table, 'parttime', 'Part-time', null, 80, null);
						this.describeAColumn(table, 'tutticfaaprec', 'Conseguiti tutti i crediti dell\'anno precedente', null, 90, null);
//$objCalcFieldConfig_carriera$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_esonero_carriera");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


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
					case "carriera": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonero_carriera', new meta_esonero_carriera('esonero_carriera'));

	}());