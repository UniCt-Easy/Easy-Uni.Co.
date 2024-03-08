(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotiporicavoaccmotive() {
		MetaPage.apply(this, ['progettotiporicavoaccmotive', 'seg', true]);
        this.name = 'Causali economico patrimoniali di ricavo associate';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotiporicavoaccmotive.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotiporicavoaccmotive,
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
					this.helpForm.filter($('#progettotiporicavoaccmotive_seg_idaccmotive'), null);
				} else {
					this.helpForm.filter($('#progettotiporicavoaccmotive_seg_idaccmotive'), this.q.eq('accmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettotiporicavoaccmotive_seg");
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
				this.helpForm.filter($('#progettotiporicavoaccmotive_seg_idaccmotive'), null);
				//afterClearin
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettotiporicavoaccmotive_seg");
				$('#progettotiporicavoaccmotive_seg_idaccmotive').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettotiporicavoaccmotive_seg_idaccmotive').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotiporicavoaccmotive_seg_idaccmotive').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Causale economico patrimoniale');
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

	window.appMeta.addMetaPage('progettotiporicavoaccmotive', 'seg', metaPage_progettotiporicavoaccmotive);

}());
