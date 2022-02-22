
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

    function metaPage_progettokind() {
		MetaPage.apply(this, ['progettokind', 'seg', false]);
        this.name = 'Modello/Template di progetto o attività';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettokind,
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
				
				if (!parentRow.idcorsostudio)
					parentRow.idcorsostudio = "N";
				if (!parentRow.stipendioannoprec)
					parentRow.stipendioannoprec = "N";
				if (!parentRow.stipendiocomericavo)
					parentRow.stipendiocomericavo = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettokind_seg");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettoattachkind'), this.getDataTable('progettoattachkindprogettostatuskind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotestokind'), this.getDataTable('progettotestokindprogettostatuskind'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettoattachkind'), this.getDataTable('progettoattachkindprogettostatuskind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotestokind'), this.getDataTable('progettotestokindprogettostatuskind'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('progettokind', 'seg', metaPage_progettokind);

}());
