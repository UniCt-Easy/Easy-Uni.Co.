(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'sosp_seg', false]);
        this.name = 'Istanza di sospensione degli studi';
		this.defaultListType = 'sosp_seg';
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
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_sosp_sosp_seg");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__sosp_seg_idcorsostudio());
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
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (!parentRow.extension)
					parentRow.extension = "sosp";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 7;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_sosp_sosp_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_sosp"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_sosp");
					meta.setDefaults(dt);
					var defistanza_sosp = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowsosp) {
							currentRowsosp.current.idistanzakind = 7;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_sosp);
				}

				//beforeFillInside

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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_sosp'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias2'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_sosp_seg_protnumero'), false);
				this.enableControl($('#istanza_sosp_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_sosp'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias2'));
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
				var def = appMeta.Deferred("afterRowSelect-istanza_sosp_sosp_seg");
				$('#istanza_sosp_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_sosp_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_sosp'].rows.length)
						this.state.DS.tables['istanza_sosp'].rows[0].idreg = r.idreg;
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_sosp_seg_iddidprog').val('');
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
				if (!$('#istanza_sosp_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
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
				var arrayTablesToProtocol = ['istanza', 'istanza_sosp'];
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

			manageistanza__sosp_seg_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__sosp_seg_idcorsostudio");
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

	window.appMeta.addMetaPage('istanza', 'sosp_seg', metaPage_istanza);

}());
