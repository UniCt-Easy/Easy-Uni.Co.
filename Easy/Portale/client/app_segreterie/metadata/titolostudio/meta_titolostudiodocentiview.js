
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

    function meta_titolostudiodocentiview() {
        MetaData.apply(this, ["titolostudiodocentiview"]);
        this.name = 'meta_titolostudiodocentiview';
    }

    meta_titolostudiodocentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_titolostudiodocentiview,
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
					case 'docenti':
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo ISTAT', null, 10, 1024);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto', null, 20, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su', null, 30, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode', null, 40, null);
						this.describeAColumn(table, 'aa', 'Anno accademco', null, 50, 9);
						this.describeAColumn(table, 'registryistituti_title', 'Istituto', null, 60, 101);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idtitolostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('titolostudiodocentiview', new meta_titolostudiodocentiview('titolostudiodocentiview'));

	}());
