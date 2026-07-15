(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'seganagstumast', true]);
        this.name = 'Iscrizioni a master';
		this.defaultListType = 'seganagstumast';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
								if (self.isNullOrMinDate(parentRow.ct))
					parentRow.ct = new Date();
;
				if (!parentRow.cu )
					parentRow.cu = appMeta.security.sysEnv.idcustomuser;
;
								if (self.isNullOrMinDate(parentRow.lt))
					parentRow.lt = new Date();
;
				if (!parentRow.lu )
					parentRow.lu = appMeta.security.sysEnv.idcustomuser;
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-iscrizione_seganagstumast");
				var arraydef = [];
				
				arraydef.push(this.manageiscrizione__seganagstumast_idcorsostudio());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#iscrizione_seganagstumast_iddidprog'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				$('#grid_sostenimento_alias3_seganagstuconsmast').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizione_seganagstumast");
				$('#iscrizione_seganagstumast_iddidprog').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#iscrizione_seganagstumast_iddidprog').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_seganagstumast_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Master');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['sostenimento_alias3'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageiscrizione__seganagstumast_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageiscrizione__seganagstumast_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdotmasview.rows, function (row) {
					if (self.state.currentRow.iddidprog)
						return row.iddidprog === self.state.currentRow.iddidprog;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('iscrizione', 'seganagstumast', metaPage_iscrizione);

}());
