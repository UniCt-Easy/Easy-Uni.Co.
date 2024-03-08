(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentokindcostoora() {
		MetaPage.apply(this, ['affidamentokindcostoora', 'default', true]);
        this.name = 'Costo orario per anno accademico';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_affidamentokindcostoora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamentokindcostoora,
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

	window.appMeta.addMetaPage('affidamentokindcostoora', 'default', metaPage_affidamentokindcostoora);

}());
