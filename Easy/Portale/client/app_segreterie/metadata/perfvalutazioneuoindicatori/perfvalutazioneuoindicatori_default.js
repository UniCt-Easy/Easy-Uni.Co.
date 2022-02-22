
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

    function metaPage_perfvalutazioneuoindicatori() {
		MetaPage.apply(this, ['perfvalutazioneuoindicatori', 'default', true]);
        this.name = 'Indicatori operativi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneuoindicatori.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneuoindicatori,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazioneuoindicatori_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazioneuoindicatori_default_completamento());
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
				
				this.manageperfvalutazioneuoindicatori_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneuoindicatori_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuoindicatori'), this.getDataTable('perfvalutazioneuoindicatorisoglia'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuoindicatori'), this.getDataTable('perfvalutazioneuoindicatorisoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.configureDependencies();
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

			configureDependencies: function () {
            var valorenumericoCtrl = $('#perfvalutazioneuoindicatori_default_valorenumerico');

            var completamentoCtrl = $('#perfvalutazioneuoindicatori_default_completamento');
            this.registerFormula(completamentoCtrl, this.manageperfvalutazioneuoindicatori_default_completamento.bind(this));
            this.addDependencies(valorenumericoCtrl, completamentoCtrl);
         },

			manageperfvalutazioneuoindicatori_default_completamento: function () {
if (this.state.currentRow.valorenumerico !==undefined && this.state.currentRow.valorenumerico !== null) {
	var arrSoglieIndicatori = _.map(this.state.callerState.DS.tables["perfvalutazioneuoindicatorisoglia"].rows, function (r) { return { indicatore: r.valorenumerico, soglia: r.valore } })            
               this.enableControl($('#perfvalutazioneuoindicatori_default_completamento'), false);
               return this.calculateCompletamentoByValoreNumerico(arrSoglieIndicatori, this.state.currentRow.valorenumerico);
            }
	else this.enableControl($('#perfvalutazioneuoindicatori_default_completamento'), true);
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazioneuoindicatori', 'default', metaPage_perfvalutazioneuoindicatori);

}());
