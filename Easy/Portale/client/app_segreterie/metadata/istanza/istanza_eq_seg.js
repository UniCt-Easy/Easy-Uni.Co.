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

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (!parentRow.extension)
					parentRow.extension = "eq";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 1;
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_eq'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias2'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_eq_seg_protnumero'), false);
				this.enableControl($('#istanza_eq_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_eq'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias2'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("istanza","idstatuskind");
				this.state.DS.tables.statuskind.staticFilter(window.jsDataQuery.eq('istanze', 'S'));
				appMeta.metaModel.cachedTable(this.getDataTable("dichiarsegview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("dichiarsegview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#istanza_eq_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_eq_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_eq'].rows.length)
						this.state.DS.tables['istanza_eq'].rows[0].idreg = r.idreg;
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrystudentiview" && r !== null) {
               appMeta.metaModel.cachedTable(this.getDataTable("dichiarsegview"), false);
               var istanza_eq_seg_iddichiar_titolo_segCtrl = $('#istanza_eq_seg_iddichiar_titolo_seg').data("customController");
					var f1 = window.jsDataQuery.eq("idreg", r ? r.idreg: null);
					var f2 = window.jsDataQuery.eq("iddichiarkind", 3);
					self.firstSearchFilter = window.jsDataQuery.and(f1, f2);
					arraydef.push(istanza_eq_seg_iddichiar_titolo_segCtrl.filteredPreFillCombo(self.firstSearchFilter, null, true)
						.then(function (dt) {
							if (self.state.DS && self.state.DS.tables.istanza_eq && self.state.DS.tables.istanza_eq.rows[0] && self.state.DS.tables.istanza_eq.rows[0].iddichiar_titolo_seg) {
								istanza_eq_seg_iddichiar_titolo_segCtrl.fillControl(null, self.state.DS.tables["istanza_eq"].rows[0].iddichiar_titolo_seg);							
							}
							
							return true;
						}).then(function (dt) {
							$("#istanza_eq_seg_iddichiar_titolo_seg").prop("disabled", $("#istanza_eq_seg_iddichiar_titolo_seg")[0].length<=1);
							return true;
						}
						)
					);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
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
