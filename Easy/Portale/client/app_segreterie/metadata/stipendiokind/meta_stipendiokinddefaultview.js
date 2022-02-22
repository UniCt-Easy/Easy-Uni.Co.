
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

    function meta_stipendiokinddefaultview() {
        MetaData.apply(this, ["stipendiokinddefaultview"]);
        this.name = 'meta_stipendiokinddefaultview';
    }

    meta_stipendiokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_stipendiokinddefaultview,
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
						this.describeAColumn(table, 'contrattokind_title', 'Ruolo', null, 10, 50);
						this.describeAColumn(table, 'inquadramento_idcontrattokind', 'Codice Inquadramento', null, 20, null);
						this.describeAColumn(table, 'inquadramento_title', 'Titolo Inquadramento', null, 20, 2048);
						this.describeAColumn(table, 'stipendiokind_scatto', 'Scatto', null, 30, null);
						this.describeAColumn(table, 'stipendiokind_tempdef', 'Tempo definito', null, 40, null);
						this.describeAColumn(table, 'stipendiokind_assegnoaggiuntivo', 'Assegno aggiuntivo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'stipendiokind_indennitadiateneo', 'Indennità di ateneo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'stipendiokind_indennitadiposizione', 'Indennità di posizione', 'fixed.2', 70, null);
						this.describeAColumn(table, 'stipendiokind_indintegrativaspeciale', 'Indennità integrativa speciale', 'fixed.2', 80, null);
						this.describeAColumn(table, 'stipendiokind_indvacancacontrattuale', 'Indennità vacanca contrattuale', 'fixed.2', 90, null);
						this.describeAColumn(table, 'stipendiokind_irap', 'IRAP', 'fixed.2', 100, null);
						this.describeAColumn(table, 'stipendiokind_oneriprevidenzialicaricoente', 'Oneri previdenziali a carico dell\'ente', 'fixed.2', 110, null);
						this.describeAColumn(table, 'stipendiokind_retribuzione', 'Retribuzione', 'fixed.2', 120, null);
						this.describeAColumn(table, 'stipendiokind_elementoperequativo', 'Elemento perequativo', 'fixed.2', 130, null);
						this.describeAColumn(table, 'stipendiokind_totaletredicesima', 'Totale tredicesima', 'fixed.2', 150, null);
						this.describeAColumn(table, 'stipendiokind_tredicesimaindennitaintegrativaspeciale', 'Tredicesima indennità integrativa speciale', 'fixed.2', 160, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstipendiokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "contrattokind_title asc , inquadramento_idcontrattokind asc , inquadramento_title asc , stipendiokind_scatto asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('stipendiokinddefaultview', new meta_stipendiokinddefaultview('stipendiokinddefaultview'));

	}());
