
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

    function metaPage_progettoasset() {
		MetaPage.apply(this, ['progettoasset', 'default', true]);
        this.name = 'Beni strumentali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettoasset.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoasset,
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
				
				if (!parentRow['!altreupb'])
					parentRow['!altreupb'] = 'S';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettoasset_default");
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

			afterFill: function () {
				this.enableControl($('#progettoasset_default_ammortamento'), false);
				this.enableControl($('#progettoasset_default_ammortamentopreventivato'), false);
				this.enableControl($('#progettoasset_default_descammortamentopreventivato'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#progettoasset_default_start').on("change", _.partial(this.managestart, self));
				$('#progettoasset_default_stop').on("change", _.partial(this.managestop, self));
				$('#progettoasset_default_altreupb').on("change", _.partial(this.managealtreupb, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(self.setFilterOnClassificazioneInventariale());
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettoasset_default");
				$('#progettoasset_default_idpiece').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettoasset_default_idpiece').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettoasset_default_idpiece').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Bene strumentale');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			setFilterOnClassificazioneInventariale: function() {
				// filtro sui beni strumentali che afferiscono alla classificazione inventariale delle voci di costo
				/*
					assetsegview where inventorytree_codeinv is in (
					select codeinv from inventorytree where idinv in (
					select idinv  from datasetparent.progettotipocostoinventorytree.idinv))
				*/

				// 1. select idinv  from datasetparent.progettotipocostoinventorytree.idinv)
				var def = appMeta.Deferred("setFilterOnClassificazioneInventariale-progettoasset_default");
				var self = window.appMeta.currentMetaPage;
				var arrayIdInv = _.map(self.state.callerState.DS.tables.progettotipocostoinventorytree.rows,
					function(r) {return r.idinv;});
				var filterInventoryTree = self.q.isIn("idinv", arrayIdInv);

				// 2. select codeinv from inventorytree where idinv in
				return appMeta.getData.runSelect("inventorytree", "codeinv", filterInventoryTree, null)
					.then(function (dtInventorytree) {
						var arrayCodeinv = _.map(dtInventorytree.rows, function (r) { return r.codeinv; });

						// 3. assetsegview where inventorytree_codeinv is in
						var filter = self.q.isIn("inventorytree_codeinv", arrayCodeinv);
						//4 . se è spuntato altreupb allora basta così altrimenti filtro anche sulle upb dell progetto
						if (!$('#progettoasset_default_altreupb').is(':checked') && self.state.currentRow) {
							var upbs = _.map(self.state.callerState.DS.tables.workpackageupb.rows, function (r) { return r.idupb; });
							filter = window.jsDataQuery.and([filter, window.jsDataQuery.isIn("upb_idupb", upbs)]);
						}

						self.state.DS.tables.assetsegview.staticFilter(filter);
						return def.resolve();
					});
			},

			calculateAmmortamento: function (that) {
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				that.getFormData(true).then(function () {

					if (that.state.currentRow.start && that.state.currentRow.stop &&
						that.state.currentRow.idasset && that.state.currentRow.idpiece) {
						appMeta.getData.launchCustomServerMethod("callSP", {
							spname: "get_asset_ammortization_by_date",
							prm1: appMeta.customUtils.getSQLStringFromDateTime(that.state.currentRow.start),
							prm2: appMeta.customUtils.getSQLStringFromDateTime(that.state.currentRow.stop),
							prm3: that.state.currentRow.idasset,
							prm4: that.state.currentRow.idpiece
						}).then(function (res) {
							var msg = "";
							if (res.err) {
								msg = "KO " + res.err;
							}
							else {
								msg = "OK. L'ammortamento preventivato è stato aggiornato";
								var ds = appMeta.getDataUtils.getJsDataSetFromJson(res.ds);
								if (ds.tables['Table']) {
									that.state.currentRow.ammortamentopreventivato = ds.tables['Table'].rows[0].valoreammortizzato;
									that.state.currentRow.descammortamentopreventivato = ds.tables['Table'].rows[0].descrizione;
									$('#progettoasset_default_ammortamentopreventivato').val(ds.tables['Table'].rows[0].valoreammortizzato);
									$('#progettoasset_default_descammortamentopreventivato').val(ds.tables['Table'].rows[0].descrizione);
								}
								else {
									msg = "KO. Il sistema non è riuscito a calcolare la quota di ammortamento. Verificare i dati inseriti.";
								}
							}
							that.hideWaitingIndicator(waitingHandler);
							that.showMessageOk(msg);
						});
					} else {
						that.hideWaitingIndicator(waitingHandler);
					}
				});
			},

			managestart: function(that) { 
				that.calculateAmmortamento(that);

			},

			managestop: function(that) { 
				that.calculateAmmortamento(that);

			},

			managealtreupb: function(that) { 
				that.setFilterOnClassificazioneInventariale();
			},

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

	window.appMeta.addMetaPage('progettoasset', 'default', metaPage_progettoasset);

}());
