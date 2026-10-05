(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaconf() {
		MetaPage.apply(this, ['tassaconf', 'default', false]);
        this.name = 'Definizione dei costi generici';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassaconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaconf,
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
				appMeta.metaModel.insertFilter(this.getDataTable("tassaconfkinddefaultview"), this.q.eq('tassaconfkind_active', 'Si'));
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

	window.appMeta.addMetaPage('tassaconf', 'default', metaPage_tassaconf);

}());
