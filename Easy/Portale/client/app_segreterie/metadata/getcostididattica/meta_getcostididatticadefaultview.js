
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

    function meta_getcostididatticadefaultview() {
        MetaData.apply(this, ["getcostididatticadefaultview"]);
        this.name = 'meta_getcostididatticadefaultview';
    }

    meta_getcostididatticadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcostididatticadefaultview,
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
						this.describeAColumn(table, 'getcostididattica_corsostudio', 'Corso di studio', null, 10, 1024);
						this.describeAColumn(table, 'getcostididattica_sede', 'Sede', null, 20, 1024);
						this.describeAColumn(table, 'aa', 'AA erogata', null, 30, 9);
						this.describeAColumn(table, 'aaprogrammata', 'AA programmata', null, 40, 9);
						this.describeAColumn(table, 'getcostididattica_curriculum', 'Curriculum', null, 50, 256);
						this.describeAColumn(table, 'getcostididattica_insegnamento', 'Insegnamento', null, 60, 256);
						this.describeAColumn(table, 'getcostididattica_modulo', 'Modulo', null, 70, 256);
						this.describeAColumn(table, 'getcostididattica_affidamento', 'Affidamento', null, 80, 1075);
						this.describeAColumn(table, 'getcostididattica_docente', 'Docente', null, 90, 101);
						this.describeAColumn(table, 'getcostididattica_ruolo', 'Ruolo', null, 100, 50);
						this.describeAColumn(table, 'getcostididattica_costoorariodacontratto', 'Costo orario da ruolo', null, 110, 2);
						this.describeAColumn(table, 'getcostididattica_costo', 'Costo', 'fixed.2', 120, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idsede", "iddidprog", "idaffidamento", "idcorsostudio", "iddidprogcurr", "idcontrattokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "getcostididattica_corsostudio asc , getcostididattica_sede asc , aa asc , aaprogrammata asc , getcostididattica_curriculum asc , getcostididattica_insegnamento asc , getcostididattica_modulo asc , getcostididattica_affidamento asc , getcostididattica_docente asc , getcostididattica_ruolo asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getcostididatticadefaultview', new meta_getcostididatticadefaultview('getcostididatticadefaultview'));

	}());
