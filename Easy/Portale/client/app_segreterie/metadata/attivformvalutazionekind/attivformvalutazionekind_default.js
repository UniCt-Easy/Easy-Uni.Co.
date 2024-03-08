(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_attivformvalutazionekind() {
		MetaPage.apply(this, ['attivformvalutazionekind', 'default', true]);
        this.name = 'Tipo di valutazione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_attivformvalutazionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivformvalutazionekind,
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
				var def = appMeta.Deferred("afterRowSelect-attivformvalutazionekind_default");
				$('#attivformvalutazionekind_default_idvalutazionekind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#attivformvalutazionekind_default_idvalutazionekind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#attivformvalutazionekind_default_idvalutazionekind').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('attivformvalutazionekind', 'default', metaPage_attivformvalutazionekind);

}());
