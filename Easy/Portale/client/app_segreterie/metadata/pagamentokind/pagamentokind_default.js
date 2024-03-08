(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pagamentokind() {
		MetaPage.apply(this, ['pagamentokind', 'default', false]);
        this.name = 'Tipologie di pagamento';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_pagamentokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pagamentokind,
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

	window.appMeta.addMetaPage('pagamentokind', 'default', metaPage_pagamentokind);

}());
