(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'ingresso', true]);
        this.name = 'Iscrizioni';
		this.defaultListType = 'ingresso';
		//pageHeaderDeclaration
    }

    metaPage_iscrizione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizione,
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
				var def = appMeta.Deferred("afterRowSelect-iscrizione_ingresso");
				$('#iscrizione_ingresso_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizione_ingresso_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_ingresso_idreg').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('iscrizione', 'ingresso', metaPage_iscrizione);

}());
