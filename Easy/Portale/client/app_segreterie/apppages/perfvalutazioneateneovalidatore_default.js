(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazioneateneovalidatore() {
		MetaPage.apply(this, ['perfvalutazioneateneovalidatore', 'default', true]);
        this.name = 'Validatore ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneateneovalidatore.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneateneovalidatore,
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
				var def = appMeta.Deferred("afterRowSelect-perfvalutazioneateneovalidatore_default");
				$('#perfvalutazioneateneovalidatore_default_idvalidatori').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazioneateneovalidatore_default_idvalidatori').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazioneateneovalidatore_default_idvalidatori').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('perfvalutazioneateneovalidatore', 'default', metaPage_perfvalutazioneateneovalidatore);

}());
