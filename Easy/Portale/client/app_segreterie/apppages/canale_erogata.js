(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_canale() {
		MetaPage.apply(this, ['canale', 'erogata', true]);
        this.name = 'Canali';
		this.defaultListType = 'erogata';
		//pageHeaderDeclaration
    }

    metaPage_canale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_canale,
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
				var def = appMeta.Deferred("afterGetFormData-canale_erogata");
				var arraydef = [];
				
				arraydef.push(this.managecanale_erogata_idsede());
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
				
				this.managecanale_erogata_idsede();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-canale_erogata");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('getdocentiperssd'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('getdocentiperssd'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_mutuazione_default').data('mdlconditionallookup', 'riferimento,S,Si;riferimento,N,No;');
				$('#grid_affidamento_default').data('mdlconditionallookup', 'freqobbl,S,Si;freqobbl,N,No;gratuito,S,Si;gratuito,N,No;riferimento,S,Si;riferimento,N,No;');
				var grid_affidamento_defaultChildsTables = [
					{ tablename: 'affidamentocaratteristica', edittype: 'default', columnlookup: 'cf', columncalc: '!affidamentocaratteristica'},
				];
				$('#grid_affidamento_default').data('childtables', grid_affidamento_defaultChildsTables);
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

			managecanale_erogata_idsede: function () {
this.state.currentRow.idsede= this.state.callerState.currentRow.idsede;
			},

			//buttons
        });

	window.appMeta.addMetaPage('canale', 'erogata', metaPage_canale);

}());
