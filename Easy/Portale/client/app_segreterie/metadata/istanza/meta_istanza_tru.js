(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_tru() {
        MetaData.apply(this, ["istanza_tru"]);
        this.name = 'meta_istanza_tru';
    }

    meta_istanza_tru.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_tru,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_tru");

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

    window.appMeta.addMeta('istanza_tru', new meta_istanza_tru('istanza_tru'));

	}());
