(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'istitutiesteri', false]);
        this.name = 'Istituti esteri';
		this.defaultListType = 'istitutiesteri';
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
					parentRow.idcentralizedcategory = 'C_10';
				if (!parentRow.idregistryclass)
					parentRow.idregistryclass = "23";
				if (!parentRow.idregistrykind)
					parentRow.idregistrykind = 4;
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "istitutiesteri";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_istitutiesteri_residence'), null);
				} else {
					this.helpForm.filter($('#registry_istitutiesteri_residence'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_istitutiesteri_istitutiesteri");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_istitutiesteri"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_istitutiesteri");
					meta.setDefaults(dt);
					var defregistry_istitutiesteri = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowistitutiesteri) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_istitutiesteri);
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
				this.helpForm.filter($('#registry_istitutiesteri_residence'), null);
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

	window.appMeta.addMetaPage('registry', 'istitutiesteri', metaPage_registry);

}());
