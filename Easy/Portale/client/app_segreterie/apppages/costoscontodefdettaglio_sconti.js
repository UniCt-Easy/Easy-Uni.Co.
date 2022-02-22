
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

    function metaPage_costoscontodefdettaglio() {
		MetaPage.apply(this, ['costoscontodefdettaglio', 'sconti', true]);
        this.name = 'Voci di dettaglio dello sconto';
		this.defaultListType = 'sconti';
		//pageHeaderDeclaration
    }

    metaPage_costoscontodefdettaglio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodefdettaglio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.fasciaiseedefdefaultview.staticFilter(window.jsDataQuery.eq("idcostoscontodef", self.idcostoscontodef));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-costoscontodefdettaglio_sconti");
				$('#costoscontodefdettaglio_sconti_idfasciaiseedef').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#costoscontodefdettaglio_sconti_idfasciaiseedef').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "fasciaiseedefdefaultview" && r !== null) {
					this.state.DS.tables.ratadefdefaultview.staticFilter(window.jsDataQuery.eq("idfasciaiseedef", r.idfasciaiseedef));
					if (this.state.DS.tables.ratadefdefaultview.rows.length)
						if (this.state.DS.tables.ratadefdefaultview.rows[0].idfasciaiseedef !== r.idfasciaiseedef) {
							this.state.DS.tables.ratadefdefaultview.clear();
							$('#costoscontodefdettaglio_sconti_idratadef').val('');
						}
				}
				$('#costoscontodefdettaglio_sconti_idratadef').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#costoscontodefdettaglio_sconti_idratadef').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#costoscontodefdettaglio_sconti_idfasciaiseedef').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Fascia ISEE');
				}
				if (!$('#costoscontodefdettaglio_sconti_idratadef').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Rata');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
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

	window.appMeta.addMetaPage('costoscontodefdettaglio', 'sconti', metaPage_costoscontodefdettaglio);

}());
