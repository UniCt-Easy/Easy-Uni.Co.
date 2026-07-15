(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudioattivform() {
		MetaPage.apply(this, ['pianostudioattivform', 'seganagstu', true]);
        this.name = 'Attività formative pianificate';
		this.defaultListType = 'seganagstu';
		//pageHeaderDeclaration
    }

    metaPage_pianostudioattivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudioattivform,
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
				var def = appMeta.Deferred("afterGetFormData-pianostudioattivform_seganagstu");
				var arraydef = [];
				
				arraydef.push(this.managepianostudioattivform_seganagstu_idcorsostudio());
				arraydef.push(this.managepianostudioattivform_seganagstu_iddidprog());
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
				
				this.managepianostudioattivform_seganagstu_idcorsostudio();
				this.managepianostudioattivform_seganagstu_iddidprog();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-pianostudioattivform_seganagstu");
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
				this.enableControl($('#pianostudioattivform_seganagstu_idsostenimento'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#pianostudioattivform_seganagstu_idsostenimento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			managepianostudioattivform_seganagstu_idcorsostudio: function () {
this.state.currentRow.idcorsostudio = this.state.callerState.currentRow.idcorsostudio
			},

			managepianostudioattivform_seganagstu_iddidprog: function () {
this.state.currentRow.iddidprog= this.state.callerState.currentRow.iddidprog
			},

			//buttons
        });

	window.appMeta.addMetaPage('pianostudioattivform', 'seganagstu', metaPage_pianostudioattivform);

}());
