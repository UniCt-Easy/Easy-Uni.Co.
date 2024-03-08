(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_expenseviewdettaglio_dei_costiview() {
        MetaData.apply(this, ["expenseviewdettaglio_dei_costiview"]);
        this.name = 'meta_expenseviewdettaglio_dei_costiview';
    }

    meta_expenseviewdettaglio_dei_costiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_expenseviewdettaglio_dei_costiview,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			//$getNewRow$

			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('expenseviewdettaglio_dei_costiview', new meta_expenseviewdettaglio_dei_costiview('expenseviewdettaglio_dei_costiview'));

	}());
