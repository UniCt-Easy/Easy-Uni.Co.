(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotipocostocontrattokind() {
		MetaPage.apply(this, ['progettotipocostocontrattokind', 'seg', true]);
        this.name = 'Tipi di contratto associati come costo';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotipocostocontrattokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocostocontrattokind,
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
					this.helpForm.filter($('#progettotipocostocontrattokind_seg_idposition'), null);
				} else {
					this.helpForm.filter($('#progettotipocostocontrattokind_seg_idposition'), this.q.eq('position_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettotipocostocontrattokind_seg");
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
				this.helpForm.filter($('#progettotipocostocontrattokind_seg_idposition'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettotipocostocontrattokind_seg");
				$('#progettotipocostocontrattokind_seg_idposition').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idposition);
				$('#progettotipocostocontrattokind_seg_idposition').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idposition);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotipocostocontrattokind_seg_idposition').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Tipo di contratto');
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

	window.appMeta.addMetaPage('progettotipocostocontrattokind', 'seg', metaPage_progettotipocostocontrattokind);

}());
