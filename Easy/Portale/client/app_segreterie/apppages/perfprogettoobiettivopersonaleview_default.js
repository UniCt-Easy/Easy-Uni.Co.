(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivopersonaleview() {
		MetaPage.apply(this, ['perfprogettoobiettivopersonaleview', 'default', true]);
        this.name = 'Obiettivi dei progetti Strategici di altre UO';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivopersonaleview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivopersonaleview,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#perfprogettoobiettivopersonaleview_default_completamento'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettosoglia'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#perfprogettoobiettivopersonaleview_default_completamento'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettosoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("perfprogettoobiettivopersonaleview","idperfvalutazioneuo");
				this.setDenyNull("perfprogettoobiettivopersonaleview","idstruttura");
				this.setDenyNull("perfprogettoobiettivopersonaleview","idperfprogetto");
				this.setDenyNull("perfprogettoobiettivopersonaleview","idperfprogettoobiettivo");
				this.setDenyNull("perfprogettoobiettivopersonaleview","year");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfprogettoobiettivopersonaleview_default");
				$('#perfprogettoobiettivopersonaleview_default_year').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.year);
				$('#perfprogettoobiettivopersonaleview_default_year').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.year);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfprogettoobiettivopersonaleview_default_year').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('year').acceptChanges();
				//innerBeforePost
			},

			children: ['perfprogettoobiettivosoglia', 'perfprogettosoglia'],
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

	window.appMeta.addMetaPage('perfprogettoobiettivopersonaleview', 'default', metaPage_perfprogettoobiettivopersonaleview);

}());
