(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfschedacambiostatoperfruolo() {
		MetaPage.apply(this, ['perfschedacambiostatoperfruolo', 'default', true]);
        this.name = 'Chi viene avvisato via mail';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfschedacambiostatoperfruolo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfschedacambiostatoperfruolo,
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
				var def = appMeta.Deferred("afterRowSelect-perfschedacambiostatoperfruolo_default");
				$('#perfschedacambiostatoperfruolo_default_idperfruolo').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfschedacambiostatoperfruolo_default_idperfruolo').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfschedacambiostatoperfruolo_default_idperfruolo').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ruolo');
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

	window.appMeta.addMetaPage('perfschedacambiostatoperfruolo', 'default', metaPage_perfschedacambiostatoperfruolo);

}());
