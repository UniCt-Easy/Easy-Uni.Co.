(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_cedolino() {
		MetaPage.apply(this, ['cedolino', 'default', true]);
        this.name = 'Stipendio mensile importato';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_cedolino.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_cedolino,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-cedolino_default");
				var arraydef = [];
				
				arraydef.push(this.managecedolino_default_tredicesima());
				arraydef.push(this.managecedolino_default_lordo());
				arraydef.push(this.managecedolino_default_tesoro());
				arraydef.push(this.managecedolino_default_previdenza());
				arraydef.push(this.managecedolino_default_irap());
				arraydef.push(this.managecedolino_default_totalece());
				arraydef.push(this.managecedolino_default_totale());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.managecedolino_default_tredicesima();
				this.managecedolino_default_lordo();
				this.managecedolino_default_tesoro();
				this.managecedolino_default_previdenza();
				this.managecedolino_default_irap();
				this.managecedolino_default_totalece();
				this.managecedolino_default_totale();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-cedolino_default");
				var arraydef = [];
				
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
				this.enableControl($('#cedolino_default_tredicesima'), true);
				this.enableControl($('#cedolino_default_lordo'), true);
				this.enableControl($('#cedolino_default_tesoro'), true);
				this.enableControl($('#cedolino_default_previdenza'), true);
				this.enableControl($('#cedolino_default_irap'), true);
				this.enableControl($('#cedolino_default_totalece'), true);
				this.enableControl($('#cedolino_default_totale'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#cedolino_default_tredicesima'), false);
				this.enableControl($('#cedolino_default_lordo'), false);
				this.enableControl($('#cedolino_default_tesoro'), false);
				this.enableControl($('#cedolino_default_previdenza'), false);
				this.enableControl($('#cedolino_default_irap'), false);
				this.enableControl($('#cedolino_default_totalece'), false);
				this.enableControl($('#cedolino_default_totale'), false);
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

			managecedolino_default_tredicesima: function () {
				this.state.currentRow['!tredicesima'] = (this.state.currentRow.stipendio + this.state.currentRow.iis) / 12;

			},

			managecedolino_default_lordo: function () {
				this.state.currentRow.lordo = (this.state.currentRow.stipendio + this.state.currentRow.iis)/12*13 + this.state.currentRow.assegno + this.state.currentRow.assegno;

			},

			managecedolino_default_tesoro: function () {
			this.state.currentRow['!tesoro'] = this.state.currentRow.lordo * 0.242;

			},

			managecedolino_default_previdenza: function () {
				this.state.currentRow['!previdenza'] = 0.071 * (0.8 * this.state.currentRow.stipendio + 0.48 * this.state.currentRow.iis) / 12 * 13;

			},

			managecedolino_default_irap: function () {
				this.state.currentRow.irap = this.state.currentRow.lordo * 0.085;

			},

			managecedolino_default_totalece: function () {
				this.state.currentRow['totalece'] = this.state.currentRow['!tesoro'] + this.state.currentRow['!previdenza'] + this.state.currentRow.irap;

			},

			managecedolino_default_totale: function () {
				this.state.currentRow.totale = this.state.currentRow.lordo + this.state.currentRow['!totalece'];

			},

			//buttons
        });

	window.appMeta.addMetaPage('cedolino', 'default', metaPage_cedolino);

}());
