
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

    function meta_nullaosta() {
        MetaData.apply(this, ["nullaosta"]);
        this.name = 'meta_nullaosta';
    }

    meta_nullaosta.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_nullaosta,
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
					case 'segisteq':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segisteq$
						break;
					case 'segistsosp':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segistsosp$
						break;
					case 'segistrin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segistrin$
						break;
					case 'segisttru':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segisttru$
						break;
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagstupre$
						break;
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segistrein$
						break;
					case 'segpratica':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_segpratica$
						break;
					case 'imm_seganagstu':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_nullaosta");

				//$getNewRowInside$

				dt.autoIncrement('idnullaosta', { minimum: 99990001 });

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

    window.appMeta.addMeta('nullaosta', new meta_nullaosta('nullaosta'));

	}());
