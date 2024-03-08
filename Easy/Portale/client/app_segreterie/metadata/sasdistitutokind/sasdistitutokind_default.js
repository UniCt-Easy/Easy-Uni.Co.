(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sasdistitutokind() {
		MetaPage.apply(this, ['sasdistitutokind', 'default', true]);
        this.name = 'Compatibilità tra sasd e tipi di istituti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sasdistitutokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sasdistitutokind,
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
				var def = appMeta.Deferred("afterRowSelect-sasdistitutokind_default");
				$('#sasdistitutokind_default_idistitutokind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#sasdistitutokind_default_idistitutokind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#sasdistitutokind_default_idistitutokind').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('sasdistitutokind', 'default', metaPage_sasdistitutokind);

}());
