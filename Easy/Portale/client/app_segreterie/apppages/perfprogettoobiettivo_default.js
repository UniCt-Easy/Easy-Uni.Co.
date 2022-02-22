
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

    function metaPage_perfprogettoobiettivo() {
		MetaPage.apply(this, ['perfprogettoobiettivo', 'default', true]);
        this.name = 'Obiettivi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivo,
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
				var def = appMeta.Deferred("afterGetFormData-perfprogettoobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettoobiettivo_default_completamento());
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
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivo_default");
				var arraydef = [];
				
				arraydef.push(this.insertSoglie());
				arraydef.push(this.manageperfprogettoobiettivo_default_completamento());
				var ctrlTree =  $('#perfprogettoobiettivoattivita_default_tree').data("customController");
					arraydef.push(ctrlTree.findAndSetRoot({
						rootTitle: 'Titolo: '+  (this.state.currentRow.title?  this.state.currentRow.title +'; ' : ''),
					   rootColumnNameTitle: 'title'
				}));
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
				this.enableControl($('#perfprogettoobiettivo_default_completamento'), false);
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

			 insertSoglie: function (prm) {

				 var year = new Date().getFullYear();
				 if (this.state.callerState.currentRow.datainizioeffettiva) {
					 year = this.state.callerState.currentRow.datainizioeffettiva.getFullYear();
				 }					 
				 else if (this.state.callerState.currentRow.datainizioprevista) {
					 year = this.state.callerState.currentRow.datainizioprevista.getFullYear();
				 }

				 var filterYear = window.jsDataQuery.eq('year', year);
				return this.superClass.insertSoglie({
					table: "perfprogettoobiettivosoglia", keyColumns: "idperfprogetto,idperfprogettoobiettivo", columnValueName: "percentuale", filter: filterYear
				});
			},

			manageperfprogettoobiettivo_default_completamento: function () {
				//campo calcolato
				var def = appMeta.Deferred("beforeFill-manageperfprogettoobiettivo_default_completamento");								
				this.state.currentRow.completamento = this.calculatePercTree(9999999).completamento;								
				def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoobiettivo', 'default', metaPage_perfprogettoobiettivo);

}());
