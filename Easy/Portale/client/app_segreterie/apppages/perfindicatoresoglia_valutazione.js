(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfindicatoresoglia() {
		MetaPage.apply(this, ['perfindicatoresoglia', 'valutazione', true]);
        this.name = 'Soglie';
		this.defaultListType = 'valutazione';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canSave = false;
		this.canCancel = false;
		this.canCmdClose = false;
		this.canShowLast = false;
		//pageHeaderDeclaration
    }

    metaPage_perfindicatoresoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfindicatoresoglia,
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

	window.appMeta.addMetaPage('perfindicatoresoglia', 'valutazione', metaPage_perfindicatoresoglia);

}());
