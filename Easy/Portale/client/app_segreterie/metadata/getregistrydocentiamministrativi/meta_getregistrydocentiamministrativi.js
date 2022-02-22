
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

    function meta_getregistrydocentiamministrativi() {
        MetaData.apply(this, ["getregistrydocentiamministrativi"]);
        this.name = 'meta_getregistrydocentiamministrativi';
    }

    meta_getregistrydocentiamministrativi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getregistrydocentiamministrativi,
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
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 50);
						this.describeAColumn(table, 'extmatricula', 'Extmatricula', null, 30, 40);
						this.describeAColumn(table, 'cf', 'CF', null, 40, 16);
						this.describeAColumn(table, 'contratto', 'Contratto', null, 50, 50);
						this.describeAColumn(table, 'ssd', 'SSD', null, 60, 50);
						this.describeAColumn(table, 'struttura', 'Struttura', null, 70, 1024);
						this.describeAColumn(table, 'istituto', 'Istituto', null, 80, 101);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["cf"].caption = "CF";
						table.columns["forename"].caption = "Nome";
						table.columns["ssd"].caption = "SSD";
						table.columns["surname"].caption = "Cognome";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_getregistrydocentiamministrativi");

				//$getNewRowInside$

				dt.autoIncrement('idreg', { minimum: 99990001 });

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
					case "default": {
						return "surname ASC , forename ASC ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getregistrydocentiamministrativi', new meta_getregistrydocentiamministrativi('getregistrydocentiamministrativi'));

	}());
