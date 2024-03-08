(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ambitoareadisc() {
		MetaPage.apply(this, ['ambitoareadisc', 'default', false]);
        this.name = 'Ambiti o aree disciplinari';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_ambitoareadisc.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ambitoareadisc,
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

	window.appMeta.addMetaPage('ambitoareadisc', 'default', metaPage_ambitoareadisc);

}());
