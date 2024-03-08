(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoria() {
		MetaPage.apply(this, ['graduatoria', 'default', false]);
        this.name = 'Definizioni delle graduatorie';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_graduatoria.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoria,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoria'), this.getDataTable('graduatoriadesc'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoria'), this.getDataTable('graduatoriadesc'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('graduatoria', 'default', metaPage_graduatoria);

}());
