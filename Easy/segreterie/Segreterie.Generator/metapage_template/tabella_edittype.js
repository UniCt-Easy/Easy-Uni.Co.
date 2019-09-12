(function() {
	
    var MetaPage = window.appMeta.MetaPage;

    function metaPage_tabella() {
        MetaPage.apply(this, arguments);
        this.name = 'titolopagina';
		this.defaultListType = 'tipoedit';
		//rowSelectedEventManager
		//buttonClickEndEventManager
    }

    metaPage_tabella.prototype = _.extend(
        new MetaPage('tabella', 'tipoedit', Principale),
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

	window.appMeta.addMetaPage('tabella', 'tipoedit', metaPage_tabella);

}());
