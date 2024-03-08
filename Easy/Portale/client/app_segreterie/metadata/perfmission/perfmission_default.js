(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfmission() {
		MetaPage.apply(this, ['perfmission', 'default', false]);
        this.name = 'Missioni istituzionali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfmission.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfmission,
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

	window.appMeta.addMetaPage('perfmission', 'default', metaPage_perfmission);

}());
