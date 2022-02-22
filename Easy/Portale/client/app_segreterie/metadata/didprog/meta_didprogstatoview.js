
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

    function meta_didprogstatoview() {
        MetaData.apply(this, ["didprogstatoview"]);
        this.name = 'meta_didprogstatoview';
    }

    meta_didprogstatoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogstatoview,
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
					case 'stato':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 40, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 40, null);
						this.describeAColumn(table, 'didprognumchiusokind_title', 'Numero chiuso', null, 140, 50);
						this.describeAColumn(table, 'graduatoria_title', 'Graduatoria', null, 170, 256);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'sessione_start', 'Data di inizio Sessione', null, 240, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine Sessione', null, 240, null);
						this.describeAColumn(table, 'titolokind_title', 'Titolo di studi', null, 250, 50);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia Tipologia', null, 30, 50);
						this.describeAColumn(table, 'sessione_idsessionekind', 'Tipologia Tipologia', null, 30, null);
//$objCalcFieldConfig_stato$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "stato": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogstatoview', new meta_didprogstatoview('didprogstatoview'));

	}());
