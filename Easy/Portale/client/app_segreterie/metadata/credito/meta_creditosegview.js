(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_creditosegview() {
        MetaData.apply(this, ["creditosegview"]);
        this.name = 'meta_creditosegview';
    }

    meta_creditosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_creditosegview,
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
						this.describeAColumn(table, 'autorizzato', 'Autorizzato', null, 20, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddebito", "idcredito", "idpagamento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('creditosegview', new meta_creditosegview('creditosegview'));

	}());
