(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_staffagrteaching() {
		MetaPage.apply(this, ['staffagrteaching', 'seg', true]);
        this.name = 'Staff Mobility Agreement for teaching';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_staffagrteaching.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_staffagrteaching,
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
					this.helpForm.filter($('#staffagrteaching_seg_idisced2013'), null);
				} else {
					this.helpForm.filter($('#staffagrteaching_seg_idisced2013'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#staffagrteaching_seg_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#staffagrteaching_seg_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#staffagrteaching_seg_idreg_resp'), null);
				} else {
					this.helpForm.filter($('#staffagrteaching_seg_idreg_resp'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#staffagrteaching_seg_idreg_respestero'), null);
				} else {
					this.helpForm.filter($('#staffagrteaching_seg_idreg_respestero'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-staffagrteaching_seg");
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
				this.helpForm.filter($('#staffagrteaching_seg_idisced2013'), null);
				this.helpForm.filter($('#staffagrteaching_seg_idreg_docenti'), null);
				this.helpForm.filter($('#staffagrteaching_seg_idreg_resp'), null);
				this.helpForm.filter($('#staffagrteaching_seg_idreg_respestero'), null);
				//afterClearin
			},

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('staffagrteaching', 'seg', metaPage_staffagrteaching);

}());
