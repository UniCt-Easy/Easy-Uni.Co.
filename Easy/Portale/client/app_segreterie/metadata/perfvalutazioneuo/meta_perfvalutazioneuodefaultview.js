
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

    function meta_perfvalutazioneuodefaultview() {
        MetaData.apply(this, ["perfvalutazioneuodefaultview"]);
        this.name = 'meta_perfvalutazioneuodefaultview';
    }

    meta_perfvalutazioneuodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneuodefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				var objCalcFieldConfig = {};
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'struttura_title', 'Denominazione Unità organizzativa', null, 10, 1024);
						this.describeAColumn(table, 'year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'perfvalutazioneuo_risultato', 'Risultato %', 'fixed.2', 30, null);
						this.describeAColumn(table, 'perfschedastatus_title', 'Stato', null, 40, 1024);
						this.describeAColumn(table, 'registryval_title', 'Valutatore', null, 50, 101);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoproguo', 'Peso della valutazione della performance dei Progetti Strategici della UO', 'fixed.2', 70, null);
						this.describeAColumn(table, 'perfvalutazioneuo_completamentopsuo', 'Percentuale di completamento per i progetti Strategici della UO', 'fixed.2', 80, null);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoprogaltreuo', 'Peso della valutazione della performance dei Progetti Strategici di altre UO ', 'fixed.2', 100, null);
						this.describeAColumn(table, 'perfvalutazioneuo_completamentopsauo', 'Percentuale di completamento dei progetti Strategici di altre UO', 'fixed.2', 110, null);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoindicatori', 'Peso della valutazione della performance degli indicatori', 'fixed.2', 130, null);
						this.describeAColumn(table, 'perfvalutazioneuo_indicatori', 'Percentuale di completamento degli indicatori', 'fixed.2', 140, null);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoobiettivi', 'Peso della valutazione della performance degli obiettivi una tantum', 'fixed.2', 160, null);
						this.describeAColumn(table, 'perfvalutazioneuo_obiettiviindividuali', 'Percentuale di completamento degli obiettivi una tantum', 'fixed.2', 170, null);
						this.describeAColumn(table, 'registryappr_title', 'Approvatore', null, 180, 101);
						this.describeAColumn(table, 'XXperfprogettoobiettivouoview', 'Obiettivi dei progetti Strategici della UO', null, 200, null);
						this.describeAColumn(table, 'XXperfprogettoobiettivopersonaleview', 'Obiettivi dei progetti Strategici di altre UO', null, 210, null);
						this.describeAColumn(table, 'XXperfvalutazioneuoindicatori', 'Indicatori operativi', null, 220, null);
						this.describeAColumn(table, 'XXperfobiettiviuo', 'Obiettivi una tantum', null, 230, null);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione U.O. madre', null, 90, 1024);
						this.describeAColumn(table, 'struttura_paridstruttura', 'U.O. madre U.O. madre', null, 90, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogettouo", "idperfvalutazioneuo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfvalutazioneuodefaultview', new meta_perfvalutazioneuodefaultview('perfvalutazioneuodefaultview'));

	}());
