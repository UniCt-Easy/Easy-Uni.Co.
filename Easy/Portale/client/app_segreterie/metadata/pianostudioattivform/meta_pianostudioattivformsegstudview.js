
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

    function meta_pianostudioattivformsegstudview() {
        MetaData.apply(this, ["pianostudioattivformsegstudview"]);
        this.name = 'meta_pianostudioattivformsegstudview';
    }

    meta_pianostudioattivformsegstudview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioattivformsegstudview,
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
					case 'segstud':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 20, null);
						this.describeAColumn(table, 'attivform_title', 'Attività formativa del corso', null, 30, -1);
						this.describeAColumn(table, 'attivform_scelta_title', 'Attività formativa che lo studente svolgerà', null, 40, -1);
//$objCalcFieldConfig_segstud$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio", "idpianostudio", "idpianostudioattivform"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('pianostudioattivformsegstudview', new meta_pianostudioattivformsegstudview('pianostudioattivformsegstudview'));

	}());
