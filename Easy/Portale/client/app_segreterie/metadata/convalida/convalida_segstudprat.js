(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalida() {
		MetaPage.apply(this, ['convalida', 'segstudprat', true]);
        this.name = 'Convalida/riconoscimento/dispensa ';
		this.defaultListType = 'segstudprat';
		//pageHeaderDeclaration
    }

    metaPage_convalida.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalida,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidante'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidato'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidante'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('convalida'), this.getDataTable('convalidato'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("convalida","idreg");
				appMeta.metaModel.insertFilter(this.getDataTable("convalidakinddefaultview"), this.q.eq('convalidakind_active', 'Si'));
				$('#grid_convalidante_segstudprat').data('mdlconditionallookup', 'changes,S,Si;changes,N,No;');
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

	window.appMeta.addMetaPage('convalida', 'segstudprat', metaPage_convalida);

}());
