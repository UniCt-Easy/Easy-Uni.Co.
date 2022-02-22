
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

    function meta_tirocinioprogettosegview() {
        MetaData.apply(this, ["tirocinioprogettosegview"]);
        this.name = 'meta_tirocinioprogettosegview';
    }

    meta_tirocinioprogettosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioprogettosegview,
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
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, -1);
						this.describeAColumn(table, 'tirocinioprogetto_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'tirocinioprogetto_competenze', 'Competenze', null, 40, -1);
						this.describeAColumn(table, 'tirocinioprogetto_datafineeffettiva', 'Data fine effettiva', null, 50, null);
						this.describeAColumn(table, 'tirocinioprogetto_datafineprevista', 'Data fine prevista', null, 60, null);
						this.describeAColumn(table, 'tirocinioprogetto_datainizioeffettiva', 'Data inizio effettiva', null, 70, null);
						this.describeAColumn(table, 'tirocinioprogetto_datainizioprevista', 'Data inizio prevista', null, 80, null);
						this.describeAColumn(table, 'tirocinioprogetto_dataverbale', 'Data verbale', null, 90, null);
						this.describeAColumn(table, 'tirocinioprogetto_description_en', 'Descrizione in inglese', null, 100, -1);
						this.describeAColumn(table, 'aoo_title', 'Area organizzativa omogenea', null, 110, 1024);
						this.describeAColumn(table, 'registrydocenti_title', 'Tutor', null, 120, 101);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 150, 1024);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura didattica', null, 160, 1024);
						this.describeAColumn(table, 'tirociniostato_title', 'Stato del tirocinio', null, 190, 50);
						this.describeAColumn(table, 'tirocinioprogetto_ore', 'Ore', null, 200, null);
						this.describeAColumn(table, 'tirocinioprogetto_tempiaccesso', 'Tempi di accesso', null, 230, -1);
						this.describeAColumn(table, 'tirocinioprogetto_title_en', 'Titolo in inglese', null, 240, -1);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg_studenti", "idreg_referente", "idtirocinioprogetto", "idtirocinioproposto", "idtirociniocandidatura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc, tirocinioprogetto_description desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirocinioprogettosegview', new meta_tirocinioprogettosegview('tirocinioprogettosegview'));

	}());
