(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_titolostudio() {
		MetaPage.apply(this, ['titolostudio', 'docenti', true]);
        this.name = 'Titoli di studio';
		this.defaultListType = 'docenti';
		//pageHeaderDeclaration
    }

    metaPage_titolostudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_titolostudio,
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
				
				if (this.isNull(parentRow.conseguito) || parentRow.conseguito == '')
					parentRow.conseguito = 'N';
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#titolostudio_docenti_idreg_istituti'), null);
				} else {
					this.helpForm.filter($('#titolostudio_docenti_idreg_istituti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-titolostudio_docenti");
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

			afterClear: function () {
				this.helpForm.filter($('#titolostudio_docenti_idreg_istituti'), null);
				//afterClearin
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("titolostudio","data");
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

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('titolostudio', 'docenti', metaPage_titolostudio);

}());
