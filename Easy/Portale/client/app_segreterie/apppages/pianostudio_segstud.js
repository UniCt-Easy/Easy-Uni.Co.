(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudio() {
		MetaPage.apply(this, ['pianostudio', 'segstud', false]);
        this.name = 'Piani di studio';
		this.defaultListType = 'segstud';
		//pageHeaderDeclaration
    }

    metaPage_pianostudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-pianostudio_segstud");
				var arraydef = [];
				
				arraydef.push(this.managepianostudio__segstud_idcorsostudio());
				arraydef.push(this.managepianostudio__segstud_iddidprog());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("pianostudio","idiscrizione");
				appMeta.metaModel.cachedTable(this.getDataTable("iscrizionesegview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("iscrizionesegview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#pianostudio_segstud_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pianostudio_segstud_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#pianostudio_segstud_idiscrizione').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pianostudio_segstud_idiscrizione').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("iscrizionesegview"), false);
					var pianostudio_segstud_idiscrizioneCtrl = $('#pianostudio_segstud_idiscrizione').data("customController");
					arraydef.push(pianostudio_segstud_idiscrizioneCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idiscrizione)
								pianostudio_segstud_idiscrizioneCtrl.fillControl(null, self.state.currentRow.idiscrizione);
							return true;
						})
);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#pianostudio_segstud_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#pianostudio_segstud_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			children: ['pianostudioattivform'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			managepianostudio__segstud_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-managepianostudio__segstud_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionesegview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			managepianostudio__segstud_iddidprog: function () {
				var def = appMeta.Deferred("beforeFill-managepianostudio__segstud_iddidprog");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionesegview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.iddidprog = masterRow.iddidprog;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('pianostudio', 'segstud', metaPage_pianostudio);

}());
