
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


(function() {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprograppstud() {
		MetaPage.apply(this, ['didprograppstud', 'default', true]);
        this.name = 'Rappresentanti degli studenti per la didattica programmata';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprograppstud.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprograppstud,
            superClass: MetaPage.prototype,

            getName:function () {
               return this.name;
			},

			isValid: function (r) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_tabella");
				var objrow = r.current;
				var errmess, errfield, firstErrorObj;

				var mandatoryFields = [];
				var maxLengthFields = [];
				var minRowsRequired = [];

				if(r.table.name == "didprograppstud") mandatoryFields.push({field:"idcorsostudio", label:"Identificativo"}); 
				if(r.table.name == "didprograppstud") mandatoryFields.push({field:"iddidprog", label:"Didattica Programmata"}); 
				if(r.table.name == "didprograppstud") mandatoryFields.push({field:"idreg_studenti", label:"Studente"}); 
//$isValidArray$
				firstErrorObj = this.superClass.validateRow(r, mandatoryFields, maxLengthFields, minRowsRequired);
				if (firstErrorObj)
					return def.resolve(firstErrorObj);
//$isValid$
				return def.resolve(null);
			},
			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			//afterRowSelect

			//rowSelected

			//buttonClickEnd

			//buttons
        });

	window.appMeta.addMetaPage('didprograppstud', 'default', metaPage_didprograppstud);

}());
