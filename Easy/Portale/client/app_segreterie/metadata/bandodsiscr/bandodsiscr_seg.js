(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsiscr() {
		MetaPage.apply(this, ['bandodsiscr', 'seg', true]);
        this.name = 'Iscrizioni';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsiscr.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsiscr,
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
				var def = appMeta.Deferred("beforeFill-bandodsiscr_seg");
				var arraydef = [];
				
				var dtbandodsiscresito = this.state.DS.tables["bandodsiscresito"];
				if (dtbandodsiscresito.rows.length === 0) {
					var metabandodsiscresito = appMeta.getMeta("bandodsiscresito");
					metabandodsiscresito.setDefaults(dtbandodsiscresito);
					var defbandodsiscresito = metabandodsiscresito.getNewRow(parentRow.getRow(), dtbandodsiscresito, self.editType).then(
						function (currentRowbandodsiscresito) {
							//defaultbandodsiscresitoObject
							return true;
						}
					);
					arraydef.push(defbandodsiscresito);
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
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.bandodsiscresito, "seg", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("bandodsiscresito");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-bandodsiscr_seg");
				$('#bandodsiscr_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandodsiscr_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandodsiscr_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['bandodsiscresito'],
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

	window.appMeta.addMetaPage('bandodsiscr', 'seg', metaPage_bandodsiscr);

}());
