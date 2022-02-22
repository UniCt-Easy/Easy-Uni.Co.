
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

    function metaPage_pcsassunzionisimulate() {
		MetaPage.apply(this, ['pcsassunzionisimulate', 'default', true]);
        this.name = 'Assunzioni simulate';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_pcsassunzionisimulate.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pcsassunzionisimulate,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.percentuale)
					parentRow.percentuale = 100;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-pcsassunzionisimulate_default");
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

			//afterClear

			afterFill: function () {
				this.enableControl($('#pcsassunzionisimulate_default_stipendio'), false);
				this.enableControl($('#pcsassunzionisimulate_default_totale'), false);
				this.enableControl($('#pcsassunzionisimulate_default_totale1'), false);
				this.enableControl($('#pcsassunzionisimulate_default_totale2'), false);
				this.enableControl($('#pcsassunzionisimulate_default_totale3'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#pcsassunzionisimulate_default_data').on("change", _.partial(this.managedata, self));
				$('#pcsassunzionisimulate_default_idcontrattokind').on("change", _.partial(this.manageidcontrattokind, self));
				$('#pcsassunzionisimulate_default_idcontrattokind_start').on("change", _.partial(this.manageidcontrattokind_start, self));
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

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			manageTotali: function (p) {
				if (p.state.currentRow) {
					var currDateString = $('#pcsassunzionisimulate_default_data').val();
					var currDate = null;
					if (!currDateString)
						currDate = p.state.currentRow.data;
					else
						currDate = p.getDateTimeFromString(currDateString);
					//---------------------------0----------------------------------
					var costoMax = p.getCostoMax(p);
					//se non è assunto nell'anno corrente azzero il costo per quest'anno
					if (currDate)
						if (currDate.getFullYear() > p.state.callerState.currentRow.year)
							costoMax = 0
						else {
							var m = currDate.getMonth();
							var mesiLavorati = 12 - m;
							costoMax = (costoMax / 12) * mesiLavorati;
						}
					var tot = _.ceil(costoMax * (p.percentuale ? (p.percentuale / 100) : 1), 2);
					var stip = _.ceil(p.getCostoArrivo(p), 2);
					p.state.currentRow.totale = tot;
					p.state.currentRow.stipendio = stip;
					$('#pcsassunzionisimulate_default_totale').val(p.fillTextBoxFromNumber(tot));
					$('#pcsassunzionisimulate_default_stipendio').val(p.fillTextBoxFromNumber(stip));

					//---------------------------1----------------------------------
					costoMax = p.getCostoMax(p);
					if (p.isDocente(p)) {
						var rivalutazione1 = 1;
						if (p.state.callerState.currentRow.incrementodocenti1)
							rivalutazione1 = (p.state.callerState.currentRow.incrementodocenti1 + 100) / 100;
						costoMax = costoMax * rivalutazione1;
					}

					//se non è assunto nell'anno corrente azzero il costo per quest'anno
					if (currDate)
						if (currDate.getFullYear() > (p.state.callerState.currentRow.year + 1))
							costoMax = 0
						else {
							if (currDate.getFullYear() == (p.state.callerState.currentRow.year + 1)) {
								var m = currDate.getMonth();
								var mesiLavorati = 12 - m;
								costoMax = (costoMax / 12) * mesiLavorati;
							}
						}
					costoMax = _.ceil(costoMax * (p.percentuale ? (p.percentuale / 100) : 1), 2);
					p.state.currentRow.totale1 = costoMax;
					$('#pcsassunzionisimulate_default_totale1').val(p.fillTextBoxFromNumber(costoMax));

					//----------------------------2-----------------------------
					costoMax = p.getCostoMax(p);
					if (p.isDocente(p)) {
						var rivalutazione1 = 1;
						if (p.state.callerState.currentRow.incrementodocenti1)
							rivalutazione1 = (p.state.callerState.currentRow.incrementodocenti1 + 100) / 100;
						costoMax = costoMax * rivalutazione1;
						var rivalutazione2 = 1;
						if (p.state.callerState.currentRow.incrementodocenti2)
							rivalutazione2 = (p.state.callerState.currentRow.incrementodocenti2 + 100) / 100;
						costoMax = costoMax * rivalutazione2;
					}
					//se non è assunto nell'anno corrente azzero il costo per quest'anno
					if (currDate)
						if (currDate.getFullYear() > (p.state.callerState.currentRow.year + 2))
							costoMax = 0
						else {
							if (currDate.getFullYear() == (p.state.callerState.currentRow.year + 2)) {
								var m = currDate.getMonth();
								var mesiLavorati = 12 - m;
								costoMax = (costoMax / 12) * mesiLavorati;
							}
						}
					costoMax = _.ceil(costoMax * (p.percentuale ? (p.percentuale / 100) : 1), 2);
					p.state.currentRow.totale2 = costoMax;
					$('#pcsassunzionisimulate_default_totale2').val(p.fillTextBoxFromNumber(costoMax));
					//----------------------------3-------------------------------------
					costoMax = p.getCostoMax(p);
					if (p.isDocente(p)) {
						var rivalutazione1 = 1;
						if (p.state.callerState.currentRow.incrementodocenti1)
							rivalutazione1 = (p.state.callerState.currentRow.incrementodocenti1 + 100) / 100;
						costoMax = costoMax * rivalutazione1;
						var rivalutazione2 = 1;
						if (p.state.callerState.currentRow.incrementodocenti2)
							rivalutazione2 = (p.state.callerState.currentRow.incrementodocenti2 + 100) / 100;
						costoMax = costoMax * rivalutazione2;
						var rivalutazione3 = 1;
						if (p.state.callerState.currentRow.incrementodocenti3)
							rivalutazione3 = (p.state.callerState.currentRow.incrementodocenti3 + 100) / 100;
						costoMax = costoMax * rivalutazione3;
					}

					//se non è assunto nell'anno corrente azzero il costo per quest'anno
					if (currDate)
						if (currDate.getFullYear() > (p.state.callerState.currentRow.year + 3))
							costoMax = 0
						else {
							if (currDate.getFullYear() == (p.state.callerState.currentRow.year + 3)) {
								var m = currDate.getMonth();
								var mesiLavorati = 12 - m;
								costoMax = (costoMax / 12) * mesiLavorati;
							}
						}

					costoMax = _.ceil(costoMax * (p.percentuale ? (p.percentuale / 100) : 1), 2);
					p.state.currentRow.totale3 = costoMax;
					$('#pcsassunzionisimulate_default_totale3').val(p.fillTextBoxFromNumber(costoMax));
				}
			},

			getCostoArrivo: function (p) {
				var ck = p.state.DS.tables['getcontrattikindview'];
				var ckArrivo = $('#pcsassunzionisimulate_default_idcontrattokind').val();
				var CkArrivoRows = ck.select(p.q.eq('idcontrattokind', parseInt(ckArrivo)));
				var costoCkArrivo = 0;
				if (CkArrivoRows.length > 0)
					if (CkArrivoRows[0].costolordoannuo)
						costoCkArrivo = CkArrivoRows[0].costolordoannuo;

				return costoCkArrivo;
			},

			getCostoMax: function (p) {
				var costoCkArrivo = p.getCostoArrivo(p);

				var ck = p.state.DS.tables['getcontrattikindview'];
				var ckPartenza = $('#pcsassunzionisimulate_default_idcontrattokind_start').val();
				var costoCkPartenzaRows = ck.select(p.q.eq('idcontrattokind', parseInt(ckPartenza)));
				var costoCkPartenza = 0;
				if (costoCkPartenzaRows.length > 0)
					if (costoCkPartenzaRows[0].costolordoannuo)
						costoCkPartenza = costoCkPartenzaRows[0].costolordoannuo;

				return costoCkArrivo - costoCkPartenza;
			},

			isDocente: function (p) {
				var ck = p.state.DS.tables['getcontrattikindview'];
				var ckArrivo = $('#pcsassunzionisimulate_default_idcontrattokind').val();
				var CkArrivoRows = ck.select(p.q.eq('idcontrattokind', parseInt(ckArrivo)));
				var output = false;
				if (CkArrivoRows.length > 0)
					output = CkArrivoRows[0].tempdef == 'S';
				return output;
			},

			managedata: function(that) { 
				that.manageTotali(that);
			},

			manageidcontrattokind: function(that) { 
				that.manageTotali(that);
			},

			manageidcontrattokind_start: function(that) { 
				that.manageTotali(that);
			},

			//buttons
        });

	window.appMeta.addMetaPage('pcsassunzionisimulate', 'default', metaPage_pcsassunzionisimulate);

}());
