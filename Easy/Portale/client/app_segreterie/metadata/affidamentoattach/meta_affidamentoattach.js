
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

    function meta_affidamentoattach() {
        MetaData.apply(this, ["affidamentoattach"]);
        this.name = 'meta_affidamentoattach';
    }

    meta_affidamentoattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentoattach,
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
					case 'seganag':
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 30, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 30, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						objCalcFieldConfig['!idattach_attach_size'] = { tableNameLookup:'attach', columnNameLookup:'size', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 33, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 35, null);
//$objCalcFieldConfig_seganag$
						break;
					case 'default':
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 30, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 30, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						objCalcFieldConfig['!idattach_attach_size'] = { tableNameLookup:'attach', columnNameLookup:'size', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Nome del file', null, 33, null);
						this.describeAColumn(table, '!idattach_attach_size', 'Dimensione', null, 35, null);
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
               var def = appMeta.Deferred("getNewRow-meta_affidamentoattach");

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

    window.appMeta.addMeta('affidamentoattach', new meta_affidamentoattach('affidamentoattach'));

	}());
