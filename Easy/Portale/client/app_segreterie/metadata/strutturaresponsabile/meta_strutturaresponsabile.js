
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

    function meta_strutturaresponsabile() {
        MetaData.apply(this, ["strutturaresponsabile"]);
        this.name = 'meta_strutturaresponsabile';
    }

    meta_strutturaresponsabile.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaresponsabile,
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
						this.describeAColumn(table, 'idperfruolo', 'Ruolo ', null, 20, 50);
						this.describeAColumn(table, 'start', 'Data inizio validità', null, 50, null);
						this.describeAColumn(table, 'stop', 'Data fine validità', null, 60, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Membro del personale', null, 31, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg' };
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
						table.columns["idperfruolo"].caption = "Ruolo ";
						table.columns["idreg"].caption = "Membro del personale";
						table.columns["start"].caption = "Data inizio validità";
						table.columns["stop"].caption = "Data fine validità";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_strutturaresponsabile");

				//$getNewRowInside$

				dt.autoIncrement('idstrutturaresponsabile', { minimum: 99990001 });

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

    window.appMeta.addMeta('strutturaresponsabile', new meta_strutturaresponsabile('strutturaresponsabile'));

	}());
