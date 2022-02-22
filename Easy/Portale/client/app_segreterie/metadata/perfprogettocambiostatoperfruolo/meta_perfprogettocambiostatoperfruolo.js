
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

    function meta_perfprogettocambiostatoperfruolo() {
        MetaData.apply(this, ["perfprogettocambiostatoperfruolo"]);
        this.name = 'meta_perfprogettocambiostatoperfruolo';
    }

    meta_perfprogettocambiostatoperfruolo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocambiostatoperfruolo,
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
					case 'maildest':
						this.describeAColumn(table, 'idperfruolo', 'Codice', null, 10, 50);
//$objCalcFieldConfig_maildest$
						break;
					case 'default':
						this.describeAColumn(table, 'idperfruolo', 'Codice', null, 10, 50);
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
					case 'maildest':
						table.columns["idperfruolo"].caption = "Codice";
//$innerSetCaptionConfig_maildest$
						break;
					case 'default':
						table.columns["idperfruolo"].caption = "Codice";
						table.columns["idperfruolo"].caption = "Ruolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettocambiostatoperfruolo");

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

			getSorting: function (listType) {
				switch (listType) {
					case "maildest": {
						return "idperfruolo desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettocambiostatoperfruolo', new meta_perfprogettocambiostatoperfruolo('perfprogettocambiostatoperfruolo'));

	}());
