
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

    function meta_afferenzastruview() {
        MetaData.apply(this, ["afferenzastruview"]);
        this.name = 'meta_afferenzastruview';
    }

    meta_afferenzastruview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_afferenzastruview,
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
					case 'stru':
						this.describeAColumn(table, 'mansionekind_title', 'Mansione', null, 20, 2048);
						this.describeAColumn(table, 'registry_title', 'Membro del personale', null, 30, 101);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura', null, 40, 1024);
						this.describeAColumn(table, 'afferenza_start', 'Dal ', null, 50, null);
						this.describeAColumn(table, 'afferenza_stop', 'Al ', null, 60, null);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
//$objCalcFieldConfig_stru$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idafferenza", "idstruttura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('afferenzastruview', new meta_afferenzastruview('afferenzastruview'));

	}());
