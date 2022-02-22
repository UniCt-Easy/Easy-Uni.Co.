
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

    function meta_learningagrstudsegview() {
        MetaData.apply(this, ["learningagrstudsegview"]);
        this.name = 'meta_learningagrstudsegview';
    }

    meta_learningagrstudsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrstudsegview,
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
						this.describeAColumn(table, 'learningagrkind_title', 'Tipologia Tipologia di learning agreement', null, 50, 50);
						this.describeAColumn(table, 'learningagrkind_description', 'Descrizione Tipologia di learning agreement', null, 50, 256);
						this.describeAColumn(table, 'registryistitutiesteri_title', 'Istituto', null, 70, 101);
						this.describeAColumn(table, 'learningagrstud_note', 'Note', null, 80, -1);
						this.describeAColumn(table, 'learningagrstud_start', 'Data di inizio', null, 90, null);
						this.describeAColumn(table, 'learningagrstud_stop', 'Data di fine', null, 100, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idbandomi", "idiscrizionebmi", "idlearningagrstud"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('learningagrstudsegview', new meta_learningagrstudsegview('learningagrstudsegview'));

	}());
