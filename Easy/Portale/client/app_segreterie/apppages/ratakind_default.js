(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ratakind() {
		MetaPage.apply(this, ['ratakind', 'default', false]);
        this.name = 'Rate';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_ratakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ratakind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-ratakind_default");
				var arraydef = [];
				
				arraydef.push(this.manageratakind_default_idratakind());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-ratakind_default");
				var arraydef = [];
				
				arraydef.push(this.manageratakind_default_idratakind());
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

			manageratakind_default_idratakind: function () {
				var def = appMeta.Deferred("beforeFill-manageratakind_idratakind");
				var self = this;
				this.state.currentRow.idratakind = this.state.currentRow.title;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('ratakind', 'default', metaPage_ratakind);

}());
