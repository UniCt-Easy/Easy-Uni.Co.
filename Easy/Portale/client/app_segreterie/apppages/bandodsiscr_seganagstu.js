
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function metaPage_bandodsiscr() {
		MetaPage.apply(this, ['bandodsiscr', 'seganagstu', true]);
        this.name = 'Iscrizioni ai bandi per il diritto allo studio';
		this.defaultListType = 'seganagstu';
		//pageHeaderDeclaration
    }

    metaPage_bandodsiscr.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsiscr,
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-bandodsiscr_seganagstu");
				var arraydef = [];
				
				var dtbandodsiscresito = this.state.DS.tables["bandodsiscresito"];
				if (dtbandodsiscresito.rows.length === 0) {
					var metabandodsiscresito = appMeta.getMeta("bandodsiscresito");
					metabandodsiscresito.setDefaults(dtbandodsiscresito);
					var defbandodsiscresito = metabandodsiscresito.getNewRow(parentRow.getRow(), dtbandodsiscresito, self.editType).then(
						function (currentRowbandodsiscresito) {
							//defaultbandodsiscresitoObject
							return true;
						}
					);
					arraydef.push(defbandodsiscresito);
				}

				//beforeFillInside

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
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.bandodsiscresito, "seganagstu", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("bandodsiscresito");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-bandodsiscr_seganagstu");
				$('#bandodsiscr_seganagstu_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandodsiscr_seganagstu_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandodsiscr_seganagstu_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			children: ['bandodsiscresito'],
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

	window.appMeta.addMetaPage('bandodsiscr', 'seganagstu', metaPage_bandodsiscr);

}());