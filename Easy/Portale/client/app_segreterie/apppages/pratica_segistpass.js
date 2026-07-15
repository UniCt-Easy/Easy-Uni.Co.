(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pratica() {
		MetaPage.apply(this, ['pratica', 'segistpass', true]);
        this.name = 'Pratica di convalida/riconoscimento/dispensa collegata';
		this.defaultListType = 'segistpass';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-pratica_segistpass");
				var arraydef = [];
				
				arraydef.push(this.managepratica_segistpass_idiscrizione_from());
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
				
				this.managepratica_segistpass_idiscrizione_from();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-pratica_segistpass");
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
				this.enableControl($('#pratica_segistpass_idiscrizione_from'), true);
				this.enableControl($('#pratica_segistpass_protnumero'), true);
				this.enableControl($('#pratica_segistpass_protanno'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#pratica_segistpass_idiscrizione_from'), false);
				this.enableControl($('#pratica_segistpass_protnumero'), false);
				this.enableControl($('#pratica_segistpass_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.eq("idreg", this.state.callerState.currentRow.idreg_studenti));
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq("statuskind_pratica",'Si'));
				$('#grid_convalida_segistpass').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

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


			//insertClick

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

			managepratica_segistpass_idiscrizione_from: function () {
				this.state.currentRow.idiscrizione_from = appMeta.currApp.currentMetaPage.state.callerState.DS.tables.istanza_pas.rows[0].idiscrizione_from;
				$('#InvisibleTxtiscrizionedefaultview_pratica').val(this.state.currentRow.idiscrizione_from);
			},

			//buttons
        });

	window.appMeta.addMetaPage('pratica', 'segistpass', metaPage_pratica);

}());
