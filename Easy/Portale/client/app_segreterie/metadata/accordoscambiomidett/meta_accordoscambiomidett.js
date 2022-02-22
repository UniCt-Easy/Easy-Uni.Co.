
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_accordoscambiomidett() {
        MetaData.apply(this, ["accordoscambiomidett"]);
        this.name = 'meta_accordoscambiomidett';
    }

    meta_accordoscambiomidett.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomidett,
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
						this.describeAColumn(table, 'numdocincoming', 'Numero di docenti incoming', null, 60, null);
						this.describeAColumn(table, 'numdocoutgoing', 'Numero di docenti outgoing', null, 70, null);
						this.describeAColumn(table, 'numpersincoming', 'Numero di personale incoming', null, 80, null);
						this.describeAColumn(table, 'numpersoutgoing', 'Numero di personale outgoing', null, 90, null);
						this.describeAColumn(table, 'numstulearincoming', 'Numero di studenti incoming for learning', null, 100, null);
						this.describeAColumn(table, 'numstulearoutgoing', 'Numero di studenti outgoing for learning', null, 110, null);
						this.describeAColumn(table, 'numstutraincoming', 'Numero di studenti incoming for traineeship', null, 120, null);
						this.describeAColumn(table, 'numstutraoutgoing', 'Numero di studenti outgoing for traineeship', null, 130, null);
						this.describeAColumn(table, 'stipula', 'Data di stipula', null, 140, null);
						this.describeAColumn(table, 'stop', 'Data di termine dell\'accordo', null, 150, null);
						this.describeAColumn(table, '!idisced2013_isced2013_detailedfield', 'Classificazione ISCED 2013', null, 31, null);
						objCalcFieldConfig['!idisced2013_isced2013_detailedfield'] = { tableNameLookup:'isced2013', columnNameLookup:'detailedfield', columnNamekey:'idisced2013' };
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_title', 'Istituto estero', null, 11, null);
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						this.describeAColumn(table, '!idtorkind_torkind_title', 'Tipologia Modalit� di invio del trascript of record', null, 51, null);
						this.describeAColumn(table, '!idtorkind_torkind_description', 'Descrizione Modalit� di invio del trascript of record', null, 52, null);
						objCalcFieldConfig['!idtorkind_torkind_title'] = { tableNameLookup:'torkind', columnNameLookup:'title', columnNamekey:'idtorkind' };
						objCalcFieldConfig['!idtorkind_torkind_description'] = { tableNameLookup:'torkind', columnNameLookup:'description', columnNamekey:'idtorkind' };
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
						table.columns["numstulearincoming"].caption = "Numero di studenti incoming for learning";
						table.columns["numstulearoutgoing"].caption = "Numero di studenti outgoing for learning";
						table.columns["stipula"].caption = "Data di stipula";
						table.columns["stop"].caption = "Data di termine dell'accordo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_accordoscambiomidett");

				//$getNewRowInside$

				dt.autoIncrement('idaccordoscambiomidett', { minimum: 99990001 });

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

    window.appMeta.addMeta('accordoscambiomidett', new meta_accordoscambiomidett('accordoscambiomidett'));

	}());
