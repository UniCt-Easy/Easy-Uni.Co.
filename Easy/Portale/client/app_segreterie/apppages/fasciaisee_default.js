(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_fasciaisee() {
		MetaPage.apply(this, ['fasciaisee', 'default', false]);
        this.name = 'Fasce ISEE';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_fasciaisee.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_fasciaisee,
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
				var def = appMeta.Deferred("afterGetFormData-fasciaisee_default");
				var arraydef = [];
				
				arraydef.push(this.managefasciaisee_default_idfasciaisee());
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
				var def = appMeta.Deferred("beforeFill-fasciaisee_default");
				var arraydef = [];
				
				arraydef.push(this.managefasciaisee_default_idfasciaisee());
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

			managefasciaisee_default_idfasciaisee: function () {
				var def = appMeta.Deferred("beforeFill-managefasciaisee_idfasciaisee");
				var self = this;
				this.state.currentRow.idfasciaisee = this.state.currentRow.title;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('fasciaisee', 'default', metaPage_fasciaisee);

}());
