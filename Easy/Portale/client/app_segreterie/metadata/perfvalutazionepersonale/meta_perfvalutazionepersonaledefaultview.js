
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

    function meta_perfvalutazionepersonaledefaultview() {
        MetaData.apply(this, ["perfvalutazionepersonaledefaultview"]);
        this.name = 'meta_perfvalutazionepersonaledefaultview';
    }

    meta_perfvalutazionepersonaledefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaledefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'registry_title', 'Valutato', null, 1300, 101);
						this.describeAColumn(table, 'year', 'Anno solare', null, 3000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_risultato', 'Percentuale risultato', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'perfschedastatus_title', 'Stato', null, 5200, 1024);
						this.describeAColumn(table, 'registryval_title', 'Valutatore', null, 6300, 101);
						this.describeAColumn(table, 'registryappr_title', 'Approvatore', null, 7300, 101);
						this.describeAColumn(table, 'XXperfvalutazionepersonaleuo', 'Performance dell’unità organizzativa', null, 8000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesoperfuo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 9000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_percperfuo', 'Percentuale di completamento dell’unità organizzativa', 'fixed.2', 10000, null);
						this.describeAColumn(table, 'XXperfvalutazionepersonalecomportamento', 'Comportamenti Attesi ', null, 11000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 12000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 13000, null);
						this.describeAColumn(table, 'XXperfvalutazionepersonaleobiettivo', 'Obiettivi Individuali', null, 14000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 15000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 16000, null);
						this.describeAColumn(table, 'struttura_title', 'Denominazione U.O. Afferenza', null, 17110, 1024);
						this.describeAColumn(table, 'afferenza_start', 'Dal Afferenza', null, 17400, null);
						this.describeAColumn(table, 'afferenza_stop', 'Al Afferenza', null, 17500, null);
						this.describeAColumn(table, 'mansionekind_title', 'Titolo Mansione Afferenza', null, 18020, 2048);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfvalutazionepersonale"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfvalutazionepersonaledefaultview', new meta_perfvalutazionepersonaledefaultview('perfvalutazionepersonaledefaultview'));

	}());
