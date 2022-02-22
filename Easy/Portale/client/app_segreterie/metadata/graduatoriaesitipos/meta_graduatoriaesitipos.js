
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

    function meta_graduatoriaesitipos() {
        MetaData.apply(this, ["graduatoriaesitipos"]);
        this.name = 'meta_graduatoriaesitipos';
    }

    meta_graduatoriaesitipos.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_graduatoriaesitipos,
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
						this.describeAColumn(table, 'pos', 'Posizione', null, 60, null);
						this.describeAColumn(table, 'punteggio', 'Punteggio', 'fixed.2', 70, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_idreg_studenti_title', 'Studente', null, 41, null);
						objCalcFieldConfig['!idreg_studenti_registry_studenti_idreg_studenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_title', 'Studente', null, 41, null);
						objCalcFieldConfig['!idreg_studenti_registry_studenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
//$objCalcFieldConfig_seg$
						break;
					case 'stato':
						this.describeAColumn(table, 'pos', 'Posizione', null, 70, null);
						this.describeAColumn(table, 'punteggio', 'Punteggio', 'fixed.2', 80, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_idreg_studenti_title', 'Studente', null, 51, null);
						objCalcFieldConfig['!idreg_studenti_registry_studenti_idreg_studenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
//$objCalcFieldConfig_stato$
						break;
					case 'default':
						this.describeAColumn(table, 'pos', 'Posizione', null, 70, null);
						this.describeAColumn(table, 'punteggio', 'Punteggio', 'fixed.2', 80, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_idreg_studenti_title', 'Studente', null, 51, null);
						objCalcFieldConfig['!idreg_studenti_registry_studenti_idreg_studenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
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
               var def = appMeta.Deferred("getNewRow-meta_graduatoriaesitipos");

				var realParentObjectRow = parentRow;
					if (editType === "seg") {
					var realParentTableName = "graduatoriaesiti";
					var realParentTable = dt.dataset.tables["graduatoriaesiti"];
					if (!realParentTable) {
						console.log("ERROR: la tabella " + realParentTableName + "  non esiste nel dataset");
						return def.resolve(null);
					}
					if (!realParentTable.rows.length) {
						console.log("ERROR: la tabella " + realParentTableName + "  non ha righe");
						return def.resolve(null);
					}
					realParentObjectRow = realParentTable.rows[0].getRow();
				}
				//$getNewRowInside$

				dt.autoIncrement('idgraduatoriaesitipos', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(realParentObjectRow, dt, editType)
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
						return "pos asc ";
					}
					case "stato": {
						return "pos asc ";
					}
					case "default": {
						return "pos asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('graduatoriaesitipos', new meta_graduatoriaesitipos('graduatoriaesitipos'));

	}());
