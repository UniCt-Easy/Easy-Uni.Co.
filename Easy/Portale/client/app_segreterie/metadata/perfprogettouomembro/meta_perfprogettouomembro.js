
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

    function meta_perfprogettouomembro() {
        MetaData.apply(this, ["perfprogettouomembro"]);
        this.name = 'meta_perfprogettouomembro';
    }

    meta_perfprogettouomembro.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettouomembro,
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
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome', null, 12, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome', null, 14, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_cf', 'CF', null, 13, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto', null, 17, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_istituto', 'Istituto', null, 15, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_ssd', 'SSD', null, 16, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_struttura', 'Struttura', null, 17, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_cf'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'cf', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_istituto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'istituto', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_ssd'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'ssd', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_struttura'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'struttura', columnNamekey:'idreg' };
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
               var def = appMeta.Deferred("getNewRow-meta_perfprogettouomembro");

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
					case "default": {
						return "idreg_amministrativi asc ";
					}
					case "default": {
						return "idreg asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfprogettouomembro', new meta_perfprogettouomembro('perfprogettouomembro'));

	}());
