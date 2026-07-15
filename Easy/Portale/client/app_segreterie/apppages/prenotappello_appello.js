(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_prenotappello() {
		MetaPage.apply(this, ['prenotappello', 'appello', true]);
        this.name = 'Prenotazioni';
		this.defaultListType = 'appello';
		//pageHeaderDeclaration
    }

    metaPage_prenotappello.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_prenotappello,
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
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-prenotappello_appello");
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
				this.enableControl($('#prenotappello_appello_data'), true);
				this.enableControl($('#prenotappello_appello_idpianostudioattivform'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#prenotappello_appello_data'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.pianostudioattivformprenotview.staticFilter(window.jsDataQuery.eq('pianostudioattivform_idattivform', this.state.callerState.currentRow.idattivform));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-prenotappello_appello");
				$('#prenotappello_appello_idpianostudioattivform').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idpianostudioattivform);
				$('#prenotappello_appello_idpianostudioattivform').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idpianostudioattivform);
				if (t.name === "pianostudioattivformprenotview" && r !== null) {
					return this.manageidpianostudioattivform(this).then(function () {
						return def.resolve();
					});
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#prenotappello_appello_idpianostudioattivform').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo attività formativa del piano di studi');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			//afterPost

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

			manageidpianostudioattivform: function(that) { 
				var def = appMeta.Deferred("manageidpianostudioattivform-prenotappello_appello");
				that.state.currentRow.idattivform = that.state.DS.tables.pianostudioattivformprenotview.rows[0].idattivform_scelta;
				that.state.currentRow.idiscrizione = that.state.DS.tables.pianostudioattivformprenotview.rows[0].idiscrizione ;
				that.state.currentRow.idpianostudio = that.state.DS.tables.pianostudioattivformprenotview.rows[0].idpianostudio;
				that.state.currentRow.idreg = that.state.DS.tables.pianostudioattivformprenotview.rows[0].idreg 
				return def.resolve();

			},

			//buttons
        });

	window.appMeta.addMetaPage('prenotappello', 'appello', metaPage_prenotappello);

}());
