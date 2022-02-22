
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

    function meta_mansionekind() {
        MetaData.apply(this, ["mansionekind"]);
        this.name = 'meta_mansionekind';
    }

    meta_mansionekind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mansionekind,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'pesoateneo', 'Peso della valutazione della performance organizzativa di ateneo', 'fixed.2', 70, null);
						this.describeAColumn(table, 'pesouo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 80, null);
						this.describeAColumn(table, 'pesocomp', 'Peso della valutazione della performance dei comportamenti', 'fixed.2', 90, null);
						this.describeAColumn(table, 'pesoindividuale', 'Peso della valutazione della performance individuale', 'fixed.2', 100, null);
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
						table.columns["title"].caption = "Titolo";
						table.columns["pesoateneo"].caption = "Peso della valutazione della performance organizzativa di ateneo";
						table.columns["pesoindividuale"].caption = "Peso della valutazione della performance individuale";
						table.columns["pesouo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["pesocomp"].caption = "Peso della valutazione della performance dei comportamenti";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_mansionekind");

				//$getNewRowInside$

				dt.autoIncrement('idmansionekind', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('mansionekind', new meta_mansionekind('mansionekind'));

	}());
