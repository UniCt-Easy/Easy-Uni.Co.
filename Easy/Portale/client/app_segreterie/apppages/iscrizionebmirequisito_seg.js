(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizionebmirequisito() {
		MetaPage.apply(this, ['iscrizionebmirequisito', 'seg', true]);
        this.name = 'Requisiti richiesti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_iscrizionebmirequisito.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizionebmirequisito,
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
				
				if (!parentRow.idiscrizionebmi)
					parentRow.idiscrizionebmi = "cerca";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-iscrizionebmirequisito_seg");
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

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizionebmirequisito_seg");
				$('#iscrizionebmirequisito_seg_idiscrizionebmi').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizionebmirequisito_seg_idiscrizionebmi').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizionebmirequisito_seg_idiscrizionebmi').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione al bando di mobilità internazionale');
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

	window.appMeta.addMetaPage('iscrizionebmirequisito', 'seg', metaPage_iscrizionebmirequisito);

}());
