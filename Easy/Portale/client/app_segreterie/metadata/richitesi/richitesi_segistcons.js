
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

    function metaPage_richitesi() {
		MetaPage.apply(this, ['richitesi', 'segistcons', true]);
        this.name = 'Richiesta di Tesi';
		this.defaultListType = 'segistcons';
		//pageHeaderDeclaration
    }

    metaPage_richitesi.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_richitesi,
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
				
				if (!parentRow.accettata)
					parentRow.accettata = 'N';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-richitesi_segistcons");
				var arraydef = [];
				
				var dttesi = this.state.DS.tables["tesi"];
				if (dttesi.rows.length === 0) {
					var metatesi = appMeta.getMeta("tesi");
					metatesi.setDefaults(dttesi);
					var deftesi = metatesi.getNewRow(parentRow.getRow(), dttesi, self.editType).then(
						function (currentRowtesi) {
							//defaulttesiObject
							return true;
						}
					);
					arraydef.push(deftesi);
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
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.tesi, "segistcons", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("tesi");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-richitesi_segistcons");
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.registrydefaultview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.registrydefaultview.rows.length)
						if (this.state.DS.tables.registrydefaultview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.registrydefaultview.clear();
							$('#richitesi_segistcons_idreg').val('');
						}
				}
				$('#richitesi_segistcons_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#richitesi_segistcons_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#richitesi_segistcons_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['tesi', 'tesikeyword'],
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

	window.appMeta.addMetaPage('richitesi', 'segistcons', metaPage_richitesi);

}());
