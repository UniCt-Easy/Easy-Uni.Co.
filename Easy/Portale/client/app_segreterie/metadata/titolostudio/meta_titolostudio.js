
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

    function meta_titolostudio() {
        MetaData.apply(this, ["titolostudio"]);
        this.name = 'meta_titolostudio';
    }

    meta_titolostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_titolostudio,
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
					case 'docenti':
						this.describeAColumn(table, 'voto', 'Voto', null, 20, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 30, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 40, null);
						this.describeAColumn(table, 'aa', 'Anno accademco', null, 50, 9);
						this.describeAColumn(table, '!idistattitolistudio_istattitolistudio_titolo', 'Titolo ISTAT', null, 11, null);
						objCalcFieldConfig['!idistattitolistudio_istattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idistattitolistudio' };
						this.describeAColumn(table, '!idreg_istituti_registry_istituti_title', 'Istituto', null, 61, null);
						objCalcFieldConfig['!idreg_istituti_registry_istituti_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_istituti' };
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_titolostudio");

				//$getNewRowInside$

				dt.autoIncrement('idtitolostudio', { minimum: 99990001 });

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

    window.appMeta.addMeta('titolostudio', new meta_titolostudio('titolostudio'));

	}());
