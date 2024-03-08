(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_allegatirichiesti() {
		MetaPage.apply(this, ['allegatirichiesti', 'default', false]);
        this.name = 'Definizione degli allegati ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_allegatirichiesti.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_allegatirichiesti,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("allegatirichiesti","active");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('allegatirichiesti', 'default', metaPage_allegatirichiesti);

}());
