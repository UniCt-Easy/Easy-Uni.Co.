
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

    function meta_publicazdefaultview() {
        MetaData.apply(this, ["publicazdefaultview"]);
        this.name = 'meta_publicazdefaultview';
    }

    meta_publicazdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazdefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 512);
						this.describeAColumn(table, 'publicaz_title2', 'Sottotitolo', null, 30, 512);
						this.describeAColumn(table, 'publicaz_annopub', 'Anno pubblicazione', null, 40, null);
						this.describeAColumn(table, 'publicaz_editore', 'Editore', null, 50, 150);
						this.describeAColumn(table, 'progetto_titolobreve', 'Idprogetto', null, 60, 2048);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idpublicaz"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc , publicaz_title2 asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('publicazdefaultview', new meta_publicazdefaultview('publicazdefaultview'));

	}());
