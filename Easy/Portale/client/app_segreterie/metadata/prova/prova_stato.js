(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_prova() {
		MetaPage.apply(this, ['prova', 'stato', true]);
        this.name = 'Prove';
		this.defaultListType = 'stato';
		//pageHeaderDeclaration
    }

    metaPage_prova.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_prova,
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
				
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-prova_stato");
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

			afterLink: function () {
				var self = this;
				this.setDenyNull("prova","title");
				this.setDenyNull("prova","start");
				this.setDenyNull("prova","stop");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('prova', 'stato', metaPage_prova);

}());
