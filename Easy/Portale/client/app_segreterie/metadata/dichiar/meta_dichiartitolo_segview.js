
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

    function meta_dichiartitolo_segview() {
        MetaData.apply(this, ["dichiartitolo_segview"]);
        this.name = 'meta_dichiartitolo_segview';
    }

    meta_dichiartitolo_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiartitolo_segview,
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
					case 'titolo_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico della dichiarazione', null, 10, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 40, 101);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di studio', null, 50, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di studio', null, 50, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di studio', null, 50, null);
//$objCalcFieldConfig_titolo_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddichiar"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiartitolo_segview', new meta_dichiartitolo_segview('dichiartitolo_segview'));

	}());
