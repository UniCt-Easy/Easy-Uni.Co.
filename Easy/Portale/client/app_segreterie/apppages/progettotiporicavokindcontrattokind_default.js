(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotiporicavokindcontrattokind() {
		MetaPage.apply(this, ['progettotiporicavokindcontrattokind', 'default', true]);
        this.name = 'Tipi di contratto associati come ricavo';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettotiporicavokindcontrattokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotiporicavokindcontrattokind,
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
					this.helpForm.filter($('#progettotiporicavokindcontrattokind_default_idposition'), null);
				} else {
					this.helpForm.filter($('#progettotiporicavokindcontrattokind_default_idposition'), this.q.eq('position_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettotiporicavokindcontrattokind_default");
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
				this.helpForm.filter($('#progettotiporicavokindcontrattokind_default_idposition'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettotiporicavokindcontrattokind_default");
				$('#progettotiporicavokindcontrattokind_default_idposition').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idposition);
				$('#progettotiporicavokindcontrattokind_default_idposition').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idposition);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotiporicavokindcontrattokind_default_idposition').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
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

	window.appMeta.addMetaPage('progettotiporicavokindcontrattokind', 'default', metaPage_progettotiporicavokindcontrattokind);

}());
