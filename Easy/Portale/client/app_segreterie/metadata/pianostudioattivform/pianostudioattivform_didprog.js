(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudioattivform() {
		MetaPage.apply(this, ['pianostudioattivform', 'didprog', true]);
        this.name = 'Attività formative pianificate';
		this.defaultListType = 'didprog';
		//pageHeaderDeclaration
    }

    metaPage_pianostudioattivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudioattivform,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			afterFill: function () {
				this.enableControl($('#pianostudioattivform_didprog_idsostenimento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('pianostudioattivform', 'didprog', metaPage_pianostudioattivform);

}());
