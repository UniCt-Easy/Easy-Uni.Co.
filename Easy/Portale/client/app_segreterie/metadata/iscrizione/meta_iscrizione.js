
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


(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_iscrizione() {
		MetaData.apply(this, ["iscrizione"]);
		this.name = 'meta_iscrizione';
	}

	meta_iscrizione.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_iscrizione,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup: 'registry_alias1', columnNameLookup: 'title', columnNamekey: 'idreg' };
												objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_didprog$
						break;
					case 'seganagstu':
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 52, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Denominazione Didattica programmata', null, 51, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seganagstuacc':
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Prova di accesso', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Prova di accesso', null, 52, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstuacc$
						break;
					case 'seganagstumast':
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Master', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Master', null, 52, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstumast$
						break;
					case 'seganagstustato':
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Esame di stato', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Esame di stato', null, 52, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstustato$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						//$objCalcFieldConfig_seg$
						break;
					case 'ingresso':
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup: 'registry', columnNameLookup: 'title', columnNamekey: 'idreg' };
												objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_ingresso$
						break;
					case 'stato':
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_stato$
						break;
					case 'dotmas':
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_dotmas$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'dotmas':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_dotmas$
						break;
					case 'stato':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_stato$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_iscrizione");

				var realParentObjectRow = parentRow;
				if (editType === "stato") {
					var realParentTableName = "didprog";
					var realParentTable = dt.dataset.tables["didprog"];
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
				if (editType === "dotmas") {
					var realParentTableName = "didprog";
					var realParentTable = dt.dataset.tables["didprog"];
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
				if (editType === "ingresso") {
					var realParentTableName = "didprog";
					var realParentTable = dt.dataset.tables["didprog"];
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

				dt.autoIncrement('idiscrizione', { minimum: 99990001 });

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
					case "didprog": {
						return "idreg desc";
					}
					case "seg": {
						return "iddidprog desc, idreg desc";
					}
					case "dotmas": {
						return "idreg desc";
					}
					case "stato": {
						return "idreg desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

		});

	window.appMeta.addMeta('iscrizione', new meta_iscrizione('iscrizione'));

}());
