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
				
				arraydef.push(this.manageCouses());
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
				
				arraydef.push(this.manageCouses());
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

			
			afterFill: function () {
				this.enableControl($('#diderog_default_idcorsostudiokind'), false);
				this.enableControl($('#diderog_default_idcorsostudiolivello'), false);
				this.enableControl($('#diderog_default_inesaurimentoSi'), false);
				this.enableControl($('#diderog_default_inesaurimentoNo'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformvalutazionekind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('diderog'), this.getDataTable('canale'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('canaleregistry'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('iscrizione'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			
			
			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#diderog_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno Accademico');
				}
				if (!$('#diderog_default_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studio');
				}
				if (!$('#diderog_default_idsede').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Sede');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('getcostididattica').acceptChanges();
				//innerBeforePost
			},

			//afterPost

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-diderog_default");
				$('#diderog_default_idcorsostudiokind').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#diderog_default_idcorsostudiokind').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#diderog_default_idcorsostudiolivello').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#diderog_default_idcorsostudiolivello').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);

				$('#diderog_default_aa').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#diderog_default_aa').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#diderog_default_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#diderog_default_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#diderog_default_idsede').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#diderog_default_idsede').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				if (t.name === "annoaccademico" && r !== null) {
					return this.manageaa(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "corsostudiokinddefaultview" && r !== null) {
					return this.manageidcorsostudiokind(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "corsostudiolivellodefaultview" && r !== null) {
					return this.manageidcorsostudiolivello(this).then(function () {
						return def.resolve();
					});
				}
				//afterRowSelectin
				return def.resolve();
			},

			afterClear: function () {
				//parte sincrona
				const annoCorrente = this.getAAByDate(new Date());
				$('#diderog_default_aa').val(annoCorrente).trigger('change');

				this.enableControl($('#diderog_default_aa'), true);
				this.enableControl($('#diderog_default_idcorsostudiokind'), true);
				this.enableControl($('#diderog_default_idcorsostudiolivello'), true);
				this.enableControl($('#diderog_default_idcorsostudio'), true);
				this.enableControl($('#diderog_default_inesaurimentoSi'), true);
				this.enableControl($('#diderog_default_inesaurimentoNo'), true);
				this.enableControl($('#diderog_default_idsede'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformvalutazionekind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('diderog'), this.getDataTable('canale'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('canaleregistry'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('iscrizione'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterLink: function () {
				var self = this;
				this.getDataTable("corsostudioelenchiprogerogview").staticFilter(this.q.eq('idcorsostudio', 0));

				appMeta.metaModel.insertFilter(this.getDataTable("corsostudiokinddefaultview"), this.q.eq('corsostudiokind_active', 'Si'));
				$('#grid_attivform_erogata').data('mdlconditionallookup', 'tipovalutaz,P,Profitto;tipovalutaz,I,Idoneità;');
				$('#grid_canale_erogata').data('mdlconditionallookup', '!filtrostud,T,Tutti;!filtrostud,I,Solo studenti iscritti alla didattica programmata;');
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

			manageCouses: function(){
				let self = this;
				if (!this.state.isSearchState()) {

					if (!this.state.isInsertState()) return appMeta.Deferred("manageCouses").resolve();

					//INSERIMENTO
					//mostro tutti i corsi programmati (deve esistere l'anno)
					let aa = $('#diderog_default_aa').val();
					let idcorsostudiokind = $('#diderog_default_idcorsostudiokind').val();
					let idcorsostudiolivello = $('#diderog_default_idcorsostudiolivello').val();
					let filterDidProg = (aa ? [this.q.eq("aa", aa)] : null);

					return appMeta.getData.runSelect("didproganno", "aa,idcorsostudio", filterDidProg)
						.then(function (dt) {
							let filterCorsi =
								self.q.and(
									self.q.isIn('idcorsostudio',
									_.map(dt.rows, function (r) {
										return r.idcorsostudio;
									})),
									...(idcorsostudiokind ? [self.q.eq("corsostudio_idcorsostudiokind", idcorsostudiokind)] : []),
									...(idcorsostudiolivello ? [self.q.eq("idcorsostudiolivello", idcorsostudiolivello)] : [])
								);
									
							self.getDataTable('corsostudioelenchiprogerogview').clear();
							var selBuilderArray = [];
							//faccio la query su sql e aggiorno contemporaneamente il dataset
							selBuilderArray.push({ filter: filterCorsi, top: null, tableName: 'corsostudioelenchiprogerogview', table: self.getDataTable('corsostudioelenchiprogerogview') });

							return appMeta.getData.multiRunSelect(selBuilderArray)
								.then(function () {
									var csCtrl = $('#diderog_default_idcorsostudio').data("customController");
									return csCtrl.clearControl();
								})
								.then(function () {
									var csCtrl = $('#diderog_default_idcorsostudio').data("customController");
									return csCtrl.fillControl($('#diderog_default_idcorsostudio'));
								});
						});
				}

				//RICERCA
				//mostro solo i corsi usati nelle erogate

				let aa = $('#diderog_default_aa').val();
				let idcorsostudiokind = $('#diderog_default_idcorsostudiokind').val();
				let idcorsostudiolivello = $('#diderog_default_idcorsostudiolivello').val();
				let filterDidProg = this.q.and(
					...(aa ? [this.q.eq("aa", aa)] : []),
					...(idcorsostudiokind ? [this.q.eq("idcorsostudiokind", idcorsostudiokind)] : []),
					...(idcorsostudiolivello ? [this.q.eq("idcorsostudiolivello", idcorsostudiolivello)] : [])
				);

				return appMeta.getData.runSelect("diderog", "aa,idcorsostudio", filterDidProg)
					.then(function (dt) {
						let filterCorsi = self.q.isIn('idcorsostudio',
							_.map(dt.rows, function (r) {
								return r.idcorsostudio;
							}));
						self.getDataTable('corsostudioelenchiprogerogview').clear();
						var selBuilderArray = [];
						//faccio la query su sql e aggiorno contemporaneamente il dataset
						selBuilderArray.push({ filter: filterCorsi, top: null, tableName: 'corsostudioelenchiprogerogview', table: self.getDataTable('corsostudioelenchiprogerogview') });

						return appMeta.getData.multiRunSelect(selBuilderArray)
							.then(function () {
								var csCtrl = $('#diderog_default_idcorsostudio').data("customController");
								return csCtrl.clearControl();
							})
							.then(function () {
								var csCtrl = $('#diderog_default_idcorsostudio').data("customController");
								return csCtrl.fillControl($('#diderog_default_idcorsostudio'));
							});
					});
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

			manageaa: function(that) { 
				var def = appMeta.Deferred("manageYearfilter");
				this.manageCouses().then(function(){ 
					return def.resolve();
				});
				return def.promise();
			},

			manageidcorsostudiokind: function(that) { 
				var def = appMeta.Deferred("managetypefilter");
				this.manageCouses().then(function(){ 
					return def.resolve();
				});
				return def.promise();
			},

			manageidcorsostudiolivello: function(that) { 
				var def = appMeta.Deferred("manageLevelfilter");
				this.manageCouses().then(function(){ 
					return def.resolve();
				});
				return def.promise();
			},

			//buttons
        });

	window.appMeta.addMetaPage('diderog', 'default', metaPage_diderog);

}());
