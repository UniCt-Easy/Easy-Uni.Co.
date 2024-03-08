(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonalesoglia() {
		MetaPage.apply(this, ['perfvalutazionepersonalesoglia', 'default', true]);
        this.name = 'Soglie definite per l’obiettivo individuale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonalesoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonalesoglia,
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

	window.appMeta.addMetaPage('perfvalutazionepersonalesoglia', 'default', metaPage_perfvalutazionepersonalesoglia);

}());
