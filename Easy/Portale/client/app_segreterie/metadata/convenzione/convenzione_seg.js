(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convenzione() {
		MetaPage.apply(this, ['convenzione', 'seg', false]);
        this.name = 'Convenzioni';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_convenzione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convenzione,
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
				var def = appMeta.Deferred("afterRowSelect-convenzione_seg");
				$('#convenzione_seg_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#convenzione_seg_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#convenzione_seg_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Istituto, ente o azienda');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			createAndGetListManager: function (searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, isCommandSearch) {
                // isCommandSearch è true se lancio comando di ricerca, false se vengo da un autochoose, e qin quel caso implemnto comportamento di default
                var startColumnName = "convenzione_start";
                var titleColumnName = "title";
                var stopColumnName = "convenzione_stop";
                if (isCommandSearch) return new window.appMeta.ListManagerCalendar(searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, startColumnName , titleColumnName, stopColumnName);
                // se non esco prima, significa autochoose e quindi esegue il sodiuce della superClass
                return this.superClass.createAndGetListManager(searchTableName, listingType, prefilter, isModal,rootElement, that, filterLocked, toMerge, isCommandSearch);
            },

			children: ['convenzioneattach'],
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

	window.appMeta.addMetaPage('convenzione', 'seg', metaPage_convenzione);

}());
