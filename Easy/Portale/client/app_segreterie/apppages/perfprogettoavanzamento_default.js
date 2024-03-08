(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoavanzamento() {
		MetaPage.apply(this, ['perfprogettoavanzamento', 'default', true]);
        this.name = 'Avanzamenti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoavanzamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoavanzamento,
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
				var def = appMeta.Deferred("afterGetFormData-perfprogettoavanzamento_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettoavanzamento_default_avanzamento());
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
				
				this.manageperfprogettoavanzamento_default_avanzamento();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfprogettoavanzamento_default_idreg_amministrativi'), null);
				} else {
					this.helpForm.filter($('#perfprogettoavanzamento_default_idreg_amministrativi'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfprogettoavanzamento_default_idreg_amministrativi_ver'), null);
				} else {
					this.helpForm.filter($('#perfprogettoavanzamento_default_idreg_amministrativi_ver'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoavanzamento_default");
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
				this.helpForm.filter($('#perfprogettoavanzamento_default_idreg_amministrativi'), null);
				this.helpForm.filter($('#perfprogettoavanzamento_default_idreg_amministrativi_ver'), null);
				this.enableControl($('#perfprogettoavanzamento_default_data'), true);
				this.enableControl($('#perfprogettoavanzamento_default_avanzamento'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfprogettoavanzamento_default_data'), false);
				this.enableControl($('#perfprogettoavanzamento_default_avanzamento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterProgettoavanzamento_default_idreg();
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
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

			setFilterProgettoavanzamento_default_idreg: function () {
           var arrayRegAmministrativi = _.map(this.state.callerPage.getDataTable("perfprogettouomembro").rows, function (r) { return r.idreg; });
            var filter = window.jsDataQuery.isIn("idreg", arrayRegAmministrativi);
            this.state.DS.tables.registryamministrativiview.staticFilter(filter);
            this.state.DS.tables.registryamministrativiview_alias1.staticFilter(filter);
         },

			manageperfprogettoavanzamento_default_avanzamento: function () {
    if (this.state.isInsertState()) {
					this.state.currentRow.avanzamento = this.state.callerState.currentRow.risultato;
					this.state.currentRow.data = new Date();
				}
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoavanzamento', 'default', metaPage_perfprogettoavanzamento);

}());
