(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pettycashsegview() {
        MetaData.apply(this, ["pettycashsegview"]);
        this.name = 'meta_pettycashsegview';
    }

    meta_pettycashsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pettycashsegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 50);
						this.describeAColumn(table, 'pettycash_pettycode', 'Codice', null, 20, 20);
						this.describeAColumn(table, 'pettycash_active', 'attivo', null, 40, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idpettycash"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('pettycashsegview', new meta_pettycashsegview('pettycashsegview'));

	}());
