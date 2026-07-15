(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_costoscontodefdettagliokind() {
		MetaPage.apply(this, ['costoscontodefdettagliokind', 'default', false]);
        this.name = 'Voci dei dettaglio debito';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_costoscontodefdettagliokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodefdettagliokind,
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
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotivecredit'), null);
				} else {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotivecredit'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiverevenue'), null);
				} else {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiverevenue'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiveundotax'), null);
				} else {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiveundotax'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiveundotaxpost'), null);
				} else {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiveundotaxpost'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idfinmotive'), null);
				} else {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idfinmotive'), this.q.eq('finmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idfinmotive_iva'), null);
				} else {
					this.helpForm.filter($('#costoscontodefdettagliokind_default_idfinmotive_iva'), this.q.eq('finmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-costoscontodefdettagliokind_default");
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
				//parte sincrona
				this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotivecredit'), null);
				this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiverevenue'), null);
				this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiveundotax'), null);
				this.helpForm.filter($('#costoscontodefdettagliokind_default_idaccmotiveundotaxpost'), null);
				this.helpForm.filter($('#costoscontodefdettagliokind_default_idfinmotive'), null);
				this.helpForm.filter($('#costoscontodefdettagliokind_default_idfinmotive_iva'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//afterPost

			//buttons
        });

	window.appMeta.addMetaPage('costoscontodefdettagliokind', 'default', metaPage_costoscontodefdettagliokind);

}());
