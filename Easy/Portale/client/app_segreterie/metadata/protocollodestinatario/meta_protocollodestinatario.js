
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

    function meta_protocollodestinatario() {
        MetaData.apply(this, ["protocollodestinatario"]);
        this.name = 'meta_protocollodestinatario';
    }

    meta_protocollodestinatario.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollodestinatario,
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
						this.describeAColumn(table, 'destmail', 'E-mail', null, 20, 512);
						this.describeAColumn(table, 'destidamm', 'Amministrazione pubblica destinataria - Codice IPA', null, 30, 50);
						this.describeAColumn(table, 'destcodiceaoo', 'Amministrazione pubblica destinataria - Codice IPA area organizzativa omogenea', null, 40, 50);
						this.describeAColumn(table, '!idreg_dest_registry_title', 'Destinatario', null, 11, null);
						objCalcFieldConfig['!idreg_dest_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_dest' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_protocollodestinatario");

				//$getNewRowInside$

				dt.autoIncrement('idprotocollodestinatario', { minimum: 99990001 });

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

    window.appMeta.addMeta('protocollodestinatario', new meta_protocollodestinatario('protocollodestinatario'));

	}());
