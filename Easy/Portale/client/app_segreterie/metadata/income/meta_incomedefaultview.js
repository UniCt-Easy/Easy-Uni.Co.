(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_incomedefaultview() {
        MetaData.apply(this, ["incomedefaultview"]);
        this.name = 'meta_incomedefaultview';
    }

    meta_incomedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_incomedefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 150);
						this.describeAColumn(table, 'income_ymov', 'Anno movimento', null, 20, null);
						this.describeAColumn(table, 'income_nmov', 'Numero movimento', null, 30, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idinc"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('incomedefaultview', new meta_incomedefaultview('incomedefaultview'));

	}());
