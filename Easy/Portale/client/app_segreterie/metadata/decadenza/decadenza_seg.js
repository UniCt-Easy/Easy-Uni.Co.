(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_decadenza() {
		MetaPage.apply(this, ['decadenza', 'seg', false]);
        this.name = 'Decadenza';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_decadenza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_decadenza,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-decadenza_seg");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			//afterClear

			afterFill: function () {
				this.enableControl($('#decadenza_seg_protnumero'), false);
				this.enableControl($('#decadenza_seg_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("iscrizionedefaultview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("iscrizionedefaultview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#decadenza_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#decadenza_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#decadenza_seg_idiscrizione').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#decadenza_seg_idiscrizione').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("iscrizionedefaultview"), false);
					var decadenza_seg_idiscrizioneCtrl = $('#decadenza_seg_idiscrizione').data("customController");
					arraydef.push(decadenza_seg_idiscrizioneCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idiscrizione)
								decadenza_seg_idiscrizioneCtrl.fillControl(null, self.state.currentRow.idiscrizione);
							return true;
						})
);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#decadenza_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#decadenza_seg_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			firebtnProtocol: function (that) {
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
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

	window.appMeta.addMetaPage('decadenza', 'seg', metaPage_decadenza);

}());
