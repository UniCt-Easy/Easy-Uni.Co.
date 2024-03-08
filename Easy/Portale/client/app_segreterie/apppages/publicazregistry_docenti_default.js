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
