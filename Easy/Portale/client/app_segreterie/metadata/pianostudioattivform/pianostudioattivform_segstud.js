(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudioattivform() {
		MetaPage.apply(this, ['pianostudioattivform', 'segstud', true]);
        this.name = 'Attività formative pianificate';
		this.defaultListType = 'segstud';
		//pageHeaderDeclaration
    }

    metaPage_pianostudioattivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudioattivform,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			afterFill: function () {
				this.enableControl($('#pianostudioattivform_segstud_idsostenimento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("pianostudioattivform","idattivform_scelta");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-pianostudioattivform_segstud");
				$('#pianostudioattivform_segstud_idattivform_scelta').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pianostudioattivform_segstud_idattivform_scelta').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#pianostudioattivform_segstud_idattivform_scelta').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Attività formativa che lo studente svolgerà');
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

	window.appMeta.addMetaPage('pianostudioattivform', 'segstud', metaPage_pianostudioattivform);

}());
