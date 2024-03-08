(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettocambiostatoperfruolo() {
		MetaPage.apply(this, ['perfprogettocambiostatoperfruolo', 'maildest', true]);
        this.name = 'Chi viene avvisato via mail';
		this.defaultListType = 'maildest';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettocambiostatoperfruolo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettocambiostatoperfruolo,
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
				var def = appMeta.Deferred("afterRowSelect-perfprogettocambiostatoperfruolo_maildest");
				$('#perfprogettocambiostatoperfruolo_maildest_idperfruolo').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettocambiostatoperfruolo_maildest_idperfruolo').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfprogettocambiostatoperfruolo_maildest_idperfruolo').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Codice');
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

	window.appMeta.addMetaPage('perfprogettocambiostatoperfruolo', 'maildest', metaPage_perfprogettocambiostatoperfruolo);

}());
