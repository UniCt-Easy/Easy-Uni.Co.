
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

    function meta_accordoscambiomidettazsegview() {
        MetaData.apply(this, ["accordoscambiomidettazsegview"]);
        this.name = 'meta_accordoscambiomidettazsegview';
    }

    meta_accordoscambiomidettazsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomidettazsegview,
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
						this.describeAColumn(table, 'registryaziende_title', 'Azienda', null, 30, 101);
						this.describeAColumn(table, 'accordoscambiomidettaz_numstud', 'Numero di studenti', null, 40, null);
						this.describeAColumn(table, 'accordoscambiomidettaz_stipula', 'Data di stipula', null, 50, null);
						this.describeAColumn(table, 'accordoscambiomidettaz_stop', 'Data di termine', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg_aziende", "idaccordoscambiomi", "idaccordoscambiomidettaz"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('accordoscambiomidettazsegview', new meta_accordoscambiomidettazsegview('accordoscambiomidettazsegview'));

	}());
