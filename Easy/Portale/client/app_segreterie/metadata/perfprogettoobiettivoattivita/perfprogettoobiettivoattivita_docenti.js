
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
		MetaPage.apply(this, ['perfprogettoobiettivoattivita', 'docenti', false]);
        this.name = 'Le mie attività sui progetti strategici';
		this.defaultListType = 'docenti';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
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

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.idreg)
					parentRow.idreg = this.sec.usr('idreg');
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivoattivita_docenti");
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

			
			afterRowSelect: function (t, r) {
				$('#perfprogettoobiettivoattivita_docenti_idperfprogetto').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettoobiettivoattivita_docenti_idperfprogetto').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "perfprogettodefaultview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("perfprogettoobiettivo"), false);
					var perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivoCtrl = $('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').data("customController");
					arraydef.push(perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivoCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idperfprogetto", r ? r.idperfprogetto : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idperfprogettoobiettivo)
								return perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivoCtrl.fillControl(null, self.state.currentRow.idperfprogettoobiettivo);
						})
						.then(function (dt) {
							var ctrl = $('#perfprogettoobiettivoattivita_docenti_paridperfprogettoobiettivoattivita').data("customController");
							if (self.state.currentRow && self.state.currentRow.idperfprogettoobiettivoattivita)
								return ctrl.fillControl(null, self.state.currentRow.idperfprogettoobiettivoattivita);
						})
					);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfprogettoobiettivoattivita_docenti_idperfprogetto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Progetto Strategico');
				}
				if (!$('#perfprogettoobiettivoattivita_docenti_idperfprogettoobiettivo').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Obiettivo strategico');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterLink: function () {
				var self = this;
				appMeta.metaModel.cachedTable(this.getDataTable("perfprogettoobiettivo"), true);
				appMeta.metaModel.lockRead(this.getDataTable("perfprogettoobiettivo"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];

					var filter = self.q.eq('idreg', appMeta.security.usr("idreg"));
					var def = appMeta.getData.runSelect('perfprogettouomembro', 'idperfprogetto', filter)
						.then(function (dt) {
							var arrayOr = [];
							_.forEach(dt.rows, function (r) {
								arrayOr.push(self.q.eq('idperfprogetto', r.idperfprogetto));
							});
							self.getDataTable('perfprogettodefaultview').staticFilter(self.q.or(arrayOr));
							return true;
						})
					arraydef.push(def);

					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			children: [''],
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

	window.appMeta.addMetaPage('perfprogettoobiettivoattivita', 'docenti', metaPage_perfprogettoobiettivoattivita);

}());
