
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

    function metaPage_cefrlanglevel() {
		MetaPage.apply(this, ['cefrlanglevel', 'accordoscambiomidettlang', true]);
        this.name = 'Livello richiesto per le lingue';
		this.defaultListType = 'accordoscambiomidettlang';
		//pageHeaderDeclaration
    }

    metaPage_cefrlanglevel.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_cefrlanglevel,
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
				
				if (!parentRow.idaccordoscambiomidettlangkind)
					parentRow.idaccordoscambiomidettlangkind = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-cefrlanglevel_accordoscambiomidettlang");
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

			afterLink: function () {
				var self = this;
				this.setDenyNull("cefrlanglevel","idaccordoscambiomi");
				this.setDenyNull("cefrlanglevel","idaccordoscambiomidett");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('cefrlanglevel', 'accordoscambiomidettlang', metaPage_cefrlanglevel);

}());