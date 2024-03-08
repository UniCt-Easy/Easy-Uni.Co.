(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfpositionattach() {
		MetaPage.apply(this, ['perfpositionattach', 'default', true]);
        this.name = 'Moduli di rendicontazione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfpositionattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfpositionattach,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('perfpositionattach', 'default', metaPage_perfpositionattach);

}());
