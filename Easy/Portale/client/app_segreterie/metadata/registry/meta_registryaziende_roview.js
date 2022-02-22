
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

    function meta_registryaziende_roview() {
        MetaData.apply(this, ["registryaziende_roview"]);
        this.name = 'meta_registryaziende_roview';
    }

    meta_registryaziende_roview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryaziende_roview,
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
					case 'aziende_ro':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'registryclass_description', 'Tipologia', null, 20, 150);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'geo_nation_title', 'Nazionalità', null, 110, 65);
						this.describeAColumn(table, 'registry_flag_pa', 'Ente pubblico', null, 1000, null);
						this.describeAColumn(table, 'ateco_codice', 'Codice Classificazione Ateco', null, 70, 50);
						this.describeAColumn(table, 'ateco_title', 'Titolo Classificazione Ateco', null, 70, 255);
						this.describeAColumn(table, 'naturagiur_title', 'Natura Giuridica', null, 80, 200);
						this.describeAColumn(table, 'numerodip_title', 'Numero di dipendenti', null, 90, 50);
						this.describeAColumn(table, 'nace_idnace', 'Identificativo NACE', null, 100, 50);
						this.describeAColumn(table, 'nace_activity', 'Activity NACE', null, 100, -1);
						this.describeAColumn(table, 'registry_aziende_pic', 'Participant Identification Code (PIC)', null, 120, 10);
//$objCalcFieldConfig_aziende_ro$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "aziende_ro": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('registryaziende_roview', new meta_registryaziende_roview('registryaziende_roview'));

	}());
