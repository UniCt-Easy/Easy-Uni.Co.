(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_fasciaiseedef() {
		MetaPage.apply(this, ['fasciaiseedef', 'sconti', false]);
        this.name = 'Fasce ISEE';
		this.defaultListType = 'sconti';
		//pageHeaderDeclaration
    }

    metaPage_fasciaiseedef.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_fasciaiseedef,
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
				
				parentRow.idcostoscontodef = this.state.callerState.currentRow.idcostoscontodef;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#fasciaiseedef_sconti_idfasciaisee'), null);
				} else {
					this.helpForm.filter($('#fasciaiseedef_sconti_idfasciaisee'), this.q.eq('fasciaisee_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-fasciaiseedef_sconti");
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
				this.helpForm.filter($('#fasciaiseedef_sconti_idfasciaisee'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				var f1 = window.jsDataQuery.eq("idcostoscontodef", this.state.callerState.currentRow.idcostoscontodef);
				self.firstSearchFilter  = f1;
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

	window.appMeta.addMetaPage('fasciaiseedef', 'sconti', metaPage_fasciaiseedef);

}());
