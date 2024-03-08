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

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.provvisoria)
					parentRow.provvisoria = "S";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-graduatoriaesiti_stato");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('graduatoriaesiti', 'stato', metaPage_graduatoriaesiti);

}());
