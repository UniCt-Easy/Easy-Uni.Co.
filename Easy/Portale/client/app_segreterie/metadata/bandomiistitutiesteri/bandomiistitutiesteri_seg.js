(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomiistitutiesteri() {
		MetaPage.apply(this, ['bandomiistitutiesteri', 'seg', true]);
        this.name = 'Elenco degli istituti esteri coinvolti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomiistitutiesteri.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomiistitutiesteri,
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
				var def = appMeta.Deferred("afterRowSelect-bandomiistitutiesteri_seg");
				$('#bandomiistitutiesteri_seg_idreg_istitutiesteri').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomiistitutiesteri_seg_idreg_istitutiesteri').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomiistitutiesteri_seg_idreg_istitutiesteri').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Istituto');
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

	window.appMeta.addMetaPage('bandomiistitutiesteri', 'seg', metaPage_bandomiistitutiesteri);

}());
