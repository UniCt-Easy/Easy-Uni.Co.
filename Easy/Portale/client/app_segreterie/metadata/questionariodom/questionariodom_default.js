(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_questionariodom() {
		MetaPage.apply(this, ['questionariodom', 'default', true]);
        this.name = 'Domande';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_questionariodom.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_questionariodom,
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

			//buttons
        });

	window.appMeta.addMetaPage('questionariodom', 'default', metaPage_questionariodom);

}());
