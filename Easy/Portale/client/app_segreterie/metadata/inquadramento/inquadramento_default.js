(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_inquadramento() {
		MetaPage.apply(this, ['inquadramento', 'default', true]);
        this.name = 'Inquadramento';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_inquadramento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_inquadramento,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData

			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$('#grid_stipendiocomplemento_default').data('mdlconditionallookup', 'idstipendiocomplementokind,3,Tipologia: Compenso individuale accessorio (CIA) ;idstipendiocomplementokind,6,Tipologia: Indennità art. 7 l. 43892 ;idstipendiocomplementokind,4,Tipologia: Indennità di Amministrazione ;idstipendiocomplementokind,5,Tipologia: Indennità di Funzione ;idstipendiocomplementokind,1,Tipologia: Indice di vacanza contrattuale (IVC) ;idstipendiocomplementokind,2,Tipologia: Retribuzione professionale docente (RPD) ;');
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

			//afterPost

			//buttons
        });

	window.appMeta.addMetaPage('inquadramento', 'default', metaPage_inquadramento);

}());
