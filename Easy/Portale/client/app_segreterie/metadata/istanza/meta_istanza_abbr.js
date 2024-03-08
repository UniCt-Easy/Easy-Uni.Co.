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

			//$setCaptions$

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
