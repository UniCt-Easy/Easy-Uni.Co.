(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalida() {
		MetaPage.apply(this, ['convalida', 'segmi', true]);
        this.name = 'Convalide';
		this.defaultListType = 'segmi';
		//pageHeaderDeclaration
    }

    metaPage_convalida.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalida,
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-convalida_segmi");
				var arraydef = [];
				
				var dtconvalidante = this.state.DS.tables["convalidante"];
				if (dtconvalidante.rows.length === 0) {
					var metaconvalidante = appMeta.getMeta("convalidante");
					metaconvalidante.setDefaults(dtconvalidante);
					var defconvalidante = metaconvalidante.getNewRow(parentRow.getRow(), dtconvalidante, self.editType).then(
						function (currentRowconvalidante) {
							//defaultconvalidanteObject
							return true;
						}
					);
					arraydef.push(defconvalidante);
				}

				var dtconvalidato = this.state.DS.tables["convalidato"];
				if (dtconvalidato.rows.length === 0) {
					var metaconvalidato = appMeta.getMeta("convalidato");
					metaconvalidato.setDefaults(dtconvalidato);
					var defconvalidato = metaconvalidato.getNewRow(parentRow.getRow(), dtconvalidato, self.editType).then(
						function (currentRowconvalidato) {
							//defaultconvalidatoObject
							return true;
						}
					);
					arraydef.push(defconvalidato);
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

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.convalidante, "segmi", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("convalidante");
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.convalidato, "segmi", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("convalidato");
				appMeta.metaModel.insertFilter(this.getDataTable("convalidakinddefaultview"), this.q.eq('convalidakind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("changeskinddefaultview"), this.q.eq('changeskind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-convalida_segmi");
				$('#convalidato_segmi_idiscrizionebmi').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizionebmi);
				$('#convalidato_segmi_idiscrizionebmi').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idiscrizionebmi);
				$('#convalidato_segmi_idlearningagrstud').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idlearningagrstud);
				$('#convalidato_segmi_idlearningagrstud').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idlearningagrstud);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#convalidato_segmi_idiscrizionebmi').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione al bando di mobilità internazionale');
				}
				if (!$('#convalidato_segmi_idlearningagrstud').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Learning agreements for studies');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['convalidante', 'convalidato'],
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

	window.appMeta.addMetaPage('convalida', 'segmi', metaPage_convalida);

}());
