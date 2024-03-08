(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettouo() {
		MetaPage.apply(this, ['perfprogettouo', 'default', true]);
        this.name = 'Unità di lavoro';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettouo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettouo,
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
				var def = appMeta.Deferred("afterGetFormData-perfprogettouo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettouo_default_struttura());
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettouo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettouo_default_struttura());
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
				this.enableControl($('#perfprogettouo_default_struttura'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfprogettouo_default_struttura'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_perfprogettouomembro_default').data('mdlconditionallookup', 'agile,S,Si;agile,N,No;');
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

			manageperfprogettouo_default_struttura: function () {
           //campo calcolato
            var self = this;
            var arr = [];
            var def = appMeta.Deferred("manageperfprogettouo_default_struttura");

            self.state.currentRow['!struttura'] = "";

            _.forEach(self.getDataTable('getregistrydocentiamministrativi').rows, function (rudrmembro) {
               if (!arr.includes(rudrmembro.struttura) && !!rudrmembro.struttura) {
                  arr.push(rudrmembro.struttura);
               }
            });
            self.state.currentRow['!struttura'] = arr.join('; ');
            return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettouo', 'default', metaPage_perfprogettouo);

}());
