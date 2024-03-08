(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettobudget() {
		MetaPage.apply(this, ['progettobudget', 'seg', true]);
        this.name = 'Categorie di costo o ricavo';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettobudget.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettobudget,
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
				var def = appMeta.Deferred("afterGetFormData-progettobudget_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettobudget_seg_budgetvariazione());
				arraydef.push(this.manageprogettobudget_seg_spese());
				arraydef.push(this.manageprogettobudget_seg_ricaviincassati());
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
				
				this.manageprogettobudget_seg_budgetvariazione();
				this.manageprogettobudget_seg_spese();
				this.manageprogettobudget_seg_ricaviincassati();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettobudget_seg");
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
				this.enableControl($('#progettobudget_seg_budgetvariazione'), true);
				this.enableControl($('#progettobudget_seg_spese'), true);
				this.enableControl($('#progettobudget_seg_ricaviincassati'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettobudgetvariazione'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettocosto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettoricavo'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#progettobudget_seg_budgetvariazione'), false);
				this.enableControl($('#progettobudget_seg_spese'), false);
				this.enableControl($('#progettobudget_seg_ricaviincassati'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettobudgetvariazione'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettocosto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettoricavo'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto();
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettobudget_seg");
				$('#progettobudget_seg_idworkpackage').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idworkpackage);
				$('#progettobudget_seg_idworkpackage').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idworkpackage);
				$('#progettobudget_seg_idprogettotipocosto').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogettotipocosto);
				$('#progettobudget_seg_idprogettotipocosto').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogettotipocosto);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettobudget_seg_idworkpackage').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				if (!$('#progettobudget_seg_idprogettotipocosto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Voce di costo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto: function () {
				var self = this;
				var filter = self.q.eq('idprogetto', self.state.callerState.currentRow.idprogetto);
				self.state.DS.tables.workpackagesegview.staticFilter(filter);
				self.state.DS.tables.progettotipocosto.staticFilter(filter);
			},

			manageprogettobudget_seg_budgetvariazione: function () {
				var self = this;
				var progettobudgetvariazione = this.getDataTable('progettobudgetvariazione');
				var dateCurr = new Date(1900, 1, 1);
				_.forEach(progettobudgetvariazione.rows, function (r) {
					if (r.data > dateCurr && !!r.newamount && !!r.data) {
						self.state.currentRow["!budgetvariazione"] = r.newamount
					}
				});
			},

			manageprogettobudget_seg_spese: function () {
				var speseCtrl = $("[data-tag='progettobudget.!spese']");
				var self = this;
				speseCtrl.val(_.sumBy(this.state.callerState.DS.tables.progettocosto.rows, function (r) {
					if (r.idworkpackage === self.state.currentRow.idworkpackage && r.idprogettotipocosto === self.state.currentRow.idprogettotipocosto)
						return r.amount;
				}));
			},

			manageprogettobudget_seg_ricaviincassati: function () {
				var ricaviCtrl = $("[data-tag='progettobudget.!ricaviincassati']");
				var self = this;
				var tot = _.sumBy(this.state.callerState.DS.tables.progettoricavo.rows, function (r) {
					if (r.idworkpackage === self.state.currentRow.idworkpackage && r.idprogettotipocosto === self.state.currentRow.idprogettotipocosto)
						return r.amount;
				});
				ricaviCtrl.val(tot);

			},

			children: ['progettobudgetvariazione', 'progettocosto', 'progettoricavo'],
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

	window.appMeta.addMetaPage('progettobudget', 'seg', metaPage_progettobudget);

}());
