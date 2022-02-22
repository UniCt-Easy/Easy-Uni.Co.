
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

    function meta_commiss() {
        MetaData.apply(this, ["commiss"]);
        this.name = 'meta_commiss';
    }

    meta_commiss.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_commiss,
			superClass: MetaData.prototype,

			//$describeColumns$

			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'ingresso':
						table.columns["idreg_docenti"].caption = "Verbalizzante";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'default':
						table.columns["idreg_docenti"].caption = "Verbalizzante";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_commiss");

				//$getNewRowInside$

				dt.autoIncrement('idcommiss', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "ingresso": {
						return "idcommiss asc ";
					}
					case "default": {
						return "idcommiss asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('commiss', new meta_commiss('commiss'));

	}());
