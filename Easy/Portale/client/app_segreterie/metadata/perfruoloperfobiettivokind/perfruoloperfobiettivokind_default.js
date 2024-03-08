(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfruoloperfobiettivokind() {
		MetaPage.apply(this, ['perfruoloperfobiettivokind', 'default', true]);
        this.name = 'Obiettivi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfruoloperfobiettivokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfruoloperfobiettivokind,
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
				var def = appMeta.Deferred("afterRowSelect-perfruoloperfobiettivokind_default");
				$('#perfruoloperfobiettivokind_default_idperfobiettivokind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfruoloperfobiettivokind_default_idperfobiettivokind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfruoloperfobiettivokind_default_idperfobiettivokind').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Obiettivo');
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

	window.appMeta.addMetaPage('perfruoloperfobiettivokind', 'default', metaPage_perfruoloperfobiettivokind);

}());
