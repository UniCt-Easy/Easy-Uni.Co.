(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprogporzanno() {
		MetaPage.apply(this, ['didprogporzanno', 'default', true]);
        this.name = 'Porzione d\'anno';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprogporzanno.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprogporzanno,
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
				var def = appMeta.Deferred("afterGetFormData-didprogporzanno_default");
				var arraydef = [];
				
				arraydef.push(this.managedidprogporzanno_default_title());
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
				var def = appMeta.Deferred("beforeFill-didprogporzanno_default");
				var arraydef = [];
				
				arraydef.push(this.managedidprogporzanno_default_title());
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

			managedidprogporzanno_default_title: function () {
var def = appMeta.Deferred("beforeFill-managedidprogporzanno_title");     this.state.currentRow.title = this.state.currentRow.indice + " " + this.stringFromIdporzanno(this.state.currentRow.iddidprogporzannokind);     return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('didprogporzanno', 'default', metaPage_didprogporzanno);

}());
