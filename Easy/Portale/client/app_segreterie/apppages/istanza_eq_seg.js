(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'eq_seg', false]);
        this.name = 'Istanza di equipollenza ';
		this.defaultListType = 'eq_seg';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (self.isNullOrMinDate(parentRow.data))
				parentRow.data = new Date();
				parentRow.extension = "eq";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_eq_eq_seg");
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
					this.helpForm.filter($('#istanza_eq_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_eq_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_eq_eq_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_eq"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_eq");
					meta.setDefaults(dt);
					var defistanza_eq = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRoweq) {
							currentRoweq.current.idistanzakind = 1;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_eq);
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
				//parte sincrona
				this.enableControl($('#istanza_eq_seg_idreg_studenti'), true);
				this.helpForm.filter($('#istanza_eq_seg_idreg_studenti'), null);
				this.enableControl($('#istanza_eq_seg_idcorsostudio'), true);
				this.enableControl($('#istanza_eq_seg_iddidprog'), true);
				this.enableControl($('#istanza_eq_seg_protnumero'), true);
				this.enableControl($('#istanza_eq_seg_protanno'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_eq'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_eq_seg_protnumero'), false);
				this.enableControl($('#istanza_eq_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_eq'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_eq');
				this.state.DS.tables.istanza.defaults({ 'aa': this.getAAByDate() });
				this.state.DS.tables.istanza.defaults({ 'data': new Date() });
				this.state.DS.tables.istanza.defaults({ 'extension': "eq" });
				this.state.DS.tables.istanza.defaults({ 'idistanzakind': 1 });
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("istanza","idstatuskind");
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_eq_eq_seg");
				$('#istanza_eq_seg_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#istanza_eq_seg_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_eq'].rows.length)
						this.state.DS.tables['istanza_eq'].rows[0].idreg = r.idreg;
				$('#istanza_eq_seg_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#istanza_eq_seg_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				if (t.name === "corsostudiodefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("idcorsostudio", r.idcorsostudio));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].idcorsostudio !== r.idcorsostudio) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_eq_seg_iddidprog').val('');
						}
				}
				$('#istanza_eq_seg_iddidprog').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#istanza_eq_seg_iddidprog').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#istanza_eq_seg_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#istanza_eq_seg_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
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
				if (!$('#istanza_eq_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#istanza_eq_seg_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso equipollente');
				}
				if (!$('#istanza_eq_seg_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica equipollente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskinddefaultview');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_eq'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['diniego_alias2', 'nullaosta'],
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

	window.appMeta.addMetaPage('istanza', 'eq_seg', metaPage_istanza);

}());
