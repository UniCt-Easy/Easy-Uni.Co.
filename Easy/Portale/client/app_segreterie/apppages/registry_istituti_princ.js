
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
		MetaPage.apply(this, ['registry', 'istituti_princ', false]);
        this.name = 'Istituto in gestione';
		this.defaultListType = 'istituti_princ';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.canShowLast = false;
		this.firstSearchFilter = window.jsDataQuery.constant(true);
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_istituti_istituti_princ");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_istituti"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_istituti");
					meta.setDefaults(dt);
					var defregistry_istituti = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowistituti) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_istituti);
				}

				var dtistitutoprinc = this.state.DS.tables["istitutoprinc"];
				if (dtistitutoprinc.rows.length === 0) {
					var metaistitutoprinc = appMeta.getMeta("istitutoprinc");
					metaistitutoprinc.setDefaults(dtistitutoprinc);
					var defistitutoprinc = metaistitutoprinc.getNewRow(parentRow.getRow(), dtistitutoprinc, self.editType).then(
						function (currentRowistitutoprinc) {
							//defaultistitutoprincObject
							return true;
						}
					);
					arraydef.push(defistitutoprinc);
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('aoo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('struttura'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('aoo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('struttura'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.istitutoprinc, "default", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("istitutoprinc");
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

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'istituti_princ', metaPage_registry);

}());
