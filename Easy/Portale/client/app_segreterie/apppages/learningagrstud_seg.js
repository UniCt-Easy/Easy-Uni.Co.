﻿(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_learningagrstud() {
		MetaPage.apply(this, ['learningagrstud', 'seg', true]);
        this.name = 'Learning agreement for studies';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_learningagrstud.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_learningagrstud,
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
				
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-learningagrstud_seg");
				var arraydef = [];
				
				var dtcefrlanglevel = this.state.DS.tables["cefrlanglevel"];
				if (dtcefrlanglevel.rows.length === 0) {
					var metacefrlanglevel = appMeta.getMeta("cefrlanglevel");
					metacefrlanglevel.setDefaults(dtcefrlanglevel);
					var defcefrlanglevel = metacefrlanglevel.getNewRow(parentRow.getRow(), dtcefrlanglevel, self.editType).then(
						function (currentRowcefrlanglevel) {
							//defaultcefrlanglevelObject
							return true;
						}
					);
					arraydef.push(defcefrlanglevel);
				}

				//beforeFillInside

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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.cefrlanglevel, "default", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("cefrlanglevel");
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

	window.appMeta.addMetaPage('learningagrstud', 'seg', metaPage_learningagrstud);

}());
