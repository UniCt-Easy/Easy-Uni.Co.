(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_abbr() {
        MetaData.apply(this, ["istanza_abbr"]);
        this.name = 'meta_istanza_abbr';
    }

    meta_istanza_abbr.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_abbr,
			superClass: MetaData.prototype,

			//$describeColumns$

			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'abbr_seg':
						table.columns["iddichiar"].caption = "Dichiarazione per la quale esonerare una o più attività";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione attuale";
						table.columns["idiscrizione_from"].caption = "Iscrizione da cui convalidare i sostenimenti";
						table.columns["idreg"].caption = "Studente";
						table.columns["idtitolostudio"].caption = "Titolo di studio da cui convalidare i sostenimenti";
//$innerSetCaptionConfig_abbr_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_abbr");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanza_abbr', new meta_istanza_abbr('istanza_abbr'));

	}());
