(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfstrutturaperfindicatore() {
		MetaPage.apply(this, ['perfstrutturaperfindicatore', 'default', true]);
        this.name = 'Indicatori associati';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfstrutturaperfindicatore.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfstrutturaperfindicatore,
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
				var def = appMeta.Deferred("afterRowSelect-perfstrutturaperfindicatore_default");
				$('#perfstrutturaperfindicatore_default_idperfindicatore').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfstrutturaperfindicatore_default_idperfindicatore').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfstrutturaperfindicatore_default_idperfindicatore').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
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

	window.appMeta.addMetaPage('perfstrutturaperfindicatore', 'default', metaPage_perfstrutturaperfindicatore);

}());
