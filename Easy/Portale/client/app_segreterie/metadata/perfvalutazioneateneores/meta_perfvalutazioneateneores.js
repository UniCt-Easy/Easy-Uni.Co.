
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

    function meta_perfvalutazioneateneores() {
        MetaData.apply(this, ["perfvalutazioneateneores"]);
        this.name = 'meta_perfvalutazioneateneores';
    }

    meta_perfvalutazioneateneores.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneateneores,
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
						this.describeAColumn(table, 'indicatore', 'Indicatore', null, 40, 1024);
						this.describeAColumn(table, 'target', 'Target', null, 50, 1024);
						this.describeAColumn(table, 'valoreraggiunto', 'Valore raggiunto', null, 60, 1024);
						this.describeAColumn(table, 'percentualeraggiunta', 'Percentuale raggiunta', 'fixed.2', 70, null);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 100, null);
						this.describeAColumn(table, 'fonte', 'Fonte', null, 110, 1024);
						this.describeAColumn(table, '!idperfmission_perfmission_title', 'Missione istituzionale', null, 11, null);
						objCalcFieldConfig['!idperfmission_perfmission_title'] = { tableNameLookup:'perfmission', columnNameLookup:'title', columnNamekey:'idperfmission' };
						this.describeAColumn(table, '!idreg_registry_title', 'Compilatore', null, 161, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
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
						table.columns["fonte"].caption = "Fonte";
						table.columns["idperfmission"].caption = "Missione istituzionale";
						table.columns["indicatore"].caption = "Indicatore";
						table.columns["percentualeraggiunta"].caption = "Percentuale raggiunta";
						table.columns["peso"].caption = "Peso";
						table.columns["target"].caption = "Target";
						table.columns["valoreraggiunto"].caption = "Valore raggiunto";
						table.columns["idreg"].caption = "Compilatore";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneateneores");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazioneateneores', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazioneateneores', new meta_perfvalutazioneateneores('perfvalutazioneateneores'));

	}());
