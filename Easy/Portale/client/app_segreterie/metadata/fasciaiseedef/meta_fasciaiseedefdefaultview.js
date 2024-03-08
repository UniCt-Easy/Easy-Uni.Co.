(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_fasciaiseedefdefaultview() {
        MetaData.apply(this, ["fasciaiseedefdefaultview"]);
        this.name = 'meta_fasciaiseedefdefaultview';
    }

    meta_fasciaiseedefdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_fasciaiseedefdefaultview,
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
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
//$objCalcFieldConfig_default$
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

    window.appMeta.addMeta('fasciaiseedefdefaultview', new meta_fasciaiseedefdefaultview('fasciaiseedefdefaultview'));

	}());
