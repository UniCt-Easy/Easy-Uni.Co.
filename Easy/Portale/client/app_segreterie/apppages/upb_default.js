(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_upb() {
		MetaPage.apply(this, ['upb', 'default', false]);
        this.name = 'Unità previsionali di base';
		this.defaultListType = 'default';
		this.isList = true;
		this.isTree = true;
		this.searchEnabled = false;
		//pageHeaderDeclaration
    }

    metaPage_upb.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_upb,
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

			beforeSelectTreeManager: function () {
				var def = appMeta.Deferred('beforeSelectTreeManager');
				return def.resolve(true)
			},

			//buttons
        });

	window.appMeta.addMetaPage('upb', 'default', metaPage_upb);

}());
