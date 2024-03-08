(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_contrattokind() {
		MetaPage.apply(this, ['contrattokind', 'default', false]);
        this.name = 'Tipologie di contratto';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_contrattokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_contrattokind,
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
				this.state.DS.tables.contrattokind.defaults({ 'parttime': "N" });
				$('#grid_inquadramento_default').data('mdlconditionallookup', 'tempdef,S,Si;tempdef,N,No;');
				$('#grid_contrattokindposition_default').data('mdlconditionallookup', '!idposition_position_active,S,Si;!idposition_position_active,N,No;!idposition_position_foreignclass,S,Si;!idposition_position_foreignclass,N,No;');
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

	window.appMeta.addMetaPage('contrattokind', 'default', metaPage_contrattokind);

}());
