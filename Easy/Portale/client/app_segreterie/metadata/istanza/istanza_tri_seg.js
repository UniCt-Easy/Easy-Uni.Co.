(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'tri_seg', false]);
        this.name = 'Istanza di trasferimento in ingresso';
		this.defaultListType = 'tri_seg';
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
				parentRow.extension = "tri";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_tri_tri_seg");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__tri_seg_idcorsostudio());
				arraydef.push(this.manageistanza__tri_seg_iddidprog());
				arraydef.push(this.manageistanza_tri__seg_idcorsostudio());
				arraydef.push(this.manageistanza_tri__seg_iddidprog());
				arraydef.push(this.manageistanza_tri__seg_idreg());
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
					this.helpForm.filter($('#istanza_tri_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_tri_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istanza_tri_seg_idreg_istituti'), null);
				} else {
					this.helpForm.filter($('#istanza_tri_seg_idreg_istituti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_tri_tri_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_tri"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_tri");
					meta.setDefaults(dt);
					var defistanza_tri = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowtri) {
							currentRowtri.current.idistanzakind = 5;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_tri);
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
				this.enableControl($('#istanza_tri_seg_idreg_studenti'), true);
				this.helpForm.filter($('#istanza_tri_seg_idreg_studenti'), null);
				this.enableControl($('#istanza_tri_seg_idiscrizione'), true);
				this.helpForm.filter($('#istanza_tri_seg_idreg_istituti'), null);
				this.enableControl($('#istanza_tri_seg_protnumero'), true);
				this.enableControl($('#istanza_tri_seg_protanno'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_tri_seg_protnumero'), false);
				this.enableControl($('#istanza_tri_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_tri');
				this.state.DS.tables.istanza.defaults({ 'aa': this.getAAByDate() });
				this.state.DS.tables.istanza.defaults({ 'data': new Date() });
				this.state.DS.tables.istanza.defaults({ 'extension': "tri" });
				this.state.DS.tables.istanza.defaults({ 'idistanzakind': 5 });
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.registrydefaultview.staticFilter(window.jsDataQuery.isIn("idregistryclass",['21','23']));
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_tri_tri_seg");
				$('#istanza_tri_seg_idreg_studenti').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				$('#istanza_tri_seg_idreg_studenti').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg_studenti);
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_tri'].rows.length)
						this.state.DS.tables['istanza_tri'].rows[0].idreg = r.idreg;
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.iscrizionedefaultview.rows.length)
						if (this.state.DS.tables.iscrizionedefaultview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.iscrizionedefaultview.clear();
							$('#istanza_tri_seg_idiscrizione').val('');
						}
				}
				$('#istanza_tri_seg_idiscrizione').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#istanza_tri_seg_idiscrizione').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				if (t.name === 'iscrizionedefaultview' && r !== null)
					if (this.state.DS.tables['istanza_tri'].rows.length)
						this.state.DS.tables['istanza_tri'].rows[0].idiscrizione = r.idiscrizione;
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.dichiartitolo_segview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.dichiartitolo_segview.rows.length)
						if (this.state.DS.tables.dichiartitolo_segview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.dichiartitolo_segview.clear();
							$('#istanza_tri_seg_iddichiar_titolo').val('');
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
				if (!$('#istanza_tri_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#istanza_tri_seg_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
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
				var arrayTablesToProtocol = ['istanza', 'istanza_tri'];
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

			manageidiscrizione: function(that) { 
				var def = appMeta.Deferred("manageidiscrizione");
			if (this.state.DS.tables.iscrizionedefaultview.rows.length) {
				this.state.currentRow.iddidprog = this.state.DS.tables.iscrizionedefaultview.rows[0].iddidprog;
				this.state.currentRow.idcorsostudio = this.state.DS.tables.iscrizionedefaultview.rows[0].idcorsostudio;
				this.state.DS.tables.istanza_tri.rows[0].iddidprog = this.state.DS.tables.iscrizionedefaultview.rows[0].iddidprog;
				this.state.DS.tables.istanza_tri.rows[0].idcorsostudio = this.state.DS.tables.iscrizionedefaultview.rows[0].idcorsostudio;
			}
			return def.resolve();
			},

			manageistanza__tri_seg_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__tri_seg_idcorsostudio");
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

			manageistanza__tri_seg_iddidprog: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__tri_seg_iddidprog");
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

			manageistanza_tri__seg_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_tri__seg_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionedefaultview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_tri.rows[0].idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			manageistanza_tri__seg_iddidprog: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_tri__seg_iddidprog");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.iscrizionedefaultview.rows, function (row) {
					if (self.state.currentRow.idiscrizione)
						return row.idiscrizione === self.state.currentRow.idiscrizione;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_tri.rows[0].iddidprog = masterRow.iddidprog;
				return def.resolve();
			},

			manageistanza_tri__seg_idreg: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_tri__seg_idreg");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.registrystudentiview.rows, function (row) {
					if (self.state.currentRow.idreg_studenti)
						return row.idreg === self.state.currentRow.idreg_studenti;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_tri.rows[0].idreg = masterRow.idreg;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'tri_seg', metaPage_istanza);

}());
