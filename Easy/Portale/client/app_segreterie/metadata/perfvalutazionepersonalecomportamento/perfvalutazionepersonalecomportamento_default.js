
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

    function metaPage_perfvalutazionepersonalecomportamento() {
		MetaPage.apply(this, ['perfvalutazionepersonalecomportamento', 'default', true]);
        this.name = 'Comportamenti Attesi ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonalecomportamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonalecomportamento,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazionepersonalecomportamento_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazionepersonalecomportamento_default_completamento());
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
				
				this.manageperfvalutazionepersonalecomportamento_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazionepersonalecomportamento_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
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

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-perfvalutazionepersonalecomportamento_default");
				$('#perfvalutazionepersonalecomportamento_default_idperfcomportamento').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazionepersonalecomportamento_default_idperfcomportamento').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazionepersonalecomportamento_default_idperfcomportamento').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Comportamento');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			configureDependencies: function () {
            var valorenumericoCtrl = $('#perfvalutazionepersonalecomportamento_default_valorenumerico');

            var completamentoCtrl = $('#perfvalutazionepersonalecomportamento_default_completamento');
            this.registerFormula(completamentoCtrl, this.manageperfvalutazionepersonalecomportamento_default_completamento.bind(this));
            this.addDependencies(valorenumericoCtrl, completamentoCtrl);
         },

			manageperfvalutazionepersonalecomportamento_default_completamento: function () {
if (this.state.currentRow.valorenumerico !==undefined && this.state.currentRow.valorenumerico !== null) {
	var arrSoglieComportamento = _.map(this.state.callerState.DS.tables["perfvalutazionepersonalecomportamentosoglia"].rows, function (r) { return { indicatore: r.valorenumerico, soglia: r.valore } })            
               this.enableControl($('#perfvalutazionepersonalecomportamento_default_completamento'), false);
               return this.calculateCompletamentoByValoreNumerico(arrSoglieComportamento, this.state.currentRow.valorenumerico);
            }
	else this.enableControl($('#perfvalutazionepersonalecomportamento_default_completamento'), true);
			},

			children: ['perfvalutazionepersonalecomportamentosoglia'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazionepersonalecomportamento', 'default', metaPage_perfvalutazionepersonalecomportamento);

}());
