(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivosoglia() {
		MetaPage.apply(this, ['perfprogettoobiettivosoglia', 'soglia', true]);
        this.name = 'Soglie';
		this.defaultListType = 'soglia';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivosoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivosoglia,
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

	window.appMeta.addMetaPage('perfprogettoobiettivosoglia', 'soglia', metaPage_perfprogettoobiettivosoglia);

}());
