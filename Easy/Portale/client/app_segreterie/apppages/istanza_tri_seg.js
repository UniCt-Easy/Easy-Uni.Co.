(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'tri_seg', false]);
        this.name = 'Istanza di trasferimento in ingresso';
		this.defaultListType = 'tri_seg';
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
					parentRow.extension = "tri";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 5;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_tri_tri_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_tri"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_tri");
					meta.setDefaults(dt);
					var defistanza_tri = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowtri) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_tri);
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_tri'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalidato'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_tri_seg_protnumero'), false);
				this.enableControl($('#istanza_tri_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_tri'));
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

	window.appMeta.addMetaPage('istanza', 'tri_seg', metaPage_istanza);

}());
