(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_flowchartuser() {
		MetaPage.apply(this, ['flowchartuser', 'seg', true]);
        this.name = 'Utenti del nodo di sicurezza';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_flowchartuser.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_flowchartuser,
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
				
				if (!parentRow.flagdefault)
					parentRow.flagdefault = 'N';
				if (!parentRow.start)
					parentRow.start = new Date('01/01/1900');
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-flowchartuser_seg");
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
				var def = appMeta.Deferred("afterRowSelect-flowchartuser_seg");
				$('#flowchartuser_seg_idcustomuser').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#flowchartuser_seg_idcustomuser').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#flowchartuser_seg_idcustomuser').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Utente');
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

	window.appMeta.addMetaPage('flowchartuser', 'seg', metaPage_flowchartuser);

}());
