
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

    function metaPage_progettoudrmembro() {
		MetaPage.apply(this, ['progettoudrmembro', 'seg', true]);
        this.name = 'Membri';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettoudrmembro.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoudrmembro,
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
				var def = appMeta.Deferred("afterGetFormData-progettoudrmembro_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettoudrmembro_seg_orerendicontate());
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
				var def = appMeta.Deferred("beforeFill-progettoudrmembro_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettoudrmembro_seg_orerendicontate());
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
				this.enableControl($('#progettoudrmembro_seg_orerendicontate'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("progettoudrmembro","idreg");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettoudrmembro_seg");
				if (t.name === "getregistrydocentiamministrativi" && r !== null) {
					this.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.getregistrydocentiamministratividefaultview.rows.length)
						if (this.state.DS.tables.getregistrydocentiamministratividefaultview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.getregistrydocentiamministratividefaultview.clear();
							$('#progettoudrmembro_seg_idreg').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			manageprogettoudrmembro_seg_orerendicontate: function () {
				var def = appMeta.Deferred("manageorerendicontate-progettoudrmembro_seg");
				var projectPage = appMeta.currentMetaPage.state.callerState.callerPage;
				var membroRow = appMeta.currentMetaPage.state.currentRow;
				var q = appMeta.currentMetaPage.q;
				if (membroRow.idreg) {
					var rendicontattivitaprogettoRows = projectPage.getDataTable("rendicontattivitaprogetto")
						.select(q.eq("idreg", membroRow.idreg));
					if (rendicontattivitaprogettoRows.length > 0) {
						var rendicontattivitaprogettooraRows = projectPage.getDataTable("rendicontattivitaprogettoora")
							.select(q.isIn("idrendicontattivitaprogetto", _.map(
								rendicontattivitaprogettoRows, function (row) {
									return row.idrendicontattivitaprogetto;
								})));
						if (rendicontattivitaprogettooraRows.length > 0) {
							membroRow['!orerendicontate'] = _.sumBy(rendicontattivitaprogettooraRows, function (r) {
								if (r.ore) return r.ore;
								return 0;
							});
						}
					}
				}
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettoudrmembro', 'seg', metaPage_progettoudrmembro);

}());
