(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettobudgetvariazione() {
		MetaPage.apply(this, ['progettobudgetvariazione', 'default', true]);
        this.name = 'Variazioni del budget';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettobudgetvariazione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettobudgetvariazione,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.setFilterprogettobudgetvariazione_default();
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

			setFilterprogettobudgetvariazione_default: function () {
				var self = this;
				var UPBRows = _.map(self.state.callerState.callerState.DS.tables.workpackageupb.rows,
					function (row) {
						if (row.idworkpackage === self.state.callerState.currentRow.idworkpackage) {
							return row.idupb;
						}
					});
				var filterUPB = this.q.isIn('idupb', _.filter(UPBRows,
					function (upb) {
						return !!upb;
					}
				));
				self.state.DS.tables.upbdefaultview.staticFilter(filterUPB);
				var AccmotiveRows = _.map(self.state.callerState.callerState.DS.tables.progettotipocostoaccmotive.rows,
					function (row) {
						if (row.idprogettotipocosto === self.state.callerState.currentRow.idprogettotipocosto) {
							return row.idaccmotive;
						}
					});
				var filterAccmotive = this.q.isIn('idaccmotive', _.filter(AccmotiveRows,
					function (acc) {
						return !!acc;
					}
				));
				self.state.DS.tables.accmotivedefaultview.staticFilter(filterAccmotive);
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettobudgetvariazione', 'default', metaPage_progettobudgetvariazione);

}());
