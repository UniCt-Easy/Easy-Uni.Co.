(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalida() {
		MetaPage.apply(this, ['convalida', 'segistrein', true]);
        this.name = 'Convalida/riconoscimento/dispensa ';
		this.defaultListType = 'segistrein';
		//pageHeaderDeclaration
    }

    metaPage_convalida.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalida,
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
				
				if (!parentRow.idconvalidakind)
					parentRow.idconvalidakind = 2;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-convalida_segistrein");
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

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('convalida', 'segistrein', metaPage_convalida);

}());
