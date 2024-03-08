(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_position() {
		MetaPage.apply(this, ['position', 'default', false]);
        this.name = 'Tipologie di contratto';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_position.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_position,
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
				this.state.DS.tables.position.defaults({ 'parttime': "N" });
				$('#grid_inquadramento_default').data('mdlconditionallookup', 'tempdef,S,Si;tempdef,N,No;');
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

	window.appMeta.addMetaPage('position', 'default', metaPage_position);

}());
