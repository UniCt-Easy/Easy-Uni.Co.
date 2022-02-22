
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

    function meta_tirociniocandidatura() {
        MetaData.apply(this, ["tirociniocandidatura"]);
        this.name = 'meta_tirociniocandidatura';
    }

    meta_tirociniocandidatura.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirociniocandidatura,
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
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Tutor', null, 31, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_studenti_registry_studenti_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						this.describeAColumn(table, '!idtirociniocandidaturakind_tirociniocandidaturakind_title', 'Tipologia', null, 61, null);
						objCalcFieldConfig['!idtirociniocandidaturakind_tirociniocandidaturakind_title'] = { tableNameLookup:'tirociniocandidaturakind', columnNameLookup:'title', columnNamekey:'idtirociniocandidaturakind' };
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
						table.columns["idreg_docenti"].caption = "Tutor";
						table.columns["idreg_referente"].caption = "Referente dell'azienda";
						table.columns["idreg_studenti"].caption = "Studente";
						table.columns["idtirociniocandidaturakind"].caption = "Tipologia";
						table.columns["idtirocinioproposto"].caption = "Proposta di tirocinio";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tirociniocandidatura");

				//$getNewRowInside$

				dt.autoIncrement('idtirociniocandidatura', { minimum: 99990001 });

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

    window.appMeta.addMeta('tirociniocandidatura', new meta_tirociniocandidatura('tirociniocandidatura'));

	}());
