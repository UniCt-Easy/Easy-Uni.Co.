
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

    function meta_tirociniopropostosegview() {
        MetaData.apply(this, ["tirociniopropostosegview"]);
        this.name = 'meta_tirociniopropostosegview';
    }

    meta_tirociniopropostosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirociniopropostosegview,
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
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 10, -1);
						this.describeAColumn(table, 'aoo_title', 'Area organizzativa omogenea', null, 40, 1024);
						this.describeAColumn(table, 'registryreferente_title', 'Referente', null, 50, 101);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura dell\'istituto', null, 60, 1024);
						this.describeAColumn(table, 'tirocinioproposto_ore', 'Ore', null, 80, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg_referente", "idtirocinioproposto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirociniopropostosegview', new meta_tirociniopropostosegview('tirociniopropostosegview'));

	}());
