
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

    function meta_perfinterazioni() {
        MetaData.apply(this, ["perfinterazioni"]);
        this.name = 'meta_perfinterazioni';
    }

    meta_perfinterazioni.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfinterazioni,
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
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'commentival', 'Commenti valutatore', null, 30, -1);
						this.describeAColumn(table, 'commenti', 'Commenti valutato', null, 40, -1);
						this.describeAColumn(table, '!idperfinterazionekind_perfinterazionekind_title', 'Tipo di interazione', null, 11, null);
						objCalcFieldConfig['!idperfinterazionekind_perfinterazionekind_title'] = { tableNameLookup:'perfinterazionekind', columnNameLookup:'title', columnNamekey:'idperfinterazionekind' };
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
						table.columns["commenti"].caption = "Commenti valutato";
						table.columns["commentival"].caption = "Commenti valutatore";
						table.columns["data"].caption = "Data";
						table.columns["idperfinterazionekind"].caption = "Tipo di interazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfinterazioni");

				//$getNewRowInside$

				dt.autoIncrement('idperfinterazioni', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfinterazioni', new meta_perfinterazioni('perfinterazioni'));

	}());
