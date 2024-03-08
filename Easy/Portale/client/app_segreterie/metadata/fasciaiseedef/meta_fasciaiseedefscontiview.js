(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_fasciaiseedefscontiview() {
        MetaData.apply(this, ["fasciaiseedefscontiview"]);
        this.name = 'meta_fasciaiseedefscontiview';
    }

    meta_fasciaiseedefscontiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_fasciaiseedefscontiview,
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
					case 'sconti':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
//$objCalcFieldConfig_sconti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idfasciaiseedef", "idcostoscontodef"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('fasciaiseedefscontiview', new meta_fasciaiseedefscontiview('fasciaiseedefscontiview'));

	}());
