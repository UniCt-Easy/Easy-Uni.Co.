
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

    function metaPage_attivform() {
		MetaPage.apply(this, ['attivform', 'gruppo', true]);
        this.name = 'Attività formative';
		this.defaultListType = 'gruppo';
		//pageHeaderDeclaration
    }

    metaPage_attivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivform,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			afterFill: function () {
				this.enableControl($('#attivform_gruppo_idinsegn'), false);
				this.enableControl($('#attivform_gruppo_idinsegninteg'), false);
				this.enableControl($('#attivform_gruppo_obbform'), false);
				this.enableControl($('#attivform_gruppo_obbform_en'), false);
				this.enableControl($('#attivform_gruppo_tipovalutazP'), false);
				this.enableControl($('#attivform_gruppo_tipovalutazI'), false);
				this.enableControl($('#attivform_gruppo_sortcode'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-attivform_gruppo");
				if (t.name === "insegndefaultview" && r !== null) {
					this.state.DS.tables.insegnintegdefaultview.staticFilter(window.jsDataQuery.eq("idinsegn", r.idinsegn));
					if (this.state.DS.tables.insegnintegdefaultview.rows.length)
						if (this.state.DS.tables.insegnintegdefaultview.rows[0].idinsegn !== r.idinsegn) {
							this.state.DS.tables.insegnintegdefaultview.clear();
							$('#attivform_gruppo_idinsegninteg').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('attivform', 'gruppo', metaPage_attivform);

}());
