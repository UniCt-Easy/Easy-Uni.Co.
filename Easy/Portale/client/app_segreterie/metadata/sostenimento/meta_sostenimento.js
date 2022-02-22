
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

    function meta_sostenimento() {
        MetaData.apply(this, ["sostenimento"]);
        this.name = 'meta_sostenimento';
    }

    meta_sostenimento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimento,
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
					case 'didprog':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_didprog$
						break;
					case 'segcons':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'domande', 'Domande', null, 30, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'insecod', 'Codice insegnamento', null, 150, 50);
						this.describeAColumn(table, 'insedesc', 'Insegnamento', null, 160, 1024);
						this.describeAColumn(table, 'livello', 'Livello', null, 170, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 210, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 220, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 230, null);
//$objCalcFieldConfig_segcons$
						break;
					case 'seganagstustato':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstustato$
						break;
					case 'seganagstuconsmast':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstuconsmast$
						break;
					case 'seganagstuacc':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstuacc$
						break;
					case 'seganagstusing':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'segstud':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
//$objCalcFieldConfig_segstud$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa', null, 91, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'ingresso':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_ingresso$
						break;
					case 'default':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
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
					case 'ingresso':
						table.columns["ects"].caption = "ECTS";
						table.columns["idappello"].caption = "Appello";
						table.columns["idattivform"].caption = "Attività formativa";
						table.columns["idcorsostudio"].caption = "Corso studio";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idprova"].caption = "Prova";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Identificativo";
						table.columns["idsostenimentoesito"].caption = "Esito";
						table.columns["idtitolostudio"].caption = "Titolo di studio";
						table.columns["insecod"].caption = "Codice insegnamento";
						table.columns["insedesc"].caption = "Insegnamento";
						table.columns["paridsostenimento"].caption = "Sostenimento parziale di";
						table.columns["protanno"].caption = "Anno protocollo";
						table.columns["protnumero"].caption = "Numero Protocollo";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_ingresso$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_sostenimento");

				//$getNewRowInside$

				dt.autoIncrement('idsostenimento', { minimum: 99990001 });

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

        });

    window.appMeta.addMeta('sostenimento', new meta_sostenimento('sostenimento'));

	}());
