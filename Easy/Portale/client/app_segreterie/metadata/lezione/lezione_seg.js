
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

    function metaPage_lezione() {
		MetaPage.apply(this, ['lezione', 'seg', true]);
        this.name = 'Lezioni';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_lezione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_lezione,
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
				var def = appMeta.Deferred("afterGetFormData-lezione_seg");
				var arraydef = [];
				
				arraydef.push(this.managelezione_seg_title());
				arraydef.push(this.managelezione_seg_idreg_docenti());
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
				
				if (!parentRow.idsede || parentRow.idsede == 0)
					parentRow.idsede = this.state.callerState.currentRow.idsede;
				if (!parentRow.nonsvolta)
					parentRow.nonsvolta = "N";
				if (!parentRow.stage)
					parentRow.stage = "N";
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
				if (!parentRow.visita)
					parentRow.visita = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-lezione_seg");
				var arraydef = [];
				
				arraydef.push(this.managelezione_seg_title());
				arraydef.push(this.managelezione_seg_idreg_docenti());
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

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-lezione_seg");
				$('#lezione_seg_idedificio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_seg_idedificio').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#lezione_seg_idaula').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_seg_idaula').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#lezione_seg_idedificio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Edificio');
				}
				if (!$('#lezione_seg_idaula').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Aula');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			managelezione_seg_title: function () {
				var def = appMeta.Deferred("beforeFill-managelezione_title");
				var self = this;
				var affidamentolezione = _.find(this.state.DS.tables.affidamento.rows, function (row) {
					return row.idaffidamento === self.state.currentRow.idaffidamento;
				});
				this.state.currentRow["!title"] = affidamentolezione.title;
				return def.resolve();

			},

			managelezione_seg_idreg_docenti: function () {
     var def = appMeta.Deferred("beforeFill-managelezione_idreg_docenti");
     var self = this;
     var affidamentolezione = _.find(this.state.DS.tables.affidamento.rows, function (row) {
      return row.idaffidamento === self.state.currentRow.idaffidamento;
     });
     this.state.currentRow.idreg_docenti = affidamentolezione.idreg_docenti;
     return def.resolve(); 
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

	window.appMeta.addMetaPage('lezione', 'seg', metaPage_lezione);

}());
