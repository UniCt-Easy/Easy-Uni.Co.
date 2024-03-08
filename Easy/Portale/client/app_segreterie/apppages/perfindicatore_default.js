(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfindicatore() {
		MetaPage.apply(this, ['perfindicatore', 'default', false]);
        this.name = 'Indicatori';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfindicatore.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfindicatore,
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfindicatore_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
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
				this.state.DS.tables.perfindicatore.defaults({ 'inverso': "N" });
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

			 insertSoglie: function (prm) {
            return this.superClass.insertSoglie({
               table: "perfindicatoresoglia", keyColumns: "idperfindicatore" });           
         },

			//buttons
        });

	window.appMeta.addMetaPage('perfindicatore', 'default', metaPage_perfindicatore);

}());
