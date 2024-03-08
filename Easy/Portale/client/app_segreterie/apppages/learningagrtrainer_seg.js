(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_learningagrtrainer() {
		MetaPage.apply(this, ['learningagrtrainer', 'seg', true]);
        this.name = 'Learning agreement for traineeship ';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_learningagrtrainer.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_learningagrtrainer,
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
				var def = appMeta.Deferred("beforeFill-learningagrtrainer_seg");
				var arraydef = [];
				
				var dtconvalida = this.state.DS.tables["convalida"];
				if (dtconvalida.rows.length === 0) {
					var metaconvalida = appMeta.getMeta("convalida");
					metaconvalida.setDefaults(dtconvalida);
					var defconvalida = metaconvalida.getNewRow(parentRow.getRow(), dtconvalida, self.editType).then(
						function (currentRowconvalida) {
							//defaultconvalidaObject
							return true;
						}
					);
					arraydef.push(defconvalida);
				}

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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('cefrlanglevel'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('cefrlanglevel'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.convalida, "segmitr", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("convalida");
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

	window.appMeta.addMetaPage('learningagrtrainer', 'seg', metaPage_learningagrtrainer);

}());
