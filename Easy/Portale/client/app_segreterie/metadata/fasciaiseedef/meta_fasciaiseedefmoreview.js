(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_fasciaiseedefmoreview() {
        MetaData.apply(this, ["fasciaiseedefmoreview"]);
        this.name = 'meta_fasciaiseedefmoreview';
    }

    meta_fasciaiseedefmoreview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_fasciaiseedefmoreview,
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
					case 'more':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 3000, 50);
//$objCalcFieldConfig_more$
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

    window.appMeta.addMeta('fasciaiseedefmoreview', new meta_fasciaiseedefmoreview('fasciaiseedefmoreview'));

	}());
