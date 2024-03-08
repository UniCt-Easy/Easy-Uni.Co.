(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'default', false]);
        this.name = 'Anagrafica generale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registry,
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
				
				if (!parentRow.residence)
					parentRow.residence = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_default");
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

			configureDependencies:function () {
                var p1 = $("input[data-tag='registry.surname']");
                var p2 = $("input[data-tag='registry.forename']");
                var f1 = $("input[data-tag='registry.title']");

                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename;
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            },

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'default', metaPage_registry);

}());
