(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotipocostoinventorytree() {
		MetaPage.apply(this, ['progettotipocostoinventorytree', 'seg', true]);
        this.name = 'Classificazione inventariale associata';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotipocostoinventorytree.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocostoinventorytree,
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
				var def = appMeta.Deferred("afterRowSelect-progettotipocostoinventorytree_seg");
				$('#progettotipocostoinventorytree_seg_idinv').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettotipocostoinventorytree_seg_idinv').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotipocostoinventorytree_seg_idinv').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Classificazione inventariale');
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

	window.appMeta.addMetaPage('progettotipocostoinventorytree', 'seg', metaPage_progettotipocostoinventorytree);

}());
