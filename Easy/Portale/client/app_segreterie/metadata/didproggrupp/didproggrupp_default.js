(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didproggrupp() {
		MetaPage.apply(this, ['didproggrupp', 'default', false]);
        this.name = 'Gruppi opzionali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didproggrupp.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didproggrupp,
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
				
				parentRow.idcorsostudio = this.state.callerState.currentRow.idcorsostudio;
				parentRow.iddidprog = this.state.callerState.currentRow.iddidprog;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didproggrupp_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('didproggrupp'), this.getDataTable('attivform'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('didproggrupp'), this.getDataTable('attivform'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				var f1 = window.jsDataQuery.eq("idcorsostudio", this.state.callerState.currentRow.idcorsostudio);
				var f2 = window.jsDataQuery.eq("iddidprog", this.state.callerState.currentRow.iddidprog);
				self.firstSearchFilter  = window.jsDataQuery.and(f1, f2);
					self.startFilter = self.firstSearchFilter;
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

			//buttons
        });

	window.appMeta.addMetaPage('didproggrupp', 'default', metaPage_didproggrupp);

}());
