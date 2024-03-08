(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotipocostotax() {
		MetaPage.apply(this, ['progettotipocostotax', 'seg', true]);
        this.name = 'Tipi di ritenuta associati';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotipocostotax.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocostotax,
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
				var def = appMeta.Deferred("afterRowSelect-progettotipocostotax_seg");
				$('#progettotipocostotax_seg_taxcode').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettotipocostotax_seg_taxcode').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotipocostotax_seg_taxcode').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Tipi di ritenuta');
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

	window.appMeta.addMetaPage('progettotipocostotax', 'seg', metaPage_progettotipocostotax);

}());
