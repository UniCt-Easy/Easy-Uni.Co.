(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'conseg_seg', false]);
        this.name = 'Istanze di conseguimento';
		this.defaultListType = 'conseg_seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_istanza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanza,
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
				parentRow.extension = "conseg";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istanza_conseg_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_conseg_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_conseg_conseg_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_conseg"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_conseg");
					meta.setDefaults(dt);
					var defistanza_conseg = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowconseg) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_conseg);
				}

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
				this.helpForm.filter($('#istanza_conseg_seg_idreg_studenti'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_conseg'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('relatore'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('richitesi'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_conseg_seg_protnumero'), false);
				this.enableControl($('#istanza_conseg_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_conseg'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('relatore'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('richitesi'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.istanza.defaults({ 'extension': "conseg" });
				this.state.DS.tables.istanza.defaults({ 'idistanzakind': 12 });
				this.state.DS.tables.istanza.defaults({ 'idstatuskind': 1 });
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskind.staticFilter(window.jsDataQuery.eq('istanze', 'S'));
				$('#grid_richitesi_segistcons').data('mdlconditionallookup', 'accettata,S,Si;accettata,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_conseg_conseg_seg");
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_conseg_seg_iddidprog').val('');
						}
				}
				$('#istanza_conseg_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_conseg_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_conseg'].rows.length)
						this.state.DS.tables['istanza_conseg'].rows[0].idreg = r.idreg;
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
				if (!$('#istanza_conseg_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_conseg'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['relatore', 'richitesi'],
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

	window.appMeta.addMetaPage('istanza', 'conseg_seg', metaPage_istanza);

}());
