(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_esonero() {
		MetaPage.apply(this, ['esonero', 'disabil', false]);
        this.name = 'Definizione degli esoneri di invalidità';
		this.defaultListType = 'disabil';
		//pageHeaderDeclaration
    }

    metaPage_esonero.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_esonero,
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
				var def = appMeta.Deferred("beforeFill-esonero_disabil_disabil");
				var arraydef = [];
				
				var dt = this.state.DS.tables["esonero_disabil"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("esonero_disabil");
					meta.setDefaults(dt);
					var defesonero_disabil = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowdisabil) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defesonero_disabil);
				}

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
				appMeta.metaModel.insertFilter(this.getDataTable("esoneroanskind"), this.q.eq('active', 'S'));
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

	window.appMeta.addMetaPage('esonero', 'disabil', metaPage_esonero);

}());
