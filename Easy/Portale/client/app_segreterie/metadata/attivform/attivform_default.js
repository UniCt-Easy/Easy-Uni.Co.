
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

    function metaPage_attivform() {
		MetaPage.apply(this, ['attivform', 'default', true]);
        this.name = 'Attività formative';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_attivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivform,
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
				var def = appMeta.Deferred("afterGetFormData-attivform_default");
				var arraydef = [];
				
				arraydef.push(this.manageattivform_default_title());
				arraydef.push(this.manageattivform_default_idsede());
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
				
				this.manageattivform_default_idsede();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-attivform_default");
				var arraydef = [];
				
				arraydef.push(this.manageattivform_default_title());
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformproped'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('canale'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformproped'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('canale'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.didprogcurr.staticFilter(window.jsDataQuery.eq("iddidprog", this.state.callerState.currentRow.iddidprog));
				var grid_attivformcaratteristica_defaultChildsTables = [
					{ tablename: 'attivformcaratteristicaora', edittype: 'default', columnlookup: 'idorakind', columncalc: '!attivformcaratteristicaora'},
				];
				$('#grid_attivformcaratteristica_default').data('childtables', grid_attivformcaratteristica_defaultChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-attivform_default");
				if (t.name === "insegndefaultview" && r !== null) {
					this.state.DS.tables.insegnintegdefaultview.staticFilter(window.jsDataQuery.eq("idinsegn", r.idinsegn));
					if (this.state.DS.tables.insegnintegdefaultview.rows.length)
						if (this.state.DS.tables.insegnintegdefaultview.rows[0].idinsegn !== r.idinsegn) {
							this.state.DS.tables.insegnintegdefaultview.clear();
							$('#attivform_default_idinsegninteg').val('');
						}
				}
				$('#attivform_default_iddidprogcurr').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidprogcurr').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidprogori').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidprogori').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidproganno').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidproganno').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidprogporzanno').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#attivform_default_iddidprogporzanno').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#attivform_default_iddidprogcurr').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Curriculum');
				}
				if (!$('#attivform_default_iddidprogori').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Orientamento');
				}
				if (!$('#attivform_default_iddidproganno').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno di corso');
				}
				if (!$('#attivform_default_iddidprogporzanno').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Porzione d\'anno');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			manageattivform_default_title: function () {
				var def = appMeta.Deferred("beforeFill-manageattivform_title");
				var self = this;

				var insegnamento = _.find(this.state.DS.tables.insegndefaultview.rows, function (row) {
					return row.idinsegn === self.state.currentRow.idinsegn;
				});
				var modulo = _.find(this.state.DS.tables.insegninteg.rows, function (row) {
					return row.idinsegninteg === self.state.currentRow.idinsegninteg;
				});
				this.state.currentRow.title =
					(insegnamento ? insegnamento.dropdown_title.trim() : "") +
					(modulo ? "; Modulo: " + modulo.denominazione : "");

				var annocorso = _.find(this.state.DS.tables.didprogannodefaultview.rows, function (row) {
					return row.iddidproganno === self.state.currentRow.iddidproganno;
				});
				if (annocorso)
					this.state.currentRow.aa = annocorso.aa;

				return def.resolve();
			},

			manageattivform_default_idsede: function () {
				this.state.currentRow.idsede = this.state.callerState.currentRow.idsede;

			},

			children: ['attivformcaratteristica', 'attivformproped', 'canale'],
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

	window.appMeta.addMetaPage('attivform', 'default', metaPage_attivform);

}());
