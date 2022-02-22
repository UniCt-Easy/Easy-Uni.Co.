
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


(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_analisiannuale() {
		MetaPage.apply(this, ['analisiannuale', 'default', false]);
        this.name = 'Previsione dei costi stipendi nel triennio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_analisiannuale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_analisiannuale,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-analisiannuale_default");
				var arraydef = [];
				
				arraydef.push(this.manageanalisiannuale_default_year1());
				arraydef.push(this.manageanalisiannuale_default_year2());
				arraydef.push(this.manageanalisiannuale_default_year3());
				arraydef.push(this.manageanalisiannuale_default_indicatore0());
				arraydef.push(this.manageanalisiannuale_default_indicatore1());
				arraydef.push(this.manageanalisiannuale_default_costopt());
				arraydef.push(this.manageanalisiannuale_default_indicatore2());
				arraydef.push(this.manageanalisiannuale_default_spesedocenti0());
				arraydef.push(this.manageanalisiannuale_default_indicatore3());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidocenti0());
				arraydef.push(this.manageanalisiannuale_default_spesedirPTA0());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidirPTA0());
				arraydef.push(this.manageanalisiannuale_default_totspesepersonalecaricoateneo0());
				arraydef.push(this.manageanalisiannuale_default_speseDG0());
				arraydef.push(this.manageanalisiannuale_default_numeratore0());
				arraydef.push(this.manageanalisiannuale_default_denominatore0());
				arraydef.push(this.manageanalisiannuale_default_spesedocenti1());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidocenti1());
				arraydef.push(this.manageanalisiannuale_default_spesedirPTA1());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidirPTA1());
				arraydef.push(this.manageanalisiannuale_default_totspesepersonalecaricoateneo1());
				arraydef.push(this.manageanalisiannuale_default_speseDG1());
				arraydef.push(this.manageanalisiannuale_default_numeratore1());
				arraydef.push(this.manageanalisiannuale_default_spesedocenti2());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidocenti2());
				arraydef.push(this.manageanalisiannuale_default_spesedirPTA2());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidirPTA2());
				arraydef.push(this.manageanalisiannuale_default_totspesepersonalecaricoateneo2());
				arraydef.push(this.manageanalisiannuale_default_speseDG2());
				arraydef.push(this.manageanalisiannuale_default_numeratore2());
				arraydef.push(this.manageanalisiannuale_default_spesedocenti3());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidocenti3());
				arraydef.push(this.manageanalisiannuale_default_spesedirPTA3());
				arraydef.push(this.manageanalisiannuale_default_finanzesternidirPTA3());
				arraydef.push(this.manageanalisiannuale_default_totspesepersonalecaricoateneo3());
				arraydef.push(this.manageanalisiannuale_default_speseDG3());
				arraydef.push(this.manageanalisiannuale_default_numeratore3());
				arraydef.push(this.manageanalisiannuale_default_denominatore1());
				arraydef.push(this.manageanalisiannuale_default_denominatore2());
				arraydef.push(this.manageanalisiannuale_default_denominatore3());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow['!denominatore0'])
					parentRow['!denominatore0'] = 0;
				if (!parentRow['!numeratore0'])
					parentRow['!numeratore0'] = 0;
				this.manageanalisiannuale_default_year1();
				this.manageanalisiannuale_default_year2();
				this.manageanalisiannuale_default_year3();
				this.manageanalisiannuale_default_indicatore0();
				this.manageanalisiannuale_default_indicatore1();
				this.manageanalisiannuale_default_costopt();
				this.manageanalisiannuale_default_indicatore2();
				this.manageanalisiannuale_default_spesedocenti0();
				this.manageanalisiannuale_default_indicatore3();
				this.manageanalisiannuale_default_finanzesternidocenti0();
				this.manageanalisiannuale_default_spesedirPTA0();
				this.manageanalisiannuale_default_finanzesternidirPTA0();
				this.manageanalisiannuale_default_totspesepersonalecaricoateneo0();
				this.manageanalisiannuale_default_speseDG0();
				this.manageanalisiannuale_default_numeratore0();
				this.manageanalisiannuale_default_denominatore0();
				this.manageanalisiannuale_default_spesedocenti1();
				this.manageanalisiannuale_default_finanzesternidocenti1();
				this.manageanalisiannuale_default_spesedirPTA1();
				this.manageanalisiannuale_default_finanzesternidirPTA1();
				this.manageanalisiannuale_default_totspesepersonalecaricoateneo1();
				this.manageanalisiannuale_default_speseDG1();
				this.manageanalisiannuale_default_numeratore1();
				this.manageanalisiannuale_default_spesedocenti2();
				this.manageanalisiannuale_default_finanzesternidocenti2();
				this.manageanalisiannuale_default_spesedirPTA2();
				this.manageanalisiannuale_default_finanzesternidirPTA2();
				this.manageanalisiannuale_default_totspesepersonalecaricoateneo2();
				this.manageanalisiannuale_default_speseDG2();
				this.manageanalisiannuale_default_numeratore2();
				this.manageanalisiannuale_default_spesedocenti3();
				this.manageanalisiannuale_default_finanzesternidocenti3();
				this.manageanalisiannuale_default_spesedirPTA3();
				this.manageanalisiannuale_default_finanzesternidirPTA3();
				this.manageanalisiannuale_default_totspesepersonalecaricoateneo3();
				this.manageanalisiannuale_default_speseDG3();
				this.manageanalisiannuale_default_numeratore3();
				this.manageanalisiannuale_default_denominatore1();
				this.manageanalisiannuale_default_denominatore2();
				this.manageanalisiannuale_default_denominatore3();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-analisiannuale_default");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcsassunzionisimulate'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcscessazioniview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('stipendioannuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcsassunzioni'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcspuntiorganicoview'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#analisiannuale_default_costopt'), false);
				this.enableControl($('#analisiannuale_default_spesedocenti0'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidocenti0'), false);
				this.enableControl($('#analisiannuale_default_spesedirPTA0'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidirPTA0'), false);
				this.enableControl($('#analisiannuale_default_totspesepersonalecaricoateneo0'), false);
				this.enableControl($('#analisiannuale_default_speseDG0'), false);
				this.enableControl($('#analisiannuale_default_numeratore0'), false);
				this.enableControl($('#analisiannuale_default_denominatore0'), false);
				this.enableControl($('#analisiannuale_default_year1'), false);
				this.enableControl($('#analisiannuale_default_spesedocenti1'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidocenti1'), false);
				this.enableControl($('#analisiannuale_default_spesedirPTA1'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidirPTA1'), false);
				this.enableControl($('#analisiannuale_default_totspesepersonalecaricoateneo1'), false);
				this.enableControl($('#analisiannuale_default_speseDG1'), false);
				this.enableControl($('#analisiannuale_default_numeratore1'), false);
				this.enableControl($('#analisiannuale_default_denominatore1'), false);
				this.enableControl($('#analisiannuale_default_year2'), false);
				this.enableControl($('#analisiannuale_default_spesedocenti2'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidocenti2'), false);
				this.enableControl($('#analisiannuale_default_spesedirPTA2'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidirPTA2'), false);
				this.enableControl($('#analisiannuale_default_totspesepersonalecaricoateneo2'), false);
				this.enableControl($('#analisiannuale_default_speseDG2'), false);
				this.enableControl($('#analisiannuale_default_numeratore2'), false);
				this.enableControl($('#analisiannuale_default_denominatore2'), false);
				this.enableControl($('#analisiannuale_default_year3'), false);
				this.enableControl($('#analisiannuale_default_spesedocenti3'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidocenti3'), false);
				this.enableControl($('#analisiannuale_default_spesedirPTA3'), false);
				this.enableControl($('#analisiannuale_default_finanzesternidirPTA3'), false);
				this.enableControl($('#analisiannuale_default_totspesepersonalecaricoateneo3'), false);
				this.enableControl($('#analisiannuale_default_speseDG3'), false);
				this.enableControl($('#analisiannuale_default_numeratore3'), false);
				this.enableControl($('#analisiannuale_default_denominatore3'), false);
				this.enableControl($('#analisiannuale_default_indicatore0'), false);
				this.enableControl($('#analisiannuale_default_indicatore1'), false);
				this.enableControl($('#analisiannuale_default_indicatore2'), false);
				this.enableControl($('#analisiannuale_default_indicatore3'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcsassunzionisimulate'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcscessazioniview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('stipendioannuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcsassunzioni'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('analisiannuale'), this.getDataTable('pcspuntiorganicoview'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#analisiannuale_default_idattach_cessazione').on("change", _.partial(this.manageidattach_cessazione, self));
				$('#analisiannuale_default_importfilecontratti').on("change", _.partial(this.manageimportfilecontratti, self));
				$('#analisiannuale_default_importstipendi').on("change", _.partial(this.manageimportstipendi, self));
				this.setDenyNull("analisiannuale","year");
				//indico al framework che la tabella getcontrattikindview è cached
				var getcontrattikindviewTable = this.getDataTable("getcontrattikindview");
				appMeta.metaModel.cachedTable(getcontrattikindviewTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(getcontrattikindviewTable, null, null));
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-analisiannuale_default");
				$('#analisiannuale_default_year').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#analisiannuale_default_year').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#analisiannuale_default_year').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('pcscessazioniview').acceptChanges();
				this.getDataTable('pcspuntiorganicoview').acceptChanges();
				//innerBeforePost
			},

			manageidattach_cessazione: function(that) { 
				var files = event.target.files;
				var file = files[0];
				var colname = 'idanalisiannuale';
				var id = that.state.currentRow[colname];
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_cessazionicsa', [id], 0, 'pcscessazioniview', colname );


			},

			manageimportfilecontratti: function(that) { 
				var files = event.target.files;
				var file = files[0];
				var colname = 'year';
				var id = that.state.currentRow[colname];
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_contratticsa', [id], 0, 'stipendioannuo', colname);
			},

			manageimportstipendi: function(that) { 
				var files = event.target.files;
				var file = files[0];
				var colname = 'year';
				var id = that.state.currentRow[colname];
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_stipendicsa', [id], 0, 'stipendioannuo', colname );
			},

			manageanalisiannuale_default_year1: function () {
				this.state.currentRow['!year1'] = this.state.currentRow.year +1;

			},

			manageanalisiannuale_default_year2: function () {
				this.state.currentRow['!year2'] = this.state.currentRow.year +2;

			},

			manageanalisiannuale_default_year3: function () {
				this.state.currentRow['!year3'] = this.state.currentRow.year +3;
			},

			manageanalisiannuale_default_indicatore0: function () {
				//Tachimetro anno corrente
				var analisiannuale_default_indicatore0Ctrl = $("#analisiannuale_default_indicatore0");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importoateneo0;
				});
				tot = (tot +
					(this.state.currentRow.speseDG0 ? this.state.currentRow.speseDG0 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa0 ? this.state.currentRow.fondocontrattazioneintegrativa0 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL0 ? this.state.currentRow.trattamentostipintegrativoCEL0 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento0 ? this.state.currentRow.contrattiincarichiinsegnamento0 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento0 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento0 : 0)
				)
					/ (
						(this.state.currentRow.ffo0 ? this.state.currentRow.ffo0 : 0) +
						(this.state.currentRow.programmazionetriennale0 ? this.state.currentRow.programmazionetriennale0 : 0) +
						(this.state.currentRow.tasse0 ? this.state.currentRow.tasse0 : 0) -
						(this.state.currentRow.speseriduzione0 ? this.state.currentRow.speseriduzione0 : 0)
					)
				tot = tot * 100;
				analisiannuale_default_indicatore0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!indicatore0"] = tot;

			},

			manageanalisiannuale_default_indicatore1: function () {
				//Tachimetro anno successivo
				var analisiannuale_default_indicatore1Ctrl = $("#analisiannuale_default_indicatore1");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importoateneo1;
				});
				tot = (tot +
					(this.state.currentRow.speseDG1 ? this.state.currentRow.speseDG1 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa1 ? this.state.currentRow.fondocontrattazioneintegrativa1 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL1 ? this.state.currentRow.trattamentostipintegrativoCEL1 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento1 ? this.state.currentRow.contrattiincarichiinsegnamento1 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento1 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento1 : 0)
				)
					/ (
						(this.state.currentRow.ffo1 ? this.state.currentRow.ffo1 : 0) +
						(this.state.currentRow.programmazionetriennale1 ? this.state.currentRow.programmazionetriennale1 : 0) +
						(this.state.currentRow.tasse1 ? this.state.currentRow.tasse1 : 0) -
						(this.state.currentRow.speseriduzione1 ? this.state.currentRow.speseriduzione1 : 0)
					)
				tot = tot * 100;
				analisiannuale_default_indicatore1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!indicatore1"] = tot;

			},

			manageanalisiannuale_default_costopt: function () {
				var ck = this.state.DS.tables['getcontrattikindview'];
				var CkArrivoRows = ck.select(this.q.eq('idcontrattokind', 1));
				var costoCkArrivo = 0;
				if (CkArrivoRows.length > 0)
					if (CkArrivoRows[0].costolordoannuo)
						costoCkArrivo = CkArrivoRows[0].costolordoannuo * 12;
				this.state.currentRow.costopt = costoCkArrivo;
				$("#analisiannuale_default_costopt").val(this.fillTextBoxFromNumber(costoCkArrivo));
			},

			manageanalisiannuale_default_indicatore2: function () {
				//tachimetro secondo anno successivo
				var analisiannuale_default_indicatore2Ctrl = $("#analisiannuale_default_indicatore2");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importoateneo2;
				});
				tot = (tot +
					(this.state.currentRow.speseDG2 ? this.state.currentRow.speseDG2 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa2 ? this.state.currentRow.fondocontrattazioneintegrativa2 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL2 ? this.state.currentRow.trattamentostipintegrativoCEL2 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento2 ? this.state.currentRow.contrattiincarichiinsegnamento2 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento2 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento2 : 0)
				)
					/ (
						(this.state.currentRow.ffo2 ? this.state.currentRow.ffo2 : 0) +
						(this.state.currentRow.programmazionetriennale2 ? this.state.currentRow.programmazionetriennale2 : 0) +
						(this.state.currentRow.tasse2 ? this.state.currentRow.tasse2 : 0) -
						(this.state.currentRow.speseriduzione2 ? this.state.currentRow.speseriduzione2 : 0)
					)
				tot = tot * 100;
				analisiannuale_default_indicatore2Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!indicatore2"] = tot;
			},

			manageanalisiannuale_default_spesedocenti0: function () {
				var analisiannuale_default_spesedocenti0Ctrl = $("#analisiannuale_default_spesedocenti0");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importo0; //lordo
				});
				analisiannuale_default_spesedocenti0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.spesedocenti0 = tot;

			},

			manageanalisiannuale_default_indicatore3: function () {
				//tachimetro terzo anno successivo
				var analisiannuale_default_indicatore3Ctrl = $("#analisiannuale_default_indicatore3");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importoateneo3;
				});
				tot = (tot +
					(this.state.currentRow.speseDG3 ? this.state.currentRow.speseDG3 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa3 ? this.state.currentRow.fondocontrattazioneintegrativa3 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL3 ? this.state.currentRow.trattamentostipintegrativoCEL3 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento3 ? this.state.currentRow.contrattiincarichiinsegnamento3 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento3 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento3 : 0)
				)
					/ (
						(this.state.currentRow.ffo3 ? this.state.currentRow.ffo3 : 0) +
						(this.state.currentRow.programmazionetriennale3 ? this.state.currentRow.programmazionetriennale3 : 0) +
						(this.state.currentRow.tasse3 ? this.state.currentRow.tasse3 : 0) -
						(this.state.currentRow.speseriduzione3 ? this.state.currentRow.speseriduzione3 : 0)
					)
				tot = tot * 100;
				analisiannuale_default_indicatore3Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!indicatore3"] = tot;
			},

			manageanalisiannuale_default_finanzesternidocenti0: function () {
				var analisiannuale_default_finanzesternidocenti0Ctrl = $("#analisiannuale_default_finanzesternidocenti0");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importoesterno0; //lordo
				});
				analisiannuale_default_finanzesternidocenti0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.finanzesternidocenti0 = tot;
			},

			manageanalisiannuale_default_spesedirPTA0: function () {
				var analisiannuale_default_spesedirPTA0Ctrl = $("#analisiannuale_default_spesedirPTA0");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importo0; //lordo
				});
				analisiannuale_default_spesedirPTA0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.spesedirPTA0 = tot;


			},

			manageanalisiannuale_default_finanzesternidirPTA0: function () {
				var analisiannuale_default_finanzesternidirPTA0Ctrl = $("#analisiannuale_default_finanzesternidirPTA0");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importoesterno0; //lordo
				});
				analisiannuale_default_finanzesternidirPTA0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.finanzesternidirPTA0 = tot;

			},

			manageanalisiannuale_default_totspesepersonalecaricoateneo0: function () {
				var analisiannuale_default_totspesepersonalecaricoateneo0Ctrl = $("#analisiannuale_default_totspesepersonalecaricoateneo0");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.contrattokind_title.contains("Direttore generale")))
						return r.importoateneo0; //netto
				});
				analisiannuale_default_totspesepersonalecaricoateneo0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.totspesepersonalecaricoateneo0 = tot;

			},

			manageanalisiannuale_default_speseDG0: function () {
				var analisiannuale_default_speseDG0Ctrl = $("#analisiannuale_default_speseDG0");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.contrattokind_title.contains("Direttore generale"))
						return r.importoateneo0; //netto
				});
				analisiannuale_default_speseDG0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.speseDG0 = tot;

			},

			manageanalisiannuale_default_numeratore0: function () {
				var analisiannuale_default_numeratore0Ctrl = $("#analisiannuale_default_numeratore0");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importo0;
				});
				tot = (tot +
					(this.state.currentRow.speseDG0 ? this.state.currentRow.speseDG0 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa0 ? this.state.currentRow.fondocontrattazioneintegrativa0 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL0 ? this.state.currentRow.trattamentostipintegrativoCEL0 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento0 ? this.state.currentRow.contrattiincarichiinsegnamento0 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento0 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento0 : 0)
				);
				analisiannuale_default_numeratore0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!numeratore0"] = tot;

			},

			manageanalisiannuale_default_denominatore0: function () {
				var analisiannuale_default_denominatore0Ctrl = $("#analisiannuale_default_denominatore0");
				var tot =
					(this.state.currentRow.ffo0 ? this.state.currentRow.ffo0 : 0) +
					(this.state.currentRow.programmazionetriennale0 ? this.state.currentRow.programmazionetriennale0 : 0) +
					(this.state.currentRow.tasse0 ? this.state.currentRow.tasse0 : 0) -
					(this.state.currentRow.speseriduzione0 ? this.state.currentRow.speseriduzione0 : 0);

				analisiannuale_default_denominatore0Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!denominatore0"] = tot;
			},

			manageanalisiannuale_default_spesedocenti1: function () {
				var analisiannuale_default_spesedocenti1Ctrl = $("#analisiannuale_default_spesedocenti1");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importo1; //lordo
				});
				analisiannuale_default_spesedocenti1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.spesedocenti1 = tot;

			},

			manageanalisiannuale_default_finanzesternidocenti1: function () {
				var analisiannuale_default_finanzesternidocenti1Ctrl = $("#analisiannuale_default_finanzesternidocenti1");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importoesterno1; //lordo
				});
				analisiannuale_default_finanzesternidocenti1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.finanzesternidocenti1 = tot;
			},

			manageanalisiannuale_default_spesedirPTA1: function () {
				var analisiannuale_default_spesedirPTA1Ctrl = $("#analisiannuale_default_spesedirPTA1");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importo1; //lordo
				});
				analisiannuale_default_spesedirPTA1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.spesedirPTA1 = tot;

			},

			manageanalisiannuale_default_finanzesternidirPTA1: function () {
				var analisiannuale_default_finanzesternidirPTA1Ctrl = $("#analisiannuale_default_finanzesternidirPTA1");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importoesterno1; //lordo
				});
				analisiannuale_default_finanzesternidirPTA1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.finanzesternidirPTA1 = tot;
			},

			manageanalisiannuale_default_totspesepersonalecaricoateneo1: function () {
				var analisiannuale_default_totspesepersonalecaricoateneo1Ctrl = $("#analisiannuale_default_totspesepersonalecaricoateneo1");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.contrattokind_title.contains("Direttore generale")))
						return r.importoateneo1; //netto
				});
				analisiannuale_default_totspesepersonalecaricoateneo1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow.totspesepersonalecaricoateneo1 = tot;
			},

			manageanalisiannuale_default_speseDG1: function () {
				var analisiannuale_default_speseDG1Ctrl = $("#analisiannuale_default_speseDG1");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.contrattokind_title.contains("Direttore generale"))
						return r.importoateneo1; //netto
				});
				analisiannuale_default_speseDG1Ctrl.val(tot);
				this.state.currentRow.speseDG1 = tot;
			},

			manageanalisiannuale_default_numeratore1: function () {
				var analisiannuale_default_numeratore1Ctrl = $("#analisiannuale_default_numeratore1");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importo1;
				});
				tot = (tot +
					(this.state.currentRow.speseDG1 ? this.state.currentRow.speseDG1 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa1 ? this.state.currentRow.fondocontrattazioneintegrativa1 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL1 ? this.state.currentRow.trattamentostipintegrativoCEL1 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento1 ? this.state.currentRow.contrattiincarichiinsegnamento1 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento1 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento1 : 0)
				);
				analisiannuale_default_numeratore1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!numeratore1"] = tot;
			},

			manageanalisiannuale_default_spesedocenti2: function () {
				var analisiannuale_default_spesedocenti2Ctrl = $("#analisiannuale_default_spesedocenti2");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importo2; //lordo
				});
				analisiannuale_default_spesedocenti2Ctrl.val(tot);
				this.state.currentRow.spesedocenti2 = tot;
			},

			manageanalisiannuale_default_finanzesternidocenti2: function () {
				var analisiannuale_default_finanzesternidocenti2Ctrl = $("#analisiannuale_default_finanzesternidocenti2");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importoesterno2; //lordo
				});
				analisiannuale_default_finanzesternidocenti2Ctrl.val(tot);
				this.state.currentRow.finanzesternidocenti2 = tot;
			},

			manageanalisiannuale_default_spesedirPTA2: function () {
				var analisiannuale_default_spesedirPTA2Ctrl = $("#analisiannuale_default_spesedirPTA2");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importo2; //lordo
				});
				analisiannuale_default_spesedirPTA2Ctrl.val(tot);
				this.state.currentRow.spesedirPTA2 = tot;

			},

			manageanalisiannuale_default_finanzesternidirPTA2: function () {
				var analisiannuale_default_finanzesternidirPTA2Ctrl = $("#analisiannuale_default_finanzesternidirPTA2");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importoesterno2; //lordo
				});
				analisiannuale_default_finanzesternidirPTA2Ctrl.val(tot);
				this.state.currentRow.finanzesternidirPTA2 = tot;
			},

			manageanalisiannuale_default_totspesepersonalecaricoateneo2: function () {
				var analisiannuale_default_totspesepersonalecaricoateneo2Ctrl = $("#analisiannuale_default_totspesepersonalecaricoateneo2");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.contrattokind_title.contains("Direttore generale")))
						return r.importoateneo2; //netto
				});
				analisiannuale_default_totspesepersonalecaricoateneo2Ctrl.val(tot);
				this.state.currentRow.totspesepersonalecaricoateneo2 = tot;
			},

			manageanalisiannuale_default_speseDG2: function () {
				var analisiannuale_default_speseDG2Ctrl = $("#analisiannuale_default_speseDG2");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.contrattokind_title.contains("Direttore generale"))
						return r.importoateneo2; //netto
				});
				analisiannuale_default_speseDG2Ctrl.val(tot);
				this.state.currentRow.speseDG2 = tot;
			},

			manageanalisiannuale_default_numeratore2: function () {
				var analisiannuale_default_numeratore2Ctrl = $("#analisiannuale_default_numeratore2");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importo2;
				});
				tot = (tot +
					(this.state.currentRow.speseDG2 ? this.state.currentRow.speseDG2 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa2 ? this.state.currentRow.fondocontrattazioneintegrativa2 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL2 ? this.state.currentRow.trattamentostipintegrativoCEL2 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento2 ? this.state.currentRow.contrattiincarichiinsegnamento2 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento2 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento2 : 0)
				);
				analisiannuale_default_numeratore2Ctrl.val(tot);
				this.state.currentRow["!numeratore2"] = tot;
			},

			manageanalisiannuale_default_spesedocenti3: function () {
				var analisiannuale_default_spesedocenti3Ctrl = $("#analisiannuale_default_spesedocenti3");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importo3; //lordo
				});
				analisiannuale_default_spesedocenti3Ctrl.val(tot);
				this.state.currentRow.spesedocenti3 = tot;
			},

			manageanalisiannuale_default_finanzesternidocenti3: function () {
				var analisiannuale_default_finanzesternidocenti3Ctrl = $("#analisiannuale_default_finanzesternidocenti3");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.isdoc === 'S')
						return r.importoesterno3; //lordo
				});
				analisiannuale_default_finanzesternidocenti3Ctrl.val(tot);
				this.state.currentRow.finanzesternidocenti3 = tot;
			},

			manageanalisiannuale_default_spesedirPTA3: function () {
				var analisiannuale_default_spesedirPTA3Ctrl = $("#analisiannuale_default_spesedirPTA3");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importo3; //lordo
				});
				analisiannuale_default_spesedirPTA3Ctrl.val(tot);
				this.state.currentRow.spesedirPTA3 = tot;

			},

			manageanalisiannuale_default_finanzesternidirPTA3: function () {
				var analisiannuale_default_finanzesternidirPTA3Ctrl = $("#analisiannuale_default_finanzesternidirPTA3");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.isdoc === 'S') && !(r.contrattokind_title.contains("Direttore generale")))
						return r.importoesterno3; //lordo
				});
				analisiannuale_default_finanzesternidirPTA3Ctrl.val(tot);
				this.state.currentRow.finanzesternidirPTA3 = tot;
			},

			manageanalisiannuale_default_totspesepersonalecaricoateneo3: function () {
				var analisiannuale_default_totspesepersonalecaricoateneo3Ctrl = $("#analisiannuale_default_totspesepersonalecaricoateneo3");
				var self = this;
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (!(r.contrattokind_title.contains("Direttore generale")))
						return r.importoateneo3; //netto
				});
				analisiannuale_default_totspesepersonalecaricoateneo3Ctrl.val(tot);
				this.state.currentRow.totspesepersonalecaricoateneo3 = tot;
			},

			manageanalisiannuale_default_speseDG3: function () {
				var analisiannuale_default_speseDG3Ctrl = $("#analisiannuale_default_speseDG3");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					if (r.contrattokind_title.contains("Direttore generale"))
						return r.importoateneo3; //netto
				});
				analisiannuale_default_speseDG3Ctrl.val(tot);
				this.state.currentRow.speseDG3 = tot;
			},

			manageanalisiannuale_default_numeratore3: function () {
				var analisiannuale_default_numeratore3Ctrl = $("#analisiannuale_default_numeratore3");
				var tot = _.sumBy(this.state.DS.tables.pcspuntiorganicoview.rows, function (r) {
					return r.importo3;
				});
				tot = (tot +
					(this.state.currentRow.speseDG3 ? this.state.currentRow.speseDG3 : 0) +
					(this.state.currentRow.fondocontrattazioneintegrativa3 ? this.state.currentRow.fondocontrattazioneintegrativa3 : 0) +
					(this.state.currentRow.trattamentostipintegrativoCEL3 ? this.state.currentRow.trattamentostipintegrativoCEL3 : 0) +
					(this.state.currentRow.contrattiincarichiinsegnamento3 ? this.state.currentRow.contrattiincarichiinsegnamento3 : 0) -
					(this.state.currentRow.finanzesternicontrattiincarichiinsegnamento3 ? this.state.currentRow.finanzesternicontrattiincarichiinsegnamento3 : 0)
				);
				analisiannuale_default_numeratore3Ctrl.val(tot);
				this.state.currentRow["!numeratore3"] = tot;
			},

			manageanalisiannuale_default_denominatore1: function () {
				var analisiannuale_default_denominatore1Ctrl = $("#analisiannuale_default_denominatore1");
				var tot =
					(this.state.currentRow.ffo1 ? this.state.currentRow.ffo1 : 0) +
					(this.state.currentRow.programmazionetriennale1 ? this.state.currentRow.programmazionetriennale1 : 0) +
					(this.state.currentRow.tasse1 ? this.state.currentRow.tasse1 : 0) -
					(this.state.currentRow.speseriduzione1 ? this.state.currentRow.speseriduzione1 : 0);

				analisiannuale_default_denominatore1Ctrl.val(this.fillTextBoxFromNumber(tot));
				this.state.currentRow["!denominatore1"] = tot;
			},

			manageanalisiannuale_default_denominatore2: function () {
				var analisiannuale_default_denominatore2Ctrl = $("#analisiannuale_default_denominatore2");
				var tot =
					(this.state.currentRow.ffo2 ? this.state.currentRow.ffo2 : 0) +
					(this.state.currentRow.programmazionetriennale2 ? this.state.currentRow.programmazionetriennale2 : 0) +
					(this.state.currentRow.tasse2 ? this.state.currentRow.tasse2 : 0) -
					(this.state.currentRow.speseriduzione2 ? this.state.currentRow.speseriduzione2 : 0);

				analisiannuale_default_denominatore2Ctrl.val(tot);
				this.state.currentRow["!denominatore2"] = tot;
			},

			manageanalisiannuale_default_denominatore3: function () {
				var analisiannuale_default_denominatore3Ctrl = $("#analisiannuale_default_denominatore3");
				var tot =
					(this.state.currentRow.ffo3 ? this.state.currentRow.ffo3 : 0) +
					(this.state.currentRow.programmazionetriennale3 ? this.state.currentRow.programmazionetriennale3 : 0) +
					(this.state.currentRow.tasse3 ? this.state.currentRow.tasse3 : 0) -
					(this.state.currentRow.speseriduzione3 ? this.state.currentRow.speseriduzione3 : 0);

				analisiannuale_default_denominatore3Ctrl.val(tot);
				this.state.currentRow["!denominatore3"] = tot;
			},

			children: ['pcsassunzioni', 'pcsassunzionisimulate', 'pcsbilancio', 'pcscessazioniview', 'pcspuntiorganicoview', 'stipendioannuo'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('analisiannuale', 'default', metaPage_analisiannuale);

}());
