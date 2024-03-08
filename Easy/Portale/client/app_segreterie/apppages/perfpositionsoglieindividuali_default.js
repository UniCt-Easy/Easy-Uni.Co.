(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfpositionsoglieindividuali() {
		MetaPage.apply(this, ['perfpositionsoglieindividuali', 'default', true]);
        this.name = 'Soglie degli obiettivi individuali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfpositionsoglieindividuali.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfpositionsoglieindividuali,
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

	window.appMeta.addMetaPage('perfpositionsoglieindividuali', 'default', metaPage_perfpositionsoglieindividuali);

}());
