(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizionebmiattach() {
		MetaPage.apply(this, ['iscrizionebmiattach', 'seg', true]);
        this.name = 'Allegati richiesti ';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_iscrizionebmiattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizionebmiattach,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('iscrizionebmiattach', 'seg', metaPage_iscrizionebmiattach);

}());
