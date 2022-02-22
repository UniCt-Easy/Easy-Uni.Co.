(function() {

    var MetaData = window.appMeta.Meta_APP_Data;

    function meta_tabella() {
        MetaData.apply(this, ["tabella"]);
        this.name = 'meta_tabella';
    }

    meta_tabella.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tabella,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			//$getNewRow$

			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('tabella', new meta_tabella('tabella'));

	}());
