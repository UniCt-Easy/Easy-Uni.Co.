(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanzaattach() {
		MetaPage.apply(this, ['istanzaattach', 'seg', true]);
        this.name = 'Certificati';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_istanzaattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanzaattach,
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
				
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 9;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanzaattach_seg");
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

	window.appMeta.addMetaPage('istanzaattach', 'seg', metaPage_istanzaattach);

}());
