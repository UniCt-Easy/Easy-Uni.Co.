(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfsoglia() {
		MetaPage.apply(this, ['perfsoglia', 'default', false]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_perfsoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfsoglia,
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
				this.setDenyNull("perfsoglia","year");
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

	window.appMeta.addMetaPage('perfsoglia', 'default', metaPage_perfsoglia);

}());
