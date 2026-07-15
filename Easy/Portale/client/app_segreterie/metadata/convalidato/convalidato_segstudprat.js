(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidato() {
		MetaPage.apply(this, ['convalidato', 'segstudprat', true]);
        this.name = 'Convalidati';
		this.defaultListType = 'segstudprat';
		//pageHeaderDeclaration
    }

    metaPage_convalidato.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidato,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			
			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			afterLink: function () {
	var self = this;

	appMeta.metaModel.insertFilter(this.getDataTable("changeskinddefaultview"), this.q.eq('changeskind_active', 'Si'));
	this.state.DS.tables.attivformdefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", this.state.callerState.currentRow.iddidprog));
				//fireAfterLink
	return this.superClass.afterLink.call(this).then(function () {
		var arraydef = [];

		arraydef.push(
			self.getAttivformByIscrizione(self.state.callerState.currentRow.idiscrizione)
				.then(function (idattivforms) {
					var selBuilderArray = [];
					selBuilderArray.push({ filter: self.q.isIn('idattivform', idattivforms), top: null, tableName: 'attivformdefaultview', table: self.getDataTable('attivformdefaultview') });
					return appMeta.getData.multiRunSelect(selBuilderArray);
				})
		);
		//fireAfterLinkAsinc
		return $.when.apply($, arraydef);
	});
},

			//buttons
        });

	window.appMeta.addMetaPage('convalidato', 'segstudprat', metaPage_convalidato);

}());
