
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

    function meta_tipologiastudente() {
        MetaData.apply(this, ["tipologiastudente"]);
        this.name = 'meta_tipologiastudente';
    }

    meta_tipologiastudente.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tipologiastudente,
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
						this.describeAColumn(table, 'abbreviazione', 'Iscritto con una abbreviazione di corso', null, 20, null);
						this.describeAColumn(table, 'annoiscr', 'Anno di iscrizione', null, 30, null);
						this.describeAColumn(table, 'immatricolato', 'Immatricolato', null, 70, null);
						this.describeAColumn(table, 'iscrittobmi', 'Iscritto ad un bando di mobilità internazionale', null, 80, null);
						this.describeAColumn(table, 'passaggio', 'Iscritto con un passaggio di corso', null, 90, null);
						this.describeAColumn(table, 'tri', 'Trasferimento in ingresso', null, 100, null);
						this.describeAColumn(table, '!idcorsostudiokind_corsostudiokind_title', 'Tipologia del corso a cui è iscritto', null, 61, null);
						objCalcFieldConfig['!idcorsostudiokind_corsostudiokind_title'] = { tableNameLookup:'corsostudiokind', columnNameLookup:'title', columnNamekey:'idcorsostudiokind' };
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
						table.columns["abbreviazione"].caption = "Iscritto con una abbreviazione di corso";
						table.columns["annoiscr"].caption = "Anno di iscrizione";
						table.columns["idcorsostudiokind"].caption = "Tipologia del corso a cui è iscritto";
						table.columns["iscrittobmi"].caption = "Iscritto ad un bando di mobilità internazionale";
						table.columns["passaggio"].caption = "Iscritto con un passaggio di corso";
						table.columns["tri"].caption = "Trasferimento in ingresso";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tipologiastudente");

				//$getNewRowInside$

				dt.autoIncrement('idtipologiastudente', { minimum: 99990001 });

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

    window.appMeta.addMeta('tipologiastudente', new meta_tipologiastudente('tipologiastudente'));

	}());
