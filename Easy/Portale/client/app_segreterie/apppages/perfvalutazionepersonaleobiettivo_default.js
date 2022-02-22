
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

    function metaPage_perfvalutazionepersonaleobiettivo() {
		MetaPage.apply(this, ['perfvalutazionepersonaleobiettivo', 'default', true]);
        this.name = 'Obiettivi Individuali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonaleobiettivo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonaleobiettivo,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazionepersonaleobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazionepersonaleobiettivo_default_completamento());
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
				
				this.manageperfvalutazionepersonaleobiettivo_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazionepersonaleobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());				//beforeFillInside
				
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
            var valorenumericoCtrl = $('#perfvalutazionepersonaleobiettivo_default_valorenumerico');

            var completamentoCtrl = $('#perfvalutazionepersonaleobiettivo_default_completamento');
            this.registerFormula(completamentoCtrl, this.manageperfvalutazionepersonaleobiettivo_default_completamento.bind(this));
            this.addDependencies(valorenumericoCtrl, completamentoCtrl);
         },
 insertSoglie: function (prm) {

				var filterYear = window.jsDataQuery.eq('year', this.state.callerState.currentRow.year);

				var message = null;
				if (this.getDataTable("perfvalutazionepersonalesoglia").rows.length > 0) {
					message = false;
				}

				return this.superClass.insertSoglie({
					table: "perfvalutazionepersonalesoglia", tableSoglie: "perfsoglia", keyColumns: "idperfvalutazionepersonaleobiettivo,idperfvalutazionepersonale", columnValueName: "percentuale", filter: filterYear, desMessage: message
				});
			  },

			manageperfvalutazionepersonaleobiettivo_default_completamento: function () {
if (this.state.currentRow.valorenumerico !==undefined && this.state.currentRow.valorenumerico !== null) {
	var arrSoglieObiettivi = _.map(this.state.callerState.DS.tables["perfvalutazionepersonalesoglia"].rows, function (r) { return { indicatore: r.valorenumerico, soglia: r.percentuale} })            
               this.enableControl($('#perfvalutazionepersonaleobiettivo_default_completamento'), false);
               return this.calculateCompletamentoByValoreNumerico(arrSoglieObiettivi , this.state.currentRow.valorenumerico);
            }
	else this.enableControl($('#perfvalutazionepersonaleobiettivo_default_completamento'), true);
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazionepersonaleobiettivo', 'default', metaPage_perfvalutazionepersonaleobiettivo);

}());
