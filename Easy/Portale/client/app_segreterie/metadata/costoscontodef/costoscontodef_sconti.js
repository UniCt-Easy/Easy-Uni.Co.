
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_costoscontodef() {
		MetaPage.apply(this, ['costoscontodef', 'sconti', false]);
        this.name = 'Sconti';
		this.defaultListType = 'sconti';
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
					parentRow.idcostoscontodefkind = 2;
				$("#XXfasciaiseedef").prop("disabled", !this.state.isEditState());
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-costoscontodef_sconti");
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
					return this.showMessageOk("Devi prima salvare lo sconto, e creare gli oggetti: fascia isee, rata etc...");
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

	window.appMeta.addMetaPage('costoscontodef', 'sconti', metaPage_costoscontodef);

}());
