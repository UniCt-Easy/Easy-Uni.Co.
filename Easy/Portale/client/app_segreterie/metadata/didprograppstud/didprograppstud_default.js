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
