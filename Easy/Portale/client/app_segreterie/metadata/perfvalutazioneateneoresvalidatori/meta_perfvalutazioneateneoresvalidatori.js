(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneateneoresvalidatori() {
        MetaData.apply(this, ["perfvalutazioneateneoresvalidatori"]);
        this.name = 'meta_perfvalutazioneateneoresvalidatori';
    }

    meta_perfvalutazioneateneoresvalidatori.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneateneoresvalidatori,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneateneoresvalidatori");

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

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "idvalidatori asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfvalutazioneateneoresvalidatori', new meta_perfvalutazioneateneoresvalidatori('perfvalutazioneateneoresvalidatori'));

	}());
