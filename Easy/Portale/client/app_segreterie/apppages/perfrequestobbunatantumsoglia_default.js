(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfrequestobbunatantumsoglia() {
		MetaPage.apply(this, ['perfrequestobbunatantumsoglia', 'default', true]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfrequestobbunatantumsoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfrequestobbunatantumsoglia,
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

	window.appMeta.addMetaPage('perfrequestobbunatantumsoglia', 'default', metaPage_perfrequestobbunatantumsoglia);

}());
