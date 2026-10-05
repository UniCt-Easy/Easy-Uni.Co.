(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodocelement() {
		MetaPage.apply(this, ['protocollodocelement', 'seg', true]);
        this.name = 'Elemento del documento';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_protocollodocelement.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodocelement,
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
				this.state.DS.tables.protocollodockind.staticFilter(window.jsDataQuery.eq("kind", this.state.callerState.callerState.DS.tables.protocollokinddefaultview.rows.find(row => row.idprotocollokind === this.state.callerState.callerState.currentRow.idprotocollokind)?.title ?? ''));
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

			//afterPost

			//buttons
        });

	window.appMeta.addMetaPage('protocollodocelement', 'seg', metaPage_protocollodocelement);

}());
