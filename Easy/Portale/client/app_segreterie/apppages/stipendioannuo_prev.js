
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

    function metaPage_stipendioannuo() {
		MetaPage.apply(this, ['stipendioannuo', 'prev', true]);
        this.name = 'Personale già assunto';
		this.defaultListType = 'prev';
		//pageHeaderDeclaration
    }

    metaPage_stipendioannuo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_stipendioannuo,
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
				var def = appMeta.Deferred("afterGetFormData-stipendioannuo_prev");
				var arraydef = [];
				
				arraydef.push(this.managestipendioannuo_prev_irap());
				arraydef.push(this.managestipendioannuo_prev_totale());
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
				
				this.managestipendioannuo_prev_irap();
				this.managestipendioannuo_prev_totale();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#stipendioannuo_prev_idreg'), null);
				} else {
					this.helpForm.filter($('#stipendioannuo_prev_idreg'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-stipendioannuo_prev");
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
				this.helpForm.filter($('#stipendioannuo_prev_idreg'), null);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#stipendioannuo_prev_irap'), false);
				this.enableControl($('#stipendioannuo_prev_totale'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#stipendioannuo_prev_caricoente').on("change", _.partial(this.managecaricoente, self));
				$('#stipendioannuo_prev_lordo').on("change", _.partial(this.managelordo, self));
				appMeta.metaModel.cachedTable(this.getDataTable("contrattoprevview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("contrattoprevview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#stipendioannuo_prev_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#stipendioannuo_prev_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#stipendioannuo_prev_idcontratto').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#stipendioannuo_prev_idcontratto').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrypersoneview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("contrattoprevview"), false);
					var stipendioannuo_prev_idcontrattoCtrl = $('#stipendioannuo_prev_idcontratto').data("customController");
					arraydef.push(stipendioannuo_prev_idcontrattoCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idcontratto)
								stipendioannuo_prev_idcontrattoCtrl.fillControl(null, self.state.currentRow.idcontratto);
							return true;
						})
);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			afterActivation: function () {
				var parentRow = this.state.currentRow;
				var self = this;
				//afterActivationin
				var arraydef = [];
				if (parentRow.idreg) {
					appMeta.metaModel.cachedTable(this.getDataTable("contrattoprevview"), false);
					var stipendioannuo_prev_idcontrattoCtrl = $('#stipendioannuo_prev_idcontratto').data("customController");
					arraydef.push(stipendioannuo_prev_idcontrattoCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", parentRow.idreg), null, true));
				}
				//afterActivationAsincIn
				return $.when.apply($, arraydef);
			},

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#stipendioannuo_prev_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Dipendente');
				}
				if (!$('#stipendioannuo_prev_idcontratto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Contratto');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			managestipendioannuo_prev_irap_totale: function (p) {
					var lordo = 0;
					var caricoente = 0;
					if(p.state.currentRow){
						if(p.state.currentRow.lordo)
							lordo = p.state.currentRow.lordo;
						if(p.state.currentRow.caricoente )
							caricoente = p.state.currentRow.caricoente ;
						var irap = _.ceil(lordo * 8.5, 2);
						var totale = lordo + caricoente + irap;
						p.state.currentRow.totale = totale ;
						p.state.currentRow.irap = irap ;
						$('#stipendioannuo_prev_totale').val(totale);
						$('#stipendioannuo_prev_irap').val(irap);
					}

			}
,

			managecaricoente: function(that) { 
				managestipendioannuo_prev_irap_totale(that);
			},

			managelordo: function(that) { 
				managestipendioannuo_prev_irap_totale(that);
			},

			managestipendioannuo_prev_irap: function () {
				this.state.currentRow.irap = this.state.currentRow.lordo * 0.085;
			},

			managestipendioannuo_prev_totale: function () {
				this.state.currentRow.totale = this.state.currentRow.lordo + this.state.currentRow.caricoente + this.state.currentRow.irap;

			},

			children: [''],
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

	window.appMeta.addMetaPage('stipendioannuo', 'prev', metaPage_stipendioannuo);

}());
