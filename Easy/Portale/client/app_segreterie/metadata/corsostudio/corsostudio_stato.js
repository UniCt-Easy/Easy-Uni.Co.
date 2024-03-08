(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_corsostudio() {
		MetaPage.apply(this, ['corsostudio', 'stato', false]);
        this.name = 'Esami di stato';
		this.defaultListType = 'stato';
		//pageHeaderDeclaration
    }

    metaPage_corsostudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudio,
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
				var def = appMeta.Deferred("afterGetFormData-corsostudio_stato");
				var arraydef = [];
				
				arraydef.push(this.managedidprog_stato_title());
				arraydef.push(this.managedidprog_stato_title_en());
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
				
				if (!parentRow.idcorsostudiokind)
					parentRow.idcorsostudiokind = 13;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-corsostudio_stato");
				var arraydef = [];
				
				var dtdidprog = this.state.DS.tables["didprog"];
				if (dtdidprog.rows.length === 0) {
					var metadidprog = appMeta.getMeta("didprog");
					metadidprog.setDefaults(dtdidprog);
					var defdidprog = metadidprog.getNewRow(parentRow.getRow(), dtdidprog, self.editType).then(
						function (currentRowdidprog) {
							currentRowdidprog.current.iddidprogsuddannokind = 5;
							currentRowdidprog.current.immatoltreauth = "S";
							//defaultdidprogObject
							return true;
						}
					);
					arraydef.push(defdidprog);
				}

				arraydef.push(this.managedidprog_stato_title());
				arraydef.push(this.managedidprog_stato_title_en());
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
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.didprog, "stato", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("didprog");
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar35').fullCalendar('rerenderEvents');
				});
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			managedidprog_stato_title: function () {
				var def = appMeta.Deferred("beforeFill-managedidprog_title");
				var self = this;
				if (this.state.DS.tables.didprog)
					if (this.state.DS.tables.didprog.rows[0])
						this.state.DS.tables.didprog.rows[0].title = self.state.currentRow.title;
				return def.resolve();
			},

			managedidprog_stato_title_en: function () {
				var def = appMeta.Deferred("beforeFill-managedidprog_title_en");
				var self = this;
				if (this.state.DS.tables.didprog)
					if (this.state.DS.tables.didprog.rows[0])
						this.state.DS.tables.didprog.rows[0].title_en = self.state.currentRow.title_en;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('corsostudio', 'stato', metaPage_corsostudio);

}());
