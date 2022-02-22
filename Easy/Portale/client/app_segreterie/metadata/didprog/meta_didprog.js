
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

    function meta_didprog() {
        MetaData.apply(this, ["didprog"]);
        this.name = 'meta_didprog';
    }

    meta_didprog.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprog,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
//$objCalcFieldConfig_default$
						break;
					case 'ingresso':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
//$objCalcFieldConfig_ingresso$
						break;
					case 'dotmas':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
//$objCalcFieldConfig_dotmas$
						break;
					case 'stato':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
//$objCalcFieldConfig_stato$
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
						table.columns["aa"].caption = "Anno accademico";
						table.columns["annosolare"].caption = "Anno solare";
						table.columns["attribdebiti"].caption = "Attribuzione eventuali crediti o debiti formativi";
						table.columns["codicemiur"].caption = "Codice MIUR";
						table.columns["dataconsmaxiscr"].caption = "Data del conseguimento massima per il quale è consentito iscriversi";
						table.columns["freqobbl"].caption = "Frequenza Obbligatoria";
						table.columns["idareadidattica"].caption = "Area didattica";
						table.columns["idconvenzione"].caption = "Convenzione";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Identificativo";
						table.columns["iddidprognumchiusokind"].caption = "Numero chiuso";
						table.columns["iddidprogsuddannokind"].caption = "Suddivisioni dell'anno";
						table.columns["iderogazkind"].caption = "Erogazione";
						table.columns["idgraduatoria"].caption = "Graduatoria";
						table.columns["idnation_lang"].caption = "Lingua di erogazione";
						table.columns["idnation_lang2"].caption = "Seconda lingua di erogazione";
						table.columns["idnation_langvis"].caption = "Lingua di visualizzazione";
						table.columns["idreg_docenti"].caption = "Referente";
						table.columns["idsede"].caption = "Sede";
						table.columns["idsessione"].caption = "Sessione";
						table.columns["idtitolokind"].caption = "Titolo di studi";
						table.columns["immatoltreauth"].caption = "Consenti l'immatricolazione oltre i termini";
						table.columns["modaccesso"].caption = "Modalità e conoscenze per l'accesso";
						table.columns["modaccesso_en"].caption = "Modalità e conoscenze per l'accesso (EN)";
						table.columns["obbformativi"].caption = "Obiettivi formativi";
						table.columns["obbformativi_en"].caption = "Obiettivi formativi (EN)";
						table.columns["preimmatoltreauth"].caption = "Consenti la pre-immatricolazione oltre i termini";
						table.columns["progesamamm"].caption = "Programma dell'esame di ammissione";
						table.columns["prospoccupaz"].caption = "Prospettive occupazionali";
						table.columns["provafinaledesc"].caption = "Caratteristiche della prova finale";
						table.columns["regolamentotax"].caption = "Regolamento delle tasse";
						table.columns["regolamentotaxurl"].caption = "Indirizzo WEB del regolamento delle tasse";
						table.columns["startiscrizioni"].caption = "Data di inizio delle iscrizioni";
						table.columns["stopiscrizioni"].caption = "Data di fine delle Iscrizioni";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (EN)";
						table.columns["utenzasost"].caption = "Utenza sostenibile";
						table.columns["website"].caption = "Sito WEB del corso";
//$innerSetCaptionConfig_default$
						break;
					case 'ingresso':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'dotmas':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["annosolare"].caption = "Anno solare";
						table.columns["attribdebiti"].caption = "Attribuzione eventuali crediti o debiti formativi";
						table.columns["codicemiur"].caption = "Codice MIUR";
						table.columns["dataconsmaxiscr"].caption = "Data del conseguimento massima per il quale è consentito iscriversi";
						table.columns["freqobbl"].caption = "Frequenza Obbligatoria";
						table.columns["idareadidattica"].caption = "Area didattica";
						table.columns["idconvenzione"].caption = "Convenzione";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Identificativo";
						table.columns["iddidprognumchiusokind"].caption = "Numero chiuso";
						table.columns["iddidprogsuddannokind"].caption = "Suddivisioni dell'anno";
						table.columns["iderogazkind"].caption = "Erogazione";
						table.columns["idgraduatoria"].caption = "Graduatoria";
						table.columns["idnation_lang"].caption = "Lingua di erogazione";
						table.columns["idnation_lang2"].caption = "Seconda lingua di erogazione";
						table.columns["idnation_langvis"].caption = "Lingua di visualizzazione";
						table.columns["idreg_docenti"].caption = "Referente";
						table.columns["idsede"].caption = "Sede";
						table.columns["idsessione"].caption = "Sessione";
						table.columns["idtitolokind"].caption = "Titolo di studi";
						table.columns["immatoltreauth"].caption = "Consenti l'immatricolazione oltre i termini";
						table.columns["modaccesso"].caption = "Modalità e conoscenze per l'accesso";
						table.columns["modaccesso_en"].caption = "Modalità e conoscenze per l'accesso (EN)";
						table.columns["obbformativi"].caption = "Obiettivi formativi";
						table.columns["obbformativi_en"].caption = "Obiettivi formativi (EN)";
						table.columns["preimmatoltreauth"].caption = "Consenti la pre-immatricolazione oltre i termini";
						table.columns["progesamamm"].caption = "Programma dell'esame di ammissione";
						table.columns["prospoccupaz"].caption = "Prospettive occupazionali";
						table.columns["provafinaledesc"].caption = "Caratteristiche della prova finale";
						table.columns["regolamentotax"].caption = "Regolamento delle tasse";
						table.columns["regolamentotaxurl"].caption = "Indirizzo WEB del regolamento delle tasse";
						table.columns["startiscrizioni"].caption = "Data di inizio delle iscrizioni";
						table.columns["stopiscrizioni"].caption = "Data di fine delle Iscrizioni";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (EN)";
						table.columns["utenzasost"].caption = "Utenza sostenibile";
						table.columns["website"].caption = "Sito WEB del corso";
//$innerSetCaptionConfig_dotmas$
						break;
					case 'stato':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["annosolare"].caption = "Anno solare";
						table.columns["attribdebiti"].caption = "Attribuzione eventuali crediti o debiti formativi";
						table.columns["codicemiur"].caption = "Codice MIUR";
						table.columns["dataconsmaxiscr"].caption = "Data del conseguimento massima per il quale è consentito iscriversi";
						table.columns["freqobbl"].caption = "Frequenza Obbligatoria";
						table.columns["idareadidattica"].caption = "Area didattica";
						table.columns["idconvenzione"].caption = "Convenzione";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Identificativo";
						table.columns["iddidprognumchiusokind"].caption = "Numero chiuso";
						table.columns["iddidprogsuddannokind"].caption = "Suddivisioni dell'anno";
						table.columns["iderogazkind"].caption = "Erogazione";
						table.columns["idgraduatoria"].caption = "Graduatoria";
						table.columns["idnation_lang"].caption = "Lingua di erogazione";
						table.columns["idnation_lang2"].caption = "Seconda lingua di erogazione";
						table.columns["idnation_langvis"].caption = "Lingua di visualizzazione";
						table.columns["idreg_docenti"].caption = "Referente";
						table.columns["idsede"].caption = "Sede";
						table.columns["idsessione"].caption = "Sessione";
						table.columns["idtitolokind"].caption = "Titolo di studi";
						table.columns["immatoltreauth"].caption = "Consenti iscrizioni oltre i termini";
						table.columns["modaccesso"].caption = "Modalità e conoscenze per l'accesso";
						table.columns["modaccesso_en"].caption = "Modalità e conoscenze per l'accesso (EN)";
						table.columns["obbformativi"].caption = "Obiettivi formativi";
						table.columns["obbformativi_en"].caption = "Obiettivi formativi (EN)";
						table.columns["preimmatoltreauth"].caption = "Consenti la pre-immatricolazione oltre i termini";
						table.columns["progesamamm"].caption = "Programma dell'esame di ammissione";
						table.columns["prospoccupaz"].caption = "Prospettive occupazionali";
						table.columns["provafinaledesc"].caption = "Caratteristiche della prova finale";
						table.columns["regolamentotax"].caption = "Regolamento delle tasse";
						table.columns["regolamentotaxurl"].caption = "Indirizzo WEB del regolamento delle tasse";
						table.columns["startiscrizioni"].caption = "Data di inizio delle iscrizioni";
						table.columns["stopiscrizioni"].caption = "Data di fine delle Iscrizioni";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (EN)";
						table.columns["utenzasost"].caption = "Utenza sostenibile";
						table.columns["website"].caption = "Sito WEB del corso";
//$innerSetCaptionConfig_stato$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_didprog");

				//$getNewRowInside$

				dt.autoIncrement('iddidprog', { minimum: 99990001 });

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
						return "title desc, aa desc, idsede desc";
					}
					case "ingresso": {
						return "title asc ";
					}
					case "dotmas": {
						return "title asc ";
					}
					case "stato": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprog', new meta_didprog('didprog'));

	}());
