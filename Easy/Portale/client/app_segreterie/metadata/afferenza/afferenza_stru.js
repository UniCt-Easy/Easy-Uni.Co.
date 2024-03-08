(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_afferenza() {
		MetaPage.apply(this, ['afferenza', 'stru', true]);
        this.name = 'Personale afferente';
		this.defaultListType = 'stru';
		//pageHeaderDeclaration
    }

    metaPage_afferenza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_afferenza,
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
				var def = appMeta.Deferred("afterRowSelect-afferenza_stru");
				$('#afferenza_stru_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#afferenza_stru_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#afferenza_stru_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Membro del personale');
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

	window.appMeta.addMetaPage('afferenza', 'stru', metaPage_afferenza);

}());
