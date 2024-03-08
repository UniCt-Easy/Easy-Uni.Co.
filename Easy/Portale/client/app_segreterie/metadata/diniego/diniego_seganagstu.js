(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_diniego() {
		MetaPage.apply(this, ['diniego', 'seganagstu', true]);
        this.name = 'Diniego';
		this.defaultListType = 'seganagstu';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_diniego.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_diniego,
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
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-diniego_seganagstu");
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
				this.enableControl($('#diniego_seganagstu_protanno'), false);
				this.enableControl($('#diniego_seganagstu_protnumero'), false);
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
				var idreg_destinazione = that.state.currentRow.idreg; 
				var oggetto = 'Diniego del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data);
				var idprotocollodockind = 7;
				var arrayTablesToProtocol = ['diniego'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.iddiniego;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('diniego', 'seganagstu', metaPage_diniego);

}());
