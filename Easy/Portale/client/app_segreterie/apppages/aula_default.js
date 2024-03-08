(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_aula() {
		MetaPage.apply(this, ['aula', 'default', false]);
        this.name = 'Aule';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_aula.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_aula,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar21').fullCalendar('rerenderEvents');
				});
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar22').fullCalendar('rerenderEvents');
				});
				this.state.DS.tables.sededefaultview.staticFilter(window.jsDataQuery.eq("sede_idreg", self.idreg_istituto));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-aula_default");
				$('#aula_default_idsede').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#aula_default_idsede').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#aula_default_idedificio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#aula_default_idedificio').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#aula_default_idsede').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Sede');
				}
				if (!$('#aula_default_idedificio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Edificio');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['lezione', 'provaaula', 'sospensione'],
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

	window.appMeta.addMetaPage('aula', 'default', metaPage_aula);

}());
