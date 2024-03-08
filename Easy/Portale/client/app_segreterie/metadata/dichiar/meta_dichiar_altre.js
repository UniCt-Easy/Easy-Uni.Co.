(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar_altre() {
        MetaData.apply(this, ["dichiar_altre"]);
        this.name = 'meta_dichiar_altre';
    }

    meta_dichiar_altre.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar_altre,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_dichiar_altre");

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

    window.appMeta.addMeta('dichiar_altre', new meta_dichiar_altre('dichiar_altre'));

	}());
