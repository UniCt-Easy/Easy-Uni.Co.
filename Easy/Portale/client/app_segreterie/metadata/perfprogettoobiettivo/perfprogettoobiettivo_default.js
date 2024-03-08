(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivo() {
		MetaPage.apply(this, ['perfprogettoobiettivo', 'default', true]);
        this.name = 'Obiettivi';
		this.defaultListType = 'default';
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivo,
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
				var def = appMeta.Deferred("afterGetFormData-perfprogettoobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettoobiettivo_default_completamento());
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
				arraydef.push(this.manageperfprogettoobiettivo_default_completamento());
				var ctrlTree =  $('#perfprogettoobiettivoattivita_alias3_default_tree').data("customController");
					arraydef.push(ctrlTree.findAndSetRoot({
						rootTitle: 'Titolo: '+  (this.state.currentRow.title?  this.state.currentRow.title +'; ' : ''),
				        rootColumnNameTitle: 'title',
						tableForReading: 'perfprogettoobiettivoattivita'
				}));
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
				this.enableControl($('#perfprogettoobiettivo_default_completamento'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($("#XXperfprogettoobiettivointerazione"), this.state.isEditState());
				this.enableControl($('#perfprogettoobiettivo_default_completamento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#XXperfprogettoobiettivointerazione").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXperfprogettoobiettivointerazione").length) {
					$("#XXperfprogettoobiettivointerazione").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			 insertSoglie: function (prm) {

				 var year = new Date().getFullYear();
				 if (this.state.callerState.currentRow.datainizioeffettiva) {
					 year = this.state.callerState.currentRow.datainizioeffettiva.getFullYear();
				 }					 
				 else if (this.state.callerState.currentRow.datainizioprevista) {
					 year = this.state.callerState.currentRow.datainizioprevista.getFullYear();
				 }

				 var filterYear = window.jsDataQuery.eq('year', year);
				return this.superClass.insertSoglie({
					table: "perfprogettoobiettivosoglia", keyColumns: "idperfprogetto,idperfprogettoobiettivo", columnValueName: "percentuale", filter: filterYear
				});
			},

			manageperfprogettoobiettivo_default_completamento: function () {
				//campo calcolato
				var def = appMeta.Deferred("beforeFill-manageperfprogettoobiettivo_default_completamento");								
				this.state.currentRow.completamento = this.calculatePercTree(9999999, "perfprogettoobiettivoattivita_alias3").completamento;								
				def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoobiettivo', 'default', metaPage_perfprogettoobiettivo);

}());
