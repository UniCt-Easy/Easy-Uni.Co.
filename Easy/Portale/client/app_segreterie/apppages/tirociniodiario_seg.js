(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirociniodiario() {
		MetaPage.apply(this, ['tirociniodiario', 'seg', true]);
        this.name = 'Diario';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tirociniodiario.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirociniodiario,
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

			createAndGetListManager: function (searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, isCommandSearch) {
                // isCommandSearch è true se lancio comando di ricerca, false se vengo da un autochoose, e qin quel caso implemnto comportamento di default
                var startColumnName = "data";
                var titleColumnName = "description";
                var stopColumnName = null;
                if (isCommandSearch) return new window.appMeta.ListManagerCalendar(searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, startColumnName , titleColumnName, stopColumnName);
                // se non esco prima, significa autochoose e quindi esegue il sodiuce della superClass
                return this.superClass.createAndGetListManager(searchTableName, listingType, prefilter, isModal,rootElement, that, filterLocked, toMerge, isCommandSearch);
            },

			//buttons
        });

	window.appMeta.addMetaPage('tirociniodiario', 'seg', metaPage_tirociniodiario);

}());
