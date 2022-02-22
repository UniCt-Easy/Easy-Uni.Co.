
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

    function meta_perfvalutazionepersonaleuo() {
        MetaData.apply(this, ["perfvalutazionepersonaleuo"]);
        this.name = 'meta_perfvalutazionepersonaleuo';
    }

    meta_perfvalutazionepersonaleuo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaleuo,
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
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 20, null);
						this.describeAColumn(table, 'punteggio', 'Punteggio', 'fixed.2', 30, null);
						this.describeAColumn(table, 'punteggiopesato', 'Punteggio pesato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'afferenza', 'Tempo di afferenza', 'fixed.2', 50, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Unità organizzativa', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Unità organizzativa', null, 11, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
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
						table.columns["afferenza"].caption = "Tempo di afferenza";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["peso"].caption = "Peso";
						table.columns["punteggio"].caption = "Punteggio";
						table.columns["punteggiopesato"].caption = "Punteggio pesato";
						table.columns["idstruttura"].caption = "Unità organizzativa";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonaleuo");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonaleuo', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazionepersonaleuo', new meta_perfvalutazionepersonaleuo('perfvalutazionepersonaleuo'));

	}());
