(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonaleuo() {
		MetaPage.apply(this, ['perfvalutazionepersonaleuo', 'default', true]);
        this.name = 'Performance dell’unità organizzativa';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonaleuo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonaleuo,
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
				
				if (this.isNull(parentRow.peso))
					parentRow.peso = 100;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfvalutazionepersonaleuo_default_idstruttura'), null);
				} else {
					this.helpForm.filter($('#perfvalutazionepersonaleuo_default_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazionepersonaleuo_default");
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
				this.helpForm.filter($('#perfvalutazionepersonaleuo_default_idstruttura'), null);
				this.enableControl($('#perfvalutazionepersonaleuo_default_punteggio'), true);
				this.enableControl($('#perfvalutazionepersonaleuo_default_afferenza'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfvalutazionepersonaleuo_default_punteggio'), false);
				this.enableControl($('#perfvalutazionepersonaleuo_default_afferenza'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfvalutazionepersonaleuo_default");
				$('#perfvalutazionepersonaleuo_default_idstruttura').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idstruttura);
				$('#perfvalutazionepersonaleuo_default_idstruttura').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idstruttura);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazionepersonaleuo_default_idstruttura').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Unità organizzativa');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: [''],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazionepersonaleuo', 'default', metaPage_perfvalutazionepersonaleuo);

}());
