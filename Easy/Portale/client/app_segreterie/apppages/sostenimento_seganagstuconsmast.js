(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sostenimento() {
		MetaPage.apply(this, ['sostenimento', 'seganagstuconsmast', true]);
        this.name = 'Sostenimenti';
		this.defaultListType = 'seganagstuconsmast';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_sostenimento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sostenimento,
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
				if (this.isNull(parentRow.votolode) || parentRow.votolode == '')
					parentRow.votolode = "N";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#sostenimento_seganagstuconsmast_idreg'), null);
				} else {
					this.helpForm.filter($('#sostenimento_seganagstuconsmast_idreg'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sostenimento_seganagstuconsmast");
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
				this.enableControl($('#sostenimento_seganagstuconsmast_idprova'), true);
				this.enableControl($('#sostenimento_seganagstuconsmast_idreg'), true);
				this.helpForm.filter($('#sostenimento_seganagstuconsmast_idreg'), null);
				this.enableControl($('#sostenimento_seganagstuconsmast_protnumero'), true);
				this.enableControl($('#sostenimento_seganagstuconsmast_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#sostenimento_seganagstuconsmast_protnumero'), false);
				this.enableControl($('#sostenimento_seganagstuconsmast_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("sostenimento","idprova");
				this.state.DS.tables.provadotmasview.staticFilter(window.jsDataQuery.eq("iddidprog", this.state.callerState.currentRow.iddidprog));
				appMeta.metaModel.insertFilter(this.getDataTable("sostenimentoesitodefaultview"), this.q.eq('sostenimentoesito_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-sostenimento_seganagstuconsmast");
				$('#sostenimento_seganagstuconsmast_idprova').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprova);
				$('#sostenimento_seganagstuconsmast_idprova').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprova);
				$('#sostenimento_seganagstuconsmast_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#sostenimento_seganagstuconsmast_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
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
				if (!$('#sostenimento_seganagstuconsmast_idprova').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Prova');
				}
				if (!$('#sostenimento_seganagstuconsmast_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.idreg_istituto;
				var idreg_destinazione = that.idreg_istituto;
				var oggetto = 'Sostenimento del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data);
				var idprotocollodockind = 5;
				var arrayTablesToProtocol = ['sostenimento'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idsostenimento;

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

	window.appMeta.addMetaPage('sostenimento', 'seganagstuconsmast', metaPage_sostenimento);

}());
