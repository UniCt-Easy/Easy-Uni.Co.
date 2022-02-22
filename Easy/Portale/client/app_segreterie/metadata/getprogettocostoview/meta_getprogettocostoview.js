
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

    function meta_getprogettocostoview() {
        MetaData.apply(this, ["getprogettocostoview"]);
        this.name = 'meta_getprogettocostoview';
    }

    meta_getprogettocostoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getprogettocostoview,
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
					case 'default':
						this.describeAColumn(table, 'raggruppamento', 'Raggruppamento', null, 10, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Workpackage', null, 20, 2048);
						this.describeAColumn(table, 'progettotipocosto_title', 'Voce di costo', null, 30, 2048);
						this.describeAColumn(table, 'ammissibilita', 'Ammissibilità', 'fixed.2', 40, null);
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'contrattokind_title', 'Tipo di contratto', null, 60, 50);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Attività svolta', null, 70, -1);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 80, 35);
						this.describeAColumn(table, 'docdate', 'Data contabile', null, 90, null);
						this.describeAColumn(table, 'adate', 'Data liquidazione', null, 100, null);
						this.describeAColumn(table, 'payment_adate', 'Data mandato di pagamento ', null, 110, null);
						this.describeAColumn(table, 'transmissiondate', 'Data di trasmissione alla banca', null, 120, null);
						this.describeAColumn(table, 'transactiondate', 'Data quietanza banca', null, 130, null);
						this.describeAColumn(table, 'description', 'Descrizione spesa', null, 200, 150);
						this.describeAColumn(table, 'ymov', 'Anno movimento spesa', null, 210, null);
						this.describeAColumn(table, 'nmov', 'N. movimento spesa', null, 220, null);
						this.describeAColumn(table, 'pettycash_description', 'Descrizione fondo economale', null, 230, 50);
						this.describeAColumn(table, 'pettycash_pettycode', 'Codice fondo economale', null, 240, 20);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 300, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 310, null);
						this.describeAColumn(table, 'cf', 'CF fornitore', null, 360, 16);
						this.describeAColumn(table, 'p_iva', 'P. IVA fornitore', null, 370, 15);
						this.describeAColumn(table, 'registry_title', 'Fornitore', null, 390, 101);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto", "idgetprogettocostoview"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "raggruppamento desc, workpackage_title desc, progettotipocosto_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getprogettocostoview', new meta_getprogettocostoview('getprogettocostoview'));

	}());
