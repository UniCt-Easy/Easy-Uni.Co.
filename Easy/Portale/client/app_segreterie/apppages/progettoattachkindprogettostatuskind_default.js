(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoattachkindprogettostatuskind() {
		MetaPage.apply(this, ['progettoattachkindprogettostatuskind', 'default', true]);
        this.name = 'Stati in cui l\'allegato è obbligatorio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettoattachkindprogettostatuskind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoattachkindprogettostatuskind,
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
				var def = appMeta.Deferred("afterRowSelect-progettoattachkindprogettostatuskind_default");
				$('#progettoattachkindprogettostatuskind_default_idprogettostatuskind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettoattachkindprogettostatuskind_default_idprogettostatuskind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettoattachkindprogettostatuskind_default_idprogettostatuskind').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('progettoattachkindprogettostatuskind', 'default', metaPage_progettoattachkindprogettostatuskind);

}());
