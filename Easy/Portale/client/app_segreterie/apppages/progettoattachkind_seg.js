(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoattachkind() {
		MetaPage.apply(this, ['progettoattachkind', 'seg', true]);
        this.name = 'Allegati necessari';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettoattachkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoattachkind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettoattachkind'), this.getDataTable('progettoattachkindprogettostatuskind'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettoattachkind'), this.getDataTable('progettoattachkindprogettostatuskind'));
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

	window.appMeta.addMetaPage('progettoattachkind', 'seg', metaPage_progettoattachkind);

}());
