(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivouoview() {
		MetaPage.apply(this, ['perfprogettoobiettivouoview', 'default', true]);
        this.name = 'Obiettivi dei progetti Strategici della UO';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivouoview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivouoview,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#perfprogettoobiettivouoview_default_completamento'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettosoglia'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfprogettoobiettivouoview_default_completamento'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettosoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("perfprogettoobiettivouoview","idperfprogettoobiettivo");
				this.setDenyNull("perfprogettoobiettivouoview","idperfvalutazioneuo");
				this.setDenyNull("perfprogettoobiettivouoview","idperfprogetto");
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

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoobiettivouoview', 'default', metaPage_perfprogettoobiettivouoview);

}());
