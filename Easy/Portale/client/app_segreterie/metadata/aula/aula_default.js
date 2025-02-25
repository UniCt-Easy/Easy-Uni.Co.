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
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#aula_default_idstruttura'), null);
				} else {
					this.helpForm.filter($('#aula_default_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-aula_default");
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
				this.helpForm.filter($('#aula_default_idstruttura'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

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
				appMeta.metaModel.insertFilter(this.getDataTable("aulakinddefaultview"), this.q.eq('aulakind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-aula_default");
				$('#aula_default_idsede').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#aula_default_idsede').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#aula_default_idedificio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idedificio);
				$('#aula_default_idedificio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idedificio);
				$('#aula_default_idsede').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idedificio);
				$('#aula_default_idsede').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idedificio);
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
