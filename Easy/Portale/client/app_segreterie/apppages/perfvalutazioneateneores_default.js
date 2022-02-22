
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

    function metaPage_perfvalutazioneateneores() {
		MetaPage.apply(this, ['perfvalutazioneateneores', 'default', true]);
        this.name = 'Risultati della performance istituzionale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneateneores.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneateneores,
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
				
				var loggato = this.sec.usr('idreg');
				//se l'utente loggato  è il compilatore disabilito tutti i campi a meno di fonte e percentuale raggiunta
				if (loggato == this.state.currentRow.idreg) {
					self.enableAllParentRowControl(parentRow,this.state.DS.name, false);
					self.enableControl($('#perfvalutazioneateneores_default_percentualeraggiunta'), true);
					self.enableControl($('#perfvalutazioneateneores_default_fonte'), true);					
					}	
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneateneores_default");
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

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfvalutazioneateneores_default");
				$('#perfvalutazioneateneores_default_idperfmission').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazioneateneores_default_idperfmission').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazioneateneores_default_idperfmission').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Missione istituzionale');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['perfvalutazioneateneoresvalidatori'],
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

	window.appMeta.addMetaPage('perfvalutazioneateneores', 'default', metaPage_perfvalutazioneateneores);

}());
