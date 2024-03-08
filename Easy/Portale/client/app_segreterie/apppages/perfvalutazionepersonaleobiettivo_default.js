(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonaleobiettivo() {
		MetaPage.apply(this, ['perfvalutazionepersonaleobiettivo', 'default', true]);
        this.name = 'Obiettivi Individuali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonaleobiettivo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonaleobiettivo,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazionepersonaleobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazionepersonaleobiettivo_default_completamento());
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
				
				if (this.isNull(parentRow.completamento))
					parentRow.completamento = 0;
				this.manageperfvalutazionepersonaleobiettivo_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazionepersonaleobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
				this.EnableControl();
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
				this.configureDependencies();
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

			//buttonClickEnd

			//insertClick

			//beforePost

			configureDependencies: function () {
				var valorenumericoCtrl = $('#perfvalutazionepersonaleobiettivo_default_valorenumerico');

				var completamentoCtrl = $('#perfvalutazionepersonaleobiettivo_default_completamento');
				this.registerFormula(completamentoCtrl, this.manageperfvalutazionepersonaleobiettivo_default_completamento.bind(this));
				this.addDependencies(valorenumericoCtrl, completamentoCtrl);
			},

			insertSoglie: function (prm) {

				var filterYear = window.jsDataQuery.eq('year', this.state.callerState.currentRow.year);

				var message = null;
				if (this.getDataTable("perfvalutazionepersonalesoglia").rows.length > 0) {
					message = false;
				}

				return this.superClass.insertSoglie({
					table: "perfvalutazionepersonalesoglia", tableSoglie: "perfsoglia", keyColumns: "idperfvalutazionepersonaleobiettivo,idperfvalutazionepersonale", columnValueName: "percentuale", filter: filterYear, desMessage: message
				});
			},
			
			EnableControl: function () {
				if (this.state.callerPage.crea !== true) {
					this.enableControl('#perfvalutazionepersonaleobiettivo_default_peso', false)
					this.enableControl('#perfvalutazionepersonaleobiettivo_default_title', false)
					this.enableControl('#perfvalutazionepersonaleobiettivo_default_description', false)					

				}
								
				var goi = $('#grid_perfvalutazionepersonalesoglia_default').data("customController")
				if (goi) {
					if (this.state.callerPage.crea !== true) {
						$(goi.el).css("pointer-events", "none")
					} else {
						$(goi.el).css("pointer-events", "unset")
					}
				}
			},

			manageperfvalutazionepersonaleobiettivo_default_completamento: function () {
				var haveNumericSoglia = false;
				var arrSoglieObiettivi = _.map(this.state.DS.tables["perfvalutazionepersonalesoglia"].rows, function (r) {
					if (r.valorenumerico !== undefined && r.valorenumerico !== null) {
						haveNumericSoglia = true;
					}
					return { indicatore: r.valorenumerico, soglia: r.percentuale }
				})

				if (this.state.currentRow.valorenumerico !== undefined && this.state.currentRow.valorenumerico !== null) {
					this.enableControl($('#perfvalutazionepersonaleobiettivo_default_completamento'), false);
					return this.calculateCompletamentoByValoreNumerico(arrSoglieObiettivi, this.state.currentRow.valorenumerico);
				}
				else this.enableControl($('#perfvalutazionepersonaleobiettivo_default_completamento'), true);

				this.enableControl($('#perfvalutazionepersonaleobiettivo_default_valorenumerico'), haveNumericSoglia);
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazionepersonaleobiettivo', 'default', metaPage_perfvalutazionepersonaleobiettivo);

}());
