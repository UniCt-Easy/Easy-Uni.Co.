(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotimesheetprogetto() {
		MetaPage.apply(this, ['progettotimesheetprogetto', 'default', true]);
        this.name = 'Progetti da visualizzare nel timesheet';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettotimesheetprogetto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotimesheetprogetto,
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
				var def = appMeta.Deferred("afterRowSelect-progettotimesheetprogetto_default");
				$('#progettotimesheetprogetto_default_idprogetto').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogetto);
				$('#progettotimesheetprogetto_default_idprogetto').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogetto);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotimesheetprogetto_default_idprogetto').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('progettotimesheetprogetto', 'default', metaPage_progettotimesheetprogetto);

}());
