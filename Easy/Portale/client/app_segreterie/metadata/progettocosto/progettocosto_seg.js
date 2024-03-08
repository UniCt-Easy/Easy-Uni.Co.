(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettocosto() {
		MetaPage.apply(this, ['progettocosto', 'seg', true]);
        this.name = 'Dettaglio dei costi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettocosto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettocosto,
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
					this.helpForm.filter($('#progettocosto_seg_idposition'), null);
				} else {
					this.helpForm.filter($('#progettocosto_seg_idposition'), this.q.eq('position_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progettocosto_seg_idpettycash'), null);
				} else {
					this.helpForm.filter($('#progettocosto_seg_idpettycash'), this.q.eq('pettycash_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettocosto_seg");
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
				this.enableControl($('#progettocosto_seg_idrelated'), true);
				this.helpForm.filter($('#progettocosto_seg_idposition'), null);
				this.helpForm.filter($('#progettocosto_seg_idpettycash'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#progettocosto_seg_idrelated'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto();
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto: function () {
				var self = this;
				var filter = self.q.eq('idprogetto', self.state.callerState.currentRow.idprogetto);
				self.state.DS.tables.workpackagesegview.staticFilter(filter);
				self.state.DS.tables.progettotipocosto.staticFilter(filter);
				self.state.DS.tables.saldefaultview.staticFilter(filter);
			}
,

			//buttons
        });

	window.appMeta.addMetaPage('progettocosto', 'seg', metaPage_progettocosto);

}());
