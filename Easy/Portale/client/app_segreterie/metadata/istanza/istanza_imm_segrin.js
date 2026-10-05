(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'imm_segrin', false]);
        this.name = 'Istanze di rinnovo della iscrizione';
		this.defaultListType = 'imm_segrin';
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

						
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istanza_imm_segrin_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_imm_segrin_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_imm_imm_segrin");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_imm"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_imm");
					meta.setDefaults(dt);
					var defistanza_imm = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowimm) {
							currentRowimm.current.idistanzakind = 15;
							currentRowimm.current.parttime = "N";
							currentRowimm.current.pre = "R";
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_imm);
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
				this.enableControl($('#istanza_imm_segrin_idreg_studenti'), true);
				this.helpForm.filter($('#istanza_imm_segrin_idreg_studenti'), null);
				this.enableControl($('#istanza_imm_segrin_protnumero'), true);
				this.enableControl($('#istanza_imm_segrin_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_imm_segrin_protnumero'), false);
				this.enableControl($('#istanza_imm_segrin_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_imm');
				this.state.DS.tables.istanza.defaults({ 'aa': this.getAAByDate() });
				this.state.DS.tables.istanza.defaults({ 'data': new Date() });
				this.state.DS.tables.istanza.defaults({ 'extension': 'imm' });
				this.state.DS.tables.istanza.defaults({ 'idistanzakind': 15 });
				this.state.DS.tables.istanza.defaults({ 'idstatuskind': 1 });
				$("#btn_add_istanzadichiar_iddichiar").on("click", _.partial(this.searchAndAssigndichiar, self));
				$("#btn_add_istanzadichiar_iddichiar").prop("disabled", true);
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				$('#grid_nullaosta_imm_seganagstupre').data('mdlconditionallookup', 'parttime,S,Si;parttime,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_imm_imm_segrin");
				$('#istanza_imm_segrin_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#istanza_imm_segrin_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.iscrizionedefaultview.rows.length)
						if (this.state.DS.tables.iscrizionedefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.iscrizionedefaultview.clear();
							$('#istanza_imm_segrin_idiscrizione').val('');
						}
				}
				if (t.name === "iscrizionedefaultview" && r !== null) {
					return this.manageidiscrizione(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "registrystudentiview" && r !== null) {
					return this.manageidreg_studenti(this).then(function () {
						return def.resolve();
					});
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_istanzadichiar_iddichiar").prop("disabled", false);
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_istanzadichiar_iddichiar").prop("disabled", true);
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#istanza_imm_segrin_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#istanza_imm_segrin_idiscrizione').val() && grid.dataSourceName === 'nullaosta') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				if (!$('#istanza_imm_segrin_idiscrizione').val() && grid.dataSourceName === 'diniego_alias2') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!this.isNull($('#istanza_imm_segrin_idiscrizione').val()) && this.state.DS.tables["istanza_imm"].rows[0].idiscrizione != $('#istanza_imm_segrin_idiscrizione').val()) {
					this.state.DS.tables["istanza_imm"].rows[0].idcorsostudio = this.state.currentRow.idcorsostudio;
					this.state.DS.tables["istanza_imm"].rows[0].iddidprog = this.state.currentRow.iddidprog;
				}
				if (!this.isNull($('#istanza_imm_segrin_iddidprogcurr').val()) && this.state.DS.tables["istanza_imm"].rows[0].iddidprogcurr != $('#istanza_imm_segrin_iddidprogcurr').val())
					this.state.DS.tables["istanza_imm"].rows[0].iddidprogcurr = parseInt( $('#istanza_imm_segrin_iddidprogcurr').val());
				if (!this.isNull($('#istanza_imm_segrin_iddidprogori').val()) && this.state.DS.tables["istanza_imm"].rows[0].iddidprogori != $('#istanza_imm_segrin_iddidprogori').val())
					this.state.DS.tables["istanza_imm"].rows[0].iddidprogori = parseInt($('#istanza_imm_segrin_iddidprogori').val());

				if (self.isNullOrMinDate(parentRow.data))
				parentRow.data = new Date();
				parentRow.extension = "imm";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_imm_imm_segpre");
				var arraydef = [];
				
				arraydef.push(this.manageistanza_imm__segrin_idreg_studenti());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},

			searchAndAssigndichiar: function (that) {
				return that.searchAndAssign({
					tableName: "dichiar",
					listType: "seg",
					idControl: "txt_istanzadichiar_iddichiar",
					tagSearch: "dichiarsegview.dropdown_title",
					columnNameText: "iddichiarkind",
					columnSource: "iddichiar",
					columnToFill: "iddichiar",
					tableToFill: "istanzadichiar",
					filter: that.q.eq('idreg', that.state.currentRow.idreg_studenti)

				});
			},

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_imm'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['diniego_alias2', 'istanza_alias1', 'istanzadichiar', 'nullaosta'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageidiscrizione: function(that) { 
				var def = appMeta.Deferred("idiscrizione_change-istanza_imm_imm_segrin");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__imm_segrin_idcorsostudio());
				arraydef.push(this.manageistanza_imm__segrin_idcorsostudio());
				arraydef.push(this.manageistanza__imm_segrin_iddidprog());
				arraydef.push(this.manageistanza_imm__segrin_iddidprog());

				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},

			manageidreg_studenti: function(that) { 
				var def = appMeta.Deferred("manageidreg_studenti-istanza__imm_segrin_idreg_studenti");
				that.state.DS.tables.istanza_imm.rows[0].idreg_studenti = that.state.currentRow.idreg_studenti;
				return def.resolve();
			},

			manageistanza__imm_segrin_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__imm_segrin_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionedefaultview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			manageistanza__imm_segrin_iddidprog: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__imm_segrin_iddidprog");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionedefaultview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.iddidprog = masterRow.iddidprog;
				return def.resolve();
			},

			manageistanza_imm__segrin_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_imm__segrin_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionedefaultview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_imm.rows[0].idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			manageistanza_imm__segrin_iddidprog: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_imm__segrin_iddidprog");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionedefaultview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_imm.rows[0].iddidprog = masterRow.iddidprog;
				return def.resolve();
			},

			manageistanza_imm__segrin_idreg_studenti: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_imm__segrin_idreg_studenti");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.registrystudentiview.rows, function (row) {
					if (self.state.currentRow.idreg_studenti)
						return row.idreg === self.state.currentRow.idreg_studenti;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_imm.rows[0].idreg_studenti = masterRow.idreg;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'imm_segrin', metaPage_istanza);

}());
