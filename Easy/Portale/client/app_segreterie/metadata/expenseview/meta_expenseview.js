(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_expenseview() {
        MetaData.apply(this, ["expenseview"]);
        this.name = 'meta_expenseview';
    }

    meta_expenseview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_expenseview,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			//$getNewRow$

			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('expenseview', new meta_expenseview('expenseview'));

	}());
