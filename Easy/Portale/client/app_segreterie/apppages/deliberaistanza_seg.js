(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_deliberaistanza() {
		MetaPage.apply(this, ['deliberaistanza', 'seg', true]);
        this.name = 'Istanze deliberate';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_deliberaistanza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_deliberaistanza,
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
				var def = appMeta.Deferred("afterRowSelect-deliberaistanza_seg");
				$('#deliberaistanza_seg_iddelibera').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#deliberaistanza_seg_iddelibera').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#deliberaistanza_seg_iddelibera').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Delibera');
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

	window.appMeta.addMetaPage('deliberaistanza', 'seg', metaPage_deliberaistanza);

}());
