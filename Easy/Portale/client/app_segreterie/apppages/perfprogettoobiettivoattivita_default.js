
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

    function metaPage_perfprogettoobiettivoattivita() {
		MetaPage.apply(this, ['perfprogettoobiettivoattivita', 'default', true]);
        this.name = 'Attività';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivoattivita.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivoattivita,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_perfprogettoobiettivoattivita");
				var firstErrorObj;

                if (this.getChildren("perfprogettoobiettivoattivita", rowToCheck.current.idperfprogettoobiettivoattivita, "paridperfprogettoobiettivoattivita", true).length == 0) {
               if (!rowToCheck.current.datainizioprevista)
                  firstErrorObj = { warningMsg: "", errMsg: "Prima devi inserire una data inizio prevista", errField: "datainizioprevista", row: rowToCheck };
               else if (!rowToCheck.current.datafineprevista)
                  firstErrorObj = { warningMsg: "", errMsg: "Prima devi inserire una data  fine prevista", errField: "datafineprevista", row: rowToCheck };
            }
             

            if (!firstErrorObj) {
               if (rowToCheck.current.datainizioprevista && rowToCheck.current.datafineprevista && rowToCheck.current.datainizioprevista > rowToCheck.current.datafineprevista)
                  firstErrorObj = { warningMsg: "", errMsg: "La data fine prevista deve essere successiva alla data inizio prevista", errField: "datafineprevista", row: rowToCheck };

               if (rowToCheck.current.datainizioeffettiva && rowToCheck.current.datafineeffettiva && rowToCheck.current.datainizioeffettiva > rowToCheck.current.datafineeffettiva)
                  firstErrorObj = { warningMsg: "", errMsg: "La data fine effettiva deve essere successiva alla data inizio effettiva", errField: "datafineeffettiva", row: rowToCheck };
            }
            return def.resolve(firstErrorObj);
				//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-perfprogettoobiettivoattivita_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfprogettoobiettivoattivita_default_completamento());
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
				
				this.manageperfprogettoobiettivoattivita_default_completamento();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivoattivita_default");
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

			afterLink: function () {
				var self = this;
				this.setFilterPerfprogettoobiettivoattivita_default_idreg();
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

			setFilterPerfprogettoobiettivoattivita_default_idreg: function () {
            var self = this;
            var filter = self.q.isIn('idreg',
               _.map(self.state.callerState.callerPage.getDataTable("perfprogettouomembro").rows, function (r) { return r.idreg; })
            );
				self.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(filter);            
         },

			manageperfprogettoobiettivoattivita_default_completamento: function () {
//campo calcolato
            this.enableControl($('#perfprogettoobiettivoattivita_default_completamento'), false);
            if (this.state.formState === "insert" || this.getChildren("perfprogettoobiettivoattivita", this.state.currentRow.idperfprogettoobiettivoattivita, "paridperfprogettoobiettivoattivita", true).length == 0) {
               this.enableControl($('#perfprogettoobiettivoattivita_default_completamento'), true);
            }
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoobiettivoattivita', 'default', metaPage_perfprogettoobiettivoattivita);

}());
