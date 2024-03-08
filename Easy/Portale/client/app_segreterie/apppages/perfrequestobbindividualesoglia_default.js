(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfrequestobbindividualesoglia() {
		MetaPage.apply(this, ['perfrequestobbindividualesoglia', 'default', true]);
        this.name = 'Soglie ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfrequestobbindividualesoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfrequestobbindividualesoglia,
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

	window.appMeta.addMetaPage('perfrequestobbindividualesoglia', 'default', metaPage_perfrequestobbindividualesoglia);

}());
