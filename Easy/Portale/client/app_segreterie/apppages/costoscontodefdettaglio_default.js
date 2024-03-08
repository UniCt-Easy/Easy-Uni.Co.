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
