(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_contratto() {
		MetaPage.apply(this, ['contratto', 'amm', true]);
        this.name = 'Servizi di ruolo - Contratti';
		this.defaultListType = 'amm';
		//pageHeaderDeclaration
    }

    metaPage_contratto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_contratto,
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
				
				if (this.isNull(parentRow.parttime))
					parentRow.parttime = 100;
				if (this.isNull(parentRow.percentualesufondiateneo))
					parentRow.percentualesufondiateneo = "100";
				if (this.isNull(parentRow.tempdef) || parentRow.tempdef == '')
					parentRow.tempdef = 'N';
				if (this.isNull(parentRow.tempindet) || parentRow.tempindet == '')
					parentRow.tempindet = 'S';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-contratto_amm");
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
				this.enableControl($('#contratto_amm_anni'), true);
				this.enableControl($('#contratto_amm_mesi'), true);
				this.enableControl($('#contratto_amm_giorni'), true);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#contratto_amm_anni'), false);
				this.enableControl($('#contratto_amm_mesi'), false);
				this.enableControl($('#contratto_amm_giorni'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#contratto_amm_start').on("change", _.partial(this.managestart, self));
				$('#contratto_amm_stop').on("change", _.partial(this.managestop, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "contrattokinddefaultview" && r !== null) {
					if (r.contrattokind_parttime === 'No') {
						self.enableControl($('#contratto_amm_parttime'), false);
					}
					else {
						self.enableControl($('#contratto_amm_parttime'), true);
					}
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			afterActivation: function () {
				var parentRow = this.state.currentRow;
				var self = this;
				//afterActivationin
				var arraydef = [];
				if (parentRow.contrattokind_parttime) {
					arraydef.push(appMeta.getData.runSelect('contrattokinddefaultview', 'parttime', this.q.eq('idcontrattokind', parentRow.idcontrattokind), null)
						.then(function (dt) {
							if (dt.rows[0].contrattokind_parttime === 'No') {
								self.enableControl($('#contratto_amm_parttime'), false);
							}
							else {
								self.enableControl($('#contratto_amm_parttime'), true);
							}
							return true;
						})
					);
				}
				//afterActivationAsincIn
				return $.when.apply($, arraydef);
			},

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			refreshAmg: function(that) { 
				//calcolo durata ruolo
				if ($("#contratto_amm_start").val() != '' && $("#contratto_amm_stop").val()!='') {
					var start = that.getDateTimeFromString($("#contratto_amm_start").val());
					var stop = $("#contratto_amm_stop").val() != '' ? that.getDateTimeFromString($("#contratto_amm_stop").val()) : new Date();

					//calcolo la durata per mesi e giorni
					var output = that.getDaysAndMonthByDates(start, stop);

					//rivaluto i giorni in mesi e i mesi in anni
					var result = that.reevaluateDaysAndMonth(output);

					that.state.currentRow.giorni = result.gg;
					that.state.currentRow.mesi = result.mm;
					that.state.currentRow.anni = result.aa;
					$("#contratto_amm_anni").val(result.aa);
					$("#contratto_amm_mesi").val(result.mm);
					$("#contratto_amm_giorni").val(result.gg);
				}
				else {
					that.state.currentRow.anni = 0;
					that.state.currentRow.mesi = 0;
					that.state.currentRow.giorni = 0;					
				}
			},

			managestart: function(that) { 
				that.refreshAmg(that);
			},

			managestop: function(that) { 
				that.refreshAmg(that);
			},

			//buttons
        });

	window.appMeta.addMetaPage('contratto', 'amm', metaPage_contratto);

}());
