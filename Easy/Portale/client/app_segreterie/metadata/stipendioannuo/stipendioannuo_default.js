(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_stipendioannuo() {
		MetaPage.apply(this, ['stipendioannuo', 'default', true]);
        this.name = 'Stipendio annuo importato';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_stipendioannuo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_stipendioannuo,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-stipendioannuo_default");
				var arraydef = [];
				
				arraydef.push(this.managestipendioannuo_default_irap());
				arraydef.push(this.managestipendioannuo_default_totale());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.managestipendioannuo_default_irap();
				this.managestipendioannuo_default_totale();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-stipendioannuo_default");
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
				this.enableControl($('#stipendioannuo_default_irap'), true);
				this.enableControl($('#stipendioannuo_default_totale'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#stipendioannuo_default_irap'), false);
				this.enableControl($('#stipendioannuo_default_totale'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-stipendioannuo_default");
				$('#stipendioannuo_default_year').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.year);
				$('#stipendioannuo_default_year').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.year);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#stipendioannuo_default_year').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			managestipendioannuo_default_irap: function () {
				this.state.currentRow.irap = this.state.currentRow.lordo * 0.085;
			},

			managestipendioannuo_default_totale: function () {
				this.state.currentRow.totale = this.state.currentRow.lordo + this.state.currentRow.caricoente + this.state.currentRow.irap;

			},

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

	window.appMeta.addMetaPage('stipendioannuo', 'default', metaPage_stipendioannuo);

}());
