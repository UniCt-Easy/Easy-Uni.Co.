
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

    function meta_bandodsservizio() {
        MetaData.apply(this, ["bandodsservizio"]);
        this.name = 'meta_bandodsservizio';
    }

    meta_bandodsservizio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodsservizio,
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
						this.describeAColumn(table, 'alloggio', 'Servizio alloggio', null, 20, null);
						this.describeAColumn(table, 'borsafuorisede', 'Importo annuo borsa contributi (fuori sede)', 'fixed.2', 30, null);
						this.describeAColumn(table, 'borsainsede', 'Importo annuo borsa contributi (in sede)', 'fixed.2', 40, null);
						this.describeAColumn(table, 'borsapendolari', 'Importo annuo borsa contributi (pendolari)', 'fixed.2', 50, null);
						this.describeAColumn(table, 'contributo', 'Contributo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'contributomiimporto', 'Importo contributi per mobilità internazionale', 'fixed.2', 70, null);
						this.describeAColumn(table, 'contributomimesi', 'Numero mesi contributi mobilità internazionale', null, 80, null);
						this.describeAColumn(table, 'fuoricorso', 'Fuori corso', null, 90, null);
						this.describeAColumn(table, 'iseemax', 'ISEE massimo', 'fixed.2', 140, null);
						this.describeAColumn(table, 'ispemax', 'ISPE massimo', 'fixed.2', 150, null);
						this.describeAColumn(table, 'maggiorenne', 'Maggiorenne', null, 160, null);
						this.describeAColumn(table, 'mensa', 'Servizio mensa', null, 170, null);
						this.describeAColumn(table, 'parttime', 'Part Time', null, 180, null);
						this.describeAColumn(table, 'primaimmatlivello', 'Immatricolato per la prima volta a questo livello', null, 190, null);
						this.describeAColumn(table, '!idbandodsserviziokind_bandodsserviziokind_title', 'Tipologia Tipo servizio offerto', null, 111, null);
						this.describeAColumn(table, '!idbandodsserviziokind_bandodsserviziokind_description', 'Descrizione Tipo servizio offerto', null, 112, null);
						objCalcFieldConfig['!idbandodsserviziokind_bandodsserviziokind_title'] = { tableNameLookup:'bandodsserviziokind', columnNameLookup:'title', columnNamekey:'idbandodsserviziokind' };
						objCalcFieldConfig['!idbandodsserviziokind_bandodsserviziokind_description'] = { tableNameLookup:'bandodsserviziokind', columnNameLookup:'description', columnNamekey:'idbandodsserviziokind' };
						this.describeAColumn(table, '!idesonero_esonero_title', 'Esonero', null, 121, null);
						objCalcFieldConfig['!idesonero_esonero_title'] = { tableNameLookup:'esonero', columnNameLookup:'title', columnNamekey:'idesonero' };
						this.describeAColumn(table, '!idistattitolistudio_min_istattitolistudio_titolo', 'Titolo minimo di studio', null, 131, null);
						objCalcFieldConfig['!idistattitolistudio_min_istattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idistattitolistudio_min' };
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
						table.columns["alloggio"].caption = "Servizio alloggio";
						table.columns["borsafuorisede"].caption = "Importo annuo borsa contributi (fuori sede)";
						table.columns["borsainsede"].caption = "Importo annuo borsa contributi (in sede)";
						table.columns["borsapendolari"].caption = "Importo annuo borsa contributi (pendolari)";
						table.columns["contributomiimporto"].caption = "Importo contributi per mobilità internazionale";
						table.columns["contributomimesi"].caption = "Numero mesi contributi mobilità internazionale";
						table.columns["fuoricorso"].caption = "Fuori corso";
						table.columns["idbandodsserviziokind"].caption = "Tipo servizio offerto";
						table.columns["idesonero"].caption = "Esonero";
						table.columns["idistattitolistudio_min"].caption = "Titolo minimo di studio";
						table.columns["iseemax"].caption = "ISEE massimo";
						table.columns["ispemax"].caption = "ISPE massimo";
						table.columns["mensa"].caption = "Servizio mensa";
						table.columns["parttime"].caption = "Part Time";
						table.columns["primaimmatlivello"].caption = "Immatricolato per la prima volta a questo livello";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandodsservizio");

				//$getNewRowInside$

				dt.autoIncrement('idbandodsservizio', { minimum: 99990001 });

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

    window.appMeta.addMeta('bandodsservizio', new meta_bandodsservizio('bandodsservizio'));

	}());
