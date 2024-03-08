(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'istituti', false]);
        this.name = 'Istituti';
		this.defaultListType = 'istituti';
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
				
				if (!parentRow.idcentralizedcategory)
					parentRow.idcentralizedcategory = 'C_07';
				if (!parentRow.idnation)
					parentRow.idnation = 1;
				if (!parentRow.idregistryclass)
					parentRow.idregistryclass = "23";
				if (!parentRow.idregistrykind)
					parentRow.idregistrykind = 4;
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "istituti";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_istituti_istituti");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_istituti"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_istituti");
					meta.setDefaults(dt);
					var defregistry_istituti = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowistituti) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_istituti);
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
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

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'istituti', metaPage_registry);

}());
