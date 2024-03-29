﻿(function () {
	
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
				
				if (this.isNull(parentRow.data))
					parentRow.data = new Date();
				if (this.isNull(parentRow.idanalisiannuale) || parentRow.idanalisiannuale == 0)
					parentRow.idanalisiannuale = 4;
				if (this.isNull(parentRow.numeropersoneassunzione))
					parentRow.numeropersoneassunzione = 1;
				if (this.isNull(parentRow.percentuale))
					parentRow.percentuale = 100;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#pcsassunzionisimulate_default_idposition_start'), null);
				} else {
					this.helpForm.filter($('#pcsassunzionisimulate_default_idposition_start'), this.q.eq('position_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#pcsassunzionisimulate_default_idposition'), null);
				} else {
					this.helpForm.filter($('#pcsassunzionisimulate_default_idposition'), this.q.eq('position_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#pcsassunzionisimulate_default_idstruttura'), null);
				} else {
					this.helpForm.filter($('#pcsassunzionisimulate_default_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
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

			afterClear: function () {
				//parte sincrona
				this.helpForm.filter($('#pcsassunzionisimulate_default_idposition_start'), null);
				this.helpForm.filter($('#pcsassunzionisimulate_default_idposition'), null);
				this.enableControl($('#pcsassunzionisimulate_default_stipendio'), true);
				this.helpForm.filter($('#pcsassunzionisimulate_default_idstruttura'), null);
				this.enableControl($('#pcsassunzionisimulate_default_totale'), true);
				this.enableControl($('#pcsassunzionisimulate_default_totale1'), true);
				this.enableControl($('#pcsassunzionisimulate_default_totale2'), true);
				this.enableControl($('#pcsassunzionisimulate_default_totale3'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

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
				var def = appMeta.Deferred("afterRowSelect-pcsassunzionisimulate_default");
				if (t.name === "positiondefaultview_alias1" && r !== null) {
					this.manageidposition(this);
					return def.resolve();
				}
				if (t.name === "positiondefaultview" && r !== null) {
					this.manageidposition_start(this);
					return def.resolve();
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			beforePost: function () {
				var self = this;
				this.getDataTable('getcontrattikindview').acceptChanges();
				//innerBeforePost
			},

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
				var ckArrivo = $('#pcsassunzionisimulate_default_idposition').val();
				var CkArrivoRows = ck.select(p.q.eq('idposition', parseInt(ckArrivo)));
				var costoCkArrivo = 0;
				if (CkArrivoRows.length > 0)
					if (CkArrivoRows[0].costolordoannuo)
						costoCkArrivo = CkArrivoRows[0].costolordoannuo;

				return costoCkArrivo;
			},

			getCostoMax: function (p) {
				var costoCkArrivo = p.getCostoArrivo(p);

				var ck = p.state.DS.tables['getcontrattikindview'];
				var ckPartenza = $('#pcsassunzionisimulate_default_idposition_start').val();
				var costoCkPartenzaRows = ck.select(p.q.eq('idposition', parseInt(ckPartenza)));
				var costoCkPartenza = 0;
				if (costoCkPartenzaRows.length > 0)
					if (costoCkPartenzaRows[0].costolordoannuo)
						costoCkPartenza = costoCkPartenzaRows[0].costolordoannuo;

				return costoCkArrivo - costoCkPartenza;
			},

			isDocente: function (p) {
				var ck = p.state.DS.tables['getcontrattikindview'];
				var ckArrivo = $('#pcsassunzionisimulate_default_idposition').val();
				var CkArrivoRows = ck.select(p.q.eq('idposition', parseInt(ckArrivo)));
				var output = false;
				if (CkArrivoRows.length > 0)
					output = CkArrivoRows[0].tempdef == 'S';
				return output;
			},

			managedata: function(that) { 
				that.manageTotali(that);
			},

			manageidposition: function(that) { 
				that.manageTotali(that);
			},

			manageidposition_start: function(that) { 
				that.manageTotali(that);
			},

			//buttons
        });

	window.appMeta.addMetaPage('pcsassunzionisimulate', 'default', metaPage_pcsassunzionisimulate);

}());
