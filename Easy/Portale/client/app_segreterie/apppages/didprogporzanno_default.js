
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

    function metaPage_didprogporzanno() {
		MetaPage.apply(this, ['didprogporzanno', 'default', true]);
        this.name = 'Porzione d\'anno';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprogporzanno.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprogporzanno,
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
				var def = appMeta.Deferred("afterGetFormData-didprogporzanno_default");
				var arraydef = [];
				
				arraydef.push(this.managedidprogporzanno_default_title());
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didprogporzanno_default");
				var arraydef = [];
				
				arraydef.push(this.managedidprogporzanno_default_title());
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

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			managedidprogporzanno_default_title: function () {
var def = appMeta.Deferred("beforeFill-managedidprogporzanno_title");     this.state.currentRow.title = this.state.currentRow.indice + " " + this.stringFromIdporzanno(this.state.currentRow.iddidprogporzannokind);     return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('didprogporzanno', 'default', metaPage_didprogporzanno);

}());
