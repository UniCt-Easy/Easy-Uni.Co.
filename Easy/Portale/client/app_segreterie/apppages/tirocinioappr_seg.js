(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirocinioappr() {
		MetaPage.apply(this, ['tirocinioappr', 'seg', true]);
        this.name = 'Accettazioni o rifiuti dello studente o del referente';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tirocinioappr.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirocinioappr,
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

			//buttons
        });

	window.appMeta.addMetaPage('tirocinioappr', 'seg', metaPage_tirocinioappr);

}());
