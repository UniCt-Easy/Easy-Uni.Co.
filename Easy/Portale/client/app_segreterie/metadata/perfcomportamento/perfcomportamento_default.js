(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfcomportamento() {
		MetaPage.apply(this, ['perfcomportamento', 'default', false]);
        this.name = 'Comportamenti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfcomportamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfcomportamento,
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfcomportamento_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
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

			//beforePost

			insertSoglie: function (prm) {
            return this.superClass.insertSoglie({ table: "perfcomportamentosoglia", keyColumns: "idperfcomportamento" });
         },

			//buttons
        });

	window.appMeta.addMetaPage('perfcomportamento', 'default', metaPage_perfcomportamento);

}());
