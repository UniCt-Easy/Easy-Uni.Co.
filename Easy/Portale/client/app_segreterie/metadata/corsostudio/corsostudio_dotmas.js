
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

    function metaPage_corsostudio() {
		MetaPage.apply(this, ['corsostudio', 'dotmas', false]);
        this.name = 'Master';
		this.defaultListType = 'dotmas';
		//pageHeaderDeclaration
    }

    metaPage_corsostudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudio,
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
				var def = appMeta.Deferred("afterGetFormData-corsostudio_dotmas");
				var arraydef = [];
				
				arraydef.push(this.managedidprog_dotmas_title());
				arraydef.push(this.managedidprog_dotmas_title_en());
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
				
				if (!parentRow.idcorsostudiokind)
					parentRow.idcorsostudiokind = 2;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-corsostudio_dotmas");
				var arraydef = [];
				
				var dtdidprog = this.state.DS.tables["didprog"];
				if (dtdidprog.rows.length === 0) {
					var metadidprog = appMeta.getMeta("didprog");
					metadidprog.setDefaults(dtdidprog);
					var defdidprog = metadidprog.getNewRow(parentRow.getRow(), dtdidprog, self.editType).then(
						function (currentRowdidprog) {
							currentRowdidprog.current.iddidprogsuddannokind = 5;
							currentRowdidprog.current.idnation_lang = 1;
							currentRowdidprog.current.idnation_langvis = 1;
							currentRowdidprog.current.immatoltreauth = "S";
							//defaultdidprogObject
							return true;
						}
					);
					arraydef.push(defdidprog);
				}

				arraydef.push(this.managedidprog_dotmas_title());
				arraydef.push(this.managedidprog_dotmas_title_en());
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
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.didprog, "dotmas", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("didprog");
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar37').fullCalendar('rerenderEvents');
				});
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

			managedidprog_dotmas_title: function () {
				var def = appMeta.Deferred("beforeFill-managedidprog_title");
				var self = this;
				if (this.state.DS.tables.didprog)
					if (this.state.DS.tables.didprog.rows[0])
						this.state.DS.tables.didprog.rows[0].title = self.state.currentRow.title;
				return def.resolve();
			},

			managedidprog_dotmas_title_en: function () {
				var def = appMeta.Deferred("beforeFill-managedidprog_title_en");
				var self = this;
				if (this.state.DS.tables.didprog)
					if (this.state.DS.tables.didprog.rows[0])
						this.state.DS.tables.didprog.rows[0].title_en = self.state.currentRow.title_en;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('corsostudio', 'dotmas', metaPage_corsostudio);

}());
