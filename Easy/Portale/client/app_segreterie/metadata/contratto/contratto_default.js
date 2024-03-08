(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_contratto() {
		MetaPage.apply(this, ['contratto', 'default', true]);
        this.name = 'Servizi di ruolo - Contratti';
		this.defaultListType = 'default';
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
				var def = appMeta.Deferred("beforeFill-contratto_default");
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
				this.enableControl($('#contratto_default_anni'), true);
				this.enableControl($('#contratto_default_mesi'), true);
				this.enableControl($('#contratto_default_giorni'), true);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#contratto_default_anni'), false);
				this.enableControl($('#contratto_default_mesi'), false);
				this.enableControl($('#contratto_default_giorni'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#contratto_default_start').on("change", _.partial(this.managestart, self));
				$('#contratto_default_stop').on("change", _.partial(this.managestop, self));
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
					if (r.contrattokind_tempdef === 'No') {
						self.enableControl($('#contratto_default_tempdefSi'), false);
						self.enableControl($('#contratto_default_tempdefNo'), false);
					}
					else {
						self.enableControl($('#contratto_default_tempdefSi'), true);
						self.enableControl($('#contratto_default_tempdefNo'), true);
					}
				}
				if (t.name === "contrattokinddefaultview" && r !== null) {
					if (r.contrattokind_parttime === 'No') {
						self.enableControl($('#contratto_default_parttime'), false);
					}
					else {
						self.enableControl($('#contratto_default_parttime'), true);
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
				if (parentRow.contrattokind_tempdef) {
					arraydef.push(appMeta.getData.runSelect('contrattokinddefaultview', 'tempdef', this.q.eq('idcontrattokind', parentRow.idcontrattokind), null)
						.then(function (dt) {
							if (dt.rows[0].contrattokind_tempdef === 'No') {
								self.enableControl($('#contratto_default_tempdefSi'), false);
								self.enableControl($('#contratto_default_tempdefNo'), false);
							}
							else {
								self.enableControl($('#contratto_default_tempdefSi'), true);
								self.enableControl($('#contratto_default_tempdefNo'), true);
							}
							return true;
						})
					);
				}
				if (parentRow.contrattokind_parttime) {
					arraydef.push(appMeta.getData.runSelect('contrattokinddefaultview', 'parttime', this.q.eq('idcontrattokind', parentRow.idcontrattokind), null)
						.then(function (dt) {
							if (dt.rows[0].contrattokind_parttime === 'No') {
								self.enableControl($('#contratto_default_parttime'), false);
							}
							else {
								self.enableControl($('#contratto_default_parttime'), true);
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
				if ($("#contratto_default_start").val() != '' && $("#contratto_default_stop").val()!='') {
					var start = that.getDateTimeFromString($("#contratto_default_start").val());
					var stop = $("#contratto_default_stop").val() != '' ? that.getDateTimeFromString($("#contratto_default_stop").val()) : new Date();

					//calcolo la durata per mesi e giorni
					var output = that.getDaysAndMonthByDates(start, stop);

					//rivaluto i giorni in mesi e i mesi in anni
					var result = that.reevaluateDaysAndMonth(output);

					that.state.currentRow.giorni = result.gg;
					that.state.currentRow.mesi = result.mm;
					that.state.currentRow.anni = result.aa;
					$("#contratto_default_anni").val(result.aa);
					$("#contratto_default_mesi").val(result.mm);
					$("#contratto_default_giorni").val(result.gg);
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

	window.appMeta.addMetaPage('contratto', 'default', metaPage_contratto);

}());
