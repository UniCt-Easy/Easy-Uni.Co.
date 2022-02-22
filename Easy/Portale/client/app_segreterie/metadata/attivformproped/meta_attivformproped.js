
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

    function meta_attivformproped() {
        MetaData.apply(this, ["attivformproped"]);
        this.name = 'meta_attivformproped';
    }

    meta_attivformproped.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformproped,
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
						this.describeAColumn(table, 'alternativa', 'Alternativa', null, 10, null);
						this.describeAColumn(table, '!idattivform_proped_didprogcurr_alias1_title', 'Curriculum', null, 32, null);
						this.describeAColumn(table, '!idattivform_proped_didprogori_title', 'Orientamento', null, 33, null);
						this.describeAColumn(table, '!idattivform_proped_didproganno_title', 'Anno di corso', null, 34, null);
						this.describeAColumn(table, '!idattivform_proped_didprogporzanno_title', 'Porzione d\'anno', null, 35, null);
						this.describeAColumn(table, '!idattivform_proped_didproggrupp_alias1_title', 'Gruppo opzionale', null, 36, null);
						this.describeAColumn(table, '!idattivform_proped_insegn_denominazione', 'Denominazione Insegnamento', null, 37, null);
						this.describeAColumn(table, '!idattivform_proped_insegn_codice', 'Codice Insegnamento', null, 38, null);
						this.describeAColumn(table, '!idattivform_proped_insegninteg_denominazione', 'Denominazione Integrando', null, 38, null);
						this.describeAColumn(table, '!idattivform_proped_insegninteg_codice', 'Codice Integrando', null, 39, null);
						this.describeAColumn(table, '!idattivform_proped_attivform_alias1_start', 'Dal', null, 38, null);
						this.describeAColumn(table, '!idattivform_proped_attivform_alias1_stop', 'Al', null, 39, null);
						this.describeAColumn(table, '!idattivform_proped_attivform_alias1_tipovalutaz', 'Profitto o Idoneità', null, 40, null);
						objCalcFieldConfig['!idattivform_proped_didprogcurr_alias1_title'] = { tableNameLookup:'didprogcurr_alias1', columnNameLookup:'title', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_didproganno_title'] = { tableNameLookup:'didproganno', columnNameLookup:'title', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_didprogporzanno_title'] = { tableNameLookup:'didprogporzanno', columnNameLookup:'title', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_didproggrupp_alias1_title'] = { tableNameLookup:'didproggrupp_alias1', columnNameLookup:'title', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_insegninteg_denominazione'] = { tableNameLookup:'insegninteg', columnNameLookup:'denominazione', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_insegninteg_codice'] = { tableNameLookup:'insegninteg', columnNameLookup:'codice', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_attivform_alias1_start'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'start', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_attivform_alias1_stop'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'stop', columnNamekey:'idattivform_proped' };
						objCalcFieldConfig['!idattivform_proped_attivform_alias1_tipovalutaz'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'tipovalutaz', columnNamekey:'idattivform_proped' };
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
						table.columns["alternativa"].caption = "Alternativa";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_attivformproped");

				//$getNewRowInside$


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

    window.appMeta.addMeta('attivformproped', new meta_attivformproped('attivformproped'));

	}());
