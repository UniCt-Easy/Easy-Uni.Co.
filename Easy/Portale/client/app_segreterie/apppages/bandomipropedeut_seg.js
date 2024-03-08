(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomipropedeut() {
		MetaPage.apply(this, ['bandomipropedeut', 'seg', true]);
        this.name = 'insegnamenti che lo studente deve aver sostenuto per partecipare';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomipropedeut.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomipropedeut,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-bandomipropedeut_seg");
				$('#bandomipropedeut_seg_idinsegn').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomipropedeut_seg_idinsegn').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomipropedeut_seg_idinsegn').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
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

	window.appMeta.addMetaPage('bandomipropedeut', 'seg', metaPage_bandomipropedeut);

}());
