(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_accordoscambiomidett() {
		MetaPage.apply(this, ['accordoscambiomidett', 'seg', true]);
        this.name = 'Dettaglio dell’accordo per gli istituti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_accordoscambiomidett.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_accordoscambiomidett,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('accordoscambiomiporzanno'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('cefrlanglevel'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('accordoscambiomiporzanno'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('cefrlanglevel'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("accordoscambiomidett","idisced2013");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-accordoscambiomidett_seg");
				$('#accordoscambiomidett_seg_idreg_istitutiesteri').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#accordoscambiomidett_seg_idreg_istitutiesteri').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#accordoscambiomidett_seg_idreg_istitutiesteri').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Istituto estero');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['accordoscambiomiporzanno', 'cefrlanglevel'],
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

	window.appMeta.addMetaPage('accordoscambiomidett', 'seg', metaPage_accordoscambiomidett);

}());
