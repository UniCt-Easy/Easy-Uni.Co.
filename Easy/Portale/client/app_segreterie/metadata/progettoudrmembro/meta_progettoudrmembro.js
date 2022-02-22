
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

    function meta_progettoudrmembro() {
        MetaData.apply(this, ["progettoudrmembro"]);
        this.name = 'meta_progettoudrmembro';
    }

    meta_progettoudrmembro.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoudrmembro,
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
						this.describeAColumn(table, 'costoorario', 'Costo orario', 'fixed.2', 30, null);
						this.describeAColumn(table, 'ricavoorario', 'Ricavo orario', 'fixed.2', 40, null);
						this.describeAColumn(table, 'orepreventivate', 'Ore/uomo preventivate', null, 50, null);
						this.describeAColumn(table, '!orerendicontate', 'Ore rendicontate', null, 60, null);
						this.describeAColumn(table, 'impegno', 'Mesi/uomo preventivati', 'fixed.2', 100, null);
						this.describeAColumn(table, '!idprogettoudrmembrokind_progettoudrmembrokind_title', 'Ruolo', null, 21, null);
						objCalcFieldConfig['!idprogettoudrmembrokind_progettoudrmembrokind_title'] = { tableNameLookup:'progettoudrmembrokind', columnNameLookup:'title', columnNamekey:'idprogettoudrmembrokind' };
						this.describeAColumn(table, '!idreg_registry_title', 'Membro', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
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
						table.columns["!orerendicontate"].caption = "Ore rendicontate";
						table.columns["costoorario"].caption = "Costo orario";
						table.columns["idprogettoudrmembrokind"].caption = "Ruolo";
						table.columns["idreg"].caption = "Membro";
						table.columns["impegno"].caption = "Mesi/uomo preventivati";
						table.columns["orepreventivate"].caption = "Ore/uomo preventivate";
						table.columns["ricavoorario"].caption = "Ricavo orario";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoudrmembro");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoudrmembro', { minimum: 99990001 });

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

    window.appMeta.addMeta('progettoudrmembro', new meta_progettoudrmembro('progettoudrmembro'));

	}());
