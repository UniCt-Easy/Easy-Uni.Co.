(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomiinsegn() {
		MetaPage.apply(this, ['bandomiinsegn', 'seg', true]);
        this.name = 'Elenco degli insegnamenti che lo studente puà scegliere nei learning agreement';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomiinsegn.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomiinsegn,
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
				var def = appMeta.Deferred("afterRowSelect-bandomiinsegn_seg");
				$('#bandomiinsegn_seg_idinsegn').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomiinsegn_seg_idinsegn').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomiinsegn_seg_idinsegn').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('bandomiinsegn', 'seg', metaPage_bandomiinsegn);

}());
