(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandods() {
		MetaPage.apply(this, ['bandods', 'seg', false]);
        this.name = 'Bandi di diritto allo studio';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandods.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandods,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_bandodsservizio_seg').data('mdlconditionallookup', 'alloggio,S,Si;alloggio,N,No;fuoricorso,S,Si;fuoricorso,N,No;maggiorenne,S,Si;maggiorenne,N,No;mensa,S,Si;mensa,N,No;parttime,S,Si;parttime,N,No;primaimmatlivello,S,Si;primaimmatlivello,N,No;');
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

	window.appMeta.addMetaPage('bandods', 'seg', metaPage_bandods);

}());
