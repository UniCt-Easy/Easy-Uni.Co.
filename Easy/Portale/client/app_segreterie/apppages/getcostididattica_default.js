
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

    function metaPage_getcostididattica() {
		MetaPage.apply(this, ['getcostididattica', 'default', false]);
        this.name = 'Riepilogo dei costi degli affidamenti';
		this.defaultListType = 'default';
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canSave = false;
		this.canCancel = false;
		this.canShowLast = false;
		//pageHeaderDeclaration
    }

    metaPage_getcostididattica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_getcostididattica,
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
					this.helpForm.filter($('#getcostididattica_default_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#getcostididattica_default_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-getcostididattica_default");
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
				this.helpForm.filter($('#getcostididattica_default_idreg_docenti'), null);
				//afterClearin
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("getcostididattica","idcorsostudio");
				this.setDenyNull("getcostididattica","idsede");
				this.setDenyNull("getcostididattica","aa");
				this.setDenyNull("getcostididattica","iddidprog");
				this.setDenyNull("getcostididattica","iddidprogcurr");
				this.setDenyNull("getcostididattica","idaffidamento");
				this.setDenyNull("getcostididattica","idcontrattokind");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-getcostididattica_default");
				$('#getcostididattica_default_idcorsostudio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_idcorsostudio').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_idsede').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_idsede').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_aa').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_aa').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "corsostudiodefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("idcorsostudio", r.idcorsostudio));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].idcorsostudio !== r.idcorsostudio) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#getcostididattica_default_iddidprog').val('');
						}
				}
				$('#getcostididattica_default_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "didprogdefaultview" && r !== null) {
					this.state.DS.tables.didprogcurr.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.didprogcurr.rows.length)
						if (this.state.DS.tables.didprogcurr.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.didprogcurr.clear();
							$('#getcostididattica_default_iddidprogcurr').val('');
						}
				}
				$('#getcostididattica_default_iddidprogcurr').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_iddidprogcurr').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_idcontrattokind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#getcostididattica_default_idcontrattokind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#getcostididattica_default_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studio');
				}
				if (!$('#getcostididattica_default_idsede').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Sede');
				}
				if (!$('#getcostididattica_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo AA erogata');
				}
				if (!$('#getcostididattica_default_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				if (!$('#getcostididattica_default_iddidprogcurr').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Curriculum');
				}
				if (!$('#getcostididattica_default_idcontrattokind').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ruolo');
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

	window.appMeta.addMetaPage('getcostididattica', 'default', metaPage_getcostididattica);

}());
