
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_geo_nation() {
        MetaData.apply(this, ["geo_nation"]);
        this.name = 'meta_geo_nation';
    }

    meta_geo_nation.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_nation,
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
					case 'seg5':
						this.describeAColumn(table, 'start', 'Inizio validit�', null, 10, null);
						this.describeAColumn(table, 'stop', 'Fine validit�', null, 20, null);
						this.describeAColumn(table, 'title', 'Nazione', null, 30, 65);
//$objCalcFieldConfig_seg5$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'lang', 'Lingua', null, 40, 64);
						this.describeAColumn(table, 'start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 80, null);
//$objCalcFieldConfig_seg$
						break;
					case 'lingue':
						this.describeAColumn(table, 'lang', 'Lingua', null, 40, 64);
//$objCalcFieldConfig_lingue$
						break;
					case 'segchild':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'lang', 'Lingua', null, 40, 64);
						this.describeAColumn(table, 'start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 80, null);
						this.describeAColumn(table, '!newnation_geo_nation_title', 'Nazione in cui questa � confluita', null, 51, null);
						objCalcFieldConfig['!newnation_geo_nation_title'] = { tableNameLookup:'geo_nation_alias1', columnNameLookup:'title', columnNamekey:'newnation' };
						this.describeAColumn(table, '!oldnation_geo_nation_title', 'Nazione da cui questa � confluita', null, 61, null);
						objCalcFieldConfig['!oldnation_geo_nation_title'] = { tableNameLookup:'geo_nation_alias3', columnNameLookup:'title', columnNamekey:'oldnation' };
//$objCalcFieldConfig_segchild$
						break;
					case 'default':
						this.describeAColumn(table, 'start', 'Inizio validit�', null, 10, null);
						this.describeAColumn(table, 'stop', 'Fine validit�', null, 20, null);
						this.describeAColumn(table, 'title', 'Nazione', null, 30, 65);
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
					case 'seg5':
						table.columns["idcontinent"].caption = "Continente";
						table.columns["start"].caption = "Inizio validit�";
						table.columns["stop"].caption = "Fine validit�";
						table.columns["title"].caption = "Nazione";
//$innerSetCaptionConfig_seg5$
						break;
					case 'seg':
						table.columns["idcontinent"].caption = "Continente";
						table.columns["lang"].caption = "Lingua";
						table.columns["lang"].caption = "Lingua";
//$innerSetCaptionConfig_seg$
						break;
					case 'lingue':
						table.columns["idcontinent"].caption = "Continente";
						table.columns["lang"].caption = "Lingua";
						table.columns["start"].caption = "Inizio validit�";
						table.columns["stop"].caption = "Fine validit�";
						table.columns["title"].caption = "Nazione";
						table.columns["idnation"].caption = "Id nazione (tabella geo_nation)";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["newnation"].caption = "Nazione in cui questa � confluita";
						table.columns["oldnation"].caption = "Nazione da cui questa � confluita";
//$innerSetCaptionConfig_lingue$
						break;
					case 'segchild':
						table.columns["idcontinent"].caption = "Continente";
						table.columns["lang"].caption = "Lingua";
//$innerSetCaptionConfig_segchild$
						break;
					case 'default':
						table.columns["idcontinent"].caption = "Continente";
						table.columns["start"].caption = "Inizio validit�";
						table.columns["stop"].caption = "Fine validit�";
						table.columns["title"].caption = "Nazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_geo_nation");

				//$getNewRowInside$

				dt.autoIncrement('idnation', { minimum: 99990001 });

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
					case "seg5": {
						return "title asc ";
					}
					case "seg": {
						return "title asc ";
					}
					case "lingue": {
						return "lang asc ";
					}
					case "segchild": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_nation', new meta_geo_nation('geo_nation'));

	}());
