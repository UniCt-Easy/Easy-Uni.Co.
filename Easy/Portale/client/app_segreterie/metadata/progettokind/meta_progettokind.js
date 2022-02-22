
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

    function meta_progettokind() {
        MetaData.apply(this, ["progettokind"]);
        this.name = 'meta_progettokind';
    }

    meta_progettokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettokind,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'oredivisionecostostipendio', 'Numero ore lavorate in un anno dal personale', null, 30, null);
						this.describeAColumn(table, 'stipendioannoprec', 'Usa stipendi anno precedente', null, 80, null);
						this.describeAColumn(table, 'stipendiocomericavo', 'Usa stipendi come ricavi', null, 90, null);
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
					case 'seg':
						table.columns["description"].caption = "Descrizione";
						table.columns["idcorsostudio"].caption = "Abilita il corso di studio";
						table.columns["idprogettoactivitykind"].caption = "Tipologia";
						table.columns["oredivisionecostostipendio"].caption = "Numero ore lavorate in un anno dal personale";
						table.columns["stipendioannoprec"].caption = "Usa stipendi anno precedente";
						table.columns["title"].caption = "Titolo";
						table.columns["stipendiocomericavo"].caption = "Usa stipendi come ricavi";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettokind");

				//$getNewRowInside$

				dt.autoIncrement('idprogettokind', { minimum: 99990001 });

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
					case "seg": {
						return "idprogettoactivitykind asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettokind', new meta_progettokind('progettokind'));

	}());
