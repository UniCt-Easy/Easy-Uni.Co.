
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

    function meta_getcontrattidefaultview() {
        MetaData.apply(this, ["getcontrattidefaultview"]);
        this.name = 'meta_getcontrattidefaultview';
    }

    meta_getcontrattidefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcontrattidefaultview,
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
						this.describeAColumn(table, 'contrattokind_title', 'Tipologia Tipologia di contratto', null, 10, 50);
						this.describeAColumn(table, 'contratto_idcontrattokind', 'Tipologia di contratto Tipologia di contratto', null, 10, null);
						this.describeAColumn(table, 'inquadramento_idcontrattokind', 'Identificativo Inquadramento', null, 20, null);
						this.describeAColumn(table, 'inquadramento_title', 'Denominazione Inquadramento', null, 20, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito Inquadramento', null, 20, null);
						this.describeAColumn(table, 'contratto_idinquadramento', 'Inquadramento Inquadramento', null, 20, null);
						this.describeAColumn(table, 'title', 'Ruolo/Figura contrattuale', null, 10, 50);
						this.describeAColumn(table, 'getcontratti_costolordoannuo', 'Costo lordo annuo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'getcontratti_costomese', 'Costo mensile', 'fixed.2', 30, null);
						this.describeAColumn(table, 'getcontratti_costoora', 'Costo orario', 'fixed.2', 40, null);
						this.describeAColumn(table, 'contratto_start', 'Inizio Contratto', null, 50, null);
						this.describeAColumn(table, 'contratto_stop', 'Fine Contratto', null, 50, null);
						this.describeAColumn(table, 'contrattokind_getcontratti_title', 'id Ruolo/Figura contrattuale', null, 60, 50);
						this.describeAColumn(table, 'inquadramento_getcontratti_idcontrattokind', 'Identificativo Inquadramento', null, 70, null);
						this.describeAColumn(table, 'inquadramento_getcontratti_title', 'Denominazione Inquadramento', null, 70, 2048);
						this.describeAColumn(table, 'inquadramento_getcontratti_tempdef', 'Tempo definito Inquadramento', null, 70, null);
						this.describeAColumn(table, 'registry_title', 'Dipendente', null, 80, 101);
						this.describeAColumn(table, 'getcontratti_oremax', 'Oremax', null, 90, null);
						this.describeAColumn(table, 'getcontratti_oremaxdida', 'Oremaxdida', null, 100, null);
						this.describeAColumn(table, 'getcontratti_oremaxgg', 'Oremaxgg', null, 110, null);
						this.describeAColumn(table, 'getcontratti_oremindida', 'Oremindida', null, 120, null);
						this.describeAColumn(table, 'getcontratti_parttime', 'Percentuale part-time', 'fixed.2', 130, null);
						this.describeAColumn(table, 'getcontratti_scatto', 'Scatto', null, 140, null);
						this.describeAColumn(table, 'getcontratti_start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'getcontratti_stop', 'Fine', null, 160, null);
						this.describeAColumn(table, 'getcontratti_tempdef', 'Tempo definito', null, 170, null);
						this.describeAColumn(table, 'getcontratti_totale_inquadramento', 'Totale_inquadramento', 'fixed.2', 180, null);
						this.describeAColumn(table, 'getcontratti_totale_stipendioannuo', 'Totale_stipendioannuo', 'fixed.2', 190, null);
						this.describeAColumn(table, 'getcontratti_totale_tabellastipendiale', 'Totale_tabellastipendiale', 'fixed.2', 200, null);
						this.describeAColumn(table, 'getcontratti_totale_tipologiacontrattuale', 'Totale_tipologiacontrattuale', 'fixed.2', 210, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontratto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('getcontrattidefaultview', new meta_getcontrattidefaultview('getcontrattidefaultview'));

	}());
