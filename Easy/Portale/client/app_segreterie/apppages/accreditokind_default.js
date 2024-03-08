(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_accreditokind() {
		MetaPage.apply(this, ['accreditokind', 'default', false]);
        this.name = 'Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_accreditokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_accreditokind,
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

	window.appMeta.addMetaPage('accreditokind', 'default', metaPage_accreditokind);

}());
