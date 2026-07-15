(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_costoscontodefdettaglioriepilogoview() {
        MetaData.apply(this, ["costoscontodefdettaglioriepilogoview"]);
        this.name = 'meta_costoscontodefdettaglioriepilogoview';
    }

    meta_costoscontodefdettaglioriepilogoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefdettaglioriepilogoview,
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
					case 'riepilogo':
						this.describeAColumn(table, 'costoscontodefdettagliokind_title', 'Voce di dettaglio', null, 3200, 1024);
						this.describeAColumn(table, 'fasciaiseedef_idfasciaisee', 'Fascia ISEE', null, 4100, 50);
						this.describeAColumn(table, 'ratadef_idratakind', 'Rata', null, 5100, 50);
						this.describeAColumn(table, 'costoscontodefdettaglio_importo', 'Importo', 'fixed.2', 6000, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_parama', 'Parametro A', 'fixed.9', 7000, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_paramb', 'Parametro B', 'fixed.2', 8000, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_paramc', 'Parametro C', 'fixed.2', 9000, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_paramd', 'Parametro D', 'fixed.9', 10000, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_percentuale', 'Percentuale', 'fixed.2', 11000, null);
//$objCalcFieldConfig_riepilogo$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idratadef", "idfasciaiseedef", "idcostoscontodef", "idcostoscontodefdettaglio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "riepilogo": {
						return "fasciaiseedef_idfasciaisee asc , ratadef_idratakind asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('costoscontodefdettaglioriepilogoview', new meta_costoscontodefdettaglioriepilogoview('costoscontodefdettaglioriepilogoview'));

	}());
