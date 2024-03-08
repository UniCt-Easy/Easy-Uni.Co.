(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfobiettiviuo() {
		MetaPage.apply(this, ['perfobiettiviuo', 'default', true]);
        this.name = 'Obiettivi una tantum';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfobiettiviuo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfobiettiviuo,
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
				var def = appMeta.Deferred("afterGetFormData-perfobiettiviuo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfobiettiviuo_default_completamento());
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
				
				this.manageperfobiettiviuo_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfobiettiviuo_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
				this.EnableControl();				//beforeFillInside
				
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
				var valorenumericoCtrl = $('#perfobiettiviuo_default_valorenumerico');

				var completamentoCtrl = $('#perfobiettiviuo_default_completamento');
				this.registerFormula(completamentoCtrl, this.manageperfobiettiviuo_default_completamento.bind(this));
				this.addDependencies(valorenumericoCtrl, completamentoCtrl);
			},

			insertSoglie: function (prm) {
				var filterYear = window.jsDataQuery.eq('year', this.state.callerState.currentRow.year);

				var message = null;
				if (this.getDataTable("perfobiettiviuosoglia").rows.length > 0) {
					message = false;
				}

				return this.superClass.insertSoglie({ table: "perfobiettiviuosoglia", keyColumns: "idperfobiettiviuo,idperfvalutazioneuo", year: this.state.callerState.currentRow.year, columnValueName: "percentuale", filter: filterYear, desMessage: message });
			},

                        EnableControl: function () {
				if (this.state.callerPage.crea !== true) {
					this.enableControl('#perfobiettiviuo_default_title', false)
					this.enableControl('#perfobiettiviuo_default_description', false)
					this.enableControl('#perfobiettiviuo_default_peso', false)
				} 
				
				var goi = $('#grid_perfobiettiviuosoglia_default').data("customController")
				if (goi) {
					if (this.state.callerPage.crea !== true) {
						$(goi.el).css("pointer-events", "none")
					} else {
						$(goi.el).css("pointer-events", "unset")
					}
				}
			},

			manageperfobiettiviuo_default_completamento: function () {
				var haveNumericSoglia = false;
				var arrObiettivi = _.map(this.state.DS.tables["perfobiettiviuosoglia"].rows, function (r) {
					if (r.valorenumerico !== undefined && r.valorenumerico !== null) {
						haveNumericSoglia = true;
					}
					return { indicatore: r.valorenumerico, soglia: r.percentuale }
				})

				if (this.state.currentRow.valorenumerico !== undefined && this.state.currentRow.valorenumerico !== null) {
					this.enableControl($('#perfobiettiviuo_default_completamento'), false);
					return this.calculateCompletamentoByValoreNumerico(arrObiettivi, this.state.currentRow.valorenumerico);
				}
				else this.enableControl($('#perfobiettiviuo_default_completamento'), true);

				this.enableControl($('#perfobiettiviuo_default_valorenumerico'), haveNumericSoglia);

			},

			//buttons
        });

	window.appMeta.addMetaPage('perfobiettiviuo', 'default', metaPage_perfobiettiviuo);

}());
