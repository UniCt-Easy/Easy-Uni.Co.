
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

    function metaPage_progettobudget() {
		MetaPage.apply(this, ['progettobudget', 'seg', true]);
        this.name = 'Categorie di costo o ricavo';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettobudget.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettobudget,
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
				var def = appMeta.Deferred("afterGetFormData-progettobudget_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettobudget_seg_budgetvariazione());
				arraydef.push(this.manageprogettobudget_seg_spese());
				arraydef.push(this.manageprogettobudget_seg_ricaviincassati());
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
				
				this.manageprogettobudget_seg_budgetvariazione();
				this.manageprogettobudget_seg_spese();
				this.manageprogettobudget_seg_ricaviincassati();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettobudget_seg");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettobudgetvariazione'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettocosto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettoricavo'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#progettobudget_seg_budgetvariazione'), false);
				this.enableControl($('#progettobudget_seg_spese'), false);
				this.enableControl($('#progettobudget_seg_ricaviincassati'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettobudgetvariazione'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettocosto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettoricavo'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto();
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettobudget_seg");
				$('#progettobudget_seg_idworkpackage').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettobudget_seg_idworkpackage').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#progettobudget_seg_idprogettotipocosto').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#progettobudget_seg_idprogettotipocosto').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#progettobudget_seg_idworkpackage').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				if (!$('#progettobudget_seg_idprogettotipocosto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Voce di costo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto: function () {
				var self = this;
				var filter = self.q.eq('idprogetto', self.state.callerState.currentRow.idprogetto);
				self.state.DS.tables.workpackagesegview.staticFilter(filter);
				self.state.DS.tables.progettotipocosto.staticFilter(filter);
			},

			manageprogettobudget_seg_budgetvariazione: function () {
				var progettobudgetvariazione = this.getDataTable('progettobudgetvariazione');
				var dateCurr = new Date(1900, 1, 1);
				_.forEach(progettobudgetvariazione.rows, function (rbv) {
					if (rbv.data > dateCurr && !!r.newamount && !!r.data) {
						rb["!budgetvariazione"] = r.newamount
					}
				});

			},

			manageprogettobudget_seg_spese: function () {
				var speseCtrl = $("[data-tag='progettobudget.!spese']");
				var self = this;
				speseCtrl.val(_.sumBy(this.state.callerState.DS.tables.progettocosto.rows, function (r) {
					if (r.idworkpackage === self.state.currentRow.idworkpackage && r.idprogettotipocosto === self.state.currentRow.idprogettotipocosto)
						return r.amount;
				}));
			},

			manageprogettobudget_seg_ricaviincassati: function () {
				var ricaviCtrl = $("[data-tag='progettobudget.!ricaviincassati']");
				var self = this;
				var tot = _.sumBy(this.state.callerState.DS.tables.progettoricavo.rows, function (r) {
					if (r.idworkpackage === self.state.currentRow.idworkpackage && r.idprogettotipocosto === self.state.currentRow.idprogettotipocosto)
						return r.amount;
				});
				ricaviCtrl.val(tot);

			},

			children: ['progettobudgetvariazione', 'progettocosto', 'progettoricavo'],
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

	window.appMeta.addMetaPage('progettobudget', 'seg', metaPage_progettobudget);

}());
