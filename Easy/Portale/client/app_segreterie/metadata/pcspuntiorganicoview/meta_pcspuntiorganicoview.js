
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

    function meta_pcspuntiorganicoview() {
        MetaData.apply(this, ["pcspuntiorganicoview"]);
        this.name = 'meta_pcspuntiorganicoview';
    }

    meta_pcspuntiorganicoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcspuntiorganicoview,
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
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'contrattokind_title', 'Qualifica/Categoria', null, 20, 50);
						this.describeAColumn(table, 'puntipiu0', 'Punti organico acquisiti ', 'fixed.4', 30, null);
						this.describeAColumn(table, 'puntimeno0', 'Punti organico persi', 'fixed.4', 40, null);
						this.describeAColumn(table, 'importo0', 'Spese di personale', 'fixed.4', 50, null);
						this.describeAColumn(table, 'importoesterno0', 'Finanziamenti esterni', 'fixed.4', 60, null);
						this.describeAColumn(table, 'importoateneo0', 'A carico Ateneo', 'fixed.4', 70, null);
						this.describeAColumn(table, 'puntipiu1', 'Punti organico acquisiti anno +1', 'fixed.4', 100, null);
						this.describeAColumn(table, 'puntimeno1', 'Punti organico acquisiti anno +1', 'fixed.4', 110, null);
						this.describeAColumn(table, 'importo1', 'Spese di personale anno +1', 'fixed.4', 120, null);
						this.describeAColumn(table, 'importoesterno1', 'Finanziamenti esterni anno +1', 'fixed.4', 130, null);
						this.describeAColumn(table, 'importoateneo1', 'A carico Ateneo anno +1', 'fixed.4', 140, null);
						this.describeAColumn(table, 'puntipiu2', 'Punti organico acquisiti anno +2', 'fixed.4', 200, null);
						this.describeAColumn(table, 'puntimeno2', 'Punti organico persi anno +2', 'fixed.4', 210, null);
						this.describeAColumn(table, 'importo2', 'Spese di personale anno +2', 'fixed.4', 220, null);
						this.describeAColumn(table, 'importoesterno2', 'Finanziamenti esterni anno +2', 'fixed.4', 230, null);
						this.describeAColumn(table, 'importoateneo2', 'A carico Ateneo anno +2', 'fixed.4', 240, null);
						this.describeAColumn(table, 'puntipiu3', 'Punti organico persi anno +3', 'fixed.4', 300, null);
						this.describeAColumn(table, 'puntimeno3', 'Punti organico persi anno +3', 'fixed.4', 310, null);
						this.describeAColumn(table, 'importo3', 'Spese di personale anno +3', 'fixed.4', 320, null);
						this.describeAColumn(table, 'importoesterno3', 'Finanziamenti esterni anno +3', 'fixed.4', 330, null);
						this.describeAColumn(table, 'importoateneo3', 'A carico Ateneo anno +3', 'fixed.4', 340, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idcontrattokind"].caption = "Qualifica/Categoria";
						table.columns["importo0"].caption = "Importo anno";
						table.columns["importo1"].caption = "Importo anno successivo";
						table.columns["importo2"].caption = "Importo secondo anno successivo";
						table.columns["importo3"].caption = "Importo terzo anno successivo";
						table.columns["puntipiu0"].caption = "Punti organico acquisiti ";
						table.columns["puntipiu1"].caption = "Punti organico acquisiti anno successivo";
						table.columns["puntipiu2"].caption = "Punti organico acquisiti secondo anno successivo";
						table.columns["puntipiu3"].caption = "Punti organico persi terzo anno successivo";
						table.columns["year"].caption = "Anno";
						table.columns["puntimeno0"].caption = "Punti organico persi";
						table.columns["puntimeno1"].caption = "Punti organico acquisiti anno successivo";
						table.columns["puntimeno2"].caption = "Punti organico persi secondo anno successivo";
						table.columns["puntimeno3"].caption = "Punti organico persi terzo anno successivo";
						table.columns["contrattokind_title"].caption = "Qualifica/Categoria";
						table.columns["importo0"].caption = "Spese di personale";
						table.columns["importo1"].caption = "Spese di personale anno +1";
						table.columns["importo2"].caption = "Spese di personale anno +2";
						table.columns["importo3"].caption = "Spese di personale anno +3";
						table.columns["importoateneo0"].caption = "A carico Ateneo";
						table.columns["importoateneo1"].caption = "A carico Ateneo anno +1";
						table.columns["importoateneo2"].caption = "A carico Ateneo anno +2";
						table.columns["importoateneo3"].caption = "A carico Ateneo anno +3";
						table.columns["importoesterno0"].caption = "Finanziamenti esterni";
						table.columns["importoesterno1"].caption = "Finanziamenti esterni anno +1";
						table.columns["importoesterno2"].caption = "Finanziamenti esterni anno +2";
						table.columns["importoesterno3"].caption = "Finanziamenti esterni anno +3";
						table.columns["isdoc"].caption = "Docente";
						table.columns["puntimeno1"].caption = "Punti organico acquisiti anno +1";
						table.columns["puntimeno2"].caption = "Punti organico persi anno +2";
						table.columns["puntimeno3"].caption = "Punti organico persi anno +3";
						table.columns["puntipiu1"].caption = "Punti organico acquisiti anno +1";
						table.columns["puntipiu2"].caption = "Punti organico acquisiti anno +2";
						table.columns["puntipiu3"].caption = "Punti organico persi anno +3";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["year", "idcontrattokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('pcspuntiorganicoview', new meta_pcspuntiorganicoview('pcspuntiorganicoview'));

	}());
