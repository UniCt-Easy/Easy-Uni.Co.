(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentocaratteristicaora() {
		MetaPage.apply(this, ['affidamentocaratteristicaora', 'default', true]);
        this.name = 'Ore';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_affidamentocaratteristicaora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamentocaratteristicaora,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "orakind" && r !== null) {
					if (r.ripetizioni === 'N') {
						$('#affidamentocaratteristicaora_default_ripetizioni').val('');
						self.enableControl($('#affidamentocaratteristicaora_default_ripetizioni'), false);
					}
					else {
						self.enableControl($('#affidamentocaratteristicaora_default_ripetizioni'), true);
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
				if (parentRow.ripetizioni) {
					arraydef.push(appMeta.getData.runSelect('orakind', 'ripetizioni', this.q.eq('idorakind', parentRow.idorakind), null)
						.then(function (dt) {
							if (dt.rows[0].ripetizioni === 'N') {
								self.enableControl($('#affidamentocaratteristicaora_default_ripetizioni'), false);
							}
							else {
								self.enableControl($('#affidamentocaratteristicaora_default_ripetizioni'), true);
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

	window.appMeta.addMetaPage('affidamentocaratteristicaora', 'default', metaPage_affidamentocaratteristicaora);

}());
