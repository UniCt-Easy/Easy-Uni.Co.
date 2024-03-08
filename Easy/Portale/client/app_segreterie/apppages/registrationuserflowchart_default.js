(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registrationuserflowchart() {
		MetaPage.apply(this, ['registrationuserflowchart', 'default', true]);
        this.name = 'Autorizzazioni richieste';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_registrationuserflowchart.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registrationuserflowchart,
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
				var def = appMeta.Deferred("afterRowSelect-registrationuserflowchart_default");
				$('#registrationuserflowchart_default_idflowchart').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#registrationuserflowchart_default_idflowchart').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#registrationuserflowchart_default_idflowchart').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Autorizzazione');
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

	window.appMeta.addMetaPage('registrationuserflowchart', 'default', metaPage_registrationuserflowchart);

}());
