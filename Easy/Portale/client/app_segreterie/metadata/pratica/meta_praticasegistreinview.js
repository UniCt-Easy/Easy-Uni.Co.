
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

    function meta_praticasegistreinview() {
        MetaData.apply(this, ["praticasegistreinview"]);
        this.name = 'meta_praticasegistreinview';
    }

    meta_praticasegistreinview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticasegistreinview,
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
					case 'segistrein':
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia Tipologia', null, 10, 50);
						this.describeAColumn(table, 'dichiarkind_iddichiarkind', 'Tipologia Tipologia', null, 10, null);
						this.describeAColumn(table, 'dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 30, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data Dichiarazione da convalidare', null, 30, null);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 60, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 60, null);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 60, 9);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 100, 50);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademco Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, 9);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 130, null);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT', null, 10, 1024);
						this.describeAColumn(table, 'istattitolistudio_idistattitolistudio', 'Titolo ISTAT Titolo ISTAT', null, 10, null);
//$objCalcFieldConfig_segistrein$
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

			//$getSorting$

        });

    window.appMeta.addMeta('praticasegistreinview', new meta_praticasegistreinview('praticasegistreinview'));

	}());
