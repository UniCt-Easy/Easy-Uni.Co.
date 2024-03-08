(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazioneateneo() {
		MetaPage.apply(this, ['perfvalutazioneateneo', 'default', false]);
        this.name = 'Scheda di valutazione di Ateneo';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneateneo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneateneo,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazioneateneo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazioneateneo_default_performance());
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
				
				this.manageperfvalutazioneateneo_default_performance();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneateneo_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneateneores'), this.getDataTable('perfvalutazioneateneoresattach'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneateneores'), this.getDataTable('perfvalutazioneateneoresattach'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.perfvalutazioneateneo.defaults({ 'calcoloautomatico': 'S' });
				$('input[name="perfvalutazioneateneo_default_calcoloautomatico"]').on("change", _.partial(this.managecalcoloautomatico, self));
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

			afterPost: function () {

              // se è stato cliccato annulla o elimina non eseguo sp

				if (!this.state.currentRow) {
					return appMeta.Deferred("afterPost").resolve();
				}

				if (!this.state.currentRow.getRow) {
					return appMeta.Deferred("afterPost").resolve();
				}

				var self = this;

				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				var def = appMeta.Deferred("callSP_refresh_perftotali");


				appMeta.getData.launchCustomServerMethod("callSP", {
					spname: "sp_refresh_perftotali",
					prm1: (this.state.currentRow.year ? this.state.currentRow.year : null)
				}).then(function (res) {

					self.freshForm(true, false)
						.then(function () {
							self.hideWaitingIndicator(waitingHandler);
							if (res.err) {

								self.showMessageOk("KO " + res.err);
							}
							return def.resolve();
						});
				});

				return def.promise();

			},

                calculatePerformance: function (change) {

                // se il calcolo è fatto dall'onchange recupero i dati dal controllo
                if (change) {

                    this.state.currentRow.calcoloautomatico = $('#perfvalutazioneateneo_default_calcoloautomaticoSi').prop("checked") ? 'S' : 'N';
                }

                if (this.state.currentRow.calcoloautomatico == 'N') {
                    this.enableControl($('#perfvalutazioneateneo_default_performance'), true);
                }
                else {

                    this.enableControl($('#perfvalutazioneateneo_default_performance'), false);

                    if (this.getDataTable("perfvalutazioneateneores").rows.length > 0) {
                        var arrayPsuo = _.map(this.getDataTable("perfvalutazioneateneores").rows, function (r) { return { valore: r.percentualeraggiunta, peso: r.peso } });
                        var average = this.calculateWeightedAverage(arrayPsuo);
                        if ($('#perfvalutazioneateneo_default_performance').val() != average.toString().replace('.', ',')) {
                            this.state.currentRow.performance = average;
                            $('#perfvalutazioneateneo_default_performance').val(average.toString().replace('.', ','));
                            return;
                        }
                    }
                }
            },

			manageperfvalutazioneateneo_default_performance: function () {
                this.calculatePerformance();
			},

			managecalcoloautomatico: function(that) { 
				that.calculatePerformance(true);
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazioneateneo', 'default', metaPage_perfvalutazioneateneo);

}());
