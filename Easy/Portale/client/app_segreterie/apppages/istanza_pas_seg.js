(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'pas_seg', false]);
        this.name = 'Istanza di passaggio corso o cambio ordinamento';
		this.defaultListType = 'pas_seg';
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
				parentRow.extension = "pas";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_pas_pas_seg");
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
					this.helpForm.filter($('#istanza_pas_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_pas_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_pas_pas_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_pas"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_pas");
					meta.setDefaults(dt);
					var defistanza_pas = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowpas) {
							currentRowpas.current.idistanzakind = 3;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_pas);
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
				this.enableControl($('#istanza_pas_seg_idreg_studenti'), true);
				this.helpForm.filter($('#istanza_pas_seg_idreg_studenti'), null);
				this.enableControl($('#istanza_pas_seg_idiscrizione'), true);
				this.enableControl($('#istanza_pas_seg_protnumero'), true);
				this.enableControl($('#istanza_pas_seg_protanno'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_pas_seg_protnumero'), false);
				this.enableControl($('#istanza_pas_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_pas');
				this.state.DS.tables.istanza.defaults({ 'aa': this.getAAByDate() });
				this.state.DS.tables.istanza.defaults({ 'data': new Date() });
				this.state.DS.tables.istanza.defaults({ 'extension': "pas" });
				this.state.DS.tables.istanza.defaults({ 'idistanzakind': 3 });
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_pas_pas_seg");
				$('#istanza_pas_seg_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#istanza_pas_seg_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_pas'].rows.length)
						this.state.DS.tables['istanza_pas'].rows[0].idreg = r.idreg;
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.iscrizioneseganagstuview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.iscrizioneseganagstuview.rows.length)
						if (this.state.DS.tables.iscrizioneseganagstuview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.iscrizioneseganagstuview.clear();
							$('#istanza_pas_seg_idiscrizione_from').val('');
						}
				}
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.iscrizioneseganagstuview_alias1.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.iscrizioneseganagstuview_alias1.rows.length)
						if (this.state.DS.tables.iscrizioneseganagstuview_alias1.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.iscrizioneseganagstuview_alias1.clear();
							$('#istanza_pas_seg_idiscrizione').val('');
						}
				}
				$('#istanza_pas_seg_idiscrizione').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#istanza_pas_seg_idiscrizione').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				if (t.name === 'iscrizioneseganagstuview_alias1' && r !== null)
					if (this.state.DS.tables['istanza_pas'].rows.length)
						this.state.DS.tables['istanza_pas'].rows[0].idiscrizione = r.idiscrizione;
				if (t.name === "" && r !== null) {
					return this.manageiddidprog(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "iscrizioneseganagstuview_alias1" && r !== null) {
					return this.manageidiscrizione(this).then(function () {
						return def.resolve();
					});
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
				if (!$('#istanza_pas_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#istanza_pas_seg_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				if (!$('#istanza_pas_seg_idiscrizione_from').val() && grid.dataSourceName === 'pratica') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione di partenza');
				}
				if (!$('#istanza_pas_seg_idiscrizione_from').val() && grid.dataSourceName === 'nullaosta') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione di partenza');
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
				var arrayTablesToProtocol = ['istanza', 'istanza_pas'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['diniego_alias4', 'nullaosta', 'pratica'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageiddidprog: function(that) { 
				var def = appMeta.Deferred("iddidprog_change-istanza_pas_pas_seg");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__pas_seg_idcorsostudio());
				arraydef.push(this.manageistanza_pas__seg_idcorsostudio());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();

			},

			manageidiscrizione: function(that) { 
				var def = appMeta.Deferred("manageidiscrizione");
				let iscirzioneAttualeRows = this.state.DS.tables.iscrizioneseganagstuview.rows;
				if (iscirzioneAttualeRows.length) {
					this.state.currentRow.iddidprog = iscirzioneAttualeRows[0].iddidprog;
					this.state.currentRow.idcorsostudio = iscirzioneAttualeRows[0].idcorsostudio;
					this.state.DS.tables.istanza_pas.rows[0].iddidprog = iscirzioneAttualeRows[0].iddidprog;
					this.state.DS.tables.istanza_pas.rows[0].idcorsostudio = iscirzioneAttualeRows[0].idcorsostudio;
				}
				return def.resolve();

			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'pas_seg', metaPage_istanza);

}());
