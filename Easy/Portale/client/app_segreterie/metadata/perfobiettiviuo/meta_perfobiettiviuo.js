
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

    function meta_perfobiettiviuo() {
        MetaData.apply(this, ["perfobiettiviuo"]);
        this.name = 'meta_perfobiettiviuo';
    }

    meta_perfobiettiviuo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfobiettiviuo,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 40, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
						this.describeAColumn(table, '!perfobiettiviuosoglia', 'Soglie', null, 50, null);
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
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Titolo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfobiettiviuo");

				//$getNewRowInside$

				dt.autoIncrement('idperfobiettiviuo', { minimum: 99990001 });

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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfobiettiviuo', new meta_perfobiettiviuo('perfobiettiviuo'));

	}());
