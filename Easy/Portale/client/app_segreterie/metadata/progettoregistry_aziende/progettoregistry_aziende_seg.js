(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoregistry_aziende() {
		MetaPage.apply(this, ['progettoregistry_aziende', 'seg', true]);
        this.name = 'Enti partner';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettoregistry_aziende.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoregistry_aziende,
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
					this.helpForm.filter($('#progettoregistry_aziende_seg_idreg_aziende'), null);
				} else {
					this.helpForm.filter($('#progettoregistry_aziende_seg_idreg_aziende'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettoregistry_aziende_seg");
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
				this.helpForm.filter($('#progettoregistry_aziende_seg_idreg_aziende'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("partnerkinddefaultview"), this.q.eq('partnerkind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettoregistry_aziende_seg");
				$('#progettoregistry_aziende_seg_idreg_aziende').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_aziende);
				$('#progettoregistry_aziende_seg_idreg_aziende').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_aziende);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettoregistry_aziende_seg_idreg_aziende').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ente o azienda partner');
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

	window.appMeta.addMetaPage('progettoregistry_aziende', 'seg', metaPage_progettoregistry_aziende);

}());
