(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_fonteindicebibliometrico() {
		MetaPage.apply(this, ['fonteindicebibliometrico', 'seg', false]);
        this.name = 'Fonti degli indici bibliometrici';
		this.defaultListType = 'seg';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_fonteindicebibliometrico.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_fonteindicebibliometrico,
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

	window.appMeta.addMetaPage('fonteindicebibliometrico', 'seg', metaPage_fonteindicebibliometrico);

}());
