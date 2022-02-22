
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

    function metaPage_progettostatuskind() {
		MetaPage.apply(this, ['progettostatuskind', 'default', false]);
        this.name = 'Stati delle attività o progetti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettostatuskind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettostatuskind,
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
				
				if (!parentRow.contributo)
					parentRow.contributo = 'S';
				if (!parentRow.contributoente)
					parentRow.contributoente = 'S';
				if (!parentRow.contributoenterichiesto)
					parentRow.contributoenterichiesto = 'S';
				if (!parentRow.contributorichiesto)
					parentRow.contributorichiesto = 'S';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettostatuskind_default");
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

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('progettostatuskind', 'default', metaPage_progettostatuskind);

}());
