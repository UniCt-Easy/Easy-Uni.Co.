
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

    function meta_getcontratti() {
        MetaData.apply(this, ["getcontratti"]);
        this.name = 'meta_getcontratti';
    }

    meta_getcontratti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcontratti,
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
						this.describeAColumn(table, 'title', 'Ruolo/Figura contrattuale', null, 10, 50);
						this.describeAColumn(table, 'costolordoannuo', 'Costo lordo annuo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'costomese', 'Costo mensile', 'fixed.2', 30, null);
						this.describeAColumn(table, 'costoora', 'Costo orario', 'fixed.2', 40, null);
						this.describeAColumn(table, 'oremax', 'Oremax', null, 90, null);
						this.describeAColumn(table, 'oremaxdida', 'Oremaxdida', null, 100, null);
						this.describeAColumn(table, 'oremaxgg', 'Oremaxgg', null, 110, null);
						this.describeAColumn(table, 'oremindida', 'Oremindida', null, 120, null);
						this.describeAColumn(table, 'parttime', 'Percentuale part-time', 'fixed.2', 130, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 140, null);
						this.describeAColumn(table, 'start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'stop', 'Fine', null, 160, null);
						this.describeAColumn(table, 'tempdef', 'Tempo definito', null, 170, null);
						this.describeAColumn(table, 'totale_inquadramento', 'Totale_inquadramento', 'fixed.2', 180, null);
						this.describeAColumn(table, 'totale_stipendioannuo', 'Totale_stipendioannuo', 'fixed.2', 190, null);
						this.describeAColumn(table, 'totale_tabellastipendiale', 'Totale_tabellastipendiale', 'fixed.2', 200, null);
						this.describeAColumn(table, 'totale_tipologiacontrattuale', 'Totale_tipologiacontrattuale', 'fixed.2', 210, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["costolordoannuo"].caption = "Costo lordo annuo";
						table.columns["costomese"].caption = "Costo mensile";
						table.columns["costoora"].caption = "Costo orario";
						table.columns["idcontratto"].caption = "Contratto";
						table.columns["idcontrattokind"].caption = "id Ruolo/Figura contrattuale";
						table.columns["idinquadramento"].caption = "Inquadramento";
						table.columns["idreg"].caption = "Dipendente";
						table.columns["parttime"].caption = "Percentuale part-time";
						table.columns["start"].caption = "Inizio";
						table.columns["stop"].caption = "Fine";
						table.columns["tempdef"].caption = "Tempo definito";
						table.columns["title"].caption = "Ruolo/Figura contrattuale";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_getcontratti");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
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

    window.appMeta.addMeta('getcontratti', new meta_getcontratti('getcontratti'));

	}());
