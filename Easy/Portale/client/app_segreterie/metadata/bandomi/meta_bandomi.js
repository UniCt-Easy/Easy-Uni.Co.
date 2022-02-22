
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

    function meta_bandomi() {
        MetaData.apply(this, ["bandomi"]);
        this.name = 'meta_bandomi';
    }

    meta_bandomi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomi,
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
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Titolo del bando', null, 30, -1);
						this.describeAColumn(table, 'cfminimi', 'Crediti formativi minimi per l\'accesso', 'fixed.2', 40, null);
						this.describeAColumn(table, 'codice', 'Codice identificativo', null, 50, 50);
						this.describeAColumn(table, 'datariferimentorequisiti', 'Data di riferimento per il calcolo dei requisiti', null, 60, null);
						this.describeAColumn(table, 'durata', 'Durata', null, 70, null);
						this.describeAColumn(table, 'iscrittonellanno', 'Solo per iscritti nell\'anno', null, 160, null);
						this.describeAColumn(table, 'maxpreferenze', 'Numero massimo di preferenze', null, 170, null);
						this.describeAColumn(table, 'mediaminima', 'Mendia minima', 'fixed.2', 180, null);
						this.describeAColumn(table, 'nessundebito', 'Nessun debito formativo', null, 190, null);
						this.describeAColumn(table, 'numeroesamiminimo', 'Numero minimo di esami', null, 200, null);
						this.describeAColumn(table, 'startcandidature', 'Data di inizio delle candidature', 'g', 210, null);
						this.describeAColumn(table, 'startgraduatoria', 'Data di inizio della graduatoria', 'g', 220, null);
						this.describeAColumn(table, 'startpermanenza', 'Data di inizio del periodo all\'estero', null, 230, null);
						this.describeAColumn(table, 'startpresentazione', 'Data di inizio delle presentazioni dei Learning Agreement', 'g', 240, null);
						this.describeAColumn(table, 'stopcadidature', 'Data di fine di presentazione delle candidature', 'g', 250, null);
						this.describeAColumn(table, 'stopgraduatoria', 'Data di fine della graduatoria', 'g', 260, null);
						this.describeAColumn(table, 'stoppermanenza', 'Data di fine di permanenza all\'estero', null, 270, null);
						this.describeAColumn(table, 'stoppresentazione', 'Data di fine delle presentazioni dei Learning Agreement', 'g', 280, null);
						this.describeAColumn(table, 'testodomanda', 'Testo della intestazione della domanda di ammissione', null, 290, -1);
						this.describeAColumn(table, 'titolodomanda', 'Titolo della domanda di ammissione', null, 300, -1);
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
						table.columns["aa"].caption = "Anno Accademico";
						table.columns["cfminimi"].caption = "Crediti formativi minimi per l'accesso";
						table.columns["codice"].caption = "Codice identificativo";
						table.columns["datariferimentorequisiti"].caption = "Data di riferimento per il calcolo dei requisiti";
						table.columns["idaccordoscambiomi"].caption = "Accordo di scambio per la mobilità internazionale";
						table.columns["idassicurazione"].caption = "Assicurazione";
						table.columns["idbandomobilitaintkind"].caption = "Tipologia";
						table.columns["idduratakind"].caption = "Durata";
						table.columns["idgraduatoria"].caption = "Graduatoria";
						table.columns["idprogrammami"].caption = "Programma per la mobilità di riferimento";
						table.columns["idresidence"].caption = "Residenza";
						table.columns["idstruttura"].caption = "Struttura di riferimento";
						table.columns["iscrittonellanno"].caption = "Solo per iscritti nell'anno";
						table.columns["maxpreferenze"].caption = "Numero massimo di preferenze";
						table.columns["mediaminima"].caption = "Mendia minima";
						table.columns["nessundebito"].caption = "Nessun debito formativo";
						table.columns["numeroesamiminimo"].caption = "Numero minimo di esami";
						table.columns["startcandidature"].caption = "Data di inizio delle candidature";
						table.columns["startgraduatoria"].caption = "Data di inizio della graduatoria";
						table.columns["startpermanenza"].caption = "Data di inizio del periodo all'estero";
						table.columns["startpresentazione"].caption = "Data di inizio delle presentazioni dei Learning Agreement";
						table.columns["stopcadidature"].caption = "Data di fine di presentazione delle candidature";
						table.columns["stopgraduatoria"].caption = "Data di fine della graduatoria";
						table.columns["stoppermanenza"].caption = "Data di fine di permanenza all'estero";
						table.columns["stoppresentazione"].caption = "Data di fine delle presentazioni dei Learning Agreement";
						table.columns["testodomanda"].caption = "Testo della intestazione della domanda di ammissione";
						table.columns["title"].caption = "Titolo del bando";
						table.columns["titolodomanda"].caption = "Titolo della domanda di ammissione";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandomi");

				//$getNewRowInside$

				dt.autoIncrement('idbandomi', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('bandomi', new meta_bandomi('bandomi'));

	}());
