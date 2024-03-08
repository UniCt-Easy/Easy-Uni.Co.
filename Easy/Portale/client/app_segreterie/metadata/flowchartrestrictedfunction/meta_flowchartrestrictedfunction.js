(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_flowchartrestrictedfunction() {
        MetaData.apply(this, ["flowchartrestrictedfunction"]);
        this.name = 'meta_flowchartrestrictedfunction';
    }

    meta_flowchartrestrictedfunction.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_flowchartrestrictedfunction,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_flowchartrestrictedfunction");

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

    window.appMeta.addMeta('flowchartrestrictedfunction', new meta_flowchartrestrictedfunction('flowchartrestrictedfunction'));

	}());
