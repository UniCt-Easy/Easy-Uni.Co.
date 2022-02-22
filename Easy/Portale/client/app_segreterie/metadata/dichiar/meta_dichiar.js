
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

    function meta_dichiar() {
        MetaData.apply(this, ["dichiar"]);
        this.name = 'meta_dichiar';
    }

    meta_dichiar.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar,
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
					case 'titolo_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico della dichiarazione', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_titolo_seg$
						break;
					case 'disabil_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_disabil_seg$
						break;
					case 'altre_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_altre_seg$
						break;
					case 'altrititoli_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 580, 9);
						this.describeAColumn(table, 'date', 'Data', null, 590, null);
//$objCalcFieldConfig_altrititoli_seg$
						break;
					case 'isee_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_isee_seg$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'titolo_seg':
						table.columns["aa"].caption = "Anno accademico della dichiarazione";
//$innerSetCaptionConfig_titolo_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_dichiar");

				//$getNewRowInside$

				dt.autoIncrement('iddichiar', { minimum: 99990001 });

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

    window.appMeta.addMeta('dichiar', new meta_dichiar('dichiar'));

	}());
