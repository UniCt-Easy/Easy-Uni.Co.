(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_salprogettocosto() {
		MetaPage.apply(this, ['salprogettocosto', 'default', true]);
        this.name = 'Dettaglio dei costi del SAL';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_salprogettocosto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_salprogettocosto,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-salprogettocosto_default");
				$('#salprogettocosto_default_idprogettocosto').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogettocosto);
				$('#salprogettocosto_default_idprogettocosto').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogettocosto);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#salprogettocosto_default_idprogettocosto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Dettaglio costo');
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

	window.appMeta.addMetaPage('salprogettocosto', 'default', metaPage_salprogettocosto);

}());
