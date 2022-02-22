
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

    function metaPage_rendicontattivitaprogettoitineration() {
		MetaPage.apply(this, ['rendicontattivitaprogettoitineration', 'default', true]);
        this.name = 'Missioni dell\'attività';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogettoitineration.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogettoitineration,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicontattivitaprogettoitineration_default");
				$('#rendicontattivitaprogettoitineration_default_iditineration').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#rendicontattivitaprogettoitineration_default_iditineration').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#rendicontattivitaprogettoitineration_default_iditineration').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Missione');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

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

	window.appMeta.addMetaPage('rendicontattivitaprogettoitineration', 'default', metaPage_rendicontattivitaprogettoitineration);

}());
