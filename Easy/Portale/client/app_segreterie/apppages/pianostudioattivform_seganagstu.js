
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

    function metaPage_pianostudioattivform() {
		MetaPage.apply(this, ['pianostudioattivform', 'seganagstu', true]);
        this.name = 'Attività formative pianificate';
		this.defaultListType = 'seganagstu';
		//pageHeaderDeclaration
    }

    metaPage_pianostudioattivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudioattivform,
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
				var def = appMeta.Deferred("afterGetFormData-pianostudioattivform_seganagstu");
				var arraydef = [];
				
				arraydef.push(this.managepianostudioattivform_seganagstu_idcorsostudio());
				arraydef.push(this.managepianostudioattivform_seganagstu_iddidprog());
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
				var def = appMeta.Deferred("beforeFill-pianostudioattivform_seganagstu");
				var arraydef = [];
				
				arraydef.push(this.managepianostudioattivform_seganagstu_idcorsostudio());
				arraydef.push(this.managepianostudioattivform_seganagstu_iddidprog());
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

			afterFill: function () {
				this.enableControl($('#pianostudioattivform_seganagstu_idsostenimento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			managepianostudioattivform_seganagstu_idcorsostudio: function () {
this.state.currentRow.idcorsostudio = this.state.callerState.currentRow.idcorsostudio
			},

			managepianostudioattivform_seganagstu_iddidprog: function () {
this.state.currentRow.iddidprog= this.state.callerState.currentRow.iddidprog
			},

			//buttons
        });

	window.appMeta.addMetaPage('pianostudioattivform', 'seganagstu', metaPage_pianostudioattivform);

}());
