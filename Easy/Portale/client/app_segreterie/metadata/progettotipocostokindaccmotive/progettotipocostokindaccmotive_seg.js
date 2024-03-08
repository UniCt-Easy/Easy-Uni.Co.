(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotipocostokindaccmotive() {
		MetaPage.apply(this, ['progettotipocostokindaccmotive', 'seg', true]);
        this.name = 'Causali economico patrimoniali associate';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotipocostokindaccmotive.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocostokindaccmotive,
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
				var def = appMeta.Deferred("afterRowSelect-progettotipocostokindaccmotive_seg");
				$('#progettotipocostokindaccmotive_seg_idaccmotive').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettotipocostokindaccmotive_seg_idaccmotive').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettotipocostokindaccmotive_seg_idaccmotive').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Codice');
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

	window.appMeta.addMetaPage('progettotipocostokindaccmotive', 'seg', metaPage_progettotipocostokindaccmotive);

}());
