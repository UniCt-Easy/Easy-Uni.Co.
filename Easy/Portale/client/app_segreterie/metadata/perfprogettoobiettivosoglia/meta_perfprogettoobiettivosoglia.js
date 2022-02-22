
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

    function meta_perfprogettoobiettivosoglia() {
        MetaData.apply(this, ["perfprogettoobiettivosoglia"]);
        this.name = 'meta_perfprogettoobiettivosoglia';
    }

    meta_perfprogettoobiettivosoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivosoglia,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Soglia', null, 50, 50);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 60, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 110, -1);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 120, null);
//$objCalcFieldConfig_default$
						break;
					case 'soglia':
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, -1);
						this.describeAColumn(table, 'idperfsogliakind', 'Soglia', null, 50, 50);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 60, null);
//$objCalcFieldConfig_soglia$
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
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfsogliakind"].caption = "Soglia";
						table.columns["percentuale"].caption = "Percentuale";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoobiettivosoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoobiettivosoglia', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivosoglia', new meta_perfprogettoobiettivosoglia('perfprogettoobiettivosoglia'));

	}());
