
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

    function meta_getdocentiperssdsegview() {
        MetaData.apply(this, ["getdocentiperssdsegview"]);
        this.name = 'meta_getdocentiperssdsegview';
    }

    meta_getdocentiperssdsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getdocentiperssdsegview,
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
						this.describeAColumn(table, 'getdocentiperssd_costoorario', 'Costo orario', 'fixed.2', 10, null);
						this.describeAColumn(table, 'getdocentiperssd_oreperaacontratto', 'Ore già impegnate nell\'AA per contratto', null, 20, null);
						this.describeAColumn(table, 'getdocentiperssd_oreperaaaffidamento', 'Ore già impegnate nell\'AA per affidamenti', null, 30, null);
						this.describeAColumn(table, 'getdocentiperssd_oremindida', 'Ore minime di didattica', null, 40, null);
						this.describeAColumn(table, 'getdocentiperssd_oremaxdida', 'Ore massime di didattica', null, 50, null);
						this.describeAColumn(table, 'cognome', 'Cognome', null, 60, 50);
						this.describeAColumn(table, 'getdocentiperssd_nome', 'Nome', null, 70, 50);
						this.describeAColumn(table, 'getdocentiperssd_matricola', 'Matricola', null, 80, 50);
						this.describeAColumn(table, 'getdocentiperssd_ssd', 'Ssd', null, 90, 50);
						this.describeAColumn(table, 'getdocentiperssd_contratto', 'Contratto', null, 100, 50);
						this.describeAColumn(table, 'getdocentiperssd_iniziocontratto', 'Data di inizio del contratto', null, 110, null);
						this.describeAColumn(table, 'getdocentiperssd_terminecontratto', 'Data di fine del contratto', null, 120, null);
						this.describeAColumn(table, 'getdocentiperssd_parttime', 'Part-time', 'fixed.2', 130, null);
						this.describeAColumn(table, 'getdocentiperssd_tempodefinito', 'Tempo definito', null, 140, null);
						this.describeAColumn(table, 'getdocentiperssd_struttura', 'Struttura', null, 150, 1024);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "getdocentiperssd_costoorario asc , getdocentiperssd_oreperaacontratto asc , getdocentiperssd_oreperaaaffidamento asc , getdocentiperssd_ssd desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getdocentiperssdsegview', new meta_getdocentiperssdsegview('getdocentiperssdsegview'));

	}());
