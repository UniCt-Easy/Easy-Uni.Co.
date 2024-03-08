(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convenzioneattach() {
		MetaPage.apply(this, ['convenzioneattach', 'seg', true]);
        this.name = 'Allegati';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_convenzioneattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convenzioneattach,
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

	window.appMeta.addMetaPage('convenzioneattach', 'seg', metaPage_convenzioneattach);

}());
