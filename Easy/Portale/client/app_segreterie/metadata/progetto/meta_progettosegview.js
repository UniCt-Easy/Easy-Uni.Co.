
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

    function meta_progettosegview() {
        MetaData.apply(this, ["progettosegview"]);
        this.name = 'meta_progettosegview';
    }

    meta_progettosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettosegview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seg':
						this.describeAColumn(table, 'idprogetto', 'Codice interno', null, 1000, null);
						this.describeAColumn(table, 'progettostatuskind_title', 'Stato del progetto o attività', null, 2200, 50);
						this.describeAColumn(table, 'titolobreve', 'Titolo breve o acronimo', null, 5000, 2048);
						this.describeAColumn(table, 'registryaziende_fin_title', 'Ente finanziatore', null, 10100, 101);
						this.describeAColumn(table, 'strumentofin_title', 'Strumento di finanziamento', null, 16200, 2048);
						this.describeAColumn(table, 'progettokind_title', 'Modello di progetto', null, 17200, 2048);
						this.describeAColumn(table, 'progetto_finanziatoretxt', 'Ente finanziatore non censito', null, 18000, 2048);
						this.describeAColumn(table, 'progetto_cup', 'Codice univoco progetto (CUP)', null, 21000, 15);
						this.describeAColumn(table, 'progetto_codiceidentificativo', 'Codice attribuito dall\'ente finanziatore', null, 22000, 2048);
						this.describeAColumn(table, 'title_description', 'Descrizione Titolo Responsabile amministrativo', null, 23120, 50);
						this.describeAColumn(table, 'registryamm_surname', 'Cognome Responsabile amministrativo', null, 23200, 50);
						this.describeAColumn(table, 'registryamm_forename', 'Nome Responsabile amministrativo', null, 23300, 50);
						this.describeAColumn(table, 'registryamm_cf', 'Codice fiscale Responsabile amministrativo', null, 23400, 16);
						this.describeAColumn(table, 'registry_title', 'Principal investigator / Responsabile scientifico', null, 24300, 101);
						this.describeAColumn(table, 'registryaziende_title', 'Ente capofila', null, 25100, 101);
						this.describeAColumn(table, 'progetto_capofilatxt', 'Ente capofila non censito', null, 26000, 2048);
						this.describeAColumn(table, 'partnerkind_title', 'Ruolo dell\'ateneo', null, 27200, 2048);
						this.describeAColumn(table, 'progetto_start', 'Data di inizio', null, 30000, null);
						this.describeAColumn(table, 'progetto_stop', 'Data di fine', null, 31000, null);
						this.describeAColumn(table, 'progetto_datacontabile', 'Data chiusura contablile', null, 33000, null);
						this.describeAColumn(table, 'progetto_budget', 'Costo totale per l\'ateneo', 'fixed.2', 41000, null);
						this.describeAColumn(table, 'progetto_contributoente', 'Contributo totale ottenuto per l\'ateneo dall’ente finanziatore', 'fixed.2', 42000, null);
						this.describeAColumn(table, 'progetto_contributo', 'Cofinanziamento ottenuto dall\'ateneo', 'fixed.2', 43000, null);
						this.describeAColumn(table, 'progetto_budgetcalcolato', 'Costo totale effettivo per l\'ateneo', 'fixed.2', 45000, null);
						this.describeAColumn(table, 'progetto_budgetcalcolatodate', 'Calcolato il', 'g', 46000, null);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Didattica', null, 51100, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Didattica', null, 51600, null);
						this.describeAColumn(table, 'progetto_contributoenterichiesto', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 70000, null);
						this.describeAColumn(table, 'progetto_contributorichiesto', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 71000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto"];
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

    window.appMeta.addMeta('progettosegview', new meta_progettosegview('progettosegview'));

	}());
