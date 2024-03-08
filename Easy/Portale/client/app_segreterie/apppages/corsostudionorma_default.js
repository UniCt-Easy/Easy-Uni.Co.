(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_corsostudionorma() {
		MetaPage.apply(this, ['corsostudionorma', 'default', false]);
        this.name = 'Normativa dei corsi di studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_corsostudionorma.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudionorma,
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

	window.appMeta.addMetaPage('corsostudionorma', 'default', metaPage_corsostudionorma);

}());
