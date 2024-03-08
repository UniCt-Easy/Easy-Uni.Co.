(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pagamentosegview() {
        MetaData.apply(this, ["pagamentosegview"]);
        this.name = 'meta_pagamentosegview';
    }

    meta_pagamentosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pagamentosegview,
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
						this.describeAColumn(table, 'pagamento_dataora', 'Data e ora', 'g', 20, null);
						this.describeAColumn(table, 'pagamentokind_title', 'Tipologia', null, 40, 50);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddebito", "idpagamento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('pagamentosegview', new meta_pagamentosegview('pagamentosegview'));

	}());
