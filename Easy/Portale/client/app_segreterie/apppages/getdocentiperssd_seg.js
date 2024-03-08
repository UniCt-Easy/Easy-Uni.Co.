(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_getdocentiperssd() {
		MetaPage.apply(this, ['getdocentiperssd', 'seg', true]);
        this.name = 'Docenti compatibili per settore';
		this.defaultListType = 'seg';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canSave = false;
		this.canCancel = false;
		this.canCmdClose = false;
		this.canShowLast = false;
		//pageHeaderDeclaration
    }

    metaPage_getdocentiperssd.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_getdocentiperssd,
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
				
				if (self.isNullOrMinDate(parentRow.iniziocontratto))
					parentRow.iniziocontratto = new Date();
				if (self.isNullOrMinDate(parentRow.terminecontratto))
					parentRow.terminecontratto = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-getdocentiperssd_seg");
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

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("getdocentiperssd","aa");
				this.setDenyNull("getdocentiperssd","idreg");
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

			//buttons
        });

	window.appMeta.addMetaPage('getdocentiperssd', 'seg', metaPage_getdocentiperssd);

}());
