(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonalecomportamento() {
		MetaPage.apply(this, ['perfvalutazionepersonalecomportamento', 'default', true]);
        this.name = 'Comportamenti Attesi ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonalecomportamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonalecomportamento,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazionepersonalecomportamento_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazionepersonalecomportamento_default_completamento());
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
				
				if (!parentRow.peso)
					parentRow.peso = 1;                              

				this.EnableControl();
				this.manageperfvalutazionepersonalecomportamento_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazionepersonalecomportamento_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.configureDependencies();
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfvalutazionepersonalecomportamento_default");
				$('#perfvalutazionepersonalecomportamento_default_idperfcomportamento').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idperfcomportamento);
				$('#perfvalutazionepersonalecomportamento_default_idperfcomportamento').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idperfcomportamento);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazionepersonalecomportamento_default_idperfcomportamento').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Comportamento');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			configureDependencies: function () {
            var valorenumericoCtrl = $('#perfvalutazionepersonalecomportamento_default_valorenumerico');

            var completamentoCtrl = $('#perfvalutazionepersonalecomportamento_default_completamento');
            this.registerFormula(completamentoCtrl, this.manageperfvalutazionepersonalecomportamento_default_completamento.bind(this));
            this.addDependencies(valorenumericoCtrl, completamentoCtrl);
			},

			insertSoglie: function (prm) {

				if (this.state.currentRow.idperfcomportamento) {
					var filterYear = this.q.and(this.q.eq('idperfcomportamento', this.state.currentRow.idperfcomportamento), this.q.eq('year', this.state.callerState.currentRow.year));

					var message = null;
					if (this.getDataTable("perfvalutazionepersonalecomportamentosoglia").rows.length > 0) {
						message = false;
					}
					var grid_perfvalutazionepersonalecomportamentosoglia_default = $('#grid_perfvalutazionepersonalecomportamentosoglia_default').data("customController");
					return this.superClass.insertSoglie({
						table: "perfvalutazionepersonalecomportamentosoglia", tableSoglie: "perfcomportamentosoglia", keyColumns: "idperfvalutazionepersonalecomportamento,idperfvalutazionepersonale", columnValueName: "valore", filter: filterYear, desMessage: message
					})
					.then(function () {
						//ripulisco 
						return grid_perfvalutazionepersonalecomportamentosoglia_default.clearControl();
					})
					.then(function () {
						//faccio il fill control 
						return grid_perfvalutazionepersonalecomportamentosoglia_default.fillControl($('#grid_perfvalutazionepersonalecomportamentosoglia_default'));
					})
				}
			},			

			EnableControl: function () {
				if (this.state.callerPage.crea !== true) {
					this.enableControl('#perfvalutazionepersonalecomportamento_default_peso', false)
				} 			

			},

			manageperfvalutazionepersonalecomportamento_default_completamento: function () {
if (this.state.currentRow.valorenumerico !==undefined && this.state.currentRow.valorenumerico !== null) {
	var arrSoglieComportamento = _.map(this.state.callerState.DS.tables["perfvalutazionepersonalecomportamentosoglia"].rows, function (r) { return { indicatore: r.valorenumerico, soglia: r.valore } })            
               this.enableControl($('#perfvalutazionepersonalecomportamento_default_completamento'), false);
               return this.calculateCompletamentoByValoreNumerico(arrSoglieComportamento, this.state.currentRow.valorenumerico);
            }
	else this.enableControl($('#perfvalutazionepersonalecomportamento_default_completamento'), true);
			},

			children: ['perfvalutazionepersonalecomportamentosoglia'],
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

	window.appMeta.addMetaPage('perfvalutazionepersonalecomportamento', 'default', metaPage_perfvalutazionepersonalecomportamento);

}());
