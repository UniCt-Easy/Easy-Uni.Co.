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
				//parte sincrona
				this.helpForm.filter($('#stipendioannuo_prev_idreg'), null);
				this.enableControl($('#stipendioannuo_prev_irap'), true);
				this.enableControl($('#stipendioannuo_prev_totale'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#stipendioannuo_prev_irap'), false);
				this.enableControl($('#stipendioannuo_prev_totale'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("registrylegalstatusprevview"), this.q.eq('registrylegalstatus_active', 'Si'));
				$('#stipendioannuo_prev_caricoente').on("change", _.partial(this.managecaricoente, self));
				$('#stipendioannuo_prev_lordo').on("change", _.partial(this.managelordo, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-stipendioannuo_prev");
				$('#stipendioannuo_prev_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#stipendioannuo_prev_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#stipendioannuo_prev_idregistrylegalstatus').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idregistrylegalstatus);
				$('#stipendioannuo_prev_idregistrylegalstatus').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idregistrylegalstatus);
				$('#stipendioannuo_prev_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idregistrylegalstatus);
				$('#stipendioannuo_prev_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idregistrylegalstatus);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#stipendioannuo_prev_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Dipendente');
				}
				if (!$('#stipendioannuo_prev_idregistrylegalstatus').val() && this.children.includes(grid.dataSourceName)) {
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

			managecaricoente: function(that) { 
				that.managestipendioannuo_prev_irap_totale(that);
			},

			managelordo: function(that) { 
				that.managestipendioannuo_prev_irap_totale(that);
			},

			//buttons
        });

	window.appMeta.addMetaPage('stipendioannuo', 'prev', metaPage_stipendioannuo);

}());
