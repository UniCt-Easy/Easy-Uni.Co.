
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

    function meta_stipendio() {
        MetaData.apply(this, ["stipendio"]);
        this.name = 'meta_stipendio';
    }

    meta_stipendio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_stipendio,
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
						this.describeAColumn(table, '!previdenza', 'Opera di previdenza', 'fixed.2', 0, null);
						this.describeAColumn(table, '!tesoro', 'Tesoro', 'fixed.2', 0, null);
						this.describeAColumn(table, '!totalece', 'Totale a carico ente', 'fixed.2', 0, null);
						this.describeAColumn(table, '!tredicesima', 'Tredicesima', 'fixed.2', 0, null);
						this.describeAColumn(table, 'classe', 'Classe', null, 10, null);
						this.describeAColumn(table, 'scatto', 'Scatto', null, 20, null);
						this.describeAColumn(table, 'stipendio', 'Stipendio', 'fixed.2', 30, null);
						this.describeAColumn(table, 'iis', 'Indennità integrativa speciale', 'fixed.2', 40, null);
						this.describeAColumn(table, 'assegno', 'Assegno aggiuntivo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'lordo', 'Retribuzione totale lorda', 'fixed.2', 60, null);
						this.describeAColumn(table, 'irap', 'IRAP', 'fixed.2', 70, null);
						this.describeAColumn(table, 'totale', 'Totale costo annuo', 'fixed.2', 110, null);
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
						table.columns["!previdenza"].caption = "Opera di previdenza";
						table.columns["!tesoro"].caption = "Tesoro";
						table.columns["!totalece"].caption = "Totale a carico ente";
						table.columns["!tredicesima"].caption = "Tredicesima";
						table.columns["assegno"].caption = "Assegno aggiuntivo";
						table.columns["iis"].caption = "Indennità integrativa speciale";
						table.columns["irap"].caption = "IRAP";
						table.columns["lordo"].caption = "Retribuzione totale lorda";
						table.columns["siglaimportazione"].caption = "Sigla importazione";
						table.columns["totale"].caption = "Totale costo annuo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_stipendio");

				//$getNewRowInside$

				dt.autoIncrement('idstipendio', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('stipendio', new meta_stipendio('stipendio'));

	}());
