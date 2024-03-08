(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_costoscontodef() {
		MetaPage.apply(this, ['costoscontodef', 'default', false]);
        this.name = 'Costi';
		this.defaultListType = 'default';
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_costoscontodef.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodef,
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
				
				if (!parentRow.idcostoscontodefkind)
					parentRow.idcostoscontodefkind = 1;
				$("#XXfasciaiseedef").prop("disabled", !this.state.isEditState());
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-costoscontodef_default");
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
				$("#XXfasciaiseedef").prop("disabled", true);
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

			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXfasciaiseedef").length) {
					$("#XXfasciaiseedef").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			
			
			insertClick: function (that, grid) {
				if (this.state.isInsertState() && grid.dataSourceName === "costoscontodefdettaglio") {
					return this.showMessageOk("Devi prima salvare il costo, e creare gli oggetti: fascia isee, rata etc...");
				} else {
					return this.superClass.insertClick(that, grid);
				}
			},

			beforePost: function () {
				var def = appMeta.Deferred("afterRowSelect-costoscontodef");

				var r = this.state.currentRow;
				if (!r) return def.resolve();
				if (!r.getRow) return def.resolve();
				if (r.getRow().state !== jsDataSet.dataRowState.deleted) return def.resolve();

				// siamo nello stato deleted della riga principiale, forzo la cancellazione delle entità non subentità,che diepndono da questa didprog
				var self = this;
				var selBuilderArray = [];
				var tableArray = ["fasciaiseedef", "ratadef"];

				var idcostoscontodef = "idcostoscontodef";

				var iddidprog = this.state.currentRow[idcostoscontodef];
				var filter = window.jsDataQuery.eq(idcostoscontodef, iddidprog);

				// costruisco query
				_.forEach(tableArray, function (tname) {
					selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: self.state.DS.tables[tname] });
				});

				appMeta.getData.multiRunSelect(selBuilderArray)
					.then(function () {
						_.forEach(tableArray, function (tname) {
							var currTab = self.state.DS.tables[tname];
							_.forEach(currTab.rows, function (r) {
								// cancello solo le righe referenziate da questa didprog
								if (r[idcostoscontodef] === iddidprog) r.getRow().del();
							});
						});

						def.resolve();
					});

				return def.promise();
			},

			//buttons
        });

	window.appMeta.addMetaPage('costoscontodef', 'default', metaPage_costoscontodef);

}());
