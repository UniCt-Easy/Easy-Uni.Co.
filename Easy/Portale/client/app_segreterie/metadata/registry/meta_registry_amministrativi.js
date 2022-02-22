
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

    function meta_registry_amministrativi() {
        MetaData.apply(this, ["registry_amministrativi"]);
        this.name = 'meta_registry_amministrativi';
    }

    meta_registry_amministrativi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_amministrativi,
			superClass: MetaData.prototype,

			//$describeColumns$

			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'amministrativi':
						table.columns["cv"].caption = "Curriculum vitae";
						table.columns["idcontrattokind"].caption = "Tipo";
//$innerSetCaptionConfig_amministrativi$
						break;
					case 'amministrativi_personale':
						table.columns["cv"].caption = "Curriculum vitae";
						table.columns["idcontrattokind"].caption = "Tipo";
//$innerSetCaptionConfig_amministrativi_personale$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_amministrativi");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registry_amministrativi', new meta_registry_amministrativi('registry_amministrativi'));

	}());
