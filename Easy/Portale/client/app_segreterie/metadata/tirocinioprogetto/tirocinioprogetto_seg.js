(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirocinioprogetto() {
		MetaPage.apply(this, ['tirocinioprogetto', 'seg', true]);
        this.name = 'Progetto';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_tirocinioprogetto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirocinioprogetto,
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
				
				if (self.isNullOrMinDate(parentRow.datafineprevista))
					parentRow.datafineprevista = new Date();
				if (self.isNullOrMinDate(parentRow.datainizioprevista))
					parentRow.datainizioprevista = new Date();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#tirocinioprogetto_seg_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#tirocinioprogetto_seg_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-tirocinioprogetto_seg");
				var arraydef = [];
				
				var dttirociniorelazione = this.state.DS.tables["tirociniorelazione"];
				if (dttirociniorelazione.rows.length === 0) {
					var metatirociniorelazione = appMeta.getMeta("tirociniorelazione");
					metatirociniorelazione.setDefaults(dttirociniorelazione);
					var deftirociniorelazione = metatirociniorelazione.getNewRow(parentRow.getRow(), dttirociniorelazione, self.editType).then(
						function (currentRowtirociniorelazione) {
							//defaulttirociniorelazioneObject
							return true;
						}
					);
					arraydef.push(deftirociniorelazione);
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
				this.helpForm.filter($('#tirocinioprogetto_seg_idreg_docenti'), null);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#tirocinioprogetto_seg_protnumero'), false);
				this.enableControl($('#tirocinioprogetto_seg_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.tirociniorelazione, "seg", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("tirociniorelazione");
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				$('#grid_tirocinioappr_seg').data('mdlconditionallookup', 'approvazione,S,Si;approvazione,N,No;');
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

				var oggetto = '';

				var tirocinioinvioazienda = that.getDataTable('tirocinioinvioazienda');
				var	maxDateTirocinioinvioazienda = tirocinioinvioazienda.rows.length ? tirocinioinvioazienda.select(that.q.max('dataora')) : new Date(1000,0,1);

				var tirocinioappr = that.getDataTable('tirocinioappr');
				var	maxDateTirocinioappr = tirocinioappr.rows.length ? tirocinioappr.select(that.q.max('dataora')) : new Date(1000,0,1);

				if (maxDateTirocinioinvioazienda.valueOf() < maxDateTirocinioappr.valueOf()) {
					var tirocinioapprkind = that.getDataTable('tirocinioapprkind');
					var rowTirocinioappr = tirocinioappr.select(that.q.eq('dataora', maxDateTirocinioappr));
					var rowstirocinioapprkind = tirocinioapprkind.select(that.q.eq('idtirocinioapprkind', rowTirocinioappr.idtirocinioapprkind));
					if (that.state.currentRow.idtirocinioapprkind === 2)
						idreg_origine = that.state.currentRow.idreg_docenti;
					if (that.state.currentRow.idtirocinioapprkind === 3)
						idreg_origine = that.state.currentRow.idreg_referente;
					oggetto = (rowstirocinioapprkind.length ? ' ' + rowstirocinioapprkind[0].title : '') + ' del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.date) + ' del progetto di tirocinio';
				}
				else {
					var rowTirocinioinvioazienda = tirocinioinvioazienda.select(that.q.eq('dataora', maxDateTirocinioinvioazienda));
					oggetto = tirocinioinvioazienda.rows.length ?
						'Invio del progetto di tirocinio delle ' + that.stringFromDate_ddmmyyyy(rowTirocinioinvioazienda.dataora)
						: 'Porgetto di tirocinio non ancora inviato all\'azienda o ente';
				}

				var idprotocollodockind = 1;
				var arrayTablesToProtocol = ['tirocinioprogetto'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idtirocinioappr;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('tirocinioprogetto', 'seg', metaPage_tirocinioprogetto);

}());
