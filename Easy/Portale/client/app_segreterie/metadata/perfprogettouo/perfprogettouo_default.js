
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

    function metaPage_perfprogettouo() {
		MetaPage.apply(this, ['perfprogettouo', 'default', true]);
        this.name = 'Unità organizzative';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_perfprogettouo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettouo,
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
				var def = appMeta.Deferred("afterGetFormData-perfprogettouo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettouo_default_struttura());
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
				var def = appMeta.Deferred("beforeFill-perfprogettouo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettouo_default_struttura());
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
				this.enableControl($('#perfprogettouo_default_struttura'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_perfprogettouomembro_idreg").on("click", _.partial(this.searchAndAssigngetregistrydocentiamministrativi, self));
				$("#btn_add_perfprogettouomembro_idreg").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_perfprogettouomembro_idreg").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_perfprogettouomembro_idreg").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssigngetregistrydocentiamministrativi: function (that) {
				return that.searchAndAssign({
					tableName: "getregistrydocentiamministrativi",
					listType: "default",
					idControl: "txt_perfprogettouomembro_idreg",
					tagSearch: "getregistrydocentiamministratividefaultview.dropdown_title",
					columnNameText: "surname",
					columnSource: "idreg",
					columnToFill: "idreg",
					tableToFill: "perfprogettouomembro"
				});
			},

			manageperfprogettouo_default_struttura: function () {
           //campo calcolato
            var self = this;
            var arr = [];
            var def = appMeta.Deferred("manageperfprogettouo_default_struttura");

            self.state.currentRow['!struttura'] = "";

            _.forEach(self.getDataTable('getregistrydocentiamministrativi').rows, function (rudrmembro) {
               if (!arr.includes(rudrmembro.struttura) && !!rudrmembro.struttura) {
                  arr.push(rudrmembro.struttura);
               }
            });
            self.state.currentRow['!struttura'] = arr.join('; ');
            return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettouo', 'default', metaPage_perfprogettouo);

}());
