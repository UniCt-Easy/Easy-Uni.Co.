(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_costoscontodefdettaglio() {
		MetaPage.apply(this, ['costoscontodefdettaglio', 'more', true]);
        this.name = 'Voci di dettaglio della indennità o mora';
		this.defaultListType = 'more';
		//pageHeaderDeclaration
    }

    metaPage_costoscontodefdettaglio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodefdettaglio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#costoscontodefdettaglio_more_idfasciaiseedef'), true);
				this.enableControl($('#costoscontodefdettaglio_more_idratadef'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.fasciaiseedefdefaultview.staticFilter(window.jsDataQuery.eq("idcostoscontodef", this.state.callerState.currentRow.idcostoscontodef));
				appMeta.metaModel.insertFilter(this.getDataTable("costoscontodefdettagliokinddefaultview"), this.q.eq('costoscontodefdettagliokind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-costoscontodefdettaglio_more");
				$('#costoscontodefdettaglio_more_idfasciaiseedef').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idfasciaiseedef);
				$('#costoscontodefdettaglio_more_idfasciaiseedef').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idfasciaiseedef);
				$('#costoscontodefdettaglio_more_idratadef').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idratadef);
				$('#costoscontodefdettaglio_more_idratadef').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idratadef);
				$('#costoscontodefdettaglio_more_idfasciaiseedef').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idratadef);
				$('#costoscontodefdettaglio_more_idfasciaiseedef').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idratadef);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#costoscontodefdettaglio_more_idfasciaiseedef').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Fascia ISEE');
				}
				if (!$('#costoscontodefdettaglio_more_idratadef').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Rata');
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

	window.appMeta.addMetaPage('costoscontodefdettaglio', 'more', metaPage_costoscontodefdettaglio);

}());
