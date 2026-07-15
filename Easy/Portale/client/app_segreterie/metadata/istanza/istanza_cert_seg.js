(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'cert_seg', false]);
        this.name = 'Richiesta di certificato';
		this.defaultListType = 'cert_seg';
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
				parentRow.extension = "cert";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_cert_cert_seg");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__cert_seg_idcorsostudio());
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
				
				var gridParentRelsistanzaattach25 = self.state.DS.getParentChildRelation("istanza", "istanzaattach");
				var fatherfilteristanzaattach25 = gridParentRelsistanzaattach25[0].getChildFilter(parentRow);
				var filterGrididistanzakind25 = window.jsDataQuery.eq("idistanzakind", 9);
				var istanzaattach = this.getDataTable("istanzaattach");
				var finalfilteristanzaattach25 = window.jsDataQuery.and([fatherfilteristanzaattach25, filterGrididistanzakind25]);
				istanzaattach.rows =  _.filter(istanzaattach.rows, function(r) {return finalfilteristanzaattach25(r)});
				$("#grid_istanzaattach_seg").data("customParentRelation", finalfilteristanzaattach25);
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istanza_cert_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_cert_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_cert_cert_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_cert"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_cert");
					meta.setDefaults(dt);
					var defistanza_cert = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowcert) {
							currentRowcert.current.idistanzakind = 9;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_cert);
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
				this.enableControl($('#istanza_cert_seg_idreg_studenti'), true);
				this.helpForm.filter($('#istanza_cert_seg_idreg_studenti'), null);
				this.enableControl($('#istanza_cert_seg_iddidprog'), true);
				this.enableControl($('#istanza_cert_seg_protnumero'), true);
				this.enableControl($('#istanza_cert_seg_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_cert_seg_iddidprog'), false);
				this.enableControl($('#istanza_cert_seg_protnumero'), false);
				this.enableControl($('#istanza_cert_seg_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_cert');
				this.state.DS.tables.istanza.defaults({ 'aa': this.getAAByDate() });
				this.state.DS.tables.istanza.defaults({ 'data': new Date() });
				this.state.DS.tables.istanza.defaults({ 'extension': "cert" });
				this.state.DS.tables.istanza.defaults({ 'idistanzakind': 9 });
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				appMeta.metaModel.insertFilter(this.getDataTable("certkinddefaultview"), this.q.eq('certkind_active', 'Si'));
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_cert_cert_seg");
				$('#istanza_cert_seg_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#istanza_cert_seg_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_cert'].rows.length)
						this.state.DS.tables['istanza_cert'].rows[0].idreg = r.idreg;
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.iscrizionedefaultview.rows.length)
						if (this.state.DS.tables.iscrizionedefaultview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.iscrizionedefaultview.clear();
							$('#istanza_cert_seg_idiscrizione').val('');
						}
				}
				if (t.name === "iscrizionedefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_cert_seg_iddidprog').val('');
						}
				}
				if (t.name === "iscrizionedefaultview" && r !== null) {
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
				if (!$('#istanza_cert_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
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
				var arrayTablesToProtocol = ['istanza', 'istanza_cert'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['istanzaattach'],
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
				var def = appMeta.Deferred("manageidiscrizione");
			if (this.state.DS.tables.iscrizionedefaultview.rows.length) {
				this.state.currentRow.iddidprog = this.state.DS.tables.iscrizionedefaultview.rows[0].iddidprog;
				this.state.currentRow.idcorsostudio = this.state.DS.tables.iscrizionedefaultview.rows[0].idcorsostudio;
			}
			return def.resolve();
			},

			manageistanza__cert_seg_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__cert_seg_idcorsostudio");
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

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'cert_seg', metaPage_istanza);

}());
