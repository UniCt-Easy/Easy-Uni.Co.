(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotipocostokindtax() {
		MetaPage.apply(this, ['progettotipocostokindtax', 'seg', true]);
        this.name = 'Tipi di ritenuta associati';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotipocostokindtax.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocostokindtax,
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
				var def = appMeta.Deferred("afterRowSelect-progettotipocostokindtax_seg");
				$('#progettotipocostokindtax_seg_taxcode').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettotipocostokindtax_seg_taxcode').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotipocostokindtax_seg_taxcode').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('progettotipocostokindtax', 'seg', metaPage_progettotipocostokindtax);

}());
