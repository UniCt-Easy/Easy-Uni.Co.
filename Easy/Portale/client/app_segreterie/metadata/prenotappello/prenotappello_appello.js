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
					parentRow.data = new Date();
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

			//afterClear

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-prenotappello_appello");
				$('#prenotappello_appello_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#prenotappello_appello_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#prenotappello_appello_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
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

	window.appMeta.addMetaPage('prenotappello', 'appello', metaPage_prenotappello);

}());
