(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidante() {
		MetaPage.apply(this, ['convalidante', 'segstudprat', true]);
        this.name = 'Convalidanti';
		this.defaultListType = 'segstudprat';
		//pageHeaderDeclaration
    }

    metaPage_convalidante.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidante,
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
				appMeta.metaModel.insertFilter(this.getDataTable("changeskinddefaultview"), this.q.eq('changeskind_active', 'Si'));
				this.state.DS.tables.sostenimentoseganagstuview.staticFilter(window.jsDataQuery.eq("idreg", this.state.callerState.currentRow.idreg));
				this.state.DS.tables.tirocinioprogetto.staticFilter(window.jsDataQuery.eq("idreg_studenti", this.state.callerState.currentRow.idreg));
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

	window.appMeta.addMetaPage('convalidante', 'segstudprat', metaPage_convalidante);

}());
