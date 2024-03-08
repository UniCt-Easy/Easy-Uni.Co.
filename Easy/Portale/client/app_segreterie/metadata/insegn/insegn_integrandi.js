(function() {
	
    var MetaPage = window.appMeta.MetaPage;

    function metaPage_tabella() {
        MetaPage.apply(this, arguments);
        this.name = 'Insegnamenti integrandi';
		this.defaultListType = 'integrandi';
		//rowSelectedEventManager
		//buttonClickEndEventManager
    }

    metaPage_tabella.prototype = _.extend(
        new MetaPage('insegn', 'integrandi', true),
        {
            constructor: metaPage_tabella,
            superClass: MetaPage.prototype,

            getName:function () {
               return this.name;
            },
			
			//beforeFill

			//afterLink

			//rowSelected

			//buttonClickEnd

			//buttons
        });

	window.appMeta.addMetaPage('insegn', 'integrandi', metaPage_tabella);

}());
