(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontlezionestud() {
		MetaPage.apply(this, ['rendicontlezionestud', 'default', true]);
        this.name = 'Studenti della lezione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontlezionestud.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontlezionestud,
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
				var def = appMeta.Deferred("afterRowSelect-rendicontlezionestud_default");
				$('#rendicontlezionestud_default_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#rendicontlezionestud_default_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#rendicontlezionestud_default_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('rendicontlezionestud', 'default', metaPage_rendicontlezionestud);

}());
