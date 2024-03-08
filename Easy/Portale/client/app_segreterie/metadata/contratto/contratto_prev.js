﻿(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_contratto() {
		MetaPage.apply(this, ['contratto', 'prev', true]);
        this.name = 'Contratti';
		this.defaultListType = 'prev';
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
				
				if (!parentRow.parttime)
					parentRow.parttime = 100;
				if (!parentRow.percentualesufondiateneo)
					parentRow.percentualesufondiateneo = "100";
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				if (!parentRow.tempdef)
					parentRow.tempdef = 'N';
				if (!parentRow.tempindet)
					parentRow.tempindet = 'S';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-contratto_prev");
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

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "contrattokinddefaultview" && r !== null) {
					if (r.contrattokind_parttime === 'No') {
						$('#contratto_prev_parttime').val('');
						self.enableControl($('#contratto_prev_parttime'), false);
					}
					else {
						self.enableControl($('#contratto_prev_parttime'), true);
					}
				}
				if (t.name === "contrattokinddefaultview" && r !== null) {
					if (r.contrattokind_tempdef === 'No') {
						$('#contratto_prev_tempdef').val('');
						self.enableControl($('#contratto_prev_tempdefSi'), false);
						self.enableControl($('#contratto_prev_tempdefNo'), false);
					}
					else {
						self.enableControl($('#contratto_prev_tempdefSi'), true);
						self.enableControl($('#contratto_prev_tempdefNo'), true);
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
								self.enableControl($('#contratto_prev_parttime'), false);
							}
							else {
								self.enableControl($('#contratto_prev_parttime'), true);
							}
							return true;
						})
					);
				}
				if (parentRow.contrattokind_tempdef) {
					arraydef.push(appMeta.getData.runSelect('contrattokinddefaultview', 'tempdef', this.q.eq('idcontrattokind', parentRow.idcontrattokind), null)
						.then(function (dt) {
							if (dt.rows[0].contrattokind_tempdef === 'No') {
								self.enableControl($('#contratto_prev_tempdefSi'), false);
								self.enableControl($('#contratto_prev_tempdefNo'), false);
							}
							else {
								self.enableControl($('#contratto_prev_tempdefSi'), true);
								self.enableControl($('#contratto_prev_tempdefNo'), true);
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

			//buttons
        });

	window.appMeta.addMetaPage('contratto', 'prev', metaPage_contratto);

}());
