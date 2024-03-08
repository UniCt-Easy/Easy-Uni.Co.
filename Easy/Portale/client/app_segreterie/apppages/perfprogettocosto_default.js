(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettocosto() {
		MetaPage.apply(this, ['perfprogettocosto', 'default', true]);
        this.name = 'Costi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettocosto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettocosto,
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
					this.helpForm.filter($('#perfprogettocosto_default_idaccmotive'), null);
				} else {
					this.helpForm.filter($('#perfprogettocosto_default_idaccmotive'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfprogettocosto_default_idupb'), null);
				} else {
					this.helpForm.filter($('#perfprogettocosto_default_idupb'), this.q.eq('upb_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettocosto_default");
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
				this.helpForm.filter($('#perfprogettocosto_default_idaccmotive'), null);
				this.helpForm.filter($('#perfprogettocosto_default_idupb'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('getcostoview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('perfprogettocostobudgetview'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfprogettocosto_default_budgetcurr'), false);
				this.enableControl($('#perfprogettocosto_default_consuntivo'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('getcostoview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettocosto'), this.getDataTable('perfprogettocostobudgetview'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			
			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfprogettocosto_default");
				$('#perfprogettocosto_default_year').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettocosto_default_year').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#perfprogettocosto_default_idaccmotive').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettocosto_default_idaccmotive').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#perfprogettocosto_default_idupb').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettocosto_default_idupb').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfprogettocosto_default_year').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno');
				}
				if (!$('#perfprogettocosto_default_idaccmotive').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Voce di costo');
				}
				if (!$('#perfprogettocosto_default_idupb').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo UPB');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			
			beforePost: function () {
				  var self = this;
				  this.getDataTable('perfprogettocostobudgetview').acceptChanges();
				  //innerBeforePost
			  },

			afterRowSelect: function (t, r) {
            //afterRowSelectin
            var def = appMeta.Deferred("afterRowSelect-perfprogettocosto_default");
            $('#perfprogettocosto_default_idaccmotive').prop("disabled", this.state.isEditState());
            $('#perfprogettocosto_default_idaccmotive').prop("readonly", this.state.isEditState());
            $('#perfprogettocosto_default_idupb').prop("disabled", this.state.isEditState());
            $('#perfprogettocosto_default_idupb').prop("readonly", this.state.isEditState());
            $('#perfprogettocosto_default_year').prop("disabled", this.state.isEditState());
            $('#perfprogettocosto_default_year').prop("readonly", this.state.isEditState());
            var self = this;

            if (!(!$('#perfprogettocosto_default_idaccmotive').val() || !$('#perfprogettocosto_default_idupb').val() || !$('#perfprogettocosto_default_year').val() != '') &&
               (t.name == 'accmotivedefaultview' || t.name == 'upbdefaultview' || t.name == 'year')) {

					//ripuliamo le tabelle da riempire              				               
					self.getDataTable('getcostoview').clear();
					self.getDataTable('perfprogettocostobudgetview').clear();  					

					self.getDataTable('getcostoview').staticFilter(this.q.constant(false));
					self.getDataTable('perfprogettocostobudgetview').staticFilter(this.q.constant(false));
					
               var arraydef = [];
               var filter = this.q.and([this.q.eq('idupb', self.state.currentRow.idupb), this.q.eq('idaccmotive', self.state.currentRow.idaccmotive),
               this.q.eq('ymov', $('#perfprogettocosto_default_year').val())]);
               arraydef.push(appMeta.getData.runSelectIntoTable(self.getDataTable('getcostoview'), filter, null)
                  .then(function (t) {
							self.state.currentRow.consuntivo = 0;
							$('#perfprogettocosto_default_consuntivo').val('');
                     _.forEach(t.rows, function (rowCosto) {
                        self.state.currentRow.consuntivo += rowCosto.amount;

                     });
                     $('#perfprogettocosto_default_consuntivo').val(self.state.currentRow.consuntivo);
                     return true;
                  }).then(function () {
                     var gridCtrl = $('#grid_getcostoview_default').data("customController");
                     return gridCtrl.fillControl();

                  }));

               var filterProgetto = this.q.and([this.q.eq('idupb', self.state.currentRow.idupb), this.q.eq('idaccmotive', self.state.currentRow.idaccmotive),
               this.q.eq('yvar', $('#perfprogettocosto_default_year').val())]);

               arraydef.push(appMeta.getData.runSelectIntoTable(self.getDataTable('perfprogettocostobudgetview'), filterProgetto, null)
                  .then(function (b) {
							self.state.currentRow.budgetcurr = 0;
							$('#perfprogettocosto_default_budgetcurr').val('');
							_.forEach(b.rows, function (rowBudget) {
								self.state.currentRow.budgetcurr +=  rowBudget.amount +  rowBudget.amount2 + rowBudget.amount3 + rowBudget.amount4 + rowBudget.amount5;

                     });
							$('#perfprogettocosto_default_budgetcurr').val(self.state.currentRow.budgetcurr);
                     return true;
                  }).then(function () {
                     var gridCtrl = $('#grid_perfprogettocostobudgetview_default').data("customController");
                     return gridCtrl.fillControl();
                  }));

               $.when.apply($, arraydef)
                  .then(function () {
                     return def.resolve();
                  });

               return def.promise();

            }
            return def.resolve();

         },
         afterLink: function () {
            //evito di ricaricare tutta la griglia al caricamento della pagina                 
				this.getDataTable('getcostoview').staticFilter(this.q.constant(false));
				this.getDataTable('perfprogettocostobudgetview').staticFilter(this.q.constant(false));				
         },

			children: ['getcostoview', 'perfprogettocostobudgetview'],
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

	window.appMeta.addMetaPage('perfprogettocosto', 'default', metaPage_perfprogettocosto);

}());
