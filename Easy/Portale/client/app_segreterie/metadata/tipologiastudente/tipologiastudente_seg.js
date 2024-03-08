(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tipologiastudente() {
		MetaPage.apply(this, ['tipologiastudente', 'seg', true]);
        this.name = 'Categorie di studenti a cui è rivolto';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tipologiastudente.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tipologiastudente,
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
				var def = appMeta.Deferred("beforeFill-tipologiastudente_seg");
				var arraydef = [];
				
				var dtgraduatoriaesiti = this.state.DS.tables["graduatoriaesiti"];
				if (dtgraduatoriaesiti.rows.length === 0) {
					var metagraduatoriaesiti = appMeta.getMeta("graduatoriaesiti");
					metagraduatoriaesiti.setDefaults(dtgraduatoriaesiti);
					var defgraduatoriaesiti = metagraduatoriaesiti.getNewRow(parentRow.getRow(), dtgraduatoriaesiti, self.editType).then(
						function (currentRowgraduatoriaesiti) {
							currentRowgraduatoriaesiti.current.provvisoria = "S";
							//defaultgraduatoriaesitiObject
							return true;
						}
					);
					arraydef.push(defgraduatoriaesiti);
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

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.graduatoriaesiti, "seg", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("graduatoriaesiti");
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

	window.appMeta.addMetaPage('tipologiastudente', 'seg', metaPage_tipologiastudente);

}());
