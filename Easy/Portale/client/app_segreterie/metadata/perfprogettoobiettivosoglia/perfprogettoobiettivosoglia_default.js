(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivosoglia() {
		MetaPage.apply(this, ['perfprogettoobiettivosoglia', 'default', true]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
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

	window.appMeta.addMetaPage('perfprogettoobiettivosoglia', 'default', metaPage_perfprogettoobiettivosoglia);

}());
