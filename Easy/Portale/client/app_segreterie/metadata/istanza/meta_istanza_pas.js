
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

    function meta_istanza_pas() {
        MetaData.apply(this, ["istanza_pas"]);
        this.name = 'meta_istanza_pas';
    }

    meta_istanza_pas.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_pas,
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
					case 'seganagstu':
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione di partenza', null, 511, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione di partenza', null, 513, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione di partenza', null, 511, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione di partenza', null, 512, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione di partenza', null, 513, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione_alias6', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione_alias6', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_pas");

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

    window.appMeta.addMeta('istanza_pas', new meta_istanza_pas('istanza_pas'));

	}());
