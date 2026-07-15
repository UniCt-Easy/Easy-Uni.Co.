(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'didprog', true]);
        this.name = 'Iscrizioni';
		this.defaultListType = 'didprog';
		//pageHeaderDeclaration
    }

    metaPage_iscrizione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizione,
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
					this.helpForm.filter($('#iscrizione_didprog_idreg'), null);
				} else {
					this.helpForm.filter($('#iscrizione_didprog_idreg'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-iscrizione_didprog");
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
				this.enableControl($('#iscrizione_didprog_idreg'), true);
				this.helpForm.filter($('#iscrizione_didprog_idreg'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizioneanno'), this.getDataTable('parttimeinfo'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizioneanno'), this.getDataTable('parttimeinfo'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_sostenimento_didprog').data('mdlconditionallookup', 'livello,A,A ;livello,B,B ;livello,C,C ;livello,D,D ;votolode,S,Si;votolode,N,No;');
				var grid_pianostudio_didprogChildsTables = [
					{ tablename: 'pianostudioattivform', edittype: 'didprog', columnlookup: 'anno', columncalc: '!pianostudioattivform'},
				];
				$('#grid_pianostudio_didprog').data('childtables', grid_pianostudio_didprogChildsTables);
				$('#grid_pianostudio_didprog').data('childtablesadd', false);
				$('#grid_pianostudio_didprog').data('childtablesdelete', false);
				var grid_iscrizioneanno_didprogChildsTables = [
					{ tablename: 'parttimeinfo', edittype: 'seganagstu', columnlookup: 'idreg', columncalc: '!parttimeinfo'},
				];
				$('#grid_iscrizioneanno_didprog').data('childtables', grid_iscrizioneanno_didprogChildsTables);
				$('#grid_iscrizioneanno_didprog').data('childtablesadd', false);
				$('#grid_iscrizioneanno_didprog').data('childtablesedit', false);
				$('#grid_iscrizioneanno_didprog').data('childtablesdelete', false);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizione_didprog");
				$('#iscrizione_didprog_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#iscrizione_didprog_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_didprog_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['iscrizioneanno', 'pianostudio', 'sostenimento'],
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

	window.appMeta.addMetaPage('iscrizione', 'didprog', metaPage_iscrizione);

}());
