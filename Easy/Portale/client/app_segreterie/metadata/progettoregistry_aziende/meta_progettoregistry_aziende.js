
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

    function meta_progettoregistry_aziende() {
        MetaData.apply(this, ["progettoregistry_aziende"]);
        this.name = 'meta_progettoregistry_aziende';
    }

    meta_progettoregistry_aziende.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoregistry_aziende,
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
						this.describeAColumn(table, '!idpartnerkind_partnerkind_title', 'Tipo di partnership', null, 1071, null);
						objCalcFieldConfig['!idpartnerkind_partnerkind_title'] = { tableNameLookup:'partnerkind', columnNameLookup:'title', columnNamekey:'idpartnerkind' };
						this.describeAColumn(table, '!idreg_aziende_registry_title', 'Denominazione', null, 522, null);
						this.describeAColumn(table, '!idreg_aziende_registryclass_description', 'Tipologia', null, 523, null);
						this.describeAColumn(table, '!idreg_aziende_registry_cf', 'Codice fiscale', null, 524, null);
						this.describeAColumn(table, '!idreg_aziende_registry_p_iva', 'Partita iva', null, 525, null);
						this.describeAColumn(table, '!idreg_aziende_registry_active', 'attivo', null, 526, null);
						this.describeAColumn(table, '!idreg_aziende_geo_nation_title', 'Nazionalità', null, 532, null);
						this.describeAColumn(table, '!idreg_aziende_registry_flag_pa', 'Ente pubblico', null, 620, null);
						this.describeAColumn(table, '!idreg_aziende_ateco_codice', 'Codice Classificazione Ateco', null, 528, null);
						this.describeAColumn(table, '!idreg_aziende_ateco_title', 'Titolo Classificazione Ateco', null, 529, null);
						this.describeAColumn(table, '!idreg_aziende_naturagiur_title', 'Natura Giuridica', null, 529, null);
						this.describeAColumn(table, '!idreg_aziende_numerodip_title', 'Numero di dipendenti', null, 530, null);
						this.describeAColumn(table, '!idreg_aziende_nace_idnace', 'Identificativo NACE', null, 531, null);
						this.describeAColumn(table, '!idreg_aziende_nace_activity', 'Activity NACE', null, 532, null);
						this.describeAColumn(table, '!idreg_aziende_registry_aziende_pic', 'Participant Identification Code (PIC)', null, 532, null);
						objCalcFieldConfig['!idreg_aziende_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registryclass_description'] = { tableNameLookup:'registryclass', columnNameLookup:'description', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_geo_nation_title'] = { tableNameLookup:'geo_nation', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_flag_pa'] = { tableNameLookup:'registry', columnNameLookup:'flag_pa', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_ateco_codice'] = { tableNameLookup:'ateco', columnNameLookup:'codice', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_ateco_title'] = { tableNameLookup:'ateco', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_naturagiur_title'] = { tableNameLookup:'naturagiur', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_numerodip_title'] = { tableNameLookup:'numerodip', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_nace_idnace'] = { tableNameLookup:'nace', columnNameLookup:'idnace', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_nace_activity'] = { tableNameLookup:'nace', columnNameLookup:'activity', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_aziende_pic'] = { tableNameLookup:'registry_aziende', columnNameLookup:'pic', columnNamekey:'idreg_aziende' };
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
						table.columns["idpartnerkind"].caption = "Tipo di partnership";
						table.columns["idreg_aziende"].caption = "Ente o azienda partner";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoregistry_aziende");

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

    window.appMeta.addMeta('progettoregistry_aziende', new meta_progettoregistry_aziende('progettoregistry_aziende'));

	}());
