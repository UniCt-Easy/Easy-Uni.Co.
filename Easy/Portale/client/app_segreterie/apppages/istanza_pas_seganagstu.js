(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'pas_seganagstu', true]);
        this.name = 'Istanze di passaggio corso o cambio ordinamento';
		this.defaultListType = 'pas_seganagstu';
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
				
				if (this.isNull(parentRow.aa))
					parentRow.aa = this.getAAByDate();
								if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (this.isNull(parentRow.extension))
					parentRow.extension = "pas";
				if (this.isNull(parentRow.idistanzakind) || parentRow.idistanzakind == 0)
					parentRow.idistanzakind = 3;
				if (this.isNull(parentRow.idstatuskind))
					parentRow.idstatuskind = 1;
				parentRow.extension = "pas";
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-istanza_pas_pas_seganagstu");
				var arraydef = [];
				
				arraydef.push(this.manageistanza_pas_seganagstu_idcorsostudio());
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
				
				this.manageistanza_pas_seganagstu_idcorsostudio();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_pas_pas_seganagstu");
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
				this.enableControl($('#istanza_pas_seganagstu_iddidprog'), true);
				this.enableControl($('#istanza_pas_seganagstu_protnumero'), true);
				this.enableControl($('#istanza_pas_seganagstu_protanno'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_pas'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#istanza_pas_seganagstu_iddidprog'), false);
				this.enableControl($('#istanza_pas_seganagstu_protnumero'), false);
				this.enableControl($('#istanza_pas_seganagstu_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_pas'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.addExtraEntity('istanza_pas');
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("istanza_pas","idiscrizione_from");
				this.setDenyNull("istanza","iddidprog");
				this.setDenyNull("istanza","idiscrizione");
				this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.and(window.jsDataQuery.eq("idreg", this.state.callerState.DS.tables.registry.rows[0].idreg),	window.jsDataQuery.isNotNull("iddidprog")));
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq('statuskind_istanze', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_pas_pas_seganagstu");
				if (t.name === "iscrizionedefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_pasanagstu_seg_iddidprog').val('');
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
				if (!$('#istanza_pas_seganagstu_idiscrizione_from').val() && grid.dataSourceName === 'pratica') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione di partenza');
				}
				if (!$('#istanza_pas_seganagstu_idiscrizione_from').val() && grid.dataSourceName === 'nullaosta_alias4') {
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

			manageistanza_pas_seganagstu_idcorsostudio: function () {
				if(this.state.DS.tables.didprogdefaultview.rows.length)
					this.state.currentRow.idcorsostudio = this.state.DS.tables.didprogdefaultview.rows[0].idcorsostudio 
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'pas_seganagstu', metaPage_istanza);

}());
