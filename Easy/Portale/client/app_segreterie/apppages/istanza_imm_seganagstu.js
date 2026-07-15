(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'imm_seganagstu', true]);
        this.name = 'Istanze di immatricolazione';
		this.defaultListType = 'imm_seganagstu';
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_imm_imm_seganagstu");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_imm_alias1"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_imm");
					meta.setDefaults(dt);
					var defistanza_imm = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowimm) {
							currentRowimm.current.idistanzakind = 14;
							currentRowimm.current.parttime = "N";
							currentRowimm.current.pre = "N";
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
				this.enableControl($('#istanza_imm_seganagstu_iddidprog'), true);
				this.enableControl($('#istanza_imm_seganagstu_protnumero'), true);
				this.enableControl($('#istanza_imm_seganagstu_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_imm_seganagstu_protnumero'), false);
				this.enableControl($('#istanza_imm_seganagstu_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_imm_alias1');
				$("#btn_add_istanzadichiar_iddichiar").on("click", _.partial(this.searchAndAssigndichiar, self));
				$("#btn_add_istanzadichiar_iddichiar").prop("disabled", true);
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				$('#grid_nullaosta_imm_alias1_seganagstu').data('mdlconditionallookup', 'parttime,S,Si;parttime,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_imm_imm_seganagstu");
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_imm_seganagstu_iddidprog').val('');
						}
				}
				$('#istanza_imm_seganagstu_iddidprog').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#istanza_imm_seganagstu_iddidprog').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#istanza_imm_seganagstu_aa').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#istanza_imm_seganagstu_aa').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				if (t.name === 'didprogdefaultview' && r !== null)
					if (this.state.DS.tables['istanza_imm_alias1'].rows.length)
						this.state.DS.tables['istanza_imm_alias1'].rows[0].iddidprog = r.iddidprog;
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
				if (!$('#istanza_imm_seganagstu_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				if (!$('#istanza_imm_seganagstu_iddidprog').val() && grid.dataSourceName === 'nullaosta_alias1') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!this.isNull($('#istanza_imm_seganagstu_iddidprogcurr').val()) && this.state.DS.tables["istanza_imm_alias1"].rows[0].iddidprogcurr != $('#istanza_imm_seganagstu_iddidprogcurr').val())
					this.state.DS.tables["istanza_imm_alias1"].rows[0].iddidprogcurr = parseInt( $('#istanza_imm_seganagstu_iddidprogcurr').val());
				if (!this.isNull($('#istanza_imm_seganagstu_iddidprogori').val()) && this.state.DS.tables["istanza_imm_alias1"].rows[0].iddidprogori != $('#istanza_imm_seganagstu_iddidprogori').val())
					this.state.DS.tables["istanza_imm_alias1"].rows[0].iddidprogori = parseInt($('#istanza_imm_seganagstu_iddidprogori').val());

				if (this.isNull(parentRow.aa))
					parentRow.aa = this.getAAByDate();
								if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (this.isNull(parentRow.idistanzakind) || parentRow.idistanzakind == 0)
					parentRow.idistanzakind = 14;
				if (this.isNull(parentRow.idstatuskind))
					parentRow.idstatuskind = 1;
				parentRow.extension = "imm";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_imm_imm_segpre");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__imm_seganagstu_idcorsostudio());
				arraydef.push(this.manageistanza_imm__seganagstu_idcorsostudio());
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
					tableToFill: "istanzadichiar_alias1",
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
				var arrayTablesToProtocol = ['istanza', 'istanza_imm_alias1'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['diniego_alias1', 'istanza_alias1', 'istanzadichiar_alias1', 'nullaosta_alias1'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageistanza__imm_seganagstu_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__imm_seganagstu_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdefaultview.rows, function (row) {
					if (self.state.currentRow.iddidprog)
						return row.iddidprog === self.state.currentRow.iddidprog;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			manageistanza_imm__seganagstu_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_imm__seganagstu_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdefaultview.rows, function (row) {
					if (self.state.currentRow.iddidprog)
						return row.iddidprog === self.state.currentRow.iddidprog;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_imm_alias1.rows[0].idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'imm_seganagstu', metaPage_istanza);

}());
