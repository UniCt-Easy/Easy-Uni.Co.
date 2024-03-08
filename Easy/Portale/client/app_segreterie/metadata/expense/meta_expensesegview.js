(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_expensesegview() {
        MetaData.apply(this, ["expensesegview"]);
        this.name = 'meta_expensesegview';
    }

    meta_expensesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_expensesegview,
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
					case 'seg':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 150);
						this.describeAColumn(table, 'expense_ymov', 'Anno movimento', null, 20, null);
						this.describeAColumn(table, 'expense_nmov', 'N.movimento', null, 30, null);
						this.describeAColumn(table, 'expense_flag', 'Flag', null, 110, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idexp"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('expensesegview', new meta_expensesegview('expensesegview'));

	}());
