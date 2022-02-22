
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

    function meta_ambitoareadiscdefaultview() {
        MetaData.apply(this, ["ambitoareadiscdefaultview"]);
        this.name = 'meta_ambitoareadiscdefaultview';
    }

    meta_ambitoareadiscdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ambitoareadiscdefaultview,
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
						this.describeAColumn(table, 'title', 'Ambito', null, 20, 256);
						this.describeAColumn(table, 'classescuola_sigla', 'Sigla Scuola / Classe di laurea', null, 30, 50);
						this.describeAColumn(table, 'classescuola_title', 'Denominazione Scuola / Classe di laurea', null, 30, 256);
						this.describeAColumn(table, 'tipoattform_title', 'Denominazione Tipo attività formativa', null, 40, 1);
						this.describeAColumn(table, 'tipoattform_description', 'Descrizione Tipo attività formativa', null, 40, 256);
						this.describeAColumn(table, 'ambitoareadisc_sortcode', 'Ordinamento', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idambitoareadisc"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "classescuola_sigla desc, classescuola_title desc, tipoattform_title desc, tipoattform_description desc, ambitoareadisc_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('ambitoareadiscdefaultview', new meta_ambitoareadiscdefaultview('ambitoareadiscdefaultview'));

	}());
