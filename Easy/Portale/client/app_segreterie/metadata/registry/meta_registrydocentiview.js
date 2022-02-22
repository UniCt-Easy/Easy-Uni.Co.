
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

    function meta_registrydocentiview() {
        MetaData.apply(this, ["registrydocentiview"]);
        this.name = 'meta_registrydocentiview';
    }

    meta_registrydocentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrydocentiview,
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
					case 'docenti':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'registry_docenti_matricola', 'Matricola', null, 10, 50);
						this.describeAColumn(table, 'sasd_codice', 'Codice SASD', null, 20, 50);
						this.describeAColumn(table, 'sasd_title', 'Denominazione SASD', null, 20, 255);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di afferenza', null, 30, 1024);
						this.describeAColumn(table, 'registryistituti_title', 'Istituto, Ente o Azienda', null, 40, 101);
						this.describeAColumn(table, 'classconsorsuale_title', 'Classe consorsuale', null, 50, 50);
						this.describeAColumn(table, 'contrattokind_title', 'Tipo', null, 510, 50);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docenti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrydocentiview', new meta_registrydocentiview('registrydocentiview'));

	}());
