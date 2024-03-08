(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanzadichiar() {
		MetaPage.apply(this, ['istanzadichiar', 'seg', true]);
        this.name = 'Dichiarazioni collegate';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_istanzadichiar.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanzadichiar,
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
				var def = appMeta.Deferred("afterRowSelect-istanzadichiar_seg");
				$('#istanzadichiar_seg_iddichiar').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanzadichiar_seg_iddichiar').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#istanzadichiar_seg_iddichiar').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Dichiarazione');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			children: [''],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					return !!self.getDataTable(child).rows.length;
				});
			}
,

			//buttons
        });

	window.appMeta.addMetaPage('istanzadichiar', 'seg', metaPage_istanzadichiar);

}());
