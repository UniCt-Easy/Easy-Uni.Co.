(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontaltro() {
		MetaPage.apply(this, ['rendicontaltro', 'docente', true]);
        this.name = 'Registro delle attività oltre le lezioni';
		this.defaultListType = 'docente';
		//pageHeaderDeclaration
    }

    metaPage_rendicontaltro.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontaltro,
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
				
				if (this.isNull(parentRow.aa) || parentRow.aa == '')
					parentRow.aa = this.getAcademicYear(new Date(), 'A');
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontaltro_docente");
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

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("rendicontaltrokinddefaultview"), this.q.eq('rendicontaltrokind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicontaltro_docente");
				$('#rendicontaltro_docente_aa').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#rendicontaltro_docente_aa').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#rendicontaltro_docente_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno accademico della rendicontazione');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: [''],
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

	window.appMeta.addMetaPage('rendicontaltro', 'docente', metaPage_rendicontaltro);

}());
