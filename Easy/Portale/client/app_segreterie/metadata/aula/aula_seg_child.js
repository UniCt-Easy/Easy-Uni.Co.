(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_aula() {
		MetaPage.apply(this, ['aula', 'seg_child', true]);
        this.name = 'Aule';
		this.defaultListType = 'seg_child';
		//pageHeaderDeclaration
    }

    metaPage_aula.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_aula,
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

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('aula', 'seg_child', metaPage_aula);

}());
