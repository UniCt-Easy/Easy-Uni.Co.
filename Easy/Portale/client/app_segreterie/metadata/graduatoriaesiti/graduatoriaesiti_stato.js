(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriaesiti() {
		MetaPage.apply(this, ['graduatoriaesiti', 'stato', true]);
        this.name = 'Graduatorie provvisorie e definitive';
		this.defaultListType = 'stato';
		//pageHeaderDeclaration
    }

    metaPage_graduatoriaesiti.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriaesiti,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.isNull(parentRow.provvisoria) || parentRow.provvisoria == '')
					parentRow.provvisoria = "S";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-graduatoriaesiti_stato");
				var arraydef = [];
				
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
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

	window.appMeta.addMetaPage('graduatoriaesiti', 'stato', metaPage_graduatoriaesiti);

}());
