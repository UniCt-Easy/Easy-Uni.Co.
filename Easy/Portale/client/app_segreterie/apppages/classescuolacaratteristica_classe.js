﻿(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_classescuolacaratteristica() {
		MetaPage.apply(this, ['classescuolacaratteristica', 'classe', true]);
        this.name = 'Caratteristiche della scuola / classe di laurea';
		this.defaultListType = 'classe';
		//pageHeaderDeclaration
    }

    metaPage_classescuolacaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_classescuolacaratteristica,
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
				
				if (!parentRow.obblig)
					parentRow.obblig = "N";
				if (!parentRow.profess)
					parentRow.profess = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-classescuolacaratteristica_classe");
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
				appMeta.metaModel.cachedTable(this.getDataTable("ambitoareadiscdefaultview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("ambitoareadiscdefaultview"));
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
				if (t.name === "tipoattform" && r !== null) {
					var filter = this.q.and(this.q.eq('idclassescuola', this.state.currentRow.idclassescuola), this.q.eq('idtipoattform', r.idtipoattform));
					appMeta.metaModel.cachedTable(self.getDataTable("ambitoareadiscdefaultview"), false);
					var classescuolacaratteristica_classe_idambitoareadiscCtrl = $('#classescuolacaratteristica_classe_idambitoareadisc').data("customController");
					arraydef.push(classescuolacaratteristica_classe_idambitoareadiscCtrl.filteredPreFillCombo(filter, null, true));
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			afterActivation: function () {
				var parentRow = this.state.currentRow;
				var self = this;
				//afterActivationin
				var arraydef = [];
				if (parentRow.idtipoattform) {
					var filter = this.q.and(this.q.eq('idclassescuola', parentRow.idclassescuola), this.q.eq('idtipoattform', parentRow.idtipoattform));
					appMeta.metaModel.cachedTable(this.getDataTable("ambitoareadiscdefaultview"), false);
					var classescuolacaratteristica_classe_idambitoareadiscCtrl = $('#classescuolacaratteristica_classe_idambitoareadisc').data("customController");
					arraydef.push(classescuolacaratteristica_classe_idambitoareadiscCtrl.filteredPreFillCombo(filter, null, true));
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

	window.appMeta.addMetaPage('classescuolacaratteristica', 'classe', metaPage_classescuolacaratteristica);

}());
