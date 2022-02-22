
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

    function meta_virtualuser() {
        MetaData.apply(this, ["virtualuser"]);
        this.name = 'meta_virtualuser';
    }

    meta_virtualuser.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_virtualuser,
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
						this.describeAColumn(table, 'birthdate', 'Birthdate', null, 20, null);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'codicedipartimento', 'Codicedipartimento', null, 40, 50);
						this.describeAColumn(table, 'email', 'Email', null, 50, 200);
						this.describeAColumn(table, 'forename', 'Forename', null, 60, 50);
						this.describeAColumn(table, 'surname', 'Cognome', null, 70, 50);
						this.describeAColumn(table, 'sys_user', 'Sys_user', null, 80, 30);
						this.describeAColumn(table, 'username', 'Username', null, 100, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
                                               var def = appMeta.Deferred("getNewRow-meta_protocollo");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				// metto i default
				var objRow = dt.newRow({
					codicedipartimento: "amministrazione",
					userkind: 1
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('virtualuser', new meta_virtualuser('virtualuser'));

	}());
