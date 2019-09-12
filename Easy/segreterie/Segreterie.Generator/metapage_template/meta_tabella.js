(function() {

    var MetaData = window.appMeta.MetaData;

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

			//$getNewRow$

			isValid: function (r) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_tabella");
				var objrow = r.current;
				var errmess, errfield, objres;
//$isValid$
				return this.superClass.isValid(r)
					.then(function (res) {
						return def.resolve(res);
					});
			},

        });

    window.appMeta.addMeta('tabella', new meta_tabella('tabella'));

	}());
