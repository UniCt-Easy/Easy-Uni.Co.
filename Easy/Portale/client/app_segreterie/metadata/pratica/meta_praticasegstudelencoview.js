
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_praticasegstudelencoview() {
        MetaData.apply(this, ["praticasegstudelencoview"]);
        this.name = 'meta_praticasegstudelencoview';
    }

    meta_praticasegstudelencoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticasegstudelencoview,
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
					case 'segstudelenco':
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia Tipologia', null, 10, 50);
						this.describeAColumn(table, 'dichiarkind_iddichiarkind', 'Tipologia Tipologia', null, 10, null);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 20, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 20, 9);
						this.describeAColumn(table, 'istanzakind_title', 'Tipologia di istanza', null, 180, 50);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 190, 50);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 210, null);
//$objCalcFieldConfig_segstudelenco$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idistanza", "idpratica", "idiscrizione", "idcorsostudio", "idistanzakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segstudelenco": {
						return "registry_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('praticasegstudelencoview', new meta_praticasegstudelencoview('praticasegstudelencoview'));

	}());