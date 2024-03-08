(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_assetdiaryora() {
		MetaPage.apply(this, ['assetdiaryora', 'seg', true]);
        this.name = 'Dettaglio giorni di utilizzo';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_assetdiaryora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_assetdiaryora,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				this.enableControl($('#assetdiaryora_seg_amount'), true);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#assetdiaryora_seg_amount'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('assetdiaryora', 'seg', metaPage_assetdiaryora);

}());
