(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonaleateneo() {
		MetaPage.apply(this, ['perfvalutazionepersonaleateneo', 'default', true]);
        this.name = 'Performance organizzativa di ateneo';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonaleateneo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonaleateneo,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			afterFill: function () {
				this.enableControl($('#perfvalutazionepersonaleateneo_default_punteggiopesato'), false);
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

	window.appMeta.addMetaPage('perfvalutazionepersonaleateneo', 'default', metaPage_perfvalutazionepersonaleateneo);

}());
