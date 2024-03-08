(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsservizio() {
		MetaPage.apply(this, ['bandodsservizio', 'seg', true]);
        this.name = 'Servizi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsservizio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsservizio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('bandodsservizio', 'seg', metaPage_bandodsservizio);

}());
