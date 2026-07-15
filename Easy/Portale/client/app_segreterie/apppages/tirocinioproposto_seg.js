(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirocinioproposto() {
		MetaPage.apply(this, ['tirocinioproposto', 'seg', false]);
        this.name = 'Proposte di tirocinio';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tirocinioproposto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirocinioproposto,
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
					this.helpForm.filter($('#tirocinioproposto_seg_idreg_referente'), null);
				} else {
					this.helpForm.filter($('#tirocinioproposto_seg_idreg_referente'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#tirocinioproposto_seg_idstruttura'), null);
				} else {
					this.helpForm.filter($('#tirocinioproposto_seg_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-tirocinioproposto_seg");
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
				this.enableControl($('#tirocinioproposto_seg_idreg_referente'), true);
				this.helpForm.filter($('#tirocinioproposto_seg_idreg_referente'), null);
				this.helpForm.filter($('#tirocinioproposto_seg_idstruttura'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-tirocinioproposto_seg");
				$('#tirocinioproposto_seg_idreg_referente').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_referente);
				$('#tirocinioproposto_seg_idreg_referente').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_referente);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#tirocinioproposto_seg_idreg_referente').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Referente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			//afterPost

			children: ['tirociniocandidatura'],
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

	window.appMeta.addMetaPage('tirocinioproposto', 'seg', metaPage_tirocinioproposto);

}());
