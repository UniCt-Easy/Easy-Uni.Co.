
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function metaPage_costoscontodefdettaglio() {
		MetaPage.apply(this, ['costoscontodefdettaglio', 'default', true]);
        this.name = 'Voci di dettaglio costo';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_costoscontodefdettaglio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodefdettaglio,
            superClass: MetaPage.prototype,

            getName:function () {
               return this.name;
			},

			isValidPage: function (r) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_tabella");
				var objrow = r.current;
				var errmess, errfield, firstErrorObj;

				var mandatoryFields = [];
				var maxLengthFields = [];
				var minRowsRequired = [];

				if(r.table.name == "costoscontodefdettaglio") mandatoryFields.push({field:"idcostoscontodefdettaglio", label:"Identificativo"}); 
				if(r.table.name == "costoscontodefdettaglio") mandatoryFields.push({field:"idcostoscontodef", label:"Identificativo"}); 
				if(r.table.name == "costoscontodefdettaglio") mandatoryFields.push({field:"idfasciaiseedef", label:"Identificativo"}); 
				if(r.table.name == "costoscontodefdettaglio") mandatoryFields.push({field:"idratadef", label:"Identificativo"}); 
				if(r.table.name == "costoscontodefdettaglio") maxLengthFields.push({field:"importo", label:"Importo", maxlen:2});
				if(r.table.name == "costoscontodefdettaglio") maxLengthFields.push({field:"parama", label:"Parametro A", maxlen:2});
				if(r.table.name == "costoscontodefdettaglio") maxLengthFields.push({field:"paramb", label:"Parametro B", maxlen:2});
				if(r.table.name == "costoscontodefdettaglio") maxLengthFields.push({field:"paramc", label:"Parametro C", maxlen:2});
				if(r.table.name == "costoscontodefdettaglio") maxLengthFields.push({field:"paramd", label:"Parametro D", maxlen:2});
				if(r.table.name == "costoscontodefdettaglio") maxLengthFields.push({field:"percentuale", label:"Percentuale", maxlen:2});
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

	window.appMeta.addMetaPage('costoscontodefdettaglio', 'default', metaPage_costoscontodefdettaglio);

}());