
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

    function meta_progettocostosegview() {
        MetaData.apply(this, ["progettocostosegview"]);
        this.name = 'meta_progettocostosegview';
    }

    meta_progettocostosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettocostosegview,
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
						this.describeAColumn(table, 'progettotipocosto_title', 'Voce di costo', null, 10, 2048);
						this.describeAColumn(table, 'progettocosto_amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'contrattokind_title', 'Tipo di contratto', null, 30, 50);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Attività svolta', null, 40, -1);
						this.describeAColumn(table, 'progettocosto_doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'progettocosto_docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'expense_description', 'Descrizione Spesa', null, 70, 150);
						this.describeAColumn(table, 'expense_ymov', 'Anno movimento Spesa', null, 70, null);
						this.describeAColumn(table, 'expense_nmov', 'N.movimento Spesa', null, 70, null);
						this.describeAColumn(table, 'pettycash_description', 'Descrizione Fondo economale', null, 80, 50);
						this.describeAColumn(table, 'pettycash_pettycode', 'Codice Fondo economale', null, 80, 20);
						this.describeAColumn(table, 'progettocosto_yoperation', 'Esercizio operazione', null, 90, null);
						this.describeAColumn(table, 'progettocosto_noperation', 'Numero operazione', null, 100, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato avanzamento lavori', null, 120, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato avanzamento lavori', null, 120, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto", "idworkpackage", "idprogettocosto", "idprogettotipocosto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "progettotipocosto_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettocostosegview', new meta_progettocostosegview('progettocostosegview'));

	}());
