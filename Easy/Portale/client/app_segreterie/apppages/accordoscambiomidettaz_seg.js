(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_accordoscambiomidettaz() {
		MetaPage.apply(this, ['accordoscambiomidettaz', 'seg', true]);
        this.name = 'Dettaglio dell’accordo per le aziende';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_accordoscambiomidettaz.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_accordoscambiomidettaz,
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
					this.helpForm.filter($('#accordoscambiomidettaz_seg_idreg_aziende'), null);
				} else {
					this.helpForm.filter($('#accordoscambiomidettaz_seg_idreg_aziende'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-accordoscambiomidettaz_seg");
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
				this.enableControl($('#accordoscambiomidettaz_seg_idreg_aziende'), true);
				this.helpForm.filter($('#accordoscambiomidettaz_seg_idreg_aziende'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidettaz'), this.getDataTable('cefrlanglevel'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidettaz'), this.getDataTable('cefrlanglevel'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-accordoscambiomidettaz_seg");
				$('#accordoscambiomidettaz_seg_idreg_aziende').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_aziende);
				$('#accordoscambiomidettaz_seg_idreg_aziende').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_aziende);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#accordoscambiomidettaz_seg_idreg_aziende').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Azienda');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['cefrlanglevel'],
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

	window.appMeta.addMetaPage('accordoscambiomidettaz', 'seg', metaPage_accordoscambiomidettaz);

}());
