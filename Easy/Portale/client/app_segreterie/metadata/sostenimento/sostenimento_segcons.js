(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sostenimento() {
		MetaPage.apply(this, ['sostenimento', 'segcons', false]);
        this.name = 'Conseguimento del titolo';
		this.defaultListType = 'segcons';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
								if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-sostenimento_segcons");
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
					this.helpForm.filter($('#sostenimento_segcons_idreg'), null);
				} else {
					this.helpForm.filter($('#sostenimento_segcons_idreg'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#sostenimento_segcons_idsostenimentoesito'), null);
				} else {
					this.helpForm.filter($('#sostenimento_segcons_idsostenimentoesito'), this.q.eq('sostenimentoesito_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sostenimento_segcons");
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
				this.enableControl($('#sostenimento_segcons_idreg'), true);
				this.helpForm.filter($('#sostenimento_segcons_idreg'), null);
				this.helpForm.filter($('#sostenimento_segcons_idsostenimentoesito'), null);
				this.enableControl($('#sostenimento_segcons_protnumero'), true);
				this.enableControl($('#sostenimento_segcons_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#sostenimento_segcons_protnumero'), false);
				this.enableControl($('#sostenimento_segcons_protanno'), false);
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
				var def = appMeta.Deferred("afterRowSelect-sostenimento_segcons");
				$('#sostenimento_segcons_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#sostenimento_segcons_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				if (t.name === "corsostudiodefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("idcorsostudio", r.idcorsostudio));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].idcorsostudio !== r.idcorsostudio) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#sostenimento_segcons_iddidprog').val('');
						}
				}
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
				if (!$('#sostenimento_segcons_idreg').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('sostenimento', 'segcons', metaPage_sostenimento);

}());
