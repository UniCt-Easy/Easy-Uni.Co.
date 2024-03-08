(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_dichiar() {
		MetaPage.apply(this, ['dichiar', 'disabil_seganagstu', false]);
        this.name = 'Dichiarazione di disabilità';
		this.defaultListType = 'disabil_seganagstu';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_dichiar.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_dichiar,
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
				
				if (self.isNullOrMinDate(parentRow.date))
					parentRow.date = new Date();
				parentRow.extension = "disabil";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-dichiar_disabil_disabil_seganagstu");
				var arraydef = [];
				
				var dt = this.state.DS.tables["dichiar_disabil"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("dichiar_disabil");
					meta.setDefaults(dt);
					var defdichiar_disabil = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowdisabil) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defdichiar_disabil);
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

			afterFill: function () {
				this.enableControl($('#dichiar_disabil_seganagstu_protnumero'), false);
				this.enableControl($('#dichiar_disabil_seganagstu_protanno'), false);
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
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('dichiar', 'disabil_seganagstu', metaPage_dichiar);

}());
