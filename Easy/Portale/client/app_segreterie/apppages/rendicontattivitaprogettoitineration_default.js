(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontattivitaprogettoitineration() {
		MetaPage.apply(this, ['rendicontattivitaprogettoitineration', 'default', true]);
        this.name = 'Missioni dell\'attività';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogettoitineration.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogettoitineration,
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
					this.helpForm.filter($('#rendicontattivitaprogettoitineration_default_iditineration'), null);
				} else {
					this.helpForm.filter($('#rendicontattivitaprogettoitineration_default_iditineration'), this.q.eq('itineration_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogettoitineration_default");
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
				this.helpForm.filter($('#rendicontattivitaprogettoitineration_default_iditineration'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicontattivitaprogettoitineration_default");
				$('#rendicontattivitaprogettoitineration_default_iditineration').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iditineration);
				$('#rendicontattivitaprogettoitineration_default_iditineration').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iditineration);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#rendicontattivitaprogettoitineration_default_iditineration').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Missione');
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

	window.appMeta.addMetaPage('rendicontattivitaprogettoitineration', 'default', metaPage_rendicontattivitaprogettoitineration);

}());
