(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryaddress() {
		MetaPage.apply(this, ['registryaddress', 'seg', true]);
        this.name = 'Indirizzi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_registryaddress.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registryaddress,
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
				
				if (!parentRow.idaddresskind || parentRow.idaddresskind == 0)
					parentRow.idaddresskind = 17;
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registryaddress_seg");
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
				var def = appMeta.Deferred("afterRowSelect-registryaddress_seg");
				$('#registryaddress_seg_idaddresskind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#registryaddress_seg_idaddresskind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#registryaddress_seg_idaddresskind').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Tipologia');
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

	window.appMeta.addMetaPage('registryaddress', 'seg', metaPage_registryaddress);

}());
