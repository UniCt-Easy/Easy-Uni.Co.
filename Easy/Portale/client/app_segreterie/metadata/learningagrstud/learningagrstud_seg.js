(function () {
	
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
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#learningagrstud_seg_idreg_istitutiesteri'), null);
				} else {
					this.helpForm.filter($('#learningagrstud_seg_idreg_istitutiesteri'), this.q.eq('registry_active', 'Si'));
				}
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
				this.helpForm.filter($('#learningagrstud_seg_idreg_istitutiesteri'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.cefrlanglevel, "las", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("cefrlanglevel");
				this.setDenyNull("learningagrstud","idlearningagrstud");
				this.setDenyNull("learningagrstud","idbandomi");
				this.setDenyNull("learningagrstud","idiscrizionebmi");
				appMeta.metaModel.insertFilter(this.getDataTable("learningagrkinddefaultview"), this.q.eq('learningagrkind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("strutturadefaultview"), this.q.eq('struttura_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("cefrdefaultview"), this.q.eq('cefr_active', 'Si'));
				$('#grid_convalida_segmi').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
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
