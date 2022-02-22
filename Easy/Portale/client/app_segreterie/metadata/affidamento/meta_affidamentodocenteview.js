
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

    function meta_affidamentodocenteview() {
        MetaData.apply(this, ["affidamentodocenteview"]);
        this.name = 'meta_affidamentodocenteview';
    }

    meta_affidamentodocenteview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentodocenteview,
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
					case 'docente':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'affidamento_jsonancestor', 'Didattica', null, 10, -1);
						this.describeAColumn(table, 'affidamentokind_title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'affidamento_riferimento', 'Docente di riferimento per il canale', null, 30, null);
						this.describeAColumn(table, 'erogazkind_title', 'Tipo di erogazione', null, 40, 50);
						this.describeAColumn(table, 'affidamento_freqobbl', 'Frequenza obbligatoria', null, 50, null);
						this.describeAColumn(table, 'affidamento_gratuito', 'Gratuito', null, 60, null);
						this.describeAColumn(table, 'affidamento_start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'affidamento_stop', 'Fine', null, 160, null);
						this.describeAColumn(table, 'XXaffidamentocaratteristica', 'Caratteristiche dell\'affidamento', null, 200, null);
//$objCalcFieldConfig_docente$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idcanale", "iddidprog", "idattivform", "iddidprogori", "idaffidamento", "idcorsostudio", "iddidproganno", "iddidprogcurr", "idreg_docenti", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docente": {
						return "affidamento_riferimento asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('affidamentodocenteview', new meta_affidamentodocenteview('affidamentodocenteview'));

	}());
