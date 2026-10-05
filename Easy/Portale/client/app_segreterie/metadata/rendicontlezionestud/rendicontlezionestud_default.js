(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontlezionestud() {
		MetaPage.apply(this, ['rendicontlezionestud', 'default', true]);
        this.name = 'Studenti della lezione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontlezionestud.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontlezionestud,
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
					this.helpForm.filter($('#rendicontlezionestud_default_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#rendicontlezionestud_default_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontlezionestud_default");
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
				this.enableControl($('#rendicontlezionestud_default_idreg_studenti'), true);
				this.helpForm.filter($('#rendicontlezionestud_default_idreg_studenti'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicontlezionestud_default");
				$('#rendicontlezionestud_default_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#rendicontlezionestud_default_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#rendicontlezionestud_default_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('rendicontlezionestud', 'default', metaPage_rendicontlezionestud);

}());
