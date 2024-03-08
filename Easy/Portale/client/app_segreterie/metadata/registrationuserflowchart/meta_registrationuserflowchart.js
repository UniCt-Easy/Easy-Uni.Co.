(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrationuserflowchart() {
        MetaData.apply(this, ["registrationuserflowchart"]);
        this.name = 'meta_registrationuserflowchart';
    }

    meta_registrationuserflowchart.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrationuserflowchart,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registrationuserflowchart");

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

    window.appMeta.addMeta('registrationuserflowchart', new meta_registrationuserflowchart('registrationuserflowchart'));

	}());
