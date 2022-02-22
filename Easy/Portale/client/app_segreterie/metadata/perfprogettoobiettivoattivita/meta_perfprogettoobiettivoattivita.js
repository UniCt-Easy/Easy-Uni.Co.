
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

    function meta_perfprogettoobiettivoattivita() {
        MetaData.apply(this, ["perfprogettoobiettivoattivita"]);
        this.name = 'meta_perfprogettoobiettivoattivita';
    }

    meta_perfprogettoobiettivoattivita.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivoattivita,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 40, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 50, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 60, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 70, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 80, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Chi svolge l’attività', null, 31, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_default$
						break;
					case 'docenti':
						this.describeAColumn(table, 'title', 'Titolo', null, 40, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 50, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 60, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 70, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 80, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 90, null);
//$objCalcFieldConfig_docenti$
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
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
					case 'docenti':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
						table.columns["idperfprogetto"].caption = "Progetto Strategico";
						table.columns["idperfprogettoobiettivo"].caption = "Obiettivo strategico";
//$innerSetCaptionConfig_docenti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoobiettivoattivita");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoobiettivoattivita', { minimum: 99990001 });

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
						return "datainizioprevista asc ";
					}
					case "default": {
						return "ct asc ";
					}
					case "docenti": {
						return "ct asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title");
				var rootCondition = window.jsDataQuery.eq("paridperfprogettoobiettivoattivita", 5);
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
        });

    window.appMeta.addMeta('perfprogettoobiettivoattivita', new meta_perfprogettoobiettivoattivita('perfprogettoobiettivoattivita'));

	}());
