(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_richitesi() {
		MetaPage.apply(this, ['richitesi', 'segistcons', true]);
        this.name = 'Richiesta di Tesi';
		this.defaultListType = 'segistcons';
		//pageHeaderDeclaration
    }

    metaPage_richitesi.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_richitesi,
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
					this.helpForm.filter($('#richitesi_segistcons_idreg'), null);
				} else {
					this.helpForm.filter($('#richitesi_segistcons_idreg'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#richitesi_segistcons_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#richitesi_segistcons_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-richitesi_segistcons");
				var arraydef = [];
				
				var dttesi = this.state.DS.tables["tesi"];
				if (dttesi.rows.length === 0) {
					var metatesi = appMeta.getMeta("tesi");
					metatesi.setDefaults(dttesi);
					var deftesi = metatesi.getNewRow(parentRow.getRow(), dttesi, self.editType).then(
						function (currentRowtesi) {
							//defaulttesiObject
							return true;
						}
					);
					arraydef.push(deftesi);
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
				this.helpForm.filter($('#richitesi_segistcons_idreg'), null);
				this.helpForm.filter($('#richitesi_segistcons_idreg_docenti'), null);
				//afterClearin
			},

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.tesi, "segistcons", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("tesi");
				this.state.DS.tables.richitesi.defaults({ 'accettata': 'N' });
				$('#grid_tesikeyword_segistcons').data('mdlconditionallookup', 'lang,S,Si;lang,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-richitesi_segistcons");
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.registrydefaultview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.registrydefaultview.rows.length)
						if (this.state.DS.tables.registrydefaultview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.registrydefaultview.clear();
							$('#richitesi_segistcons_idreg').val('');
						}
				}
				$('#richitesi_segistcons_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#richitesi_segistcons_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#richitesi_segistcons_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['tesi', 'tesikeyword'],
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

	window.appMeta.addMetaPage('richitesi', 'segistcons', metaPage_richitesi);

}());
