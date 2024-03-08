(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_accordoscambiomiporzanno() {
		MetaPage.apply(this, ['accordoscambiomiporzanno', 'seg', true]);
        this.name = 'Porzioni d’anno interessate';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_accordoscambiomiporzanno.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_accordoscambiomiporzanno,
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
				var def = appMeta.Deferred("afterRowSelect-accordoscambiomiporzanno_seg");
				$('#accordoscambiomiporzanno_seg_iddidprogporzannokind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#accordoscambiomiporzanno_seg_iddidprogporzannokind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#accordoscambiomiporzanno_seg_iddidprogporzannokind').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('accordoscambiomiporzanno', 'seg', metaPage_accordoscambiomiporzanno);

}());
