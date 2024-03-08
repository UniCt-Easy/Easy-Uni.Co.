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
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'riepilogo':
						this.describeAColumn(table, 'costoscontodefdettagliokind_title', 'Voce di dettaglio', null, 30, 1024);
						this.describeAColumn(table, 'fasciaiseedef_idfasciaisee', 'Fascia ISEE', null, 40, 50);
						this.describeAColumn(table, 'ratadef_idratakind', 'Rata', null, 50, 50);
						this.describeAColumn(table, 'costoscontodefdettaglio_importo', 'Importo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_parama', 'Parametro A', 'fixed.2', 70, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_paramb', 'Parametro B', 'fixed.2', 80, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_paramc', 'Parametro C', 'fixed.2', 90, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_paramd', 'Parametro D', 'fixed.2', 100, null);
						this.describeAColumn(table, 'costoscontodefdettaglio_percentuale', 'Percentuale', 'fixed.2', 110, null);
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

			getSorting: function(listType) {
				switch (listType) {
					case "riepilogo": {
						return "idfasciaiseedef asc , idratadef asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodefdettaglioriepilogoview', new meta_costoscontodefdettaglioriepilogoview('costoscontodefdettaglioriepilogoview'));

	}());
