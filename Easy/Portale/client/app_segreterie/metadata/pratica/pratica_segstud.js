(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pratica() {
		MetaPage.apply(this, ['pratica', 'segstud', false]);
        this.name = 'Pratica di convalida/riconoscimento/dispensa';
		this.defaultListType = 'segstud';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_pratica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pratica,
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
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#pratica_segstud_idreg'), null);
				} else {
					this.helpForm.filter($('#pratica_segstud_idreg'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-pratica_segstud");
				var arraydef = [];
				
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
				this.enableControl($('#pratica_segstud_idreg'), true);
				this.helpForm.filter($('#pratica_segstud_idreg'), null);
				this.enableControl($('#pratica_segstud_idiscrizione'), true);
				this.enableControl($('#pratica_segstud_idcorsostudio'), true);
				this.enableControl($('#pratica_segstud_iddidprog'), true);
				this.enableControl($('#pratica_segstud_idistanza'), true);
				this.enableControl($('#pratica_segstud_idistanzakind'), true);
				this.enableControl($('#pratica_segstud_protnumero'), true);
				this.enableControl($('#pratica_segstud_protanno'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidante'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidato'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#pratica_segstud_idcorsostudio'), false);
				this.enableControl($('#pratica_segstud_iddidprog'), false);
				this.enableControl($('#pratica_segstud_idistanzakind'), false);
				this.enableControl($('#pratica_segstud_protnumero'), false);
				this.enableControl($('#pratica_segstud_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidante'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidato'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.istanzasegstuelencoview_alias14.staticFilter(window.jsDataQuery.isIn("idistanzakind",[1,2,3,4,5]));
				appMeta.metaModel.insertFilter(this.getDataTable("istanzakinddefaultview"), this.q.eq('istanzakind_active', 'Si'));
				this.state.DS.tables.dichiarsegview.staticFilter(window.jsDataQuery.isIn("iddichiarkind",[1,2]));
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq("statuskind_pratica",'Si'));
				$('#grid_convalida_segstudprat').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-pratica_segstud");
				$('#pratica_segstud_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#pratica_segstud_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#pratica_segstud_idiscrizione').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#pratica_segstud_idiscrizione').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#pratica_segstud_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#pratica_segstud_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizione);
				$('#pratica_segstud_idistanza').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idistanza);
				$('#pratica_segstud_idistanza').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idistanza);
				$('#pratica_segstud_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idistanza);
				$('#pratica_segstud_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idistanza);
				if (t.name === "iscrizioneseganagstuview" && r !== null) {
					return this.manageidiscrizione(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "istanzasegstuelencoview_alias14" && r !== null) {
					return this.manageidistanza(this).then(function () {
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
				if (!$('#pratica_segstud_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#pratica_segstud_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				if (!$('#pratica_segstud_idistanza').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Istanza');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;				

				var oggetto = 'Pratica del ' + that.stringFromDate_ddmmyyyy(new Date());
				var idprotocollodockind = 3;
				var arrayTablesToProtocol = ['pratica'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idpratica;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['convalida'],
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
if (that.state.DS.tables.iscrizioneseganagstuview.rows.length && that.state.currentRow) {
				let currIdIscrizione = $('#pratica_segstud_idiscrizione').val();
				let currIscr = _.find(that.state.DS.tables.iscrizioneseganagstuview.rows, function (o) { return o.idiscrizione === parseInt(currIdIscrizione); })
				if (currIscr) {
					that.state.currentRow.idcorsostudio = currIscr.idcorsostudio;
					that.state.currentRow.iddidprog = currIscr.iddidprog;
				}
}
return def.resolve();
			},

			manageidistanza: function(that) { 
								var def = appMeta.Deferred("manageidiscrizione");
				if (that.state.DS.tables.istanzasegstuelencoview_alias14.rows.length && that.state.currentRow) {
					let currIdIstanza = $('#pratica_segstud_idistanza').val();
					let currIst = _.find(that.state.DS.tables.istanzasegstuelencoview_alias14.rows, function (o) { return o.idistanza === parseInt(currIdIstanza); })
					if (currIst) {
						that.state.currentRow.idistanzakind = currIst.idistanzakind;
					}
				}
				return def.resolve();

			},

			//buttons
        });

	window.appMeta.addMetaPage('pratica', 'segstud', metaPage_pratica);

}());
