(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizioneanno() {
		MetaPage.apply(this, ['iscrizioneanno', 'didprog', true]);
        this.name = 'Anni di iscrizione';
		this.defaultListType = 'didprog';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_iscrizioneanno.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizioneanno,
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
				
				if (!parentRow.anno)
					parentRow.anno = 1;
				if (!parentRow.annofc)
					parentRow.annofc = 0;
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-iscrizioneanno_didprog");
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

			afterFill: function () {
				this.enableControl($('#iscrizioneanno_didprog_protnumero'), false);
				this.enableControl($('#iscrizioneanno_didprog_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.didprogoridefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", this.state.callerState.currentRow.iddidprog));
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

			firebtnProtocol: function (that) {
				var idreg_origine = that.idreg_istituto;
				var idreg_destinazione = that.idreg_istituto;
				var oggetto = 'Iscrizione del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data);
				var idprotocollodockind = 5;
				var arrayTablesToProtocol = ['iscrizioneanno'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idiscrizioneanno;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('iscrizioneanno', 'didprog', metaPage_iscrizioneanno);

}());
