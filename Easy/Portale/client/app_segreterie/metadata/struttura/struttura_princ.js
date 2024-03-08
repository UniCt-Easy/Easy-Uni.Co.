(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_struttura() {
		MetaPage.apply(this, ['struttura', 'princ', true]);
        this.name = 'Strutture';
		this.defaultListType = 'princ';
		//pageHeaderDeclaration
    }

    metaPage_struttura.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_struttura,
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
				
				if (this.isNull(parentRow.active) || parentRow.active == '')
					parentRow.active = 'S';
				if (this.isNull(parentRow.idreg))
					parentRow.idreg = this.idreg_istituto;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#struttura_princ_idupb'), null);
				} else {
					this.helpForm.filter($('#struttura_princ_idupb'), this.q.eq('upb_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-struttura_princ");
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
				this.helpForm.filter($('#struttura_princ_idupb'), null);
				//afterClearin
			},

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

	window.appMeta.addMetaPage('struttura', 'princ', metaPage_struttura);

}());
