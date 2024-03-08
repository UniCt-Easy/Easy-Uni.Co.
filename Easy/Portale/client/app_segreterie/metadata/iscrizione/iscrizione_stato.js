(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'stato', true]);
        this.name = 'Iscrizioni';
		this.defaultListType = 'stato';
		//pageHeaderDeclaration
    }

    metaPage_iscrizione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizione,
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
					this.helpForm.filter($('#iscrizione_stato_idreg'), null);
				} else {
					this.helpForm.filter($('#iscrizione_stato_idreg'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-iscrizione_stato");
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
				this.helpForm.filter($('#iscrizione_stato_idreg'), null);
				//afterClearin
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizione_stato");
				$('#iscrizione_stato_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizione_stato_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_stato_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: [''],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('iscrizione', 'stato', metaPage_iscrizione);

}());
