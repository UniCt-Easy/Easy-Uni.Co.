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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
								if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-decadenza_seg");
				var arraydef = [];
				
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#decadenza_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#decadenza_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
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

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#decadenza_seg_idreg_studenti'), true);
				this.helpForm.filter($('#decadenza_seg_idreg_studenti'), null);
				this.enableControl($('#decadenza_seg_idiscrizione'), true);
				this.enableControl($('#decadenza_seg_protnumero'), true);
				this.enableControl($('#decadenza_seg_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

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
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-decadenza_seg");
				$('#decadenza_seg_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#decadenza_seg_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#decadenza_seg_idiscrizione').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#decadenza_seg_idiscrizione').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				//afterRowSelectin
				return def.resolve();
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

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine =  that.idreg_istituto;
				var idreg_destinazione = that.idreg_istituto;
				var iscrizionedefaultview = that.getDataTable('iscrizionedefaultview');
				var registrystudentiview = that.getDataTable('registrystudentiview');
				var oggetto = 'Decadenza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) +
					' di' + (registrystudentiview ? ' ' + registrystudentiview.rows[0].dropdown_title : '') +
					' per l\'iscrizione ' + (iscrizionedefaultview ? ' ' + iscrizionedefaultview.rows[0].dropdown_title : '');
				var idprotocollodockind = 4;
				var arrayTablesToProtocol = ['decadenza'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.iddecadenza;

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
