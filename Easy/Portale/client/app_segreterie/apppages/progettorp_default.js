(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettorp() {
		MetaPage.apply(this, ['progettorp', 'default', true]);
        this.name = 'Reporting periods';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettorp.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettorp,
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
				
				if (this.isNull(parentRow.datefilter) || parentRow.datefilter == '')
					parentRow.datefilter = 'C';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettorp_default");
				var arraydef = [];
				
				arraydef.push(this.filterCosti());
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
				$('input[name="progettorp_default_datefilter"]').on("change", _.partial(this.managedatefilter, self));
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

			beforePost: function () {
				var self = this;
				this.getDataTable('getprogettocostoview').acceptChanges();
				//innerBeforePost
			},

			filterCosti: function () {
				if (this.state.currentRow.start && this.state.currentRow.start) {
					var filter = this.q.and(this.q.gt("docdate", this.state.currentRow.start), this.q.lt("docdate", this.state.currentRow.stop));
					if (this.state.currentRow.datefilter === 'C') {
						filter = this.q.and(this.q.gt("docdate", this.state.currentRow.start), this.q.lt("docdate", this.state.currentRow.stop));
					}
					if (this.state.currentRow.datefilter === 'L') {
						filter = this.q.and(this.q.gt("adate", this.state.currentRow.start), this.q.lt("adate", this.state.currentRow.stop));
					}
					if (this.state.currentRow.datefilter === 'M') {
						filter = this.q.and(this.q.gt("payment_adate", this.state.currentRow.start), this.q.lt("payment_adate", this.state.currentRow.stop));
					}
					if (this.state.currentRow.datefilter === 'T') {
						filter = this.q.and(this.q.gt("transmissiondate", this.state.currentRow.start), this.q.lt("transmissiondate", this.state.currentRow.stop));
					}
					if (this.state.currentRow.datefilter === 'Q') {
						filter = this.q.and(this.q.gt("transactiondate", this.state.currentRow.start), this.q.lt("transactiondate", this.state.currentRow.stop));
					}
					this.getDataTable('getprogettocostoview').clear();
					var selBuilderArray = [];
					selBuilderArray.push({ filter: filter, top: null, tableName: 'getprogettocostoview', table: this.state.DS.tables['getprogettocostoview'] });

					return appMeta.getData.multiRunSelect(selBuilderArray);
				}

				return true;
			},

			managedatefilter: function(that) { 
				var self = that;
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				self.getFormData(true)
					.then(function () {
						return that.filterCosti();
					})
					.then(function () {
						self.freshForm(true, false)
							.then(function () {
								self.hideWaitingIndicator(waitingHandler);
							});
					});
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettorp', 'default', metaPage_progettorp);

}());
