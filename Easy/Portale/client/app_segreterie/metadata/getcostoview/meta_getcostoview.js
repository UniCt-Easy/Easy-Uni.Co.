(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getcostoview() {
        MetaData.apply(this, ["getcostoview"]);
        this.name = 'meta_getcostoview';
    }

    meta_getcostoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcostoview,
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
						this.describeAColumn(table, 'description', 'Descrizione spesa', null, 10, 150);
						this.describeAColumn(table, 'accmotive_title', 'Causale economico patrimoniali', null, 20, 150);
						this.describeAColumn(table, 'adate', 'Data di liquidazione', null, 30, null);
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 40, null);
						this.describeAColumn(table, 'cf', 'CF fornitore', null, 50, 16);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 60, 35);
						this.describeAColumn(table, 'docdate', 'Data contabile', null, 70, null);
						this.describeAColumn(table, 'nmov', 'N. movimento spesa', null, 110, null);
						this.describeAColumn(table, 'p_iva', 'P. IVA fornitore', null, 120, 15);
						this.describeAColumn(table, 'payment_adate', 'Data mandato di pagamento', null, 130, null);
						this.describeAColumn(table, 'registry_title', 'Fornitore', null, 140, 101);
						this.describeAColumn(table, 'transactiondate', 'Data quietanza banca', null, 150, null);
						this.describeAColumn(table, 'transmissiondate', 'Data di trasmissione alla banca', null, 160, null);
						this.describeAColumn(table, 'ymov', 'Anno movimento spesa', null, 170, null);
//$objCalcFieldConfig_default$
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

			//$describeTree$
        });

    window.appMeta.addMeta('getcostoview', new meta_getcostoview('getcostoview'));

	}());
