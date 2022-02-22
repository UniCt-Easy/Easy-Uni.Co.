
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

    function metaPage_publicazregistry_docenti() {
		MetaPage.apply(this, ['publicazregistry_docenti', 'default', true]);
        this.name = 'Pubblicazioni';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_publicazregistry_docenti.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_publicazregistry_docenti,
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

				if(r.table.name == "publicazregistry_docenti") mandatoryFields.push({field:"idpublicaz", label:"Pubblicazione"}); 
				if(r.table.name == "publicazregistry_docenti") mandatoryFields.push({field:"idreg_docenti", label:"Docente"}); 
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

			afterRowSelect: function () {
				var def = appMeta.Deferred("afterRowSelect-publicazregistry_docenti_default");
				$('#publicazregistry_docenti_idreg_docenti').prop("disabled", false);
				$('#publicazregistry_docenti_idreg_docenti').prop("readonly", false);
				//afterRowSelectin
				return def.resolve();
			},

			//rowSelected

			//buttonClickEnd

			//buttons
        });

	window.appMeta.addMetaPage('publicazregistry_docenti', 'default', metaPage_publicazregistry_docenti);

}());
