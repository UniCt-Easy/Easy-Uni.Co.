
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

    function meta_progetto() {
        MetaData.apply(this, ["progetto"]);
        this.name = 'meta_progetto';
    }

    meta_progetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progetto,
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
						this.describeAColumn(table, 'idprogetto', 'Codice interno', null, 10, null);
						this.describeAColumn(table, 'titolobreve', 'Titolo breve o acronimo', null, 50, 2048);
						this.describeAColumn(table, 'finanziatoretxt', 'Ente finanziatore non censito', null, 180, 2048);
						this.describeAColumn(table, 'cup', 'Codice univoco progetto (CUP)', null, 210, 15);
						this.describeAColumn(table, 'codiceidentificativo', 'Codice attribuito dall\'ente finanziatore', null, 220, 2048);
						this.describeAColumn(table, 'capofilatxt', 'Ente capofila non censito', null, 260, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 300, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 310, null);
						this.describeAColumn(table, 'datacontabile', 'Data chiusura contablile', null, 330, null);
						this.describeAColumn(table, 'budget', 'Costo totale per l\'ateneo', 'fixed.2', 410, null);
						this.describeAColumn(table, 'contributoente', 'Contributo totale ottenuto per l\'ateneo dall’ente finanziatore', 'fixed.2', 420, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento ottenuto dall\'ateneo', 'fixed.2', 430, null);
						this.describeAColumn(table, 'budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 450, null);
						this.describeAColumn(table, 'budgetcalcolatodate', 'Calcolato il', 'g', 460, null);
						this.describeAColumn(table, 'contributoenterichiesto', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 700, null);
						this.describeAColumn(table, 'contributorichiesto', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 710, null);
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
						table.columns["!filtraAsset"].caption = "Filtro per la ricerca dei cespiti";
						table.columns["!altreupb"].caption = "Cerca anche cespiti di altre UPB ";
						table.columns["bandoriferimentotxt"].caption = "Bando di riferimento non censito";
						table.columns["budget"].caption = "Costo totale per l'ateneo";
						table.columns["budgetcalcolato"].caption = "Costo totale effettivo per l'ateneo";
						table.columns["budgetcalcolatodate"].caption = "Calcolato il";
						table.columns["capofilatxt"].caption = "Ente capofila non censito";
						table.columns["codiceidentificativo"].caption = "Codice identificativo";
						table.columns["contributo"].caption = "Cofinanziamento richiesto all'ateneo";
						table.columns["contributoente"].caption = "Contributo totale richiesto dall'ateneo all’ente finanziatore";
						table.columns["cup"].caption = "Codice univoco progetto (CUP)";
						table.columns["data"].caption = "Data di presentazione";
						table.columns["datacontabile"].caption = "Data chiusura contablile";
						table.columns["dataesito"].caption = "Data dell’esito di valutazione";
						table.columns["description"].caption = "Descrizione";
						table.columns["finanziamento"].caption = "Riferimenti del finanziamento";
						table.columns["finanziatoretxt"].caption = "Ente finanziatore non censito";
						table.columns["idcorsostudio"].caption = "Didattica";
						table.columns["idcurrency"].caption = "Codice valuta";
						table.columns["idduratakind"].caption = "Espressa in";
						table.columns["idprogetto"].caption = "Codice interno";
						table.columns["idprogettokind"].caption = "Tipo di progetto o attività";
						table.columns["idprogettostatuskind"].caption = "Stato del progetto o attività";
						table.columns["idreg"].caption = "Principal investigator / Responsabile di progetto ";
						table.columns["idreg_aziende"].caption = "Ente capofila";
						table.columns["idreg_aziende_fin"].caption = "Ente finanziatore";
						table.columns["idregistryprogfin"].caption = "Programma di finanziamento";
						table.columns["idregistryprogfinbando"].caption = "Bando di riferimento";
						table.columns["idstrumentofin"].caption = "Strumento di finanziamento";
						table.columns["progfinanziamentotxt"].caption = "Programma di riferimento non censito";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
						table.columns["title"].caption = "Titolo";
						table.columns["titolobreve"].caption = "Titolo breve o acronimo";
						table.columns["totalbudget"].caption = "Costo globale del progetto per tutto il partenariato";
						table.columns["totalcontributo"].caption = "Contributo globale del progetto per tutto il partenariato";
						table.columns["url"].caption = "URL del sito del progetto";
						table.columns["codiceidentificativo"].caption = "Codice attribuito dall'ente finanziatore";
						table.columns["description"].caption = "Descrizione / Abstract";
						table.columns["idprogettokind"].caption = "Modello di progetto";
						table.columns["title_en"].caption = "Titolo in inglese";
						table.columns["idreg"].caption = "Principal investigator / Responsabile scientifico";
						table.columns["idreg_amm"].caption = "Responsabile amministrativo";
						table.columns["idpartnerkind"].caption = "Ruolo dell'ateneo";
						table.columns["totalbudget"].caption = "Costo totale del progetto per tutto il partenariato";
						table.columns["contributo"].caption = "Cofinanziamento ottenuto dall'ateneo";
						table.columns["contributoente"].caption = "Contributo totale ottenuto per l'ateneo dall’ente finanziatore";
						table.columns["contributoenterichiesto"].caption = "Contributo totale richiesto dall'ateneo all’ente finanziatore";
						table.columns["contributorichiesto"].caption = "Cofinanziamento richiesto all'ateneo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progetto");

				//$getNewRowInside$

				dt.autoIncrement('idprogetto', { minimum: 99990001 });

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
						return "titolobreve asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progetto', new meta_progetto('progetto'));

	}());
