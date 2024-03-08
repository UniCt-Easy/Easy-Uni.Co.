(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'seganagstusonpre', true]);
        this.name = 'Istanze collegate';
		this.defaultListType = 'seganagstusonpre';
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
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 13;
				if (!parentRow.idstatuskind)
					parentRow.idstatuskind = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_seganagstusonpre");
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

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("istanza","paridistanza");
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
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'seganagstusonpre', metaPage_istanza);

}());
