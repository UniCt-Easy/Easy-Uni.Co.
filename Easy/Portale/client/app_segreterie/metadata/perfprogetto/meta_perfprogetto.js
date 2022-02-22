
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

    function meta_perfprogetto() {
        MetaData.apply(this, ["perfprogetto"]);
        this.name = 'meta_perfprogetto';
    }

    meta_perfprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogetto,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 40, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 50, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 60, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 70, null);
						this.describeAColumn(table, 'risultato', 'Percentuale di completamento', 'fixed.2', 80, null);
						this.describeAColumn(table, 'note', 'Note', null, 90, -1);
						this.describeAColumn(table, 'benefici', 'Benefici attesi', null, 110, -1);
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
						table.columns["benefici"].caption = "Benefici attesi";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iddidprogsuddannokind"].caption = "Frequenza monitoraggi";
						table.columns["idperfprogettostatus"].caption = "Stato";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["note"].caption = "Note";
						table.columns["title"].caption = "Titolo";
						table.columns["risultato"].caption = "Percentuale di completamento";
						table.columns["idperfprogetto"].caption = "NULL";
						table.columns["idstruttura"].caption = "Unità organizzativa";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogetto");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogetto', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogetto', new meta_perfprogetto('perfprogetto'));

	}());
