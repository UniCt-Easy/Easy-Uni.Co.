
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

    function meta_lezione() {
        MetaData.apply(this, ["lezione"]);
        this.name = 'meta_lezione';
    }

    meta_lezione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_lezione,
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
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 30, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 40, null);
//$objCalcFieldConfig_seg$
						break;
					case 'rendicont':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 100, null);
//$objCalcFieldConfig_rendicont$
						break;
					case 'attivform':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 30, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 40, null);
//$objCalcFieldConfig_attivform$
						break;
					case 'default':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 100, null);
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
					case 'seg':
						table.columns["!title"].caption = "Lezione";
						table.columns["idaffidamento"].caption = "Affidamento";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idaula"].caption = "Aula";
						table.columns["idcanale"].caption = "Canale";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidproganno"].caption = "Anno di corso";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidprogori"].caption = "Orientamento";
						table.columns["iddidprogporzanno"].caption = "Porzione d'anno";
						table.columns["idedificio"].caption = "Edificio";
						table.columns["idlezione"].caption = "Identificativo";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idsede"].caption = "Sede";
						table.columns["nonsvolta"].caption = "Non svolta";
						table.columns["start"].caption = "Data e ora inizio";
						table.columns["stop"].caption = "Data e ora fine";
//$innerSetCaptionConfig_seg$
						break;
					case 'rendicont':
						table.columns["!title"].caption = "Lezione";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["idaffidamento"].caption = "Affidamento";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idaula"].caption = "Aula";
						table.columns["idcanale"].caption = "Canale";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidproganno"].caption = "Anno di corso";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidprogori"].caption = "Orientamento";
						table.columns["iddidprogporzanno"].caption = "Porzione d'anno";
						table.columns["idedificio"].caption = "Edificio";
						table.columns["idlezione"].caption = "Identificativo";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idsede"].caption = "Sede";
						table.columns["nonsvolta"].caption = "Non svolta";
						table.columns["start"].caption = "Data e ora inizio";
						table.columns["stop"].caption = "Data e ora fine";
//$innerSetCaptionConfig_rendicont$
						break;
					case 'attivform':
						table.columns["!title"].caption = "Lezione";
						table.columns["idaffidamento"].caption = "Affidamento";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idaula"].caption = "Aula";
						table.columns["idcanale"].caption = "Canale";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidproganno"].caption = "Anno di corso";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidprogori"].caption = "Orientamento";
						table.columns["iddidprogporzanno"].caption = "Porzione d'anno";
						table.columns["idedificio"].caption = "Edificio";
						table.columns["idlezione"].caption = "Identificativo";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idsede"].caption = "Sede";
						table.columns["nonsvolta"].caption = "Non svolta";
						table.columns["start"].caption = "Data e ora inizio";
						table.columns["stop"].caption = "Data e ora fine";
//$innerSetCaptionConfig_attivform$
						break;
					case 'default':
						table.columns["!title"].caption = "Lezione";
						table.columns["idcorsostudio"].caption = "Corso di studi";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_lezione");

				//$getNewRowInside$

				dt.autoIncrement('idlezione', { minimum: 99990001 });

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
					case "rendicont": {
						return "!title asc ";
					}
					case "default": {
						return "!title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('lezione', new meta_lezione('lezione'));

	}());
