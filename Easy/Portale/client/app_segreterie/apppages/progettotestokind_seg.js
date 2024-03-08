(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotestokind() {
		MetaPage.apply(this, ['progettotestokind', 'seg', true]);
        this.name = 'Testi del modello';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotestokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotestokind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotestokind'), this.getDataTable('progettotestokindprogettostatuskind'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotestokind'), this.getDataTable('progettotestokindprogettostatuskind'));
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

	window.appMeta.addMetaPage('progettotestokind', 'seg', metaPage_progettotestokind);

}());
