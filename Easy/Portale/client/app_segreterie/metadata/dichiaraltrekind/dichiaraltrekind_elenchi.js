(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_dichiaraltrekind() {
		MetaPage.apply(this, ['dichiaraltrekind', 'elenchi', false]);
        this.name = 'Tipologia delle altre dichiarazioni';
		this.defaultListType = 'elenchi';
		//pageHeaderDeclaration
    }

    metaPage_dichiaraltrekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_dichiaraltrekind,
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
				
				if (!parentRow.active)
					parentRow.active = "S";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-dichiaraltrekind_elenchi");
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

	window.appMeta.addMetaPage('dichiaraltrekind', 'elenchi', metaPage_dichiaraltrekind);

}());
