(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomirequisito() {
		MetaPage.apply(this, ['bandomirequisito', 'seg', true]);
        this.name = 'Requisiti richiesti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomirequisito.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomirequisito,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-bandomirequisito_seg");
				$('#bandomirequisito_seg_idrequisito').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomirequisito_seg_idrequisito').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomirequisito_seg_idrequisito').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
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

	window.appMeta.addMetaPage('bandomirequisito', 'seg', metaPage_bandomirequisito);

}());
