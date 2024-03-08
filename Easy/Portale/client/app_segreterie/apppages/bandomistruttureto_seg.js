(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomistruttureto() {
		MetaPage.apply(this, ['bandomistruttureto', 'seg', true]);
        this.name = 'Elenco delle strutture ai quali corsi gli studenti incoming possono iscriversi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomistruttureto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomistruttureto,
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
				var def = appMeta.Deferred("afterRowSelect-bandomistruttureto_seg");
				$('#bandomistruttureto_seg_idstruttura').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomistruttureto_seg_idstruttura').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomistruttureto_seg_idstruttura').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Struttura didattica di accoglienza');
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

	window.appMeta.addMetaPage('bandomistruttureto', 'seg', metaPage_bandomistruttureto);

}());
