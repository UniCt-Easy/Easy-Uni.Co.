(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_commiss() {
        MetaData.apply(this, ["commiss"]);
        this.name = 'meta_commiss';
    }

    meta_commiss.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_commiss,
			superClass: MetaData.prototype,

			//$describeColumns$

			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'ingresso':
						table.columns["idreg_docenti"].caption = "Verbalizzante";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'default':
						table.columns["idreg_docenti"].caption = "Verbalizzante";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_commiss");

				//$getNewRowInside$

				dt.autoIncrement('idcommiss', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "ingresso": {
						return "idcommiss asc ";
					}
					case "default": {
						return "idcommiss asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('commiss', new meta_commiss('commiss'));

	}());
