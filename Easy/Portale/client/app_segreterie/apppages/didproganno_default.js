(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didproganno() {
		MetaPage.apply(this, ['didproganno', 'default', true]);
        this.name = 'Anni di corso';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didproganno.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didproganno,
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
				var def = appMeta.Deferred("afterGetFormData-didproganno_default");
				var arraydef = [];
				
				arraydef.push(this.managedidproganno_default_title());
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didproganno_default");
				var arraydef = [];
				
				arraydef.push(this.managedidproganno_default_title());
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

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-didproganno_default");
				$('#didproganno_default_aa').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#didproganno_default_aa').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#didproganno_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno Accademico');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			managedidproganno_default_title: function () {
    var def = appMeta.Deferred("beforeFill-manageanno_title");     var self = this;     this.state.currentRow.title = this.state.currentRow.anno + " anno";     return def.resolve();
			},

			children: ['didprogporzanno'],
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

	window.appMeta.addMetaPage('didproganno', 'default', metaPage_didproganno);

}());
