(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_questionariodomrisp() {
		MetaPage.apply(this, ['questionariodomrisp', 'default', true]);
        this.name = 'Risposte';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_questionariodomrisp.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_questionariodomrisp,
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
				
				if (!parentRow.multiplacontxt)
					parentRow.multiplacontxt = 'N';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-questionariodomrisp_default");
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

	window.appMeta.addMetaPage('questionariodomrisp', 'default', metaPage_questionariodomrisp);

}());
