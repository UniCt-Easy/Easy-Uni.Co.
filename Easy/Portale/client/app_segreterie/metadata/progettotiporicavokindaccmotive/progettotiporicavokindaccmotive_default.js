(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotiporicavokindaccmotive() {
		MetaPage.apply(this, ['progettotiporicavokindaccmotive', 'default', true]);
        this.name = 'Causali economico patrimoniali di ricavo associate';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettotiporicavokindaccmotive.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotiporicavokindaccmotive,
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
					this.helpForm.filter($('#progettotiporicavokindaccmotive_default_idaccmotive'), null);
				} else {
					this.helpForm.filter($('#progettotiporicavokindaccmotive_default_idaccmotive'), this.q.eq('accmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettotiporicavokindaccmotive_default");
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
				this.helpForm.filter($('#progettotiporicavokindaccmotive_default_idaccmotive'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettotiporicavokindaccmotive_default");
				$('#progettotiporicavokindaccmotive_default_idaccmotive').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idaccmotive);
				$('#progettotiporicavokindaccmotive_default_idaccmotive').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idaccmotive);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotiporicavokindaccmotive_default_idaccmotive').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('progettotiporicavokindaccmotive', 'default', metaPage_progettotiporicavokindaccmotive);

}());
