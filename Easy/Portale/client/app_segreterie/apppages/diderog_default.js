(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_diderog() {
		MetaPage.apply(this, ['diderog', 'default', false]);
        this.name = 'Didattica Erogata';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_diderog.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_diderog,
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
				var def = appMeta.Deferred("afterGetFormData-diderog_default");
				var arraydef = [];
				
				arraydef.push(this.managediderog_default_inesaurimento());
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-diderog_default");
				var arraydef = [];
				
				arraydef.push(this.managediderog_default_inesaurimento());
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
				this.enableControl($('#diderog_default_inesaurimentoSi'), true);
				this.enableControl($('#diderog_default_inesaurimentoNo'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformvalutazionekind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('appelloattivform'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('diderog'), this.getDataTable('canale'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#diderog_default_inesaurimentoSi'), false);
				this.enableControl($('#diderog_default_inesaurimentoNo'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformvalutazionekind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('appelloattivform'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('diderog'), this.getDataTable('canale'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_attivform_erogata').data('mdlconditionallookup', 'tipovalutaz,P,Profitto;tipovalutaz,I,Idoneità;');
				var grid_attivform_erogataChildsTables = [
					{ tablename: 'attivformcaratteristica', edittype: 'erogata', columnlookup: 'cf', columncalc: '!attivformcaratteristica'},
				];
				$('#grid_attivform_erogata').data('childtables', grid_attivform_erogataChildsTables);
				$('#grid_attivform_erogata').data('childtablesadd', false);
				$('#grid_attivform_erogata').data('childtablesedit', false);
				$('#grid_attivform_erogata').data('childtablesdelete', false);
				var grid_canale_erogataChildsTables = [
					{ tablename: 'mutuazione', edittype: 'default', columnlookup: 'json', columncalc: '!mutuazione'},
					{ tablename: 'affidamento', edittype: 'default', columnlookup: 'idreg_docenti', columncalc: '!affidamento'},
				];
				$('#grid_canale_erogata').data('childtables', grid_canale_erogataChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-diderog_default");
				$('#diderog_default_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#diderog_default_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#diderog_default_aa').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#diderog_default_aa').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#diderog_default_idsede').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#diderog_default_idsede').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#diderog_default_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studio');
				}
				if (!$('#diderog_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno Accademico');
				}
				if (!$('#diderog_default_idsede').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('getcostididattica').acceptChanges();
				//innerBeforePost
			},

			managediderog_default_inesaurimento: function () {
				var def = appMeta.Deferred("beforeFill-manageEsaurimento");
				var res = _.some(this.state.DS.tables.didproganno.rows, function (row) {
					return row.anno === 1;
				});
				this.state.currentRow.inesaurimento = res ? "N" : "S";
				return def.resolve();

			},

			children: ['attivform', 'canale', 'getcostididattica'],
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

	window.appMeta.addMetaPage('diderog', 'default', metaPage_diderog);

}());
