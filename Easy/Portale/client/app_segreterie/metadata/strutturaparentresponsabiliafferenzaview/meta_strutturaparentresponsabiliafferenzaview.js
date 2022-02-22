
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_strutturaparentresponsabiliafferenzaview() {
        MetaData.apply(this, ["strutturaparentresponsabiliafferenzaview"]);
        this.name = 'meta_strutturaparentresponsabiliafferenzaview';
    }

    meta_strutturaparentresponsabiliafferenzaview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaparentresponsabiliafferenzaview,
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
						this.describeAColumn(table, 'title', 'Title', null, 10, 1024);
						this.describeAColumn(table, 'afferente_idreg', 'Identificativo', null, 20, null);
						this.describeAColumn(table, 'afferente_title', 'Afferente_title', null, 30, 101);
						this.describeAColumn(table, 'idperfruolo', 'Identificativo', null, 40, 50);
						this.describeAColumn(table, 'registry_title', 'Registry_title', null, 80, 101);
						this.describeAColumn(table, 'start', 'Start', null, 90, null);
						this.describeAColumn(table, 'stop', 'Stop', null, 100, null);
						this.describeAColumn(table, 'strutturaresponsabile_start', 'Strutturaresponsabile_start', null, 110, null);
						this.describeAColumn(table, 'strutturaresponsabile_stop', 'Strutturaresponsabile_stop', null, 120, null);
						this.describeAColumn(table, 'titlestrutturaparent', 'Titlestrutturaparent', null, 130, 1024);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idperfruolo", "idstruttura", "idstruttura_parent"];
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

    window.appMeta.addMeta('strutturaparentresponsabiliafferenzaview', new meta_strutturaparentresponsabiliafferenzaview('strutturaparentresponsabiliafferenzaview'));

	}());
