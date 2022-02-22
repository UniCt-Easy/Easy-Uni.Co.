
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

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'aziende_ro', false]);
        this.name = 'Enti e Aziende';
		this.defaultListType = 'aziende_ro';
		//pageHeaderDeclaration
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registry,
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
				
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "aziende";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idcategory'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idcategory'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_residence'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_residence'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idnaturagiur'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idnaturagiur'), this.q.eq('naturagiur_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idnumerodip'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idnumerodip'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_aziende_aziende_ro");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_aziende"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_aziende");
					meta.setDefaults(dt);
					var defregistry_aziende = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowaziende) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_aziende);
				}

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
				this.helpForm.filter($('#registry_aziende_ro_idcategory'), null);
				this.helpForm.filter($('#registry_aziende_ro_idregistryclass'), null);
				this.helpForm.filter($('#registry_aziende_ro_residence'), null);
				this.helpForm.filter($('#registry_aziende_ro_idnaturagiur'), null);
				this.helpForm.filter($('#registry_aziende_ro_idnumerodip'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#registry_aziende_ro_title'), false);
				this.enableControl($('#registry_aziende_ro_idregistrykind'), false);
				this.enableControl($('#registry_aziende_ro_title_en'), false);
				this.enableControl($('#registry_aziende_ro_idcategory'), false);
				this.enableControl($('#registry_aziende_ro_idregistryclass'), false);
				this.enableControl($('#registry_aziende_ro_residence'), false);
				this.enableControl($('#registry_aziende_ro_ccp'), false);
				this.enableControl($('#registry_aziende_ro_idnation'), false);
				this.enableControl($('#registry_aziende_ro_flag_paS'), false);
				this.enableControl($('#registry_aziende_ro_flag_paN'), false);
				this.enableControl($('#registry_aziende_ro_idcity'), false);
				this.enableControl($('#registry_aziende_ro_location'), false);
				this.enableControl($('#registry_aziende_ro_ipa_fe'), false);
				this.enableControl($('#registry_aziende_ro_cf'), false);
				this.enableControl($('#registry_aziende_ro_p_iva'), false);
				this.enableControl($('#registry_aziende_ro_foreigncf'), false);
				this.enableControl($('#registry_aziende_ro_pic'), false);
				this.enableControl($('#registry_aziende_ro_multi_cfSi'), false);
				this.enableControl($('#registry_aziende_ro_multi_cfNo'), false);
				this.enableControl($('#registry_aziende_ro_annotation'), false);
				this.enableControl($('#registry_aziende_ro_idateco'), false);
				this.enableControl($('#registry_aziende_ro_idnace'), false);
				this.enableControl($('#registry_aziende_ro_idnaturagiur'), false);
				this.enableControl($('#registry_aziende_ro_idnumerodip'), false);
				this.enableControl($('#registry_aziende_ro_activeSi'), false);
				this.enableControl($('#registry_aziende_ro_activeNo'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
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

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'aziende_ro', metaPage_registry);

}());
