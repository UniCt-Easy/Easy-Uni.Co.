(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_contrattokindposition() {
		MetaPage.apply(this, ['contrattokindposition', 'default', true]);
        this.name = 'Ruoli associati';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_contrattokindposition.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_contrattokindposition,
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
					this.helpForm.filter($('#contrattokindposition_default_idposition'), null);
				} else {
					this.helpForm.filter($('#contrattokindposition_default_idposition'), this.q.eq('position_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-contrattokindposition_default");
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
				this.helpForm.filter($('#contrattokindposition_default_idposition'), null);
				//afterClearin
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-contrattokindposition_default");
				$('#contrattokindposition_default_idposition').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#contrattokindposition_default_idposition').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#contrattokindposition_default_idposition').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ruolo');
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

	window.appMeta.addMetaPage('contrattokindposition', 'default', metaPage_contrattokindposition);

}());
