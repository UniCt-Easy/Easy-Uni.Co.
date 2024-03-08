(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'abbr_seg', false]);
        this.name = 'Istanza di abbreviazione';
		this.defaultListType = 'abbr_seg';
		//pageHeaderDeclaration
    }

    metaPage_istanza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanza,
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
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (!parentRow.extension)
					parentRow.extension = "abbr";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 4;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_abbr_abbr_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_abbr"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_abbr");
					meta.setDefaults(dt);
					var defistanza_abbr = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowabbr) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_abbr);
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_abbr'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalidato'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_abbr_seg_protnumero'), false);
				this.enableControl($('#istanza_abbr_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_abbr'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalidato'));
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

	window.appMeta.addMetaPage('istanza', 'abbr_seg', metaPage_istanza);

}());
