(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotipocostokindinventorytree() {
		MetaPage.apply(this, ['progettotipocostokindinventorytree', 'seg', true]);
        this.name = 'Classificazione inventariale associata';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotipocostokindinventorytree.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocostokindinventorytree,
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
				var def = appMeta.Deferred("afterRowSelect-progettotipocostokindinventorytree_seg");
				$('#progettotipocostokindinventorytree_seg_idinv').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettotipocostokindinventorytree_seg_idinv').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotipocostokindinventorytree_seg_idinv').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Codice');
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

	window.appMeta.addMetaPage('progettotipocostokindinventorytree', 'seg', metaPage_progettotipocostokindinventorytree);

}());
