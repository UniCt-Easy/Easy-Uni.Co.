(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonalecomportamentosoglia() {
		MetaPage.apply(this, ['perfvalutazionepersonalecomportamentosoglia', 'default', true]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonalecomportamentosoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonalecomportamentosoglia,
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

	window.appMeta.addMetaPage('perfvalutazionepersonalecomportamentosoglia', 'default', metaPage_perfvalutazionepersonalecomportamentosoglia);

}());
