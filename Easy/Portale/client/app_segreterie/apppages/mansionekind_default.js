(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_mansionekind() {
		MetaPage.apply(this, ['mansionekind', 'default', false]);
        this.name = 'Mansioni';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_mansionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_mansionekind,
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
				this.state.DS.tables.mansionekind.defaults({ 'generascheda': 'S' });
				this.state.DS.tables.mansionekind.defaults({ 'pesoateneo': 0 });
				this.state.DS.tables.mansionekind.defaults({ 'pesocomp': 0 });
				this.state.DS.tables.mansionekind.defaults({ 'pesoindividuale': 0 });
				this.state.DS.tables.mansionekind.defaults({ 'pesouo': 0 });
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

	window.appMeta.addMetaPage('mansionekind', 'default', metaPage_mansionekind);

}());
