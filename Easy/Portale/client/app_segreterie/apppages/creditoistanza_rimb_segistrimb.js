(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_creditoistanza_rimb() {
		MetaPage.apply(this, ['creditoistanza_rimb', 'segistrimb', true]);
        this.name = 'Crediti';
		this.defaultListType = 'segistrimb';
		//pageHeaderDeclaration
    }

    metaPage_creditoistanza_rimb.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_creditoistanza_rimb,
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

	window.appMeta.addMetaPage('creditoistanza_rimb', 'segistrimb', metaPage_creditoistanza_rimb);

}());
