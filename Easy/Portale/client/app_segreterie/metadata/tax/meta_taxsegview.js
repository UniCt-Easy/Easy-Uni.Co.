(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_taxsegview() {
        MetaData.apply(this, ["taxsegview"]);
        this.name = 'meta_taxsegview';
    }

    meta_taxsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_taxsegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 50);
						this.describeAColumn(table, 'tax_taxref', 'Codice ritenuta', null, 20, 20);
						this.describeAColumn(table, 'tax_active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["taxcode"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('taxsegview', new meta_taxsegview('taxsegview'));

	}());
