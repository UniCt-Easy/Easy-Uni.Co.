
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

    function metaPage_tirociniocandidatura() {
		MetaPage.apply(this, ['tirociniocandidatura', 'seg', true]);
        this.name = 'Candidature';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tirociniocandidatura.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirociniocandidatura,
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
					this.helpForm.filter($('#tirociniocandidatura_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#tirociniocandidatura_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#tirociniocandidatura_seg_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#tirociniocandidatura_seg_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-tirociniocandidatura_seg");
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
				this.helpForm.filter($('#tirociniocandidatura_seg_idreg_studenti'), null);
				this.helpForm.filter($('#tirociniocandidatura_seg_idreg_docenti'), null);
				//afterClearin
			},

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-tirociniocandidatura_seg");
				$('#tirociniocandidatura_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#tirociniocandidatura_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#tirociniocandidatura_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['tirocinioprogetto'],
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

	window.appMeta.addMetaPage('tirociniocandidatura', 'seg', metaPage_tirociniocandidatura);

}());
