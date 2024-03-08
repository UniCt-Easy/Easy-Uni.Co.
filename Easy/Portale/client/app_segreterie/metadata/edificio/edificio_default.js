(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_edificio() {
		MetaPage.apply(this, ['edificio', 'default', false]);
        this.name = 'Edifici';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_edificio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_edificio,
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
				var def = appMeta.Deferred("afterRowSelect-edificio_default");
				$('#edificio_default_idsede').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#edificio_default_idsede').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#edificio_default_idsede').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Sede');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['aula', 'sospensione'],
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

	window.appMeta.addMetaPage('edificio', 'default', metaPage_edificio);

}());
