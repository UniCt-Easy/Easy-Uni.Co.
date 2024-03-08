(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_cefrlangleveldefaultview() {
        MetaData.apply(this, ["cefrlangleveldefaultview"]);
        this.name = 'meta_cefrlangleveldefaultview';
    }

    meta_cefrlangleveldefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_cefrlangleveldefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'geo_nation_title', 'Lingua', null, 10, 65);
						this.describeAColumn(table, 'cefrcompasc_title', 'Comprensione ascolto', null, 20, 50);
						this.describeAColumn(table, 'cefrcomplett_title', 'Comprensione lettura', null, 30, 50);
						this.describeAColumn(table, 'cefrparlinter_title', 'Parlato interazione', null, 40, 50);
						this.describeAColumn(table, 'cefrparlprod_title', 'Parlato produzione', null, 50, 50);
						this.describeAColumn(table, 'cefrscritto_title', 'Scritto', null, 60, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcefrlanglevel"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('cefrlangleveldefaultview', new meta_cefrlangleveldefaultview('cefrlangleveldefaultview'));

	}());
