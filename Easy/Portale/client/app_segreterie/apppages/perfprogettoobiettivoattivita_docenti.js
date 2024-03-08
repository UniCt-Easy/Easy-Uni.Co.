(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivoattivita() {
		MetaPage.apply(this, ['perfprogettoobiettivoattivita', 'docenti', false]);
        this.name = 'Le mie attività sui progetti strategici';
		this.defaultListType = 'docenti';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivoattivita.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivoattivita,
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
					this.helpForm.filter($('#perfprogettoobiettivoattivita_docenti_idupb'), null);
				} else {
					this.helpForm.filter($('#perfprogettoobiettivoattivita_docenti_idupb'), this.q.eq('upb_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivoattivita_docenti");
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
				this.helpForm.filter($('#perfprogettoobiettivoattivita_docenti_idupb'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($("#XXperfprogettoattivitainterazione"), this.state.isEditState());
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			
			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfprogettoobiettivoattivita_docenti");
				$('#perfprogettoobiettivoattivita_docenti_idperfprogetto').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettoobiettivoattivita_docenti_idperfprogetto').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXperfprogettoattivitainterazione").length) {
					$("#XXperfprogettoattivitainterazione").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#perfprogettoobiettivoattivita_docenti_idperfprogetto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Progetto Strategico');
				}
				if (!$('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Obiettivo strategico');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterLink: function () {
				var self = this;
				this.state.DS.tables.perfprogettoobiettivoattivita.defaults({ 'idreg': this.sec.usr('idreg') });
				$("#XXperfprogettoattivitainterazione").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];

					var filter = self.q.eq('idreg', appMeta.security.usr("idreg"));
					var def = appMeta.getData.runSelect('perfprogettouomembro', 'idperfprogetto', filter)
						.then(function (dt) {
							var arrayOr = [];
							_.forEach(dt.rows, function (r) {
								arrayOr.push(self.q.eq('idperfprogetto', r.idperfprogetto));
							});
							self.getDataTable('perfprogettodefaultview').staticFilter(self.q.or(arrayOr));
							return true;
						})
					arraydef.push(def);

					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			children: ['perfprogettoobiettivoattivitaattach'],
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

	window.appMeta.addMetaPage('perfprogettoobiettivoattivita', 'docenti', metaPage_perfprogettoobiettivoattivita);

}());
