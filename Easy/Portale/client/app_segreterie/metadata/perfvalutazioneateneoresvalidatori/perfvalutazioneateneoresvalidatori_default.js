(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazioneateneoresvalidatori() {
		MetaPage.apply(this, ['perfvalutazioneateneoresvalidatori', 'default', true]);
        this.name = 'Validatore ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneateneoresvalidatori.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneateneoresvalidatori,
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
				var def = appMeta.Deferred("afterRowSelect-perfvalutazioneateneoresvalidatori_default");
				$('#perfvalutazioneateneoresvalidatori_default_idvalidatori').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazioneateneoresvalidatori_default_idvalidatori').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazioneateneoresvalidatori_default_idvalidatori').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('perfvalutazioneateneoresvalidatori', 'default', metaPage_perfvalutazioneateneoresvalidatori);

}());
