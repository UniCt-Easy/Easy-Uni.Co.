(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_esonero() {
		MetaPage.apply(this, ['esonero', 'carriera', false]);
        this.name = 'Definizione degli esoneri  derivanti dalla carriera';
		this.defaultListType = 'carriera';
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
				var def = appMeta.Deferred("beforeFill-esonero_carriera_carriera");
				var arraydef = [];
				
				var dt = this.state.DS.tables["esonero_carriera"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("esonero_carriera");
					meta.setDefaults(dt);
					var defesonero_carriera = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowcarriera) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defesonero_carriera);
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

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('esonero', 'carriera', metaPage_esonero);

}());
