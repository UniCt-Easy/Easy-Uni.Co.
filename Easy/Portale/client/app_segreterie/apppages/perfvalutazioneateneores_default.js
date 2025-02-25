(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazioneateneores() {
		MetaPage.apply(this, ['perfvalutazioneateneores', 'default', true]);
        this.name = 'Risultati della performance istituzionale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneateneores.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneateneores,
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
				
				var loggato = this.sec.usr('idreg');
				//se l'utente loggato  è il compilatore disabilito tutti i campi a meno di fonte e percentuale raggiunta
				if (loggato == this.state.currentRow.idreg) {
					self.enableAllParentRowControl(parentRow,this.state.DS.name, false);
					self.enableControl($('#perfvalutazioneateneores_default_percentualeraggiunta'), true);
					self.enableControl($('#perfvalutazioneateneores_default_fonte'), true);					
					}
	
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneateneores_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneateneores'), this.getDataTable('perfvalutazioneateneoresattach'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneateneores'), this.getDataTable('perfvalutazioneateneoresattach'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("perfmissiondefaultview"), this.q.eq('perfmission_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfvalutazioneateneores_default");
				$('#perfvalutazioneateneores_default_idperfmission').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idperfmission);
				$('#perfvalutazioneateneores_default_idperfmission').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idperfmission);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazioneateneores_default_idperfmission').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Missione istituzionale');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['perfvalutazioneateneoresattach', 'perfvalutazioneateneoresvalidatori'],
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

	window.appMeta.addMetaPage('perfvalutazioneateneores', 'default', metaPage_perfvalutazioneateneores);

}());
